namespace dok_files_drive
{
    partial class Visualization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualization));
            this.pdfViewer = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.pdfToolStripRotate1 = new Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripRotate();
            this.btnFinishDigitalization = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pdfViewer
            // 
            this.pdfViewer.AutoSize = true;
            this.pdfViewer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pdfViewer.CurrentIndex = -1;
            this.pdfViewer.CurrentPageHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Document = null;
            this.pdfViewer.FormHighlightColor = System.Drawing.Color.Transparent;
            this.pdfViewer.FormsBlendMode = Patagames.Pdf.Enums.BlendTypes.FXDIB_BLEND_MULTIPLY;
            this.pdfViewer.LoadingIconText = "Loading...";
            this.pdfViewer.Location = new System.Drawing.Point(0, 73);
            this.pdfViewer.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.OptimizedLoadThreshold = 1000;
            this.pdfViewer.Padding = new System.Windows.Forms.Padding(10);
            this.pdfViewer.PageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pdfViewer.PageAutoDispose = true;
            this.pdfViewer.PageBackColor = System.Drawing.Color.White;
            this.pdfViewer.PageBorderColor = System.Drawing.Color.Black;
            this.pdfViewer.PageMargin = new System.Windows.Forms.Padding(10);
            this.pdfViewer.PageSeparatorColor = System.Drawing.Color.Gray;
            this.pdfViewer.RenderFlags = ((Patagames.Pdf.Enums.RenderFlags)((Patagames.Pdf.Enums.RenderFlags.FPDF_LCD_TEXT | Patagames.Pdf.Enums.RenderFlags.FPDF_NO_CATCH)));
            this.pdfViewer.ShowCurrentPageHighlight = true;
            this.pdfViewer.ShowLoadingIcon = true;
            this.pdfViewer.ShowPageSeparator = true;
            this.pdfViewer.Size = new System.Drawing.Size(1360, 643);
            this.pdfViewer.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToSize;
            this.pdfViewer.TabIndex = 0;
            this.pdfViewer.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer.TilesCount = 2;
            this.pdfViewer.UseProgressiveRender = true;
            this.pdfViewer.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer.Zoom = 1F;
            // 
            // pdfToolStripRotate1
            // 
            this.pdfToolStripRotate1.Location = new System.Drawing.Point(0, 0);
            this.pdfToolStripRotate1.Name = "pdfToolStripRotate1";
            this.pdfToolStripRotate1.PdfViewer = this.pdfViewer;
            this.pdfToolStripRotate1.Size = new System.Drawing.Size(1360, 73);
            this.pdfToolStripRotate1.TabIndex = 1;
            this.pdfToolStripRotate1.Text = "pdfToolStripRotate1";
            // 
            // btnFinishDigitalization
            // 
            this.btnFinishDigitalization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishDigitalization.Location = new System.Drawing.Point(1143, 12);
            this.btnFinishDigitalization.Name = "btnFinishDigitalization";
            this.btnFinishDigitalization.Size = new System.Drawing.Size(183, 52);
            this.btnFinishDigitalization.TabIndex = 2;
            this.btnFinishDigitalization.Text = "Finalizar digitalização";
            this.btnFinishDigitalization.UseVisualStyleBackColor = true;
            this.btnFinishDigitalization.Click += new System.EventHandler(this.btnFinishDigitalization_Click);
            // 
            // Visualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 716);
            this.Controls.Add(this.btnFinishDigitalization);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.pdfToolStripRotate1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Visualization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualization";
            this.Load += new System.EventHandler(this.Visualization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer;
        private Patagames.Pdf.Net.Controls.WinForms.ToolBars.PdfToolStripRotate pdfToolStripRotate1;
        private System.Windows.Forms.Button btnFinishDigitalization;
    }
}