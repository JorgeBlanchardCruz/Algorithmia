using ShortestReachInAGraph;

var graphs = new List<string>() {
    "2",
    "4 2",
    "1 2",
    "1 3",
    "1",
    "3 1",
    "2 3",
    "2"
};

var expected = new List<string>() { 
    "6 6 -1 ",
    "-1 6"
};

var result = ProblemResolution.ProcessGraphs(graphs);

Console.WriteLine($"expected");
expected.ForEach(Console.WriteLine);

Console.WriteLine($"{Environment.NewLine}result");
result.ForEach(Console.WriteLine);

Console.ReadKey();






/*
 * https://www.hackerrank.com/challenges/ctci-bfs-shortest-reach/problem
 */