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

    public static List<string> ProcessGraphs(List<string> problem)
    {
        var graphs = FillGraphs(problem);

        var graphWeights = GetWeights(graphs);

        var result = BuildResult(graphWeights);

        return result;
    }

    private static List<Graph> FillGraphs(List<string> problem)
    {
        List<Graph> graphs = new() { new Graph() };

        int problemsCount = Convert.ToInt32(problem[0]);
        problem.RemoveAt(0);

        foreach (var item in problem)
        {
            var edge = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (edge.Length == 1)
            {
                graphs[GetCurrentGraph()].NodeStart = edge[0];
                graphs.Add(new Graph());
                continue;
            }

            graphs[GetCurrentGraph()].Edges.Add(new Edge(edge[0], edge[1]));
        }

        graphs.RemoveAt(GetCurrentGraph());

        if (problemsCount != graphs.Count())
            throw new Exception("The number of problems do not match");

        return graphs;


        int GetCurrentGraph()
        {
            return graphs.Count - 1;
        }
    }    

    private static List<List<GraphWeight>> GetWeights(List<Graph> graphs)
    {
        List<List<GraphWeight>> graphsWeights = new();
        foreach (var graph in graphs)
        {
            graphsWeights.Add(new List<GraphWeight>());

            Edge prevEdge = graph.Edges[0];
            int lenMultiplier = 1;
            foreach (var edge in graph.Edges)
            {
                if (edge.nodeA == graph.NodeStart)
                {
                    graphsWeights[GetCurrentGraph()].Add(new GraphWeight(edge.nodeB, EdgeLen));
                    prevEdge = edge;
                    lenMultiplier = 1;

                    continue;
                }

                if (edge.nodeA == prevEdge.nodeB)
                {
                    lenMultiplier++;
                    graphsWeights[GetCurrentGraph()].Add(new GraphWeight(edge.nodeB, EdgeLen * lenMultiplier));
                    prevEdge = edge;
                    
                    continue;
                }

                lenMultiplier = 1;

                if (graph.Edges.Exists(x => x.nodeB == edge.nodeA))
                {
                    graphsWeights[GetCurrentGraph()].Add(new GraphWeight(edge.nodeB, -1));
                    continue;
                }
                
                graphsWeights[GetCurrentGraph()].Add(new GraphWeight(edge.nodeA, -1));
            }
        }

        return graphsWeights;


        int GetCurrentGraph()
        {
            return graphsWeights.Count - 1;
        }
    }

    private static List<string> BuildResult(List<List<GraphWeight>> weights)
    {
        List<string> result = new();
        foreach (var graphWeights in weights)
        {
            var shortedWeights = from w in graphWeights
                                 orderby w.Node
                                 select w;

            StringBuilder lineWeight = new();
            foreach (var weight in shortedWeights)
            {
                lineWeight.Append($"{weight.Weight} ");
            }


            result.Add(lineWeight.ToString());
        }

        return result;
    }

}
