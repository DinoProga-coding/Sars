using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class Chest
{
    Dictionary<string, string> ItemPool = new Dictionary<string, string>();
    public void CreatePool(Item item1, Item item2, Item item3)
    {
        ItemPool.Add(item1.Name, item1.Name);
        ItemPool.Add(item2.Name, item2.Name);
        ItemPool.Add(item3.Name, item3.Name);
    }

    public void OpenChest(Item item1, Item item2, Item item3, PictureBox item1obj, PictureBox item2obj, PictureBox item3obj, PictureBox chest)
    {
        Random rand = new Random();
        int loot;
        foreach(var el in ItemPool)
        {
            loot = rand.Next(0, 3);
            switch(loot)
            {
                case 0:
                    item1.UpdateCount();
                    item1obj.Visible = true;
                    break;
                case 1:
                    loot = rand.Next(0, 3);
                    if(loot == 1)
                    {
                        item1.UpdateCount();
                        item1obj.Visible = true;
                    }
                    else
                    {
                        item3.UpdateCount();
                        item3obj.Visible = true;
                    }
                    break;
                case 2:
                    item2.UpdateCount();
                    item2obj.Visible = true;
                    break;
                case 3:
                    item2.UpdateCount();
                    item2obj.Visible = true;
                    break;
            }
        }
        chest.Enabled = false;
    }
}
