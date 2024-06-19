using System.Drawing;
using System.Windows.Forms;

public class Tool 
{
    public bool IsActive { get; private set; }
    public bool IsGet { get; private set; }
    public int Damage { get; private set; }
    public string Name { get; private set; }

    public Tool(string name, int damage, bool isGet)
    {
        Name = name;
        Damage = damage;
        IsGet = isGet;
    }

    public void SetActive(bool value)
    {
        IsActive = value;
    }

    public void SetIsGet(bool value)
    {
        IsGet = value;
    }

    public void SetToolLocation(PictureBox tool, PictureBox player)
    {
        tool.Location = new Point(player.Location.X + 52, player.Location.Y + 13);
    }

    public void SetToolMirroredLocation(PictureBox tool, PictureBox player)
    {
        tool.Location = new Point(player.Location.X - 52, player.Location.Y + 13);
    }

    public void ToolPosition(Player player, PictureBox Player, Tool tool, PictureBox toolObj)
    {
        if (!player.IsLeft && !player.IsRight)
        {
            tool.SetToolLocation(toolObj, Player);
        }
        else if (player.IsRight)
        {
            tool.SetToolLocation(toolObj, Player);
        }
        else if (player.IsLeft)
        {
            tool.SetToolMirroredLocation(toolObj, Player);
        }
    }

    public void CollisionWithObject(PictureBox toolObj, PictureBox obj, Tool tool, DestructibleObject destructibleObject, Item item)
    {
        if (toolObj.Bounds.IntersectsWith(obj.Bounds) && tool.IsActive)
        {
            destructibleObject.TakeDamage(tool.Damage, obj, item);
        }
    }

    public void SetActive(PictureBox tool, PictureBox value)
    {
        if (IsActive)
        {
            value.BackColor = Color.Red;
            tool.Visible = false;
            IsActive = false;
        }
        else
        {
            value.BackColor = Color.Green;
            tool.Visible = true;
            IsActive = true;
        }
    }
}
