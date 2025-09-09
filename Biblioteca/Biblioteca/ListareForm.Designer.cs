
namespace Biblioteca
{
    partial class ListareForm
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
            this.labelAnMin = new System.Windows.Forms.Label();
            this.labelAnMax = new System.Windows.Forms.Label();
            this.labelEditura = new System.Windows.Forms.Label();
            this.labelAutori = new System.Windows.Forms.Label();
            this.tbAnMin = new System.Windows.Forms.TextBox();
            this.tbAnMax = new System.Windows.Forms.TextBox();
            this.comboBoxEdituri = new System.Windows.Forms.ComboBox();
            this.comboBoxAutori = new System.Windows.Forms.ComboBox();
            this.btnTipareste = new System.Windows.Forms.Button();
            this.tableCartiFiltrate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tableCartiFiltrate)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAnMin
            // 
            this.labelAnMin.AutoSize = true;
            this.labelAnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnMin.Location = new System.Drawing.Point(12, 33);
            this.labelAnMin.Name = "labelAnMin";
            this.labelAnMin.Size = new System.Drawing.Size(94, 25);
            this.labelAnMin.TabIndex = 1;
            this.labelAnMin.Text = "An Minim";
            // 
            // labelAnMax
            // 
            this.labelAnMax.AutoSize = true;
            this.labelAnMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnMax.Location = new System.Drawing.Point(148, 33);
            this.labelAnMax.Name = "labelAnMax";
            this.labelAnMax.Size = new System.Drawing.Size(100, 25);
            this.labelAnMax.TabIndex = 2;
            this.labelAnMax.Text = "An Maxim";
            // 
            // labelEditura
            // 
            this.labelEditura.AutoSize = true;
            this.labelEditura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditura.Location = new System.Drawing.Point(314, 31);
            this.labelEditura.Name = "labelEditura";
            this.labelEditura.Size = new System.Drawing.Size(73, 25);
            this.labelEditura.TabIndex = 3;
            this.labelEditura.Text = "Editura";
            // 
            // labelAutori
            // 
            this.labelAutori.AutoSize = true;
            this.labelAutori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutori.Location = new System.Drawing.Point(443, 31);
            this.labelAutori.Name = "labelAutori";
            this.labelAutori.Size = new System.Drawing.Size(59, 25);
            this.labelAutori.TabIndex = 4;
            this.labelAutori.Text = "Autor";
            // 
            // tbAnMin
            // 
            this.tbAnMin.Location = new System.Drawing.Point(12, 61);
            this.tbAnMin.Name = "tbAnMin";
            this.tbAnMin.Size = new System.Drawing.Size(110, 22);
            this.tbAnMin.TabIndex = 5;
            // 
            // tbAnMax
            // 
            this.tbAnMax.Location = new System.Drawing.Point(153, 59);
            this.tbAnMax.Name = "tbAnMax";
            this.tbAnMax.Size = new System.Drawing.Size(110, 22);
            this.tbAnMax.TabIndex = 6;
            // 
            // comboBoxEdituri
            // 
            this.comboBoxEdituri.FormattingEnabled = true;
            this.comboBoxEdituri.Location = new System.Drawing.Point(307, 59);
            this.comboBoxEdituri.Name = "comboBoxEdituri";
            this.comboBoxEdituri.Size = new System.Drawing.Size(121, 24);
            this.comboBoxEdituri.TabIndex = 8;
            // 
            // comboBoxAutori
            // 
            this.comboBoxAutori.FormattingEnabled = true;
            this.comboBoxAutori.Location = new System.Drawing.Point(434, 59);
            this.comboBoxAutori.Name = "comboBoxAutori";
            this.comboBoxAutori.Size = new System.Drawing.Size(121, 24);
            this.comboBoxAutori.TabIndex = 9;
            // 
            // btnTipareste
            // 
            this.btnTipareste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTipareste.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTipareste.Location = new System.Drawing.Point(755, 33);
            this.btnTipareste.Name = "btnTipareste";
            this.btnTipareste.Size = new System.Drawing.Size(132, 53);
            this.btnTipareste.TabIndex = 10;
            this.btnTipareste.Text = "Tipareste";
            this.btnTipareste.UseVisualStyleBackColor = true;
            this.btnTipareste.Click += new System.EventHandler(this.btnTipareste_Click);
            // 
            // tableCartiFiltrate
            // 
            this.tableCartiFiltrate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableCartiFiltrate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableCartiFiltrate.Location = new System.Drawing.Point(12, 96);
            this.tableCartiFiltrate.Name = "tableCartiFiltrate";
            this.tableCartiFiltrate.RowHeadersWidth = 51;
            this.tableCartiFiltrate.RowTemplate.Height = 24;
            this.tableCartiFiltrate.Size = new System.Drawing.Size(871, 390);
            this.tableCartiFiltrate.TabIndex = 11;
            // 
            // ListareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 498);
            this.Controls.Add(this.tableCartiFiltrate);
            this.Controls.Add(this.btnTipareste);
            this.Controls.Add(this.comboBoxAutori);
            this.Controls.Add(this.comboBoxEdituri);
            this.Controls.Add(this.tbAnMax);
            this.Controls.Add(this.tbAnMin);
            this.Controls.Add(this.labelAutori);
            this.Controls.Add(this.labelEditura);
            this.Controls.Add(this.labelAnMax);
            this.Controls.Add(this.labelAnMin);
            this.Name = "ListareForm";
            this.Text = "ListareForm";
            this.Load += new System.EventHandler(this.ListareForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableCartiFiltrate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAnMin;
        private System.Windows.Forms.Label labelAnMax;
        private System.Windows.Forms.Label labelEditura;
        private System.Windows.Forms.Label labelAutori;
        private System.Windows.Forms.TextBox tbAnMin;
        private System.Windows.Forms.TextBox tbAnMax;
        private System.Windows.Forms.ComboBox comboBoxEdituri;
        private System.Windows.Forms.ComboBox comboBoxAutori;
        private System.Windows.Forms.Button btnTipareste;
        private System.Windows.Forms.DataGridView tableCartiFiltrate;
    }
}