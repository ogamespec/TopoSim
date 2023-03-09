using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace System.Windows.Forms
{
	public partial class SegmentView : Control
	{
		private BufferedGraphics? gfx;
		private BufferedGraphicsContext? context;

		private bool gdi_init = false;


		public SegmentView()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		private void DrawPlot (Graphics gr)
		{
			gr.Clear(BackColor);


		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (gfx == null)
			{
				ReallocateGraphics();
			}

			if (gfx != null)
			{
				DrawPlot(gfx.Graphics);
				gfx.Render(e.Graphics);
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if (gfx != null)
			{
				gfx.Dispose();
				ReallocateGraphics();
			}

			Invalidate();
			base.OnSizeChanged(e);
		}

		private void ReallocateGraphics()
		{
			context = BufferedGraphicsManager.Current;
			context.MaximumBuffer = new Size(Width + 1, Height + 1);

			gfx = context.Allocate(CreateGraphics(),
				 new Rectangle(0, 0, Width, Height));
		}


		//[Category("Plot Appearance")]
		//public Color FillColor { get; set; }


	}
}
