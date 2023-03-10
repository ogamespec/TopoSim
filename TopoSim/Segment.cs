
using System.Drawing.Drawing2D;

namespace TopoSim
{
	public class SegmentedLayer
	{
		public TopoLayer? source_layer;
		public Image? source_layer_image;
		public List<Segment> segments = new();
	}

	public class Segment
	{
		public RectangleF rect = new();
		public bool is_solid_brush = true;
		public SolidBrush? solid_brush;
		public HatchBrush? hatch_brush;
		public Color brush_back_color;
		public Color brush_foreground_color;
	}

	public class Segmentator
	{

		static public List<SegmentedLayer> CreateDebugSegLayers()
		{
			List<SegmentedLayer> segmentedLayers = new();

			SegmentedLayer seglayer = new();

			List<Segment> segs = new();

			Segment seg1 = new();
			seg1.rect = new RectangleF(10, 10, 100, 100);
			seg1.is_solid_brush = true;
			seg1.solid_brush = new SolidBrush(Color.Indigo);
			segs.Add(seg1);

			Segment seg2 = new();
			seg2.rect = new RectangleF(50, 50, 200, 200);
			seg2.is_solid_brush = false;
			seg2.hatch_brush = new HatchBrush(HatchStyle.Divot, Color.Gold, Color.FromArgb (127, Color.Green));
			segs.Add(seg2);

			seglayer.segments = segs;

			segmentedLayers.Add(seglayer);

			return segmentedLayers;
		}


	}

}
