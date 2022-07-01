namespace ShortestReachInAGraph;

public class ProblemResolution
{
    private const int EDGE_DISTANCE = 6;
    private const int EDGE_NULLDISTANCE = -1;

    public record Edge
    {
        public string nodeA;
        public string nodeB;

        public Edge(string nodeA, string nodeB)
        {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
        }
    }

    private record Graph
    {
        public List<Edge> Edges;
        public string StartNode;

        public Graph()
        {
            Edges = new List<Edge>();
        }
    }

    private record GraphDistances
    {
        public string Node;
        public int Distance;

        public GraphDistances(string Node, int Distance)
        {
            this.Node = Node;
            this.Distance = Distance;
        }
    }


    public static string ProcessGraphs(List<string> problem)
    {
        var graph = FillGraphs(problem);

        var graphDistances = ProcessDistances(graph);

        var result = BuildResult(graphDistances, graph.StartNode);

        return result;
    }

    private static Graph FillGraphs(List<string> problem)
    {
        Graph graph = new();

        foreach (var item in problem)
        {
            var edge = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (edge.Length == 1)
            {
                graph.StartNode = edge[0];
                continue;
            }

            graph.Edges.Add(new Edge(edge[0], edge[1]));
        }

        return graph;
    }

    private static List<GraphDistances> ProcessDistances(Graph graph)
    {
        List<GraphDistances> distances = new();
        bool startNodeFound = false;
        foreach (var currentEdge in graph.Edges)
        {
            if (!startNodeFound && (currentEdge.nodeA == graph.StartNode || currentEdge.nodeB == graph.StartNode))
                startNodeFound = true;

            if (!startNodeFound)
            {                
                if (!distances.Exists(x => x.Node == currentEdge.nodeA))
                    distances.Add(new GraphDistances(currentEdge.nodeA, EDGE_NULLDISTANCE));

                if (!distances.Exists(x => x.Node == currentEdge.nodeB))
                {
                    distances.Add(new GraphDistances(currentEdge.nodeB, EDGE_NULLDISTANCE));
                    continue;
                }
            }

            var previousEdge = graph.Edges.Find(x => currentEdge.nodeA == x.nodeB);

            AddNodeDistance(currentEdge.nodeA, previousEdge is null ? string.Empty : previousEdge.nodeA);
            AddNodeDistance(currentEdge.nodeB, currentEdge.nodeA);

        }

        return distances;


        void AddNodeDistance(string node, string previousNode)
        {
            var previousDistance = distances.Find(x => x.Node == previousNode);
            var distanceFound = distances.Find(x => x.Node == node);
            if (distanceFound is not null)
                distanceFound.Distance = (previousDistance is null ? 0 : previousDistance.Distance) + EDGE_DISTANCE;
            else
                distances.Add(new GraphDistances(node, EDGE_DISTANCE));
        }
    }

    private static string BuildResult(List<GraphDistances> distances, string startNode)
    {
        var shortedDistances = (from w in distances
                              orderby w.Node
                              select w).ToList();

        int minNode = shortedDistances.Min(x => int.Parse(x.Node));
        int maxNode = shortedDistances.Max(x => int.Parse(x.Node));

        StringBuilder lineWeight = new();
        for (int i = minNode - 1; i < maxNode; i++)
        {
            var currentDistance = shortedDistances.Find(x => x.Node == (i + 1).ToString());

            if (currentDistance is null)
            {
                lineWeight.Append($"{EDGE_NULLDISTANCE} ");
                continue;
            }
            
            if (currentDistance.Node != startNode)
                lineWeight.Append($"{currentDistance.Distance} ");
        }

        return lineWeight.ToString();
    }

}
