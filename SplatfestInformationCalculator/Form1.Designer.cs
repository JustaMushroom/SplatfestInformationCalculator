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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			splatfestComboBox = new ComboBox();
			button1 = new Button();
			label2 = new Label();
			label1 = new Label();
			usernameTextBox = new TextBox();
			loadLogTextBox = new TextBox();
			tabPage2 = new TabPage();
			dataGridView1 = new DataGridView();
			MatchID = new DataGridViewTextBoxColumn();
			LobbyType = new DataGridViewTextBoxColumn();
			Victory = new DataGridViewCheckBoxColumn();
			Kills = new DataGridViewTextBoxColumn();
			Deaths = new DataGridViewTextBoxColumn();
			KDR = new DataGridViewTextBoxColumn();
			Contribution = new DataGridViewTextBoxColumn();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(800, 450);
			tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(splatfestComboBox);
			tabPage1.Controls.Add(button1);
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(label1);
			tabPage1.Controls.Add(usernameTextBox);
			tabPage1.Controls.Add(loadLogTextBox);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(792, 422);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Load Matches";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// splatfestComboBox
			// 
			splatfestComboBox.FormattingEnabled = true;
			splatfestComboBox.Location = new Point(148, 188);
			splatfestComboBox.Name = "splatfestComboBox";
			splatfestComboBox.Size = new Size(130, 23);
			splatfestComboBox.TabIndex = 4;
			// 
			// button1
			// 
			button1.Location = new Point(148, 226);
			button1.Name = "button1";
			button1.Size = new Size(130, 23);
			button1.TabIndex = 3;
			button1.Text = "Load Matches";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(161, 170);
			label2.Name = "label2";
			label2.Size = new Size(102, 15);
			label2.TabIndex = 2;
			label2.Text = "Selected Splatfest:";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(161, 112);
			label1.Name = "label1";
			label1.Size = new Size(105, 15);
			label1.TabIndex = 2;
			label1.Text = "Stat.Ink Username:";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// usernameTextBox
			// 
			usernameTextBox.Location = new Point(148, 130);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new Size(130, 23);
			usernameTextBox.TabIndex = 1;
			// 
			// loadLogTextBox
			// 
			loadLogTextBox.Dock = DockStyle.Right;
			loadLogTextBox.Location = new Point(449, 3);
			loadLogTextBox.Multiline = true;
			loadLogTextBox.Name = "loadLogTextBox";
			loadLogTextBox.ReadOnly = true;
			loadLogTextBox.Size = new Size(340, 416);
			loadLogTextBox.TabIndex = 0;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(dataGridView1);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(792, 422);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Matches List";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { MatchID, LobbyType, Victory, Kills, Deaths, KDR, Contribution });
			dataGridView1.Dock = DockStyle.Fill;
			dataGridView1.Location = new Point(3, 3);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowTemplate.Height = 25;
			dataGridView1.Size = new Size(786, 416);
			dataGridView1.TabIndex = 0;
			// 
			// MatchID
			// 
			MatchID.HeaderText = "Match ID";
			MatchID.Name = "MatchID";
			MatchID.ReadOnly = true;
			// 
			// LobbyType
			// 
			LobbyType.HeaderText = "LobbyType";
			LobbyType.Name = "LobbyType";
			LobbyType.ReadOnly = true;
			// 
			// Victory
			// 
			Victory.HeaderText = "Won";
			Victory.Name = "Victory";
			Victory.ReadOnly = true;
			// 
			// Kills
			// 
			Kills.HeaderText = "Kills";
			Kills.Name = "Kills";
			Kills.ReadOnly = true;
			// 
			// Deaths
			// 
			Deaths.HeaderText = "Deaths";
			Deaths.Name = "Deaths";
			Deaths.ReadOnly = true;
			// 
			// KDR
			// 
			dataGridViewCellStyle1.Format = "N2";
			dataGridViewCellStyle1.NullValue = null;
			KDR.DefaultCellStyle = dataGridViewCellStyle1;
			KDR.HeaderText = "KDR";
			KDR.Name = "KDR";
			KDR.ReadOnly = true;
			// 
			// Contribution
			// 
			Contribution.HeaderText = "Contribution";
			Contribution.Name = "Contribution";
			Contribution.ReadOnly = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(tabControl1);
			Name = "Form1";
			Text = "Form1";
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
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
		private DataGridViewTextBoxColumn LobbyType;
		private DataGridViewCheckBoxColumn Victory;
		private DataGridViewTextBoxColumn Kills;
		private DataGridViewTextBoxColumn Deaths;
		private DataGridViewTextBoxColumn KDR;
		private DataGridViewTextBoxColumn Contribution;
	}
}