using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Data
{
    public class CarteRepository
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=BibliotecaDB;Integrated Security=True;TrustServerCertificate=True";

        public List<Carte> GetCarti()
        {
            var carti = new List<Carte>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    /*string sql = "SELECT * FROM Carti";*/
                    string sql = @"SELECT c.Id, c.Titlu, c.AnPublicare, c.Descriere, 
                                 c.EdituraId, e.Nume as NumeEditura,
                                 STUFF((SELECT ', ' + a.Nume 
                                     FROM Autori a 
                                     INNER JOIN CartiAutori ca ON a.Id = ca.AutorId 
                                     WHERE ca.CarteId = c.Id 
                                     FOR XML PATH('')), 1, 2, '') as NumeAutori
                                 FROM Carti c 
                                 INNER JOIN Edituri e ON c.EdituraId = e.Id 
                                 ORDER BY c.Titlu";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Carte carte = new Carte();
                                carte.Id = reader.GetInt32(0);
                                carte.Titlu = reader.GetString(1);
                                carte.AnPublicare = reader.GetInt32(2);
                                carte.Descriere = reader.IsDBNull(3) ? null : reader.GetString(3);
                                carte.EdituraId = reader.GetInt32(4);
                                carte.NumeEditura = reader.GetString(5);
                                carte.NumeAutori = reader.IsDBNull(6) ? "Niciun autor" : reader.GetString(6);

                                carti.Add(carte);
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return carti;
        }

        public DataTable GetEdituri()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Nume FROM Edituri ORDER BY Nume";
                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetAutori()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Nume FROM Autori ORDER BY Nume";
                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    adapter.Fill(table);
            }
            return table;
        }

        public Carte GetCarte(int id)
        {   
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Carte carte = null;
                    //string sql = "SELECT * FROM Carti WHERE Id=@Id";
                    string sql = @"SELECT c.*, e.Nume as NumeEditura FROM Carti c INNER JOIN Edituri e ON c.EdituraId = e.Id WHERE c.Id = @Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                carte = new Carte();
                                carte.Id = reader.GetInt32(0);
                                carte.Titlu = reader.GetString(1);
                                carte.AnPublicare = reader.GetInt32(2);
                                carte.Descriere = reader.IsDBNull(3) ? null : reader.GetString(3);
                                carte.EdituraId = reader.GetInt32(4);
                                carte.NumeEditura = reader.GetString(5);
                            }
                        }
                    }
                    
                    if (carte != null)
                    {
                        carte.AutoriIds = new List<int>();
                        carte.NumeAutori = GetAutoriCarte(connection, id);
                    }
                    return carte;
                               
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                MessageBox.Show($"Eroare la citirea cărții: {ex.Message}");
            }
            return null;
        }


        private string GetAutoriCarte (SqlConnection connection, int carteId)
        {
            List<string> numeAutori = new List<string>();

            string sqlAutori = @"SELECT a.Id, a.Nume 
                               FROM Autori a 
                               INNER JOIN CartiAutori ca ON a.Id = ca.AutorId 
                               WHERE ca.CarteId = @CarteId";
            
            using (SqlCommand commandAutori = new SqlCommand(sqlAutori, connection))
            {   
                commandAutori.Parameters.AddWithValue("@CarteId", carteId);
                using (SqlDataReader readerAutori = commandAutori.ExecuteReader())
                {   
                    while (readerAutori.Read())
                    {
                        int autorId = readerAutori.GetInt32(0);
                        string numeAutor = readerAutori.GetString(1);

                        numeAutori.Add(numeAutor);
                    }  
                }
            }
            return string.Join(", ", numeAutori);
        }


        public void CreateCarte(Carte carte)
        { 
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Carti " +
                                 "(Titlu, AnPublicare, Descriere, EdituraId) VALUES " +
                                 "(@Titlu, @AnPublicare, @Descriere, @EdituraId);" +
                                 "SELECT SCOPE_IDENTITY();" ;

                    int carteId;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Titlu", carte.Titlu);
                        command.Parameters.AddWithValue("@AnPublicare", carte.AnPublicare);
                        command.Parameters.AddWithValue("@Descriere", carte.Descriere);
                        command.Parameters.AddWithValue("@EdituraId", carte.EdituraId);

                        carteId = Convert.ToInt32(command.ExecuteScalar()); // obtine noul ID
                    }

                    //adaugare autori in CartiAutori
                    if (carte.AutoriIds != null && carte.AutoriIds.Count > 0)
                    {
                        foreach (int autorId in carte.AutoriIds)
                        {
                            string sqlAutor = "INSERT INTO CartiAutori (CarteId, AutorId) VALUES (@CarteId, @AutorId)";
                            using (SqlCommand commandAutor = new SqlCommand(sqlAutor, connection))
                            {
                                commandAutor.Parameters.AddWithValue("@CarteId", carteId);
                                commandAutor.Parameters.AddWithValue("@AutorId", autorId);
                                commandAutor.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }


        public void UpdateCarte(Carte carte)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Carti " +
                                 "SET Titlu = @Titlu, AnPublicare = @AnPublicare, Descriere = @Descriere , EdituraId = @EdituraId " +
                                 "WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Titlu", carte.Titlu);
                        command.Parameters.AddWithValue("@AnPublicare", carte.AnPublicare);
                        command.Parameters.AddWithValue("@Descriere", carte.Descriere);
                        command.Parameters.AddWithValue("@EdituraId", carte.EdituraId);

                        command.Parameters.AddWithValue("@Id", carte.Id);

                        command.ExecuteNonQuery();
                    }

                    // stergerea realatiilor din CartiAutori
                    string sqlDeleteRelatii = "DELETE FROM CartiAutori WHERE CarteId = @CarteId";
                    using (SqlCommand commandDeleteRelatii = new SqlCommand(sqlDeleteRelatii, connection))
                    {
                        commandDeleteRelatii.Parameters.AddWithValue("@CarteId", carte.Id);
                        commandDeleteRelatii.ExecuteNonQuery();
                    }

                    // audagare de relatii noi in CartiAutori
                    if (carte.AutoriIds != null && carte.AutoriIds.Count > 0)
                    {
                        foreach (int autorId in carte.AutoriIds)
                        {
                            string sqlInsert = "INSERT INTO CartiAutori (CarteId, AutorId) VALUES (@CarteId, @AutorId)";
                            using (SqlCommand commandInsert = new SqlCommand(sqlInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@CarteId", carte.Id);
                                commandInsert.Parameters.AddWithValue("@AutorId", autorId);
                                commandInsert.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }


        public void DeleteCarte(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // stergerea realatiilor din CartiAutori
                    string sqlDeleteRelatii = "DELETE FROM CartiAutori WHERE CarteId = @CarteId";
                    using (SqlCommand commandDeleteRelatii = new SqlCommand(sqlDeleteRelatii, connection))
                    {
                        commandDeleteRelatii.Parameters.AddWithValue("@CarteId", id);
                        commandDeleteRelatii.ExecuteNonQuery();
                    }

                    // stergerea cartii
                    string sqlDeleteCarte = "DELETE FROM Carti WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sqlDeleteCarte, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }



        public DataTable GetCartiFiltrare (int? anMin = null, int? anMax = null, int? edituraId = null, int? autorId = null)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT DISTINCT c.Id, c.Titlu, c.AnPublicare, c.Descriere, 
                                      e.Nume as Editura,
                                      STUFF((SELECT ', ' + a.Nume 
                                             FROM Autori a 
                                             INNER JOIN CartiAutori ca ON a.Id = ca.AutorId 
                                             WHERE ca.CarteId = c.Id 
                                             FOR XML PATH('')), 1, 2, '') as Autori
                               FROM Carti c 
                               INNER JOIN Edituri e ON c.EdituraId = e.Id 
                               LEFT JOIN CartiAutori ca ON c.Id = ca.CarteId
                               WHERE 1=1";

                if (anMin.HasValue)
                    sql += " AND c.AnPublicare >= @AnMin";
                if (anMax.HasValue)
                    sql += " AND c.AnPublicare <= @AnMax";
                if (edituraId.HasValue && edituraId > 0)
                    sql += " AND c.EdituraId = @EdituraId";
                if (autorId.HasValue && autorId > 0)
                    sql += " AND ca.AutorId = @AutorId";

                sql += " ORDER BY c.Titlu";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (anMin.HasValue)
                        command.Parameters.AddWithValue("@AnMin", anMin.Value);
                    if (anMax.HasValue)
                        command.Parameters.AddWithValue("@AnMax", anMax.Value);
                    if (edituraId.HasValue && edituraId > 0)
                        command.Parameters.AddWithValue("@EdituraId", edituraId.Value);
                    if (autorId.HasValue && autorId > 0)
                        command.Parameters.AddWithValue("@AutorId", autorId.Value);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }
    }
}
