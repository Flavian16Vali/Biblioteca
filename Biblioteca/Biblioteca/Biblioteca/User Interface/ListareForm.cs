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

            IncarcaEdituri();
            IncarcaAutori();
        }

        private void IncarcaEdituri()
        {
            try
            {
                var service = new CarteService();
                DataTable edituri = service.GetEdituri();

                comboBoxEdituri.DataSource = edituri;
                comboBoxEdituri.DisplayMember = "Nume";
                comboBoxEdituri.ValueMember = "Id";

                // Adaugă "Toate editurile" la început
                DataRow toate = edituri.NewRow();
                toate["Id"] = 0;
                toate["Nume"] = "Toate editurile";
                edituri.Rows.InsertAt(toate, 0);

                comboBoxEdituri.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea editurilor: {ex.Message}");
            }
        }

        private void IncarcaAutori()
        {
            try
            {
                var service = new CarteService();
                DataTable autori = service.GetAutori();

                comboBoxAutori.DataSource = autori;
                comboBoxAutori.DisplayMember = "Nume";
                comboBoxAutori.ValueMember = "Id";

                // Adaugă "Toți autorii" la început
                DataRow toti = autori.NewRow();
                toti["Id"] = 0;
                toti["Nume"] = "Toți autorii";
                autori.Rows.InsertAt(toti, 0);

                comboBoxAutori.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea autorilor: {ex.Message}");
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

                int? anMin = string.IsNullOrEmpty(tbAnMin.Text) ? null : (int?)int.Parse(tbAnMin.Text);
                int? anMax = string.IsNullOrEmpty(tbAnMax.Text) ? null : (int?)int.Parse(tbAnMax.Text);

                if (anMin.HasValue && anMax.HasValue && anMin > anMax)
                {
                    MessageBox.Show("Anul minim nu poate fi mai mare decat anul maxim!");
                    return;
                }

                int? edituraId = null;
                if (comboBoxEdituri.SelectedIndex > 0 && comboBoxEdituri.SelectedValue != null)
                    edituraId = Convert.ToInt32(comboBoxEdituri.SelectedValue);

                int? autorId = null;
                if (comboBoxAutori.SelectedIndex > 0 && comboBoxAutori.SelectedValue != null)
                    autorId = Convert.ToInt32(comboBoxAutori.SelectedValue);

                var service = new CarteService();
                DataTable result = service.GetCartiFiltrare(anMin, anMax, edituraId, autorId);

                tableCartiFiltrate.DataSource = result;

                MessageBox.Show($"S-au gasit {result.Rows.Count} carti conform filtrelor.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la generare raport: {ex.Message}");
            }
        }
    }
}
