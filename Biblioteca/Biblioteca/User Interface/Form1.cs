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
            ReadBooks();
        }

        
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            using (CreateUpdateForm form = new CreateUpdateForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    ReadBooks();
            }
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

                int bookId = int.Parse(val);
                var service = new BookService();
                var book = service.GetBookById(bookId);
                
                if (book == null)
                {
                    MessageBox.Show("Cartea nu a fost gasita"); 
                    return;
                }

                using (CreateUpdateForm form = new CreateUpdateForm())
                {
                    form.UpdateBook(book);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Book modifiedBook = form.GetModifiedBook();
                        service.UpdateBook(modifiedBook.Id, modifiedBook.Title, modifiedBook.Description,
                                           modifiedBook.YearPublished, modifiedBook.PublisherId, modifiedBook.AuthorIds);
                        ReadBooks();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.GetType().Name} - {ex.Message}");
            }        
        }


        private void ReadBooks()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Titlu");
            dataTable.Columns.Add("An Publicare");
            dataTable.Columns.Add("Descriere");
            dataTable.Columns.Add("Editura");
            dataTable.Columns.Add("Autori");

            var service = new BookService();
            var books = service.GetBooks();

            foreach (var book in books)
            {
                var row = dataTable.NewRow();

                row["Id"] = book.Id;
                row["Titlu"] = book.Title;
                row["An Publicare"] = book.YearPublished;
                row["Descriere"] = book.Description;
                row["Editura"] = book.PublisherName;
                row["Autori"] = book.AuthorNames;

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

            int bookId = int.Parse(val);

            DialogResult dialogResult = MessageBox.Show("Esti sigur ca vrei sa stergi aceasta carte?",
                                                        "Stergere Carte", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
                return;

            try
            {
                var service = new BookService();
                service.DeleteBook(bookId);
                ReadBooks();
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
