using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameTest
{
    public partial class Form1 : Form
    {
        Tool pickaxe = new Tool("Деревянная кирка", 1);
        Tool sword = new Tool("Деревянный меч", 3);

        Player player = new Player(20, 3, "Игрок", 20);

        DestructibleObject stone = new DestructibleObject("Камень", 4, 4);

        Cursor customCursor = new Cursor("C:\\Users\\Динозавр\\source\\repos\\GameTest\\GameTest\\Content\\mainCursor.cur");

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(PlayerController);
            this.Cursor = customCursor;

            PickaxeObject.Visible = false;
            SwordObject.Visible = false;
        }

        private void SetToolsMirror()
        {
            PickaxeObject.Image = Properties.Resources.PickaxeLeft;
            SwordObject.Image = Properties.Resources.SwordLeft;
        }

        private void SetToolsNoMirror()
        {
            PickaxeObject.Image = Properties.Resources.PickaxeRight;
            SwordObject.Image = Properties.Resources.SwordRight;
        }

        private void PlayerController(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode.ToString())
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
                    SetToolsPosition();
                    pickaxe.CollisionWithObject(PickaxeObject, Stone, pickaxe, stone);
                    pickaxe.CollisionWithObject(PickaxeObject, Stone2, pickaxe, stone);
                    pickaxe.CollisionWithObject(PickaxeObject, Stone3, pickaxe, stone);
                    break;
            }
            if (Player.Bounds.IntersectsWith(DungeonPortal.Bounds))
            {
                this.Hide();
                Dungeon form2 = new Dungeon();
                form2.Visible = true;
            }
        }

        public void SetToolsPosition()
        {
            if (player.IsLeft && !player.IsRight)
            {
                PickaxeObject.Location = new Point(PickaxeObject.Location.X - 40, PickaxeObject.Location.Y);
                SwordObject.Location = new Point(SwordObject.Location.X - 40, SwordObject.Location.Y);
            }
            else
            {
                PickaxeObject.Location = new Point(PickaxeObject.Location.X + 40, PickaxeObject.Location.Y);
                SwordObject.Location = new Point(SwordObject.Location.X + 40, SwordObject.Location.Y);
            }
        }

        private void PickaxeIcon_Click(object sender, EventArgs e)
        {
            if(!sword.IsActive)
            {
                pickaxe.SetActive(PickaxeObject, PickaxeValue);
            }
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            pickaxe.ToolPosition(player, Player, pickaxe, PickaxeObject);
            sword.ToolPosition(player, Player, sword, SwordObject);
            StoneCounter.Text = stone.Count.ToString();
        }

        private void CraftingTable_Click(object sender, EventArgs e)
        {
            if(CraftPanel.Visible)
            {
                CraftPanel.Visible = false;
            }
            else
            {
                CraftPanel.Visible = true;
            }
        }


        private void SwordIcon_Click(object sender, EventArgs e)
        {
            if(!pickaxe.IsActive)
            {
                sword.SetActive(SwordObject, SwordValue);
            }
        }
    }
}
