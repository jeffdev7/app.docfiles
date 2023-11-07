namespace dok_files_drive
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblTitleMain = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.checkPDFA = new System.Windows.Forms.CheckBox();
            this.checkImgOCR = new System.Windows.Forms.CheckBox();
            this.btnSearchDevices = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDigitalizar = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbmBoxLanguage = new System.Windows.Forms.ComboBox();
            this.lblFileUploaded = new System.Windows.Forms.Label();
            this.listDevices = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblTitleMain
            // 
            this.lblTitleMain.AutoSize = true;
            this.lblTitleMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleMain.Location = new System.Drawing.Point(38, 36);
            this.lblTitleMain.Name = "lblTitleMain";
            this.lblTitleMain.Size = new System.Drawing.Size(150, 20);
            this.lblTitleMain.TabIndex = 0;
            this.lblTitleMain.Text = "Digitalizar para PDF";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(29, 195);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(72, 13);
            this.lblLanguage.TabIndex = 40;
            this.lblLanguage.Text = "Idiomas OCR:";
            // 
            // checkPDFA
            // 
            this.checkPDFA.AutoSize = true;
            this.checkPDFA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPDFA.Location = new System.Drawing.Point(42, 89);
            this.checkPDFA.Name = "checkPDFA";
            this.checkPDFA.Size = new System.Drawing.Size(174, 20);
            this.checkPDFA.TabIndex = 2;
            this.checkPDFA.Text = "Criar documentos PDF/A";
            this.checkPDFA.UseVisualStyleBackColor = true;
            // 
            // checkImgOCR
            // 
            this.checkImgOCR.AutoSize = true;
            this.checkImgOCR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkImgOCR.Location = new System.Drawing.Point(42, 121);
            this.checkImgOCR.Name = "checkImgOCR";
            this.checkImgOCR.Size = new System.Drawing.Size(211, 20);
            this.checkImgOCR.TabIndex = 3;
            this.checkImgOCR.Text = "Reconhecer texto nas imagens";
            this.checkImgOCR.UseVisualStyleBackColor = true;
            // 
            // btnSearchDevices
            // 
            this.btnSearchDevices.Location = new System.Drawing.Point(399, 81);
            this.btnSearchDevices.Name = "btnSearchDevices";
            this.btnSearchDevices.Size = new System.Drawing.Size(115, 28);
            this.btnSearchDevices.TabIndex = 4;
            this.btnSearchDevices.Text = "Buscar scanners";
            this.btnSearchDevices.UseVisualStyleBackColor = true;
            this.btnSearchDevices.Click += new System.EventHandler(this.btnSearchDevices_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(399, 359);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(323, 44);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload de arquivos";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDigitalizar
            // 
            this.btnDigitalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDigitalizar.Location = new System.Drawing.Point(32, 288);
            this.btnDigitalizar.Name = "btnDigitalizar";
            this.btnDigitalizar.Size = new System.Drawing.Size(232, 56);
            this.btnDigitalizar.TabIndex = 1;
            this.btnDigitalizar.Text = "Digitalizar para PDF";
            this.btnDigitalizar.UseVisualStyleBackColor = true;
            this.btnDigitalizar.Click += new System.EventHandler(this.btnDigitalizar_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(32, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(232, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Voltar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbmBoxLanguage
            // 
            this.cbmBoxLanguage.FormattingEnabled = true;
            this.cbmBoxLanguage.Location = new System.Drawing.Point(32, 214);
            this.cbmBoxLanguage.Name = "cbmBoxLanguage";
            this.cbmBoxLanguage.Size = new System.Drawing.Size(121, 21);
            this.cbmBoxLanguage.TabIndex = 9;
            // 
            // lblFileUploaded
            // 
            this.lblFileUploaded.AutoSize = true;
            this.lblFileUploaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileUploaded.Location = new System.Drawing.Point(405, 415);
            this.lblFileUploaded.Name = "lblFileUploaded";
            this.lblFileUploaded.Size = new System.Drawing.Size(10, 15);
            this.lblFileUploaded.TabIndex = 41;
            this.lblFileUploaded.Text = ".";
            // 
            // listDevices
            // 
            this.listDevices.FormattingEnabled = true;
            this.listDevices.Location = new System.Drawing.Point(399, 121);
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(323, 212);
            this.listDevices.TabIndex = 42;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(810, 459);
            this.Controls.Add(this.listDevices);
            this.Controls.Add(this.lblFileUploaded);
            this.Controls.Add(this.cbmBoxLanguage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDigitalizar);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnSearchDevices);
            this.Controls.Add(this.checkImgOCR);
            this.Controls.Add(this.checkPDFA);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblTitleMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digitalização";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleMain;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.CheckBox checkPDFA;
        private System.Windows.Forms.CheckBox checkImgOCR;
        private System.Windows.Forms.Button btnSearchDevices;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDigitalizar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbmBoxLanguage;
        private System.Windows.Forms.Label lblFileUploaded;
        private System.Windows.Forms.ListBox listDevices;
    }
}