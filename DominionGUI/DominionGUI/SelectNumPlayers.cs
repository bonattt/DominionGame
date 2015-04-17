using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominionGUI
{
    public partial class SelectNumPlayers : Form
    {
        public DominionCards.GameBoard board;
        public SelectNumPlayers()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectNumPlayers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string movies = "";

            if (checkBox1.Checked)
            {

                movies = movies + checkBox1.Text;

            }

            MessageBox.Show(movies);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            addRandomCards();

        }
        public void addRandomCards(){
            string kingdomCards = "";

            if (checkBox4.Checked)
            {

                var myForm = new MainBoard(); 
                

                List<int> numList = new List<int>();
                numList = RandomGenerateCards.GenerateRandom.GenerateRandomList();
                numList.Add(24);
                
              
                int xValue = 95;
                int yValue = 50;

                board = new DominionCards.GameBoard(new Dictionary<DominionCards.Card, int>(),
                    new Queue<DominionCards.Player>());


                if (numList.Contains(0))
                {
                    kingdomCards = kingdomCards + "Workshop" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.WorkshopHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue = xValue + 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Workshop());
                }



                if (numList.Contains(1)){
                    kingdomCards = kingdomCards + "Adventurer" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.AdventurerHalfNew;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue = xValue + 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Adventurer());
                }

                if (numList.Contains(2))
                {
                    kingdomCards = kingdomCards + "Bureaucrat" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.BureaucratHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Bureaucrat());
                }

                if (numList.Contains(3))
                {
                    kingdomCards = kingdomCards + "Cellar" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.CellarHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Cellar());
                }

                if (numList.Contains(4))
                {
                    kingdomCards = kingdomCards + "Chancellor" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.ChancellorHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Chancellor());
                }

                if (numList.Contains(5))
                {
                    kingdomCards = kingdomCards + "Chapel" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.ChapelHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Chapel());
                }

                if (numList.Contains(6))
                {
                    kingdomCards = kingdomCards + "Council Room" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.CouncilroomHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.CouncilRoom());
                }

                if (numList.Contains(7))
                {
                    kingdomCards = kingdomCards + "Feast" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.FeastHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Feast());
                }

                if (numList.Contains(8))
                {
                    kingdomCards = kingdomCards + "Festival" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.FestivalHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Festival());
                }

                if (numList.Contains(9))
                {
                    kingdomCards = kingdomCards + "Gardens" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.GardensHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Gardens());
                }

                if (numList.Contains(10))
                {
                    kingdomCards = kingdomCards + "Laboratory" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.LaboratoryHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Laboratory());
                }

                if (numList.Contains(11))
                {
                    kingdomCards = kingdomCards + "Library" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.LibraryHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Library());
                }

                if (numList.Contains(12))
                {
                    kingdomCards = kingdomCards + "Market" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.MarketHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Market());
                }

                if (numList.Contains(13))
                {
                    kingdomCards = kingdomCards + "Militia" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.MilitiaHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Militia());
                }

                if (numList.Contains(14))
                {
                    kingdomCards = kingdomCards + "Mine" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.MineHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Mine());
                }

                if (numList.Contains(15))
                {
                    kingdomCards = kingdomCards + "Moat" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.MoatHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Moat());
                }

                if (numList.Contains(16))
                {
                    kingdomCards = kingdomCards + "Moneylender" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.MoneylenderHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.MoneyLender());
                }

                if (numList.Contains(17))
                {
                    kingdomCards = kingdomCards + "Remodel" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.RemodelHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Remodel());
                }

                if (numList.Contains(18))
                {
                    kingdomCards = kingdomCards + "Smithy" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.SmithyHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Smithy());
                }

                if (numList.Contains(19))
                {
                    kingdomCards = kingdomCards + "Spy" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.SpyHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Spy());
                }

                if (numList.Contains(20))
                {
                    kingdomCards = kingdomCards + "Thief" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.ThiefHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Thief());
                }

                if (numList.Contains(21))
                {
                    kingdomCards = kingdomCards + "Throne Room" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.ThroneroomHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.ThroneRoom());
                }

                if (numList.Contains(22))
                {
                    kingdomCards = kingdomCards + "Village" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.VillageHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Village());
                }

                if (numList.Contains(23))
                {
                    kingdomCards = kingdomCards + "Witch" + "\n";
                    Button newButton = new Button();
                    newButton.Image = DominionGUI.Properties.Resources.WitchHalf;
                    newButton.Height = 179;
                    newButton.Width = 256;
                    newButton.Location = new Point(xValue, yValue);
                    xValue += 256;
                    newButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(new DominionCards.KingdomCards.Witch());
                }

                DominionCards.KingdomCards.Woodcutter woodcutter = new DominionCards.KingdomCards.Woodcutter();
                Button WoodcutterButton = new Button();
                if (numList.Contains(24))
                {
                    kingdomCards = kingdomCards + "Woodcutter" + "\n";
                    
                    WoodcutterButton.Image = DominionGUI.Properties.Resources.WoodcutterHalf;
                    WoodcutterButton.Height = 179;
                    WoodcutterButton.Width = 256;
                    WoodcutterButton.Location = new Point(700, 700);
                    xValue += 256;
                    WoodcutterButton.Parent = myForm;
                    myForm.Update();
                    board.addCard(woodcutter);
                }
                    
                Label countCard1Remaining = new Label();
                countCard1Remaining.Text = "Cards Remaining: " + board.getCardsLeft(woodcutter);
                countCard1Remaining.Location = new Point(500, 500);
                countCard1Remaining.Width = 1000;
                countCard1Remaining.Parent = myForm;
                myForm.Update();
                myForm.Show();
            } }
            


               
            }

        }
    

