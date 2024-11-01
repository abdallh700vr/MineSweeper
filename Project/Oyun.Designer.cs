namespace Project
{
    partial class Oyun
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
            pnlBody = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.AutoSize = true;
            pnlBody.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlBody.BackColor = Color.WhiteSmoke;
            pnlBody.Location = new Point(12, 54);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(0, 0);
            pnlBody.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BackColor = SystemColors.MenuHighlight;
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(320, 40);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(154, 8);
            button1.Name = "button1";
            button1.Size = new Size(163, 29);
            button1.TabIndex = 4;
            button1.Text = "Score Board";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 12);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 12);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // Oyun
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1037, 906);
            Controls.Add(panel2);
            Controls.Add(pnlBody);
            Name = "Oyun";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oyun";
            Load += Oyun_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBody;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}