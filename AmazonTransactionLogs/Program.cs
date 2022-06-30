global using AmazonTransactionLogs;

var log = new List<string>() {
            "4",
            "9 7 50",
            "22 7 20",
            "33 7 50",
            "22 7 30",
            "3"
        };

var expected = new List<string>() { "7" };

var result = Result2.ProcessLogs(log, Convert.ToInt32(log[log.Count() - 1]));

Console.WriteLine($"expected");
expected.ForEach(Console.WriteLine);

Console.WriteLine($"{Environment.NewLine}result");
result.ForEach(Console.WriteLine);

Console.ReadKey();




var result2 = Result2.ProcessLogs(new List<string>() {
            "*896",
            "9 7 50",
            "22 7 20",
            "33 7 50",
            "22 7 30",
            "22 13 25",
            "9 22 50",
            "10 9 1",
            "3"
        }, 2);

Console.WriteLine($"{Environment.NewLine}result");
result2.ForEach(Console.WriteLine);

Console.ReadKey();