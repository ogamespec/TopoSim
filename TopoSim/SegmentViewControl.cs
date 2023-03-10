using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;
using TopoSim;

namespace System.Windows.Forms
{
	public partial class SegmentView : Control
	{
		private BufferedGraphics? gfx;
		private BufferedGraphicsContext? context;

		List<SegmentedLayer> segmentedLayers = new ();

		private bool gdi_init = false;


		public void LoadSegmentedLayers (List<SegmentedLayer> layers, bool add)
		{
			if (add)
			{
				segmentedLayers.AddRange(layers);
			}
			else
			{
				segmentedLayers = layers;
			}
			Invalidate();
		}

		public SegmentView()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}

		private void DrawOrigin(Graphics gr)
		{

		}

		private void DrawLambdaGrid(Graphics gr)
		{

		}

		private void DrawSourceLayers(Graphics gr)
		{
			foreach (var seglayer in segmentedLayers)
			{
				if (seglayer.source_layer_image != null)
				{
					gr.DrawImage(seglayer.source_layer_image, new Point(0, 0));
				}
			}
		}

		private void DrawSegments(Graphics gr)
		{
			foreach (var seglayer in segmentedLayers)
			{
				foreach (var seg in seglayer.segments)
				{
					if (seg.rect.Width == 0 || seg.rect.Height == 0)
						continue;

					if (seg.is_solid_brush)
					{
						if (seg.solid_brush != null)
							gr.FillRectangle(seg.solid_brush, seg.rect);
					}
					else
					{
						if (seg.hatch_brush != null)
							gr.FillRectangle(seg.hatch_brush, seg.rect);
					}
				}
			}
		}

		private void DrawScene (Graphics gr)
		{
			gr.Clear(BackColor);

			if (Width <= 1 || Height <= 1)
				return;

			if (segmentedLayers.Count == 0)
				return;

			DrawSourceLayers(gr);
			DrawOrigin(gr);
			DrawSegments(gr);
			DrawLambdaGrid(gr);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (gfx == null)
			{
				ReallocateGraphics();
			}

			if (gfx != null)
			{
				DrawScene(gfx.Graphics);
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
			if (Width <= 1 || Height <= 1)
				return;

			context = BufferedGraphicsManager.Current;
			context.MaximumBuffer = new Size(Width + 1, Height + 1);

			gfx = context.Allocate(CreateGraphics(),
				 new Rectangle(0, 0, Width, Height));
		}


		//[Category("Plot Appearance")]
		//public Color FillColor { get; set; }


	}
}
