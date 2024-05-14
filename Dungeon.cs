using System.Drawing;
using System.Windows.Forms;

namespace GameTest
{
    public partial class Dungeon : Form
    {
        Cursor customCursor = new Cursor("C:\\Users\\Динозавр\\source\\repos\\GameTest\\GameTest\\Content\\mainCursor.cur");

        Player player = new Player(20, 4, "Игрок", 20);
        Mob mob = new Mob(10, 2, "Кровавый зомби", 10);
        Mob mob2 = new Mob(10, 2, "Кровавый зомби", 10);
        Mob mob3 = new Mob(10, 2, "Кровавый зомби", 10);
        Mob mob4 = new Mob(10, 2, "Кровавый зомби", 10);
        Mob mob5 = new Mob(10, 2, "Кровавый зомби", 10);
        Mob mob6 = new Mob(20, 5, "Лиственный мутант", 20);

        Item magicPowder = new Item("Магическая пыль");
        Item poisonOrb = new Item("Ядовитый шар");
        Item slime = new Item("Слизь");

        Tool sword = new Tool("Деревянный меч", 3);

        Chest chest = new Chest();

        PictureBox Enemy4 = new PictureBox();
        PictureBox Enemy5 = new PictureBox();
        PictureBox Enemy6 = new PictureBox();

        public Dungeon()
        {
            InitializeComponent();
            SwordObject.Visible = false;
            this.KeyDown += new KeyEventHandler(PlayerController);
            this.Cursor = customCursor;
        }

        private void SetTextures()
        {
            Enemy4.Image = Properties.Resources.Enemy;
            Enemy5.Image = Properties.Resources.Enemy;
            Enemy6.Image = Properties.Resources.Enemy2;
        }

        private void PlayerCollision()
        {
            if (Player.Bounds.IntersectsWith(Enemy.Bounds))
            {
                player.TakeDamage(mob.Damage, Player);
            }
            if (Player.Bounds.IntersectsWith(Enemy2.Bounds))
            {
                player.TakeDamage(mob2.Damage, Player);
            }
            if (Player.Bounds.IntersectsWith(Enemy3.Bounds))
            {
                player.TakeDamage(mob3.Damage, Player);
            }    
            if (Player.Bounds.IntersectsWith(Enemy4.Bounds))
            {
                player.TakeDamage(mob4.Damage, Player);
            }
            if (Player.Bounds.IntersectsWith(Enemy5.Bounds))
            {
                player.TakeDamage(mob5.Damage, Player);
            }
            if (Player.Bounds.IntersectsWith(Enemy6.Bounds))
            {
                player.TakeDamage(mob6.Damage, Player);
            }
        }

        private void PlayerController(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "W":
                    Player.Location = new Point(Player.Location.X, Player.Location.Y - 10);
                    break;
                case "A":
                    Player.Location = new Point(Player.Location.X - 10, Player.Location.Y);
                    SetToolsMirror();
                    player.SetIsLeft(true);
                    player.SetIsRight(false);
                    break;
                case "S":
                    Player.Location = new Point(Player.Location.X, Player.Location.Y + 10);
                    break;
                case "D":
                    Player.Location = new Point(Player.Location.X + 10, Player.Location.Y);
                    SetToolsNoMirror();
                    player.SetIsLeft(false);
                    player.SetIsRight(true);
                    break;
                case "Space":
                    SetSwordPosition();
                    mob.CheckWeaponCollision(SwordObject, Enemy, mob, sword);
                    mob2.CheckWeaponCollision(SwordObject, Enemy2, mob2, sword);
                    mob3.CheckWeaponCollision(SwordObject, Enemy3, mob3, sword);
                    mob4.CheckWeaponCollision(SwordObject, Enemy4, mob4, sword);
                    mob5.CheckWeaponCollision(SwordObject, Enemy5, mob5, sword);
                    mob6.CheckWeaponCollision(SwordObject, Enemy6, mob6, sword);
                    break;
            }
        }

        private void SetToolsMirror()
        {
            SwordObject.Image = Properties.Resources.SwordLeft;
        }

        private void SetToolsNoMirror()
        {
            SwordObject.Image = Properties.Resources.SwordRight;
        }

        public void SetSwordPosition()
        {
            if (player.IsLeft && !player.IsRight)
            {
                SwordObject.Location = new Point(SwordObject.Location.X - 40, SwordObject.Location.Y);
            }
            else
            {
                SwordObject.Location = new Point(SwordObject.Location.X + 40, SwordObject.Location.Y);
            }
        }

        private void SwordIcon_Click(object sender, System.EventArgs e)
        {
            sword.SetActive(SwordObject, SwordValue);
        }

        private void Update_Tick(object sender, System.EventArgs e)
        {
            sword.ToolPosition(player, Player, sword, SwordObject);
            PlayerHealth.Text = $"Здоровье: {player.Health}";

            PlayerCollision();

            Item1Counter.Text = magicPowder.Count.ToString();
            Item2Counter.Text = poisonOrb.Count.ToString();
            Item3Counter.Text = slime.Count.ToString();
        }

        private void mobTimer_Tick(object sender, System.EventArgs e)
        {
            mob.Movement(Enemy);
        }

        private void Chest_Click(object sender, System.EventArgs e)
        {
            chest.CreatePool(magicPowder, poisonOrb, slime);
            chest.OpenChest(magicPowder, poisonOrb, slime, magicPowderObj, poisonOrbObj, SlimeObj, Chest);
            chestVisibleTimer.Enabled = true;
        }
        int time = 0;
        private void chestVisibleTimer_Tick(object sender, System.EventArgs e)
        {
            time++;
            if(time >= 100)
            {
                Chest.Visible = false;
                magicPowderObj.Visible = false;
                SlimeObj.Visible = false;
                poisonOrbObj.Visible = false;
                chestVisibleTimer.Enabled = false;
            }
        }

        private void mob2Timer_Tick(object sender, System.EventArgs e)
        {
            mob2.Movement(Enemy2);
        }

        private void mob3Timer_Tick(object sender, System.EventArgs e)
        {
            mob3.Movement(Enemy3);
        }

        private void mob4Timer_Tick(object sender, System.EventArgs e)
        {
            mob4.Movement(Enemy4);
        }

        private void mob5Timer_Tick(object sender, System.EventArgs e)
        {
            mob5.Movement(Enemy5);
        }

        private void mob6Timer_Tick(object sender, System.EventArgs e)
        {
            mob6.Movement(Enemy6);
        }

        private void SpawnEnemyTimer_Tick(object sender, System.EventArgs e)
        {
            SetTextures();

            Controls.Add(Enemy4);
            mob4.SetLocation(Enemy4 ,340, 500);
            mob4.SetSize(Enemy4, 51, 72);
            Controls.Add(Enemy5);
            mob5.SetLocation(Enemy5, 140, 800);
            mob5.SetSize(Enemy5, 51, 72);
            Controls.Add(Enemy6);
            mob6.SetLocation(Enemy6, 700, 200);
            mob6.SetSize(Enemy6, 51, 72);

            Enemy4.SendToBack();
            Enemy5.SendToBack();
            Enemy6.SendToBack();

            SpawnEnemyTimer.Enabled = false;
        }
    }
}
