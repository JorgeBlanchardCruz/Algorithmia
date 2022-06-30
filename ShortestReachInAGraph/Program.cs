﻿global using System.Text;
using ShortestReachInAGraph;

//var graphs = new List<string>() {
//    "2",
//    "4 2",
//    "1 2",
//    "1 3",
//    "1",
//    "3 1",
//    "2 3",
//    "2"
//};

//var expected = new List<string>() { 
//    "6 6 -1 ",
//    "-1 6"
//};

class Solution
{
    static void Main(String[] args)
    {
        var graphs = new List<string>() {
            "7 4",
            "1 2",
            "1 3",
            "3 4",
            "2 5",
            "2"
        };

        var results = ProblemResolution.ProcessGraphs(graphs);
        Console.WriteLine(results);
    }
}


//class Solution
//{
//    static void Main(String[] args)
//    {
//        List<string> results = new();

//        int problemCount = int.Parse(Console.ReadLine());
//        int currentProblem = 1;
//        while (currentProblem <= problemCount)
//        {
//            List<string> problem = new();
//            string lineInput = string.Empty;
//            do
//            {
//                lineInput = Console.ReadLine();
//                problem.Add(lineInput);
//            }
//            while (lineInput != string.Empty && lineInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length == 2);

//            results.Add(ProblemResolution.ProcessGraphs(problem));
//            currentProblem++;
//        }

//        results.ForEach(Console.WriteLine);
//    }
//}