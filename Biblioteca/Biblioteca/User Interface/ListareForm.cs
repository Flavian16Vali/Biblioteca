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
    public partial class ListareForm : Form
    {

        public ListareForm()
        {
            InitializeComponent();
            comboBoxEdituri.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAutori.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxEdituri.Items.Insert(0, "Toate editurile");
            comboBoxAutori.Items.Insert(0, "Toți autorii");
            comboBoxEdituri.SelectedIndex = 0;
            comboBoxAutori.SelectedIndex = 0;
            this.tableCartiFiltrate.AllowUserToAddRows = false;

            UploadPublishers();
            UploadAuthors();
        }

        private void UploadPublishers()
        {
            try
            {
                var service = new BookService();
                DataTable publishers = service.GetPublishers();

                comboBoxEdituri.DataSource = publishers;
                comboBoxEdituri.DisplayMember = "Nume";
                comboBoxEdituri.ValueMember = "Id";

                // Adauga "Toate editurile" la inceput
                DataRow allPublishers = publishers.NewRow();
                allPublishers["Id"] = 0;
                allPublishers["Nume"] = "Toate editurile";
                publishers.Rows.InsertAt(allPublishers, 0);

                comboBoxEdituri.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încarcarea editurilor: {ex.Message}");
            }
        }


        private void UploadAuthors()
        {
            try
            {
                var service = new BookService();
                DataTable authors = service.GetAuthors();

                comboBoxAutori.DataSource = authors;
                comboBoxAutori.DisplayMember = "Nume";
                comboBoxAutori.ValueMember = "Id";

                // Adauga "Toti autorii" la inceput
                DataRow allAuthors = authors.NewRow();
                allAuthors["Id"] = 0;
                allAuthors["Nume"] = "Toti autorii";
                authors.Rows.InsertAt(allAuthors, 0);

                comboBoxAutori.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încarcarea autorilor: {ex.Message}");
            }
        }


        private void ListareForm_Load(object sender, EventArgs e)
        {

        }


        private void btnTipareste_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbAnMin.Text) && !int.TryParse(tbAnMin.Text, out _))
                {
                    MessageBox.Show("Anul minim trebuie sa fie un numar natural!");
                    tbAnMin.Focus();
                    return;
                }
                if (!string.IsNullOrEmpty(tbAnMax.Text) && !int.TryParse(tbAnMax.Text, out _))
                {
                    MessageBox.Show("Anul maxim trebuie sa fie un numar natural!");
                    tbAnMax.Focus();
                    return;
                }

                int? yearMin = string.IsNullOrEmpty(tbAnMin.Text) ? null : (int?)int.Parse(tbAnMin.Text);
                int? yearMax = string.IsNullOrEmpty(tbAnMax.Text) ? null : (int?)int.Parse(tbAnMax.Text);

                if (yearMin.HasValue && yearMax.HasValue && yearMin > yearMax)
                {
                    MessageBox.Show("Anul minim nu poate fi mai mare decat anul maxim!");
                    return;
                }

                int? publisherId = null;
                if (comboBoxEdituri.SelectedIndex > 0 && comboBoxEdituri.SelectedValue != null)
                    publisherId = Convert.ToInt32(comboBoxEdituri.SelectedValue);

                int? authorId = null;
                if (comboBoxAutori.SelectedIndex > 0 && comboBoxAutori.SelectedValue != null)
                    authorId = Convert.ToInt32(comboBoxAutori.SelectedValue);

                var service = new BookService();
                DataTable result = service.GetFilteredBooks(yearMin, yearMax, publisherId, authorId);

                tableCartiFiltrate.DataSource = result;

                MessageBox.Show($"S-au gasit {result.Rows.Count} carti conform filtrelor.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la generare raport: {ex.Message}");
            }
        }

        private void tableCartiFiltrate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStergeFiltre_Click(object sender, EventArgs e)
        {
            tbAnMin.Text = "";
            tbAnMax.Text = "";
            comboBoxEdituri.SelectedIndex = 0;
            comboBoxAutori.SelectedIndex = 0;

            btnTipareste_Click(sender, e);
        }
    }
}
