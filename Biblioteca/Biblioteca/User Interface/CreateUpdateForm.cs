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
    public partial class CreateUpdateForm : Form
    {
        public CreateUpdateForm()
        {
            InitializeComponent();
            UploadPublishers();
            UploadAuthors();
        }


        private void UploadPublishers()
        {
            try
            {
                var service = new BookService();
                DataTable publishers = service.GetPublishers();

                comboBoxEditura.DataSource = publishers;
                comboBoxEditura.DisplayMember = "Nume";
                comboBoxEditura.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la incarcarea editurilor: {ex.Message}");
            }
        }

        private void UploadAuthors()
        {
            try
            {
                var service = new BookService();
                DataTable authors = service.GetAuthors();

                comboBoxEditura.DropDownStyle = ComboBoxStyle.DropDownList;
                checkedListBoxAutori.DataSource = authors;
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


        private int bookId = 0;
        private Book currentBook;
        public void UpdateBook(Book book)
        {
            this.Text = "Modifica o Carte";
            this.label2.Text = "Modifica o Carte";

            this.labelShowId.Text = book.Id.ToString();
            this.tbTitlu.Text = book.Title;
            this.tbDescriere.Text = book.Description;
            this.tbAnPublicare.Text = book.YearPublished.ToString();

            this.bookId = book.Id;

            this.comboBoxEditura.SelectedValue = book.PublisherId;

            for (int i = 0; i < checkedListBoxAutori.Items.Count; i++)
            {
                try
                {
                    DataRowView row = (DataRowView)checkedListBoxAutori.Items[i];
                    int currentAuthorId = Convert.ToInt32(row["Id"]);

                    if (book.AuthorIds.Contains(currentAuthorId))
                    {
                        // am adaugat this aici
                        this.checkedListBoxAutori.SetItemChecked(i, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Eroare la item {i}: {ex.Message}");
                }
            }

            this.currentBook = book;
        }


        public Book GetModifiedBook()
        {
            if (currentBook == null) 
                return null;

            currentBook.Title = this.tbTitlu.Text;
            currentBook.Description = this.tbDescriere.Text;

            if (int.TryParse(this.tbAnPublicare.Text, out int yearPublished))
                currentBook.YearPublished = yearPublished;
            else
                MessageBox.Show($"Anul publicarii trebuie să fie intre 1445 și {DateTime.Now.Year}!");

            if (this.comboBoxEditura.SelectedValue != null)
                currentBook.PublisherId = Convert.ToInt32(this.comboBoxEditura.SelectedValue);
            else
            {
                MessageBox.Show("Selecteaza o editura!");
                return null;
            }

            currentBook.AuthorIds = new List<int>();
            foreach (var item in this.checkedListBoxAutori.CheckedItems)
            {
                DataRowView row = item as DataRowView;
                if (row != null)
                    currentBook.AuthorIds.Add(Convert.ToInt32(row["Id"]));
            }

            return currentBook;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.tbTitlu.Text))
                {
                    MessageBox.Show("Titlul este obligatoriu!");
                    this.tbTitlu.Focus();
                    return;
                }

                if (!int.TryParse(this.tbAnPublicare.Text, out int yearPublished))
                {
                    MessageBox.Show($"Anul publicarii trebuie sa fieun numar valid!");
                    this.tbAnPublicare.Focus();
                    return;
                }

                if (comboBoxEditura.SelectedValue == null)
                {
                    MessageBox.Show("Selecteaza o editura!");
                    this.comboBoxEditura.Focus();
                    return;
                }

                string title = this.tbTitlu.Text;
                string description = this.tbDescriere.Text;
                int publisherId = Convert.ToInt32(comboBoxEditura.SelectedValue);

                List<int> authorIds = new List<int>();
                foreach (var author in checkedListBoxAutori.CheckedItems)
                {
                    DataRowView row = author as DataRowView;
                    if (row != null)
                        authorIds.Add(Convert.ToInt32(row["Id"]));
                }
                if (authorIds.Count == 0)
                {
                    MessageBox.Show("Selecteaza cel putin un autor!");
                    this.checkedListBoxAutori.Focus();
                    return;
                }

                var service = new BookService();

                if (this.bookId == 0)
                    service.CreateBook(title, description, yearPublished, publisherId, authorIds);
                else
                    service.UpdateBook(this.bookId, title, description, yearPublished, publisherId, authorIds);
                
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}");
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
