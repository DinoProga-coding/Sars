using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

public class Mob
{
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public string Name { get; private set; }
    public int MaxHealth { get; private set; }

    public Mob(int health, int damage, string name, int maxHealth)
    {
        Health = health;
        Damage = damage;
        Name = name;
        MaxHealth = maxHealth;
    }

    public void Movement(PictureBox mob)
    {
        if(Health > 0)
        {
            Random rand = new Random();
            int direction = rand.Next(1, 10);
            switch (direction)
            {
                case 1:
                    mob.Location = new Point(mob.Location.X + 20, mob.Location.Y + 20);
                    break;
                case 2:
                    mob.Location = new Point(mob.Location.X - 20, mob.Location.Y + 20);
                    break;
                case 3:
                    mob.Location = new Point(mob.Location.X - 20, mob.Location.Y - 20);
                    break;
                case 4:
                    mob.Location = new Point(mob.Location.X + 20, mob.Location.Y - 20);
                    break;
                case 5:
                    mob.Location = new Point(mob.Location.X + 30, mob.Location.Y - 20);
                    break;
                case 6:
                    mob.Location = new Point(mob.Location.X - 30, mob.Location.Y - 20);
                    break;
                case 7:
                    mob.Location = new Point(mob.Location.X + 15, mob.Location.Y + 20);
                    break;
                case 8:
                    mob.Location = new Point(mob.Location.X - 30, mob.Location.Y + 20);
                    break;
                case 9:
                    mob.Location = new Point(mob.Location.X + 22, mob.Location.Y - 10);
                    break;
            }
        }
    }

    public void SetHealth()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage, PictureBox obj)
    {
        if (Health > 0)
        {
            Health -= damage;
        }
        else
        {
            obj.Size = new Size(0, 0);
            obj.Location = new Point(0, 0);
        }
    }

    public void CheckWeaponCollision(PictureBox weaponObj, PictureBox enemy, Mob mob, Tool weapon)
    {
        if(weaponObj.Bounds.IntersectsWith(enemy.Bounds) && weapon.IsActive) 
        {
            mob.TakeDamage(weapon.Damage, enemy);
        }
    }

    public void SetLocation(PictureBox enemy,int x, int y)
    {
        enemy.Location = new Point(x, y);
    }

    public void SetSize(PictureBox mob, int width, int height)
    {
        mob.Size = new Size(width, height);
    }
}