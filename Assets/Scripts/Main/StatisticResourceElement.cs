public class StatisticResourceElement
{
    public string message;
    public bool vector;
    public int count;
 
    public StatisticResourceElement(string message, int count, bool vector = true)
    {
        this.message = message;
        this.vector = vector;
        this.count = count;
    }
}