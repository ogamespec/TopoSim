
using Newtonsoft.Json;

namespace TopoSim
{
	public class TopoLayout
	{
		public TopoInfo? info;
		public TopoTopo? topo;
		public TopoLayer[]? layers;
	}

	public class TopoInfo
	{
		public string? description;
		public string? preview;
	}

	public class TopoTopo
	{
		public float lambda;
		public string? pie;
		public string? fet;
		public string? fet_dim;
		public string? wells;
	}

	public class TopoLayer
	{
		public string? type;
		public string? name;
		public string? pic;
		public string[]? colors;
		public string[]? vdd_colors;
		public string[]? gnd_colors;
		//public Tuple<string>[]? connects;
		public string? HatchStyle;
		public int[]? BrushBackgroundColor;
		public int[]? BrushForegroundColor;
	}

	public class TopoLoader
	{
		static public List<SegmentedLayer> LoadJson(string? json_name)
		{
			if (json_name == null)
				return new();

			string cwd = Path.GetDirectoryName(json_name);

			string text = File.ReadAllText(json_name, System.Text.Encoding.UTF8);

			if (text == null)
				return new();

			TopoLayout? layout = JsonConvert.DeserializeObject<TopoLayout>(text);
			if (layout == null)
				return new();

			List<SegmentedLayer> layers = new();

			foreach (var source_layer in layout.layers)
			{
				SegmentedLayer seglayer = new();
				seglayer.source_layer = source_layer;
				seglayer.source_layer_image = Image.FromFile(cwd + "/" + source_layer.pic);
				layers.Add(seglayer);
			}

			return layers;
		}
	}

}
