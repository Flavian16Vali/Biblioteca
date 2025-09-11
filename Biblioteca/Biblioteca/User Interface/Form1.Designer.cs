
using System;
using System.Windows.Forms;

namespace Biblioteca
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.cartiTable = new System.Windows.Forms.DataGridView();
            this.btnListeaza = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cartiTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1111, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de carti";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdauga
            // 
            this.btnAdauga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdauga.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdauga.Location = new System.Drawing.Point(12, 462);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(126, 61);
            this.btnAdauga.TabIndex = 1;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = true;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // btnSterge
            // 
            this.btnSterge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSterge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSterge.Location = new System.Drawing.Point(865, 462);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(126, 61);
            this.btnSterge.TabIndex = 2;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifica.Location = new System.Drawing.Point(733, 462);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(126, 61);
            this.btnModifica.TabIndex = 3;
            this.btnModifica.Text = "Modifica";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // cartiTable
            // 
            this.cartiTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartiTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cartiTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartiTable.Location = new System.Drawing.Point(12, 45);
            this.cartiTable.MultiSelect = false;
            this.cartiTable.Name = "cartiTable";
            this.cartiTable.RowHeadersVisible = false;
            this.cartiTable.RowHeadersWidth = 51;
            this.cartiTable.RowTemplate.Height = 24;
            this.cartiTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cartiTable.Size = new System.Drawing.Size(1111, 411);
            this.cartiTable.TabIndex = 4;
            this.cartiTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cartiTable_CellContentClick);
            // 
            // btnListeaza
            // 
            this.btnListeaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListeaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListeaza.Location = new System.Drawing.Point(997, 462);
            this.btnListeaza.Name = "btnListeaza";
            this.btnListeaza.Size = new System.Drawing.Size(126, 61);
            this.btnListeaza.TabIndex = 5;
            this.btnListeaza.Text = "Listeaza";
            this.btnListeaza.UseVisualStyleBackColor = true;
            this.btnListeaza.Click += new System.EventHandler(this.btnListeaza_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 535);
            this.Controls.Add(this.btnListeaza);
            this.Controls.Add(this.cartiTable);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnAdauga);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Biblioteca";
            ((System.ComponentModel.ISupportInitialize)(this.cartiTable)).EndInit();
            this.ResumeLayout(false);

        }

        private void cartiTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.DataGridView cartiTable;
        private System.Windows.Forms.Button btnListeaza;

        public Form1(DataGridView cartiTable)
        {
            this.cartiTable = cartiTable;
        }
    }
}

