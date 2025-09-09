using Biblioteca.Data;
using Biblioteca.DataSet;
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
                var data = new CarteDataSet();
                var carte = data.GetCarte(carteId);
                
                if (carte == null)
                {
                    MessageBox.Show("0"); return;
                }

                CreateUpdateForm form = new CreateUpdateForm();
                form.UpdateCarte(carte);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Carte carteModificata = form.GetCarteModificata();
                    data.UpdateCarte(carteModificata);
                    ReadCarti();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.GetType().Name} - {ex.Message}");
            }
            
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            CreateUpdateForm form = new CreateUpdateForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                //actualizare lista cartilor
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


            var data = new CarteDataSet();
            var carti = data.GetCarti();

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
            var val = this.cartiTable.SelectedRows[0].Cells[0].Value.ToString();
            if (val == null || val.Length == 0)
            {
                MessageBox.Show("Selectează o carte pentru ștergere!"); return;
            }

            int carteId = int.Parse(val);

            // mesaj de confirmare 
            DialogResult dialogResult = MessageBox.Show("Esti sigut ca vrei sa stergi aceasta carte?",
                                                        "Stergere Carte", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
                return;

            var data = new CarteDataSet();
            data.DeleteCarte(carteId);

            ReadCarti();
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
