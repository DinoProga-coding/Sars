using System.Windows.Forms;
using System.Drawing;

public class DestructibleObject
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public string Name { get; private set; }

    public DestructibleObject(string name, int health, int maxHealth)
    {
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
    }

    public void TakeDamage(int damage, PictureBox obj, Item item)
    {
        if(Health > 0)
        {
            Health -= damage;
        }
        else
        {
            obj.Location = new Point(0,0);
            obj.Enabled = false;
            obj.Visible = false;
            item.UpdateCount();
            SetHealth();
        }
    }

    public void SetHealth()
    {
        Health = MaxHealth;
    }
}
