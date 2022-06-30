namespace CandyBars;

public class CandiesOperator
{
    public CandiesOperator() 
    {
    }

    public List<int> HandingOutCandy(List<int> candiesA, List<int> candiesB)
    {
        int diffLen = DiffLenCandiesList(candiesA, candiesB);

        if (diffLen > 0)
        {
            return ExchangeCandies(CompareCandiesDiff(candiesB, candiesA, diffLen)); ;
        }
        else if (diffLen < 0)
        {
            return CompareCandiesDiff(candiesA, candiesB, Math.Abs(diffLen));
        }

        return new List<int>() { 0, 0 };
    }

    private List<int> CompareCandiesDiff(List<int> smallerList, List<int> largerList, int diffLen)
    {
        int halfDiffLen = diffLen / 2;

        foreach (int candyOne in smallerList)
        {
            int supposedCandy = candyOne + halfDiffLen;

            foreach (int candyTwo in largerList)
            {
                if (supposedCandy == candyTwo)
                {
                    return new List<int>() { candyOne, candyTwo };
                }
            }
        }

        return new List<int>() { 0, 0 };
    }

    private List<int> ExchangeCandies(List<int> listOfTwoCandiesOnly)
    {
        if (listOfTwoCandiesOnly.Count < 2)
            throw new Exception("Return list is less than 2");

        return new List<int>() { listOfTwoCandiesOnly[1], listOfTwoCandiesOnly[0] };
    }

    private int DiffLenCandiesList(List<int> candiesA, List<int> candiesB)
    {
        int candiesALen = SumCandyLen(candiesA);
        int candiesBLen = SumCandyLen(candiesB);

        return candiesALen - candiesBLen;
    }

    public int SumCandyLen(List<int> candies)
    {
        int sum = 0;
        foreach (var candy in candies)
        {
            sum += candy;
        }

        return sum;
    }
}
