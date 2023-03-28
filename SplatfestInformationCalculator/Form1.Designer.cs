namespace SplatfestInformationCalculator
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MatchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsVictory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.K = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadLogTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splatfestComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splatfestComboBox);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.usernameTextBox);
            this.tabPage1.Controls.Add(this.loadLogTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Load Matches";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Matches List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatchID,
            this.IsVictory,
            this.K,
            this.D,
            this.KD,
            this.Cont});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(786, 416);
            this.dataGridView1.TabIndex = 0;
            // 
            // MatchID
            // 
            this.MatchID.HeaderText = "Match ID";
            this.MatchID.Name = "MatchID";
            this.MatchID.ReadOnly = true;
            // 
            // IsVictory
            // 
            this.IsVictory.HeaderText = "Won";
            this.IsVictory.Name = "IsVictory";
            this.IsVictory.ReadOnly = true;
            // 
            // K
            // 
            this.K.HeaderText = "Kills";
            this.K.Name = "K";
            this.K.ReadOnly = true;
            // 
            // D
            // 
            this.D.HeaderText = "Deaths";
            this.D.Name = "D";
            this.D.ReadOnly = true;
            // 
            // KD
            // 
            this.KD.HeaderText = "KDR";
            this.KD.Name = "KD";
            this.KD.ReadOnly = true;
            // 
            // Cont
            // 
            this.Cont.HeaderText = "Contribution";
            this.Cont.Name = "Cont";
            this.Cont.ReadOnly = true;
            // 
            // loadLogTextBox
            // 
            this.loadLogTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.loadLogTextBox.Location = new System.Drawing.Point(449, 3);
            this.loadLogTextBox.Multiline = true;
            this.loadLogTextBox.Name = "loadLogTextBox";
            this.loadLogTextBox.ReadOnly = true;
            this.loadLogTextBox.Size = new System.Drawing.Size(340, 416);
            this.loadLogTextBox.TabIndex = 0;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(148, 130);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(130, 23);
            this.usernameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stat.Ink Username:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load Matches";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // splatfestComboBox
            // 
            this.splatfestComboBox.FormattingEnabled = true;
            this.splatfestComboBox.Location = new System.Drawing.Point(148, 188);
            this.splatfestComboBox.Name = "splatfestComboBox";
            this.splatfestComboBox.Size = new System.Drawing.Size(130, 23);
            this.splatfestComboBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selected Splatfest:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private TabControl tabControl1;
		private TabPage tabPage1;
		private ComboBox splatfestComboBox;
		private Button button1;
		private Label label2;
		private Label label1;
		private TextBox usernameTextBox;
		private TextBox loadLogTextBox;
		private TabPage tabPage2;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn MatchID;
		private DataGridViewCheckBoxColumn IsVictory;
		private DataGridViewTextBoxColumn K;
		private DataGridViewTextBoxColumn D;
		private DataGridViewTextBoxColumn KD;
		private DataGridViewTextBoxColumn Cont;
	}
}