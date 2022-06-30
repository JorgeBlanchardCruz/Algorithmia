namespace TestProject;

public class TestDataGenerator
{
    /* input
    4
    9 7 50
    22 7 20
    33 7 50
    22 7 30
    3
    */

    /* output
    7
    */
    public static IEnumerable<string> Log1()
    {
        yield return "4";
        yield return "9 7 50";
        yield return "22 7 20";
        yield return "33 7 50";
        yield return "22 7 30";
        yield return "3";
    }

    public static IEnumerable<string> ExpectectLog1()
    {
        yield return "7";
    }

}

public class AmazonTransactionLogsTests
{
    //[Theory]
    //[MemberData(nameof(TestDataGenerator.Log1), 3, nameof(TestDataGenerator.ExpectectLog1))]
    //public void Test1(List<string> logs, int threshold, List<string> expected)
    //{
    //    //Arrange 
    //    //Act
    //    var result = AmazonTransactionLogs.Result.processLogs(logs, threshold);

    //    //Assert
    //    Assert.Equal(expected, result);
    //}

    [Fact]    
    public void Test1()
    {
        //Arrange 
        var log = new List<string>() { 
            "4", 
            "9 7 50", 
            "22 7 20", 
            "33 7 50", 
            "22 7 30", 
            "3" 
        };
        var expected = new List<string>() { "7" };

        //Act
        var result = AmazonTransactionLogs.Result.ProcessLogs(log, Convert.ToInt32(log[log.Count() - 1]));

        //Assert
        Assert.Equal(expected, result);
    }
}