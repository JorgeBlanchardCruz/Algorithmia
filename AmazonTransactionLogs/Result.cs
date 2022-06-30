namespace AmazonTransactionLogs;

public class Result
{
    private record log(string sender_user_id, string recipient_user_id);
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
        List<log> recordLogs = ConvertLogStringToRecord(logs);

        List<transactionsRepeats> repeats = ProcessTransactionsRepeats(recordLogs);

        List<string> result = RepeatsFilteredByThreshold(repeats, threshold);

        return result;
    }

    private static List<log> ConvertLogStringToRecord(List<string> logs)
    {
        List<log> result = new();

        foreach (var itemlog in logs)
        {
            log? newlog = ConvertToLogRecord(itemlog);
            if (newlog is not null)
                result.Add(newlog);
        }

        return result;
    }

    private static log? ConvertToLogRecord(string log)
    {
        var splited = log.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (splited.Count() != 3)
            return null;

        return new log(splited[0],
                       splited[1]);
    }

    private static List<transactionsRepeats> ProcessTransactionsRepeats(List<log> recordLogs)
    {
        List<transactionsRepeats> repeats = new();

        var recordFiltered = from lo in recordLogs
                             select lo;

        foreach (log log in recordFiltered)
        {
            AddRepeat(log.sender_user_id);
            AddRepeat(log.recipient_user_id);
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
