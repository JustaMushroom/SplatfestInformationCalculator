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
			SuspendLayout();
			// 
			// label1
			// 
			label1.Dock = DockStyle.Top;
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
			// MatchInformationForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(351, 342);
			Controls.Add(matchURLBox);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MatchInformationForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "MatchInformationForm";
			ResumeLayout(false);
		}

		#endregion

		private Label label1;
		private LinkLabel matchURLBox;
	}
}