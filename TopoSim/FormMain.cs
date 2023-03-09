namespace TopoSim
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormAbout about = new();
			about.ShowDialog();
		}

		private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialogImage.ShowDialog() == DialogResult.OK)
			{
				var image = Image.FromFile(openFileDialogImage.FileName);
			}
		}
	}
}