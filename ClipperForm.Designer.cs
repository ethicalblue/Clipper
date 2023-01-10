namespace Clipper
{
    partial class ClipperForm
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
            this.buttonEnable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEnable
            // 
            this.buttonEnable.BackColor = System.Drawing.Color.Black;
            this.buttonEnable.BackgroundImage = global::Clipper.Properties.Resources.disabled;
            this.buttonEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEnable.Location = new System.Drawing.Point(12, 12);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(353, 155);
            this.buttonEnable.TabIndex = 0;
            this.buttonEnable.UseVisualStyleBackColor = false;
            this.buttonEnable.Click += new System.EventHandler(this.ButtonEnable_Click);
            // 
            // ClipperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Clipper.Properties.Resources.clipperPL;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(870, 487);
            this.Controls.Add(this.buttonEnable);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "ClipperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trojan.Clipper Sample for Security Awareness Course";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEnable;
    }
}

