namespace SplatfestInformationCalculator.Components
{
	partial class MatchInformationForm
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
			label1 = new Label();
			matchURLBox = new LinkLabel();
			RO_Title_Match = new Label();
			Match_InfoLbl = new Label();
			RO_Title_Splatfest = new Label();
			Splatfest_InfoLbl = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Dock = DockStyle.Top;
			label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(351, 15);
			label1.TabIndex = 0;
			label1.Text = "Match Information";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// matchURLBox
			// 
			matchURLBox.Dock = DockStyle.Top;
			matchURLBox.LinkColor = Color.Blue;
			matchURLBox.Location = new Point(0, 15);
			matchURLBox.Name = "matchURLBox";
			matchURLBox.Size = new Size(351, 15);
			matchURLBox.TabIndex = 1;
			matchURLBox.TabStop = true;
			matchURLBox.Text = "matchURLBox";
			matchURLBox.TextAlign = ContentAlignment.MiddleCenter;
			matchURLBox.VisitedLinkColor = Color.Blue;
			// 
			// RO_Title_Match
			// 
			RO_Title_Match.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			RO_Title_Match.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			RO_Title_Match.Location = new Point(12, 30);
			RO_Title_Match.Name = "RO_Title_Match";
			RO_Title_Match.Size = new Size(327, 21);
			RO_Title_Match.TabIndex = 2;
			RO_Title_Match.Text = "Match";
			RO_Title_Match.TextAlign = ContentAlignment.TopCenter;
			// 
			// Match_InfoLbl
			// 
			Match_InfoLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Match_InfoLbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			Match_InfoLbl.Location = new Point(12, 51);
			Match_InfoLbl.Name = "Match_InfoLbl";
			Match_InfoLbl.Size = new Size(327, 54);
			Match_InfoLbl.TabIndex = 2;
			Match_InfoLbl.Text = "<Match Information>";
			Match_InfoLbl.TextAlign = ContentAlignment.TopCenter;
			// 
			// RO_Title_Splatfest
			// 
			RO_Title_Splatfest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			RO_Title_Splatfest.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			RO_Title_Splatfest.Location = new Point(12, 105);
			RO_Title_Splatfest.Name = "RO_Title_Splatfest";
			RO_Title_Splatfest.Size = new Size(327, 21);
			RO_Title_Splatfest.TabIndex = 2;
			RO_Title_Splatfest.Text = "Splatfest";
			RO_Title_Splatfest.TextAlign = ContentAlignment.TopCenter;
			// 
			// Splatfest_InfoLbl
			// 
			Splatfest_InfoLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Splatfest_InfoLbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			Splatfest_InfoLbl.Location = new Point(12, 126);
			Splatfest_InfoLbl.Name = "Splatfest_InfoLbl";
			Splatfest_InfoLbl.Size = new Size(327, 54);
			Splatfest_InfoLbl.TabIndex = 2;
			Splatfest_InfoLbl.Text = "<Fest Information>";
			Splatfest_InfoLbl.TextAlign = ContentAlignment.TopCenter;
			// 
			// MatchInformationForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(351, 219);
			Controls.Add(Splatfest_InfoLbl);
			Controls.Add(Match_InfoLbl);
			Controls.Add(RO_Title_Splatfest);
			Controls.Add(RO_Title_Match);
			Controls.Add(matchURLBox);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MatchInformationForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Match Information";
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private LinkLabel matchURLBox;
		private Label RO_Title_Match;
		private Label Match_InfoLbl;
		private Label RO_Title_Splatfest;
		private Label Splatfest_InfoLbl;
	}
}