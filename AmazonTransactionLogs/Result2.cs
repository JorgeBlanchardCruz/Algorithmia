namespace AmazonTransactionLogs;

public class Result2
{
    private class transactionsRepeats
    {
        public string user_id;
        public int repeats;
        public transactionsRepeats(string user_id, int repeats)
        {
            this.user_id = user_id;
            this.repeats = repeats;
        }
    }

    public static List<string> ProcessLogs(List<string> logs, int threshold)
    {
        List<transactionsRepeats> repeats = ProcessTransactionsRepeats(logs);
        List<string> result = RepeatsFilteredByThreshold(repeats, threshold);
        return result;
    }

    private static List<transactionsRepeats> ProcessTransactionsRepeats(List<string> logs)
    {
        List<transactionsRepeats> repeats = new();

        foreach (var item in logs)
        {
            var logSplitted = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (logSplitted.Count() != 3)
                continue;

            string senderId = logSplitted[0];
            string recipientId = logSplitted[1];

            AddRepeat(senderId);
            AddRepeat(recipientId);
        }

        return repeats;


        void AddRepeat(string id)
        {
            var result = repeats.Find(x => x.user_id == id);
            if (result is not null)
            {
                result.repeats++;
                return;
            }

            repeats.Add(new transactionsRepeats(id, 1));
        }
    }

    private static List<string> RepeatsFilteredByThreshold(List<transactionsRepeats> repeats, int threshold)
    {
        List<string> result = new();

        var thresholders = from rp in repeats
                           where rp.repeats >= threshold
                           select rp;

        foreach (var item in thresholders.ToList())
        {
            result.Add(item.user_id.ToString());
        }

        return result;
    }

}
