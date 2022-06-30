using System.Text;

namespace ShortestReachInAGraph;

public class ProblemResolution
{
    private const int EdgeLen = 6;

    public class Edge
    {
        public string nodeA;
        public string nodeB;

        public Edge(string nodeA, string nodeB)
        {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
        }
    }

    private class Graph
    {
        public List<Edge> Edges;
        public string NodeStart;

        public Graph()
        {
            Edges = new List<Edge>();
        }
    }

    private record GraphWeight(string Node, int Weight);

    public static string ProcessGraphs(List<string> problem)
    {
        var graph = FillGraphs(problem);

        var graphWeights = GetWeights(graph);

        var result = BuildResult(graphWeights);

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
                graph.NodeStart = edge[0];
                continue;
            }

            graph.Edges.Add(new Edge(edge[0], edge[1]));
        }

        return graph;
    }

    private static List<GraphWeight> GetWeights(Graph graph)
    {
        List<GraphWeight> graphWeights = new();

        Edge prevEdge = graph.Edges[0];
        int lenMultiplier = 1;
        foreach (var edge in graph.Edges)
        {
            if (CaseOf_NodeAIsNodeStart(edge))
                continue;

            if (Caseof_NodeAEqualNodeB(edge))
                continue;            

            if (Caseof_ExistNodeBEqualNodeA(edge))    
                continue;

            lenMultiplier = 1;
            graphWeights.Add(new GraphWeight(edge.nodeA, -1));
        }

        return graphWeights;


        bool CaseOf_NodeAIsNodeStart(Edge edge)
        {
            if (edge.nodeA == graph.NodeStart)
            {
                graphWeights.Add(new GraphWeight(edge.nodeB, EdgeLen));
                prevEdge = edge;
                lenMultiplier = 1;

                return true;
            }

            return false;
        }

        bool Caseof_NodeAEqualNodeB(Edge edge)
        {
            if (edge.nodeA == prevEdge.nodeB)
            {
                lenMultiplier++;
                graphWeights.Add(new GraphWeight(edge.nodeB, EdgeLen * lenMultiplier));
                prevEdge = edge;

                return true;
            }

            return false;
        }

        bool Caseof_ExistNodeBEqualNodeA(Edge edge)
        {
            if (graph.Edges.Exists(x => x.nodeB == edge.nodeA))
            {
                graphWeights.Add(new GraphWeight(edge.nodeB, -1));

                return true;
            }

            return false;
        }
    }

    private static string BuildResult(List<GraphWeight> weights)
    {
        var shortedWeights = from w in weights
                                orderby w.Node
                                select w;

        StringBuilder lineWeight = new();
        foreach (var weight in shortedWeights)
        {
            lineWeight.Append($"{weight.Weight} ");
        }

        return lineWeight.ToString();
    }

}
