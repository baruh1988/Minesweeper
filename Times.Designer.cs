namespace minesweeper
{
    partial class Times
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
            this.components = new System.ComponentModel.Container();
            this.diff = new System.Windows.Forms.GroupBox();
            this.btnHard = new System.Windows.Forms.RadioButton();
            this.btnNormal = new System.Windows.Forms.RadioButton();
            this.btnEasy = new System.Windows.Forms.RadioButton();
            this.highScoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.leaders = new System.Windows.Forms.TableLayoutPanel();
            this.diff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.highScoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // diff
            // 
            this.diff.Controls.Add(this.btnHard);
            this.diff.Controls.Add(this.btnNormal);
            this.diff.Controls.Add(this.btnEasy);
            this.diff.Location = new System.Drawing.Point(12, 14);
            this.diff.Name = "diff";
            this.diff.Size = new System.Drawing.Size(345, 73);
            this.diff.TabIndex = 0;
            this.diff.TabStop = false;
            this.diff.Text = "Difficulty";
            // 
            // btnHard
            // 
            this.btnHard.AutoSize = true;
            this.btnHard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHard.Location = new System.Drawing.Point(189, 30);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(48, 17);
            this.btnHard.TabIndex = 2;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.CheckedChanged += new System.EventHandler(this.btnHard_CheckedChanged);
            // 
            // btnNormal
            // 
            this.btnNormal.AutoSize = true;
            this.btnNormal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNormal.Location = new System.Drawing.Point(98, 30);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(58, 17);
            this.btnNormal.TabIndex = 1;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.CheckedChanged += new System.EventHandler(this.btnNormal_CheckedChanged);
            // 
            // btnEasy
            // 
            this.btnEasy.AutoSize = true;
            this.btnEasy.Checked = true;
            this.btnEasy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEasy.Location = new System.Drawing.Point(7, 30);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(48, 17);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.TabStop = true;
            this.btnEasy.Text = "Easy";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.CheckedChanged += new System.EventHandler(this.btnEasy_CheckedChanged);
            // 
            // leaders
            // 
            this.leaders.ColumnCount = 3;
            this.leaders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.leaders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.leaders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.leaders.Location = new System.Drawing.Point(12, 93);
            this.leaders.Name = "leaders";
            this.leaders.RowCount = 10;
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leaders.Size = new System.Drawing.Size(345, 199);
            this.leaders.TabIndex = 1;
            // 
            // Times
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 333);
            this.Controls.Add(this.leaders);
            this.Controls.Add(this.diff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Times";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leader Board";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Times_FormClosing);
            this.Load += new System.EventHandler(this.Times_Load);
            this.diff.ResumeLayout(false);
            this.diff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.highScoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox diff;
        private System.Windows.Forms.RadioButton btnHard;
        private System.Windows.Forms.RadioButton btnNormal;
        private System.Windows.Forms.RadioButton btnEasy;
        private System.Windows.Forms.BindingSource highScoresBindingSource;
        private System.Windows.Forms.TableLayoutPanel leaders;
    }
}