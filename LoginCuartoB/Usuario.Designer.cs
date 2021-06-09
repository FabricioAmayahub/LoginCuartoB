
namespace LoginCuartoB
{
    partial class Usuario
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
            this.lbl_BIENV_USU = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_BIENV_USU
            // 
            this.lbl_BIENV_USU.AutoSize = true;
            this.lbl_BIENV_USU.Location = new System.Drawing.Point(431, 194);
            this.lbl_BIENV_USU.Name = "lbl_BIENV_USU";
            this.lbl_BIENV_USU.Size = new System.Drawing.Size(10, 13);
            this.lbl_BIENV_USU.TabIndex = 0;
            this.lbl_BIENV_USU.Text = ".";
            this.lbl_BIENV_USU.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "BIENVENIDO:";
            // 
            // Usuario
            // 
            this.AccessibleName = "FRM_USUARIO";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_BIENV_USU);
            this.Name = "Usuario";
            this.Text = "Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_BIENV_USU;
        private System.Windows.Forms.Label label1;
    }
}