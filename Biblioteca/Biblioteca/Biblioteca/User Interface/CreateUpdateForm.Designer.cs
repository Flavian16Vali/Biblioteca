
namespace Biblioteca
{
    partial class CreateUpdateForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.labelIdCarte = new System.Windows.Forms.Label();
            this.labelDescriere = new System.Windows.Forms.Label();
            this.labelAnPublicare = new System.Windows.Forms.Label();
            this.labelTitlu = new System.Windows.Forms.Label();
            this.tbTitlu = new System.Windows.Forms.TextBox();
            this.tbAnPublicare = new System.Windows.Forms.TextBox();
            this.tbDescriere = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelShowId = new System.Windows.Forms.Label();
            this.labelEditura = new System.Windows.Forms.Label();
            this.labelAutori = new System.Windows.Forms.Label();
            this.comboBoxEditura = new System.Windows.Forms.ComboBox();
            this.checkedListBoxAutori = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(637, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adauga Carte";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelIdCarte
            // 
            this.labelIdCarte.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdCarte.Location = new System.Drawing.Point(13, 109);
            this.labelIdCarte.Name = "labelIdCarte";
            this.labelIdCarte.Size = new System.Drawing.Size(179, 33);
            this.labelIdCarte.TabIndex = 3;
            this.labelIdCarte.Text = "Id Carte";
            this.labelIdCarte.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // labelDescriere
            // 
            this.labelDescriere.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescriere.Location = new System.Drawing.Point(12, 208);
            this.labelDescriere.Name = "labelDescriere";
            this.labelDescriere.Size = new System.Drawing.Size(180, 33);
            this.labelDescriere.TabIndex = 4;
            this.labelDescriere.Text = "Descriere";
            this.labelDescriere.Click += new System.EventHandler(this.labelDescriere_Click);
            // 
            // labelAnPublicare
            // 
            this.labelAnPublicare.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnPublicare.Location = new System.Drawing.Point(12, 175);
            this.labelAnPublicare.Name = "labelAnPublicare";
            this.labelAnPublicare.Size = new System.Drawing.Size(180, 33);
            this.labelAnPublicare.TabIndex = 5;
            this.labelAnPublicare.Text = "An Publicare";
            this.labelAnPublicare.Click += new System.EventHandler(this.labelAnPublicare_Click);
            // 
            // labelTitlu
            // 
            this.labelTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlu.Location = new System.Drawing.Point(12, 142);
            this.labelTitlu.Name = "labelTitlu";
            this.labelTitlu.Size = new System.Drawing.Size(180, 33);
            this.labelTitlu.TabIndex = 6;
            this.labelTitlu.Text = "Titlu";
            this.labelTitlu.Click += new System.EventHandler(this.label6_Click);
            // 
            // tbTitlu
            // 
            this.tbTitlu.Location = new System.Drawing.Point(213, 149);
            this.tbTitlu.Name = "tbTitlu";
            this.tbTitlu.Size = new System.Drawing.Size(338, 22);
            this.tbTitlu.TabIndex = 7;
            this.tbTitlu.TextChanged += new System.EventHandler(this.tbTitlu_TextChanged);
            // 
            // tbAnPublicare
            // 
            this.tbAnPublicare.Location = new System.Drawing.Point(214, 182);
            this.tbAnPublicare.Name = "tbAnPublicare";
            this.tbAnPublicare.Size = new System.Drawing.Size(337, 22);
            this.tbAnPublicare.TabIndex = 8;
            this.tbAnPublicare.TextChanged += new System.EventHandler(this.tbAnPublicare_TextChanged);
            // 
            // tbDescriere
            // 
            this.tbDescriere.Location = new System.Drawing.Point(213, 215);
            this.tbDescriere.Name = "tbDescriere";
            this.tbDescriere.Size = new System.Drawing.Size(337, 22);
            this.tbDescriere.TabIndex = 9;
            this.tbDescriere.TextChanged += new System.EventHandler(this.tbDescriere_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(213, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 61);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(345, 372);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 61);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelShowId
            // 
            this.labelShowId.AutoSize = true;
            this.labelShowId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShowId.Location = new System.Drawing.Point(209, 109);
            this.labelShowId.Name = "labelShowId";
            this.labelShowId.Size = new System.Drawing.Size(0, 25);
            this.labelShowId.TabIndex = 13;
            this.labelShowId.Click += new System.EventHandler(this.labelShowId_Click);
            // 
            // labelEditura
            // 
            this.labelEditura.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditura.Location = new System.Drawing.Point(12, 241);
            this.labelEditura.Name = "labelEditura";
            this.labelEditura.Size = new System.Drawing.Size(180, 33);
            this.labelEditura.TabIndex = 14;
            this.labelEditura.Text = "Editura";
            this.labelEditura.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelAutori
            // 
            this.labelAutori.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutori.Location = new System.Drawing.Point(12, 274);
            this.labelAutori.Name = "labelAutori";
            this.labelAutori.Size = new System.Drawing.Size(180, 33);
            this.labelAutori.TabIndex = 15;
            this.labelAutori.Text = "Autori";
            // 
            // comboBoxEditura
            // 
            this.comboBoxEditura.FormattingEnabled = true;
            this.comboBoxEditura.Location = new System.Drawing.Point(213, 248);
            this.comboBoxEditura.Name = "comboBoxEditura";
            this.comboBoxEditura.Size = new System.Drawing.Size(338, 24);
            this.comboBoxEditura.TabIndex = 16;
            this.comboBoxEditura.Text = "Editura";
            this.comboBoxEditura.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditura_SelectedIndexChanged);
            // 
            // checkedListBoxAutori
            // 
            this.checkedListBoxAutori.CheckOnClick = true;
            this.checkedListBoxAutori.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkedListBoxAutori.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxAutori.FormattingEnabled = true;
            this.checkedListBoxAutori.Location = new System.Drawing.Point(213, 286);
            this.checkedListBoxAutori.Name = "checkedListBoxAutori";
            this.checkedListBoxAutori.Size = new System.Drawing.Size(337, 80);
            this.checkedListBoxAutori.Sorted = true;
            this.checkedListBoxAutori.TabIndex = 17;
            // 
            // CreateUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 445);
            this.Controls.Add(this.checkedListBoxAutori);
            this.Controls.Add(this.comboBoxEditura);
            this.Controls.Add(this.labelAutori);
            this.Controls.Add(this.labelEditura);
            this.Controls.Add(this.labelShowId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbDescriere);
            this.Controls.Add(this.tbAnPublicare);
            this.Controls.Add(this.tbTitlu);
            this.Controls.Add(this.labelTitlu);
            this.Controls.Add(this.labelAnPublicare);
            this.Controls.Add(this.labelDescriere);
            this.Controls.Add(this.labelIdCarte);
            this.Controls.Add(this.label2);
            this.Name = "CreateUpdateForm";
            this.Text = "Adauga Carte";
            this.Load += new System.EventHandler(this.CreateUpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelIdCarte;
        private System.Windows.Forms.Label labelDescriere;
        private System.Windows.Forms.Label labelAnPublicare;
        private System.Windows.Forms.Label labelTitlu;
        private System.Windows.Forms.TextBox tbTitlu;
        private System.Windows.Forms.TextBox tbAnPublicare;
        private System.Windows.Forms.TextBox tbDescriere;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelShowId;
        private System.Windows.Forms.Label labelEditura;
        private System.Windows.Forms.Label labelAutori;
        private System.Windows.Forms.ComboBox comboBoxEditura;
        private System.Windows.Forms.CheckedListBox checkedListBoxAutori;
    }
}