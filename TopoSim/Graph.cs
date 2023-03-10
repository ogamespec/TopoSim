
namespace TopoSim
{

	public class Node
	{
		public List<Edge> edges = new();
		public Module? module;
	}

	public class Edge
	{
		public Node? from;
		public Node? to;
		public List<Segment> segments = new();
	}

	public class Graph
	{
		public List<Node> nodes = new();
		public List<Edge> edges = new();
	}

}
