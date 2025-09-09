using Biblioteca.Bussiness;
using Biblioteca.Data;
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
    public partial class CreateUpdateForm : Form
    {
        public CreateUpdateForm()
        {
            InitializeComponent();
            IncarcaEdituri();
            IncarcaAutori();
        }


        private void IncarcaEdituri()
        {
            try
            {
                var service = new CarteService();
                DataTable edituri = service.GetEdituri();

                comboBoxEditura.DataSource = edituri;
                comboBoxEditura.DisplayMember = "Nume";
                comboBoxEditura.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la incarcarea editurilor: {ex.Message}");
            }
        }

        private void IncarcaAutori()
        {
            try
            {
                var service = new CarteService();
                DataTable autori = service.GetAutori();

                comboBoxEditura.DropDownStyle = ComboBoxStyle.DropDownList;
                checkedListBoxAutori.DataSource = autori;
                checkedListBoxAutori.DisplayMember = "Nume";
                checkedListBoxAutori.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la incarcarea autorilor: {ex.Message}");
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private int carteId = 0;
        private Carte currentCarte;
        public void UpdateCarte(Carte carte)
        {
            this.Text = "Modifica o Carte";
            this.label2.Text = "Modifica o Carte";

            this.labelShowId.Text = carte.Id.ToString();
            this.tbTitlu.Text = carte.Titlu;
            this.tbDescriere.Text = carte.Descriere;
            this.tbAnPublicare.Text = carte.AnPublicare.ToString();

            this.carteId = carte.Id;

            this.comboBoxEditura.SelectedValue = carte.EdituraId;

            for (int i = 0; i < checkedListBoxAutori.Items.Count; i++)
            {
                try
                {
                    DataRowView row = (DataRowView)checkedListBoxAutori.Items[i];
                    int currentAutorId = Convert.ToInt32(row["Id"]);

                    if (carte.AutoriIds.Contains(currentAutorId))
                    {
                        checkedListBoxAutori.SetItemChecked(i, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la item {i}: {ex.Message}");
                }
            }

            this.currentCarte = carte;
        }

        public Carte GetCarteModificata()
        {
            if (currentCarte == null) return null;

            currentCarte.Titlu = this.tbTitlu.Text;
            currentCarte.Descriere = this.tbDescriere.Text;

            if (int.TryParse(this.tbAnPublicare.Text, out int anPublicare))
                currentCarte.AnPublicare = anPublicare;
            else
                MessageBox.Show($"Anul publicării trebuie să fie între 1445 și {DateTime.Now.Year}!");

            if (this.comboBoxEditura.SelectedValue != null)
                currentCarte.EdituraId = Convert.ToInt32(this.comboBoxEditura.SelectedValue);
            else
            {
                MessageBox.Show("Selectează o editură!");
                return null;
            }

            currentCarte.AutoriIds = new List<int>();
            foreach (var item in this.checkedListBoxAutori.CheckedItems)
            {
                DataRowView row = item as DataRowView;
                if (row != null)
                    currentCarte.AutoriIds.Add(Convert.ToInt32(row["Id"]));
            }

            return currentCarte;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Carte carte = new Carte();
                carte.Id = this.carteId; ;
                carte.Titlu = this.tbTitlu.Text;

                if (string.IsNullOrEmpty(carte.Titlu))
                {
                    MessageBox.Show("Titlul este obligatoriu!");
                    this.tbTitlu.Focus();
                    return;
                }

                carte.Descriere = this.tbDescriere.Text;

                if (!int.TryParse(this.tbAnPublicare.Text, out int anPublicare) || anPublicare < 1445 || anPublicare > DateTime.Now.Year)
                {
                    MessageBox.Show($"Anul publicării trebuie să fie între 1445 și {DateTime.Now.Year}!");
                    this.tbAnPublicare.Focus();
                    return;
                }
                carte.AnPublicare = anPublicare;

                if (comboBoxEditura.SelectedValue == null)
                {
                    MessageBox.Show("Selecteaza o editura!");
                    this.comboBoxEditura.Focus();
                    return;
                }
                carte.EdituraId = Convert.ToInt32(comboBoxEditura.SelectedValue);

                carte.AutoriIds = new List<int>();
                foreach (var autor in checkedListBoxAutori.CheckedItems)
                {
                    DataRowView row = autor as DataRowView;
                    if (row != null)
                        carte.AutoriIds.Add(Convert.ToInt32(row["Id"]));
                }
                if (carte.AutoriIds.Count == 0)
                {
                    MessageBox.Show("Selecteaza cel putin un autor!");
                    this.checkedListBoxAutori.Focus();
                    return;
                }

                var service = new CarteService();

                if (carte.Id == 0)
                    service.CreateCarte(carte);
                else
                    service.UpdateCarte(carte);

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbTitlu_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateUpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void labelDescriere_Click(object sender, EventArgs e)
        {

        }

        private void labelAnPublicare_Click(object sender, EventArgs e)
        {

        }

        private void tbAnPublicare_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDescriere_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelShowId_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEditura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
