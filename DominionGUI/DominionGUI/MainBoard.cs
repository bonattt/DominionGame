using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace DominionGUI
{
    public partial class MainBoard : Form
    {
        private static MainBoard instance;
        public DominionCards.GameBoard board;
        private System.Drawing.Bitmap[] imageadd;
        private System.Type[] cardsadd;
        private int discardsize = 0;
        public MainBoard()
        {
            InitializeComponent();
            button1.Image = DominionGUI.Properties.Resources.WorkshopHalf;
            drawCorrectImage(button1);
            board = DominionCards.GameBoard.getInstance();
            imageadd = new System.Drawing.Bitmap[] { DominionGUI.Properties.Resources.WorkshopHalf, DominionGUI.Properties.Resources.AdventurerHalfNew, DominionGUI.Properties.Resources.BureaucratHalf, DominionGUI.Properties.Resources.CellarHalf, DominionGUI.Properties.Resources.ChancellorHalf, DominionGUI.Properties.Resources.ChapelHalf, DominionGUI.Properties.Resources.CouncilroomHalf, DominionGUI.Properties.Resources.FeastHalf, DominionGUI.Properties.Resources.FestivalHalf, DominionGUI.Properties.Resources.GardensHalf, DominionGUI.Properties.Resources.LaboratoryHalf, DominionGUI.Properties.Resources.LibraryHalf, DominionGUI.Properties.Resources.MarketHalf, DominionGUI.Properties.Resources.MilitiaHalf, DominionGUI.Properties.Resources.MineHalf, DominionGUI.Properties.Resources.MoatHalf, DominionGUI.Properties.Resources.MoneylenderHalf, DominionGUI.Properties.Resources.RemodelHalf, DominionGUI.Properties.Resources.SmithyHalf, DominionGUI.Properties.Resources.SpyHalf, DominionGUI.Properties.Resources.ThiefHalf, DominionGUI.Properties.Resources.ThroneroomHalf, DominionGUI.Properties.Resources.VillageHalf, DominionGUI.Properties.Resources.WitchHalf, DominionGUI.Properties.Resources.WoodcutterHalf };
            cardsadd = new System.Type[] { typeof(DominionCards.KingdomCards.Workshop),typeof(DominionCards.KingdomCards.Adventurer),typeof(DominionCards.KingdomCards.Bureaucrat),typeof(DominionCards.KingdomCards.Cellar),typeof(DominionCards.KingdomCards.Chancellor),typeof(DominionCards.KingdomCards.Chapel),typeof(DominionCards.KingdomCards.CouncilRoom),typeof(DominionCards.KingdomCards.Feast),typeof(DominionCards.KingdomCards.Festival),typeof(DominionCards.KingdomCards.Gardens),typeof(DominionCards.KingdomCards.Laboratory),typeof(DominionCards.KingdomCards.Library),typeof(DominionCards.KingdomCards.Market),typeof(DominionCards.KingdomCards.Militia),typeof(DominionCards.KingdomCards.Mine),typeof(DominionCards.KingdomCards.Moat),typeof(DominionCards.KingdomCards.MoneyLender),typeof(DominionCards.KingdomCards.Remodel),typeof(DominionCards.KingdomCards.Smithy),typeof(DominionCards.KingdomCards.Spy),typeof(DominionCards.KingdomCards.Thief),typeof(DominionCards.KingdomCards.ThroneRoom),typeof(DominionCards.KingdomCards.Village),typeof(DominionCards.KingdomCards.Witch),typeof(DominionCards.KingdomCards.Woodcutter)};
            //addRandomtencards();
            /*discarddeck.Location = new Point(98, 769);
            discarddeck.Width = 20;
            discarddeck.Height = 10;
            discarddeck.Text = "Discard Cards Size: " + discardsize;
            discarddeck.Visible = true;*/
        }
        /*public void addRandomtencards()
        {
            List<int> numList = new List<int>();
            numList = RandomGenerateCards.GenerateRandom.GenerateRandomList(25, 10);
            int xValue = 220;
            int yValue = 400;
            for (int i = 0; i < 25; i++)
            {
                if (numList.Contains(i))
                {
                    CardButon newButton = new CardButon((DominionCards.Card)Activator.CreateInstance(cardsadd[i]));
                    newButton.Image = imageadd[i];
                    board.addCard((DominionCards.Card)Activator.CreateInstance(cardsadd[i]));
                    newButton.Click += new EventHandler(this.gameplay);
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue = xValue + 256;
                    newButton.Parent = instance;
                    instance.Update();
                    instance.Show();
                }
            }
        }*/
        public void determine()
        {
            List<int> numList = new List<int>();
            numList = RandomGenerateCards.GenerateRandom.GenerateRandomList(25, 5);
            int xValue = 220;
            int yValue = 800;
            for (int i = 0; i < 25; i++)
            {
                if (numList.Contains(i))
                {
                    CardButon newButton = new CardButon((DominionCards.Card)Activator.CreateInstance(cardsadd[i]));
                    newButton.Image = imageadd[i];
                    board.addCard((DominionCards.Card)Activator.CreateInstance(cardsadd[i]));
                    newButton.Click += new EventHandler(this.gameplay);
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue = xValue + 256;
                    newButton.Parent = instance;
                    instance.Update();
                    instance.Show();
                }
            }                
        }
        private void gameplay(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            /*discardsize = discardsize + 1;
            discarddeck.Text = "Discard Cards Size: " + discardsize;*/
            clickedButton.Visible = true;
        }

        public static MainBoard getinstance()
        {
            if (instance == null)
                instance = new MainBoard();
            return instance;
        }

        private void drawCorrectImage(Button button)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void MainBoard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
