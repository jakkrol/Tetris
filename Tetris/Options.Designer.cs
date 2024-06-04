
namespace Tetris
{
    partial class Options
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
            this.Easy_label = new System.Windows.Forms.Label();
            this.Normal_label = new System.Windows.Forms.Label();
            this.Hard_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Easy_label
            // 
            this.Easy_label.AutoSize = true;
            this.Easy_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Easy_label.Location = new System.Drawing.Point(149, 45);
            this.Easy_label.Name = "Easy_label";
            this.Easy_label.Size = new System.Drawing.Size(65, 29);
            this.Easy_label.TabIndex = 0;
            this.Easy_label.Text = "Easy";
            this.Easy_label.Click += new System.EventHandler(this.Easy_label_Click);
            // 
            // Normal_label
            // 
            this.Normal_label.AutoSize = true;
            this.Normal_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Normal_label.Location = new System.Drawing.Point(246, 45);
            this.Normal_label.Name = "Normal_label";
            this.Normal_label.Size = new System.Drawing.Size(92, 29);
            this.Normal_label.TabIndex = 1;
            this.Normal_label.Text = "Normal";
            this.Normal_label.Click += new System.EventHandler(this.Normal_label_Click);
            // 
            // Hard_label
            // 
            this.Hard_label.AutoSize = true;
            this.Hard_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Hard_label.Location = new System.Drawing.Point(371, 45);
            this.Hard_label.Name = "Hard_label";
            this.Hard_label.Size = new System.Drawing.Size(65, 29);
            this.Hard_label.TabIndex = 2;
            this.Hard_label.Text = "Hard";
            this.Hard_label.Click += new System.EventHandler(this.Hard_label_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(523, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Back";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 454);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hard_label);
            this.Controls.Add(this.Normal_label);
            this.Controls.Add(this.Easy_label);
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Easy_label;
        private System.Windows.Forms.Label Normal_label;
        private System.Windows.Forms.Label Hard_label;
        private System.Windows.Forms.Label label1;
    }
}