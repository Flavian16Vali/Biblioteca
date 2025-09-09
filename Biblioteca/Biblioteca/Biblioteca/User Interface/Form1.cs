using Biblioteca.Bussiness;
using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.cartiTable.AllowUserToAddRows = false;
            ReadCarti();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            try 
            {
                if (this.cartiTable.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selectează mai întâi o carte!");
                    return;
                }

                var val = this.cartiTable.SelectedRows[0].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(val))
                {
                    MessageBox.Show("Nu s-a putut citi ID-ul cărții!");
                    return;
                }

                int carteId = int.Parse(val);
                var service = new CarteService();
                var carte = service.GetCarteDupaId(carteId);
                
                if (carte == null)
                {
                    MessageBox.Show("Cartea nu a fost gasita"); 
                    return;
                }

                using (CreateUpdateForm form = new CreateUpdateForm())
                {
                    form.UpdateCarte(carte);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Carte carteModificata = form.GetCarteModificata();
                        service.UpdateCarte(carteModificata);
                        ReadCarti();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.GetType().Name} - {ex.Message}");
            }
            
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            using (CreateUpdateForm form = new CreateUpdateForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    ReadCarti();
            }
            
        }

        private void ReadCarti()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Titlu");
            dataTable.Columns.Add("An Publicare");
            dataTable.Columns.Add("Descriere");
            dataTable.Columns.Add("Editura");
            dataTable.Columns.Add("Autori");


            var service = new CarteService();
            var carti = service.GetToateCartile();

            foreach (var carte in carti)
            {
                var row = dataTable.NewRow();

                row["Id"] = carte.Id;
                row["Titlu"] = carte.Titlu;
                row["An Publicare"] = carte.AnPublicare;
                row["Descriere"] = carte.Descriere;
                row["Editura"] = carte.NumeEditura;
                row["Autori"] = carte.NumeAutori;

                dataTable.Rows.Add(row);
            }

            this.cartiTable.DataSource = dataTable;
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (this.cartiTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectează o carte pentru ștergere!"); 
                return;
            }

            var val = this.cartiTable.SelectedRows[0].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(val))
            {
                MessageBox.Show("Selecteaza o carte valida!");
                return;
            }

            int carteId = int.Parse(val);

            DialogResult dialogResult = MessageBox.Show("Esti sigut ca vrei sa stergi aceasta carte?",
                                                        "Stergere Carte", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
                return;


            try
            {
                var service = new CarteService();
                service.DeleteCarte(carteId);
                ReadCarti();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la stergere: {ex.Message}");
            }

            
        }

        private void btnListeaza_Click(object sender, EventArgs e)
        {
            using (ListareForm form = new ListareForm())
            {
                form.ShowDialog();
            }
        }
    }
}
