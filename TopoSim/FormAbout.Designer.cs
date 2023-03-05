namespace TopoSim
{
	partial class FormAbout
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
			pictureBox1 = new PictureBox();
			label1 = new Label();
			button1 = new Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(134, 124);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			label1.Location = new Point(161, 12);
			label1.Name = "label1";
			label1.Size = new Size(172, 30);
			label1.TabIndex = 1;
			label1.Text = "TopoSim, Layer0";
			// 
			// button1
			// 
			button1.Location = new Point(395, 155);
			button1.Name = "button1";
			button1.Size = new Size(108, 30);
			button1.TabIndex = 2;
			button1.Text = "Close";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// FormAbout
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(515, 197);
			Controls.Add(button1);
			Controls.Add(label1);
			Controls.Add(pictureBox1);
			KeyPreview = true;
			Name = "FormAbout";
			StartPosition = FormStartPosition.CenterParent;
			Text = "About";
			KeyDown += FormAbout_KeyDown;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pictureBox1;
		private Label label1;
		private Button button1;
	}
}