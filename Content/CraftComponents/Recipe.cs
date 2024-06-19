public class Recipe
{
    public int ItemCount { get; private set; }
    public int Item2Count { get; private set; }

    public Tool CraftableTool;

    public Recipe(Tool craftableTool, int itemCount, int item2Count)
    {
        CraftableTool = craftableTool;
        ItemCount = itemCount;
        Item2Count = item2Count;
    }
}
