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
    public class BookRepository
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=BibliotecaDB;Integrated Security=True;TrustServerCertificate=True";

        public List<Book> GetBooks()
        {
            var books = new List<Book>();

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
                                Book book = new Book();
                                book.Id = reader.GetInt32(0);
                                book.Title = reader.GetString(1);
                                book.YearPublished = reader.GetInt32(2);
                                book.Description = reader.IsDBNull(3) ? null : reader.GetString(3);
                                book.PublisherId = reader.GetInt32(4);
                                book.PublisherName = reader.GetString(5);
                                book.AuthorNames = reader.IsDBNull(6) ? "Niciun autor" : reader.GetString(6);

                                books.Add(book);
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return books;
        }

        public DataTable GetPublishers()
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

        public DataTable GetAuthors()
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

        public Book GetBookById(int id)
        {   
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Book book = null;
                    //string sql = "SELECT * FROM Carti WHERE Id=@Id";
                    string sql = @"SELECT c.*, e.Nume as NumeEditura FROM Carti c INNER JOIN Edituri e ON c.EdituraId = e.Id WHERE c.Id = @Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                book = new Book();
                                book.Id = reader.GetInt32(0);
                                book.Title = reader.GetString(1);
                                book.YearPublished = reader.GetInt32(2);
                                book.Description = reader.IsDBNull(3) ? null : reader.GetString(3);
                                book.PublisherId = reader.GetInt32(4);
                                book.AuthorNames = reader.IsDBNull(5) ? "Niciun autor" : reader.GetString(5);
                            }
                        }
                    }
                    
                    if (book != null)
                    {
                        string authorsSql = @"SELECT a.Id FROM Autori a INNER JOIN CartiAutori ca ON a.Id = ca.AutorId WHERE ca.CarteId = @CarteId";
                                 
                        using (SqlCommand authorsCommand = new SqlCommand(authorsSql, connection))
                        {
                            authorsCommand.Parameters.AddWithValue("@CarteId", id);
                
                            using (SqlDataReader authorsReader = authorsCommand.ExecuteReader())
                            {
                                while (authorsReader.Read())
                                {
                                    int authorId = authorsReader.GetInt32(authorsReader.GetOrdinal("Id"));
                                    book.AuthorIds.Add(authorId);
                                }
                            }
                        }
                    }
                    return book;
                               
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                throw new InvalidOperationException("Eroare la citirea cartii.", ex);
            }
        }


        private string GetBookAuthors (SqlConnection connection, int bookId)
        {
            List<string> authorNames = new List<string>();

            string sqlAuthors = @"SELECT a.Id, a.Nume 
                               FROM Autori a 
                               INNER JOIN CartiAutori ca ON a.Id = ca.AutorId 
                               WHERE ca.CarteId = @CarteId";
            
            using (SqlCommand commandAuthors = new SqlCommand(sqlAuthors, connection))
            {   
                commandAuthors.Parameters.AddWithValue("@CarteId", bookId);
                using (SqlDataReader readerAuthors = commandAuthors.ExecuteReader())
                {   
                    while (readerAuthors.Read())
                    {
                        //int authorId = readerAuthors.GetInt32(0);
                        string nameAuthor = readerAuthors.GetString(1);

                        authorNames.Add(nameAuthor);
                    }  
                }
            }
            return string.Join(", ", authorNames);
        }


        public void CreateBook(Book book)
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

                    int bookId;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Titlu", book.Title);
                        command.Parameters.AddWithValue("@AnPublicare", book.YearPublished);
                        command.Parameters.AddWithValue("@Descriere", book.Description);
                        command.Parameters.AddWithValue("@EdituraId", book.PublisherId);

                        bookId = Convert.ToInt32(command.ExecuteScalar()); // obtine noul ID
                    }

                    //adaugare autori in CartiAutori
                    if (book.AuthorIds != null && book.AuthorIds.Count > 0)
                    {
                        foreach (int authorId in book.AuthorIds)
                        {
                            string sqlAuthor = "INSERT INTO CartiAutori (CarteId, AutorId) VALUES (@CarteId, @AutorId)";
                            using (SqlCommand commandAuthor = new SqlCommand(sqlAuthor, connection))
                            {
                                commandAuthor.Parameters.AddWithValue("@CarteId", bookId);
                                commandAuthor.Parameters.AddWithValue("@AutorId", authorId);
                                commandAuthor.ExecuteNonQuery();
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


        public void UpdateBook(Book book)
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
                        command.Parameters.AddWithValue("@Titlu", book.Title);
                        command.Parameters.AddWithValue("@AnPublicare", book.YearPublished);
                        command.Parameters.AddWithValue("@Descriere", book.Description);
                        command.Parameters.AddWithValue("@EdituraId", book.PublisherId);

                        command.Parameters.AddWithValue("@Id", book.Id);

                        command.ExecuteNonQuery();
                    }

                    // stergerea realatiilor din CartiAutori
                    string sqlDeleteRelationships = "DELETE FROM CartiAutori WHERE CarteId = @CarteId";
                    using (SqlCommand commandDeleteRelationships = new SqlCommand(sqlDeleteRelationships, connection))
                    {
                        commandDeleteRelationships.Parameters.AddWithValue("@CarteId", book.Id);
                        commandDeleteRelationships.ExecuteNonQuery();
                    }

                    // audagare de relatii noi in CartiAutori
                    if (book.AuthorIds != null && book.AuthorIds.Count > 0)
                    {
                        foreach (int authorId in book.AuthorIds)
                        {
                            string sqlInsert = "INSERT INTO CartiAutori (CarteId, AutorId) VALUES (@CarteId, @AutorId)";
                            using (SqlCommand commandInsert = new SqlCommand(sqlInsert, connection))
                            {
                                commandInsert.Parameters.AddWithValue("@CarteId", book.Id);
                                commandInsert.Parameters.AddWithValue("@AutorId", authorId);
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


        public void DeleteBook(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // stergerea realatiilor din CartiAutori
                    string sqlDeleteRelationships = "DELETE FROM CartiAutori WHERE CarteId = @CarteId";
                    using (SqlCommand commandDeleteRelationships = new SqlCommand(sqlDeleteRelationships, connection))
                    {
                        commandDeleteRelationships.Parameters.AddWithValue("@CarteId", id);
                        commandDeleteRelationships.ExecuteNonQuery();
                    }

                    // stergerea cartii
                    string sqlDeleteBook = "DELETE FROM Carti WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sqlDeleteBook, connection))
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



        public DataTable GetFilteredBooks (int? yearMin = null, int? yearMax = null, int? publisherId = null, int? authorId = null)
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

                if (yearMin.HasValue)
                    sql += " AND c.AnPublicare >= @AnMin";
                if (yearMax.HasValue)
                    sql += " AND c.AnPublicare <= @AnMax";
                if (publisherId.HasValue && publisherId > 0)
                    sql += " AND c.EdituraId = @EdituraId";
                if (authorId.HasValue && authorId > 0)
                    sql += " AND ca.AutorId = @AutorId";

                sql += " ORDER BY c.Titlu";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    if (yearMin.HasValue)
                        command.Parameters.AddWithValue("@AnMin", yearMin.Value);
                    if (yearMax.HasValue)
                        command.Parameters.AddWithValue("@AnMax", yearMax.Value);
                    if (publisherId.HasValue && publisherId > 0)
                        command.Parameters.AddWithValue("@EdituraId", publisherId.Value);
                    if (authorId.HasValue && authorId > 0)
                        command.Parameters.AddWithValue("@AutorId", authorId.Value);

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
