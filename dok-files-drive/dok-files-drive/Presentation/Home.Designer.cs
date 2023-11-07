namespace dok_files_drive
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btnDigitalizar = new System.Windows.Forms.Button();
            this.btnViewFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDigitalizar
            // 
            this.btnDigitalizar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDigitalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDigitalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDigitalizar.Location = new System.Drawing.Point(170, 88);
            this.btnDigitalizar.Name = "btnDigitalizar";
            this.btnDigitalizar.Size = new System.Drawing.Size(318, 71);
            this.btnDigitalizar.TabIndex = 0;
            this.btnDigitalizar.Text = "Digitalizar";
            this.btnDigitalizar.UseVisualStyleBackColor = false;
            this.btnDigitalizar.Click += new System.EventHandler(this.btnDigitalizar_Click);
            // 
            // btnViewFiles
            // 
            this.btnViewFiles.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnViewFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewFiles.Location = new System.Drawing.Point(170, 177);
            this.btnViewFiles.Name = "btnViewFiles";
            this.btnViewFiles.Size = new System.Drawing.Size(318, 71);
            this.btnViewFiles.TabIndex = 1;
            this.btnViewFiles.Text = "Ver arquivos em nuvem";
            this.btnViewFiles.UseVisualStyleBackColor = false;
            this.btnViewFiles.Click += new System.EventHandler(this.btnViewFiles_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 343);
            this.Controls.Add(this.btnViewFiles);
            this.Controls.Add(this.btnDigitalizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDigitalizar;
        private System.Windows.Forms.Button btnViewFiles;
    }
}

