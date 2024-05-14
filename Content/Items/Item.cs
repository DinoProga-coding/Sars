public class Item
{
    public int Count { get; private set; }
    public const int MAX_STACK = 32;
    public string Name { get; private set; }

    public Item(string name)
    {
        Name = name;
    }

    public void UpdateCount()
    {
        if(Count < MAX_STACK)
        {
            Count++;
        }
    }
}