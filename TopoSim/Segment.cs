
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
	}
}
