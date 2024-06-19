public class Events
{
    public int DayCounter { get; private set; }

    public void UpdateCounter()
    {
        DayCounter++;
    }

    public void SetCount(int value)
    {
        DayCounter = value; 
    }
}
