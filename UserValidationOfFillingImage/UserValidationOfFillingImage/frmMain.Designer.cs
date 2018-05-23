namespace UserValidationOfFillingImage
{
    partial class frmMain
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
            this.picBoard = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoard
            // 
            this.picBoard.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picBoard.Location = new System.Drawing.Point(12, 12);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(550, 450);
            this.picBoard.TabIndex = 0;
            this.picBoard.TabStop = false;
            this.picBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoard_Paint);
            this.picBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoard_MouseDown);
            this.picBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoard_MouseMove);
            this.picBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoard_MouseUp);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(568, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(103, 34);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重    置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 470);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.picBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "填充图片验证";
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoard;
        private System.Windows.Forms.Button btnReset;
    }
}

