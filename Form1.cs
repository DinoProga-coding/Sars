using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameTest
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        Events eventManager = new Events();
        Crafter crafter = new Crafter();

        Tool multiTool = new Tool("Деревянный мульти инструмент", 1, true);
        Tool sword = new Tool("Деревянный меч", 3, true);
        public static Tool stoneSword = new Tool("Каменный меч", 4, false);

        Recipe stoneSwordRecipe = new Recipe(stoneSword, 2, 1);

        Player player = new Player(20, 3, "Игрок", 20);

        DestructibleObject stone = new DestructibleObject("Камень", 4, 4);
        DestructibleObject tree = new DestructibleObject("Деревце", 5, 5);

        Item stoneI = new Item("Камень");
        Item woodI = new Item("Дерево");

        Cursor customCursor = new Cursor("C:\\Users\\Динозавр\\source\\repos\\GameTest\\GameTest\\Content\\mainCursor.cur");

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(PlayerController);
            this.Cursor = customCursor;

            MultiToolObject.Visible = false;
            SwordObject.Visible = false;

            LoadData();

            GenerateTree();
        }

        private void SaveData()
        {
            Properties.Settings.Default.dayCount = eventManager.DayCounter;
            Properties.Settings.Default.Save();

            Properties.Settings.Default.woodCount = woodI.Count;
            Properties.Settings.Default.Save(); 
            
            Properties.Settings.Default.stoneCount = stoneI.Count;
            Properties.Settings.Default.Save();
        }

        private void LoadData()
        {
            eventManager.SetCount(Properties.Settings.Default.dayCount);
            woodI.SetCount(Properties.Settings.Default.woodCount);
            stoneI.SetCount(Properties.Settings.Default.stoneCount);
        }

        private void SetToolsMirror()
        {
            MultiToolObject.Image = Properties.Resources.MultiToolLeft;
            SwordObject.Image = Properties.Resources.SwordLeft;
        }

        private void SetToolsNoMirror()
        {
            MultiToolObject.Image = Properties.Resources.MultiToolRight;
            SwordObject.Image = Properties.Resources.SwordRight;
        }

        private void GenerateTree()
        {
            int type = rand.Next(0,10);

            if(type >= 6)
            {
                tree1.Image = Properties.Resources.tree;
                tree2.Image = Properties.Resources.tree;
                tree3.Image = Properties.Resources.tree;
            }
            else
            {
                tree1.Image = Properties.Resources.birch;
                tree2.Image = Properties.Resources.birch;
                tree3.Image = Properties.Resources.birch;
            }
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
                    multiTool.CollisionWithObject(MultiToolObject, Stone, multiTool, stone, stoneI);
                    multiTool.CollisionWithObject(MultiToolObject, Stone2, multiTool, stone, stoneI);
                    multiTool.CollisionWithObject(MultiToolObject, Stone3, multiTool, stone, stoneI);
                    multiTool.CollisionWithObject(MultiToolObject, tree1, multiTool, tree, woodI);
                    multiTool.CollisionWithObject(MultiToolObject, tree2, multiTool, tree, woodI);
                    multiTool.CollisionWithObject(MultiToolObject, tree3, multiTool, tree, woodI);
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
                MultiToolObject.Location = new Point(MultiToolObject.Location.X - 40, MultiToolObject.Location.Y);
                SwordObject.Location = new Point(SwordObject.Location.X - 40, SwordObject.Location.Y);
            }
            else
            {
                MultiToolObject.Location = new Point(MultiToolObject.Location.X + 40, MultiToolObject.Location.Y);
                SwordObject.Location = new Point(SwordObject.Location.X + 40, SwordObject.Location.Y);
            }
        }

        private void PickaxeIcon_Click(object sender, EventArgs e)
        {
            if(!sword.IsActive)
            {
                multiTool.SetActive(MultiToolObject, MultiToolValue);
            }
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            multiTool.ToolPosition(player, Player, multiTool, MultiToolObject);
            sword.ToolPosition(player, Player, sword, SwordObject);
            StoneCounter.Text = stoneI.Count.ToString();
            WoodCounter.Text = woodI.Count.ToString();
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
            if(!multiTool.IsActive)
            {
                sword.SetActive(SwordObject, SwordValue);
            }
        }

        private void CraftStoneSword_Click(object sender, EventArgs e)
        {
            crafter.Craft(stoneSwordRecipe, stoneI, woodI);
        }

        private void DayCounter_Tick(object sender, EventArgs e)
        {
            eventManager.UpdateCounter();
            DayCounterLabel.Text = $"День: {eventManager.DayCounter}";
        }

        private void AutoSave_Tick(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
