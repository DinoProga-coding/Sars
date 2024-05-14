using System.Windows.Forms;
using System.Drawing;

public class DestructibleObject
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public string Name { get; private set; }
    public const int MAX_STACK = 51;
    public int Count { get; private set; }

    public DestructibleObject(string name, int health, int maxHealth)
    {
        Name = name;
        Health = health;
        MaxHealth = maxHealth;
    }

    public void TakeDamage(int damage, PictureBox obj)
    {
        if(Health > 0)
        {
            Health -= damage;
        }
        else
        {
            obj.Location = new Point(99999,99999);
            SetHealth();
            if(Count < 51)
            {
                Count++;
            }
        }
    }

    public void SetHealth()
    {
        Health = MaxHealth;
    }
}
