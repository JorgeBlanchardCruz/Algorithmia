global using System.Text;
using ShortestReachInAGraph;

//ESTO ES PARA PROBAR RÁPIDO
class Solution
{
    static void Main(String[] args)
    {
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

        var graphs = new List<string>() {
            "7 4",
            "1 2",
            "1 3",
            "3 4",
            "2 5",
            "2"
        }; //out 6 12 18 6 -1 -1

        //var graphs = new List<string>() {
        //    "6 4",
        //    "1 2",
        //    "2 3",
        //    "3 4",
        //    "1 5",
        //    "1"
        //}; //out 6 12 18 6 -1

        var results = ProblemResolution.ProcessGraph(graphs);
        Console.WriteLine(results);
        Console.ReadKey();
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