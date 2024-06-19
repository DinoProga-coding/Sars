using System.Windows.Forms;

public class Crafter
{
    public void Craft(Recipe recipe, Item item1, Item item2)
    {
        if(!recipe.CraftableTool.IsGet)
        {
            if(item1.Count >= recipe.ItemCount && item2.Count >= recipe.Item2Count)
            {
                recipe.CraftableTool.SetIsGet(true);

                item1.ChangeCount(recipe.ItemCount);
                item2.ChangeCount(recipe.Item2Count);
            }
        }
        else
        {
            MessageBox.Show("Предмет уже сделан");
        }
    }
}