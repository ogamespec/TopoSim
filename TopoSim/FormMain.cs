using Newtonsoft.Json;
using System.Security.Principal;

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

		private void loadImageToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (openFileDialogImage.ShowDialog() == DialogResult.OK)
			{
				var image = Image.FromFile(openFileDialogImage.FileName);
			}
		}

		private void loadTopoJSONToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialogJSON.ShowDialog() == DialogResult.OK)
			{
				string json_name = openFileDialogJSON.FileName;

				var layers = TopoLoader.LoadJson(json_name);
				if (layers == null)
					return;

				segmentView1.LoadSegmentedLayers(layers);
			}
		}
	}
}