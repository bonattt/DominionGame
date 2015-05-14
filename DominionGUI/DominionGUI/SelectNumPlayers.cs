using System;
using System.Collections.Generic;
using System.Collections;
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
        private static System.Drawing.Bitmap[] imageadd = new System.Drawing.Bitmap[] { DominionGUI.Properties.Resources.WorkshopHalf, DominionGUI.Properties.Resources.AdventurerHalfNew, DominionGUI.Properties.Resources.BureaucratHalf, DominionGUI.Properties.Resources.CellarHalf, DominionGUI.Properties.Resources.ChancellorHalf, DominionGUI.Properties.Resources.ChapelHalf, DominionGUI.Properties.Resources.CouncilroomHalf, DominionGUI.Properties.Resources.FeastHalf, DominionGUI.Properties.Resources.FestivalHalf, DominionGUI.Properties.Resources.GardensHalf, DominionGUI.Properties.Resources.LaboratoryHalf, DominionGUI.Properties.Resources.LibraryHalf, DominionGUI.Properties.Resources.MarketHalf, DominionGUI.Properties.Resources.MilitiaHalf, DominionGUI.Properties.Resources.MineHalf, DominionGUI.Properties.Resources.MoatHalf, DominionGUI.Properties.Resources.MoneylenderHalf, DominionGUI.Properties.Resources.RemodelHalf, DominionGUI.Properties.Resources.SmithyHalf, DominionGUI.Properties.Resources.SpyHalf, DominionGUI.Properties.Resources.ThiefHalf, DominionGUI.Properties.Resources.ThroneroomHalf, DominionGUI.Properties.Resources.VillageHalf, DominionGUI.Properties.Resources.WitchHalf, DominionGUI.Properties.Resources.WoodcutterHalf };
        private static System.Type[] cardsadd = new System.Type[] { typeof(DominionCards.KingdomCards.Workshop),typeof(DominionCards.KingdomCards.Adventurer),typeof(DominionCards.KingdomCards.Bureaucrat),typeof(DominionCards.KingdomCards.Cellar),typeof(DominionCards.KingdomCards.Chancellor),typeof(DominionCards.KingdomCards.Chapel),typeof(DominionCards.KingdomCards.CouncilRoom),typeof(DominionCards.KingdomCards.Feast),typeof(DominionCards.KingdomCards.Festival),typeof(DominionCards.KingdomCards.Gardens),typeof(DominionCards.KingdomCards.Laboratory),typeof(DominionCards.KingdomCards.Library),typeof(DominionCards.KingdomCards.Market),typeof(DominionCards.KingdomCards.Militia),typeof(DominionCards.KingdomCards.Mine),typeof(DominionCards.KingdomCards.Moat),typeof(DominionCards.KingdomCards.MoneyLender),typeof(DominionCards.KingdomCards.Remodel),typeof(DominionCards.KingdomCards.Smithy),typeof(DominionCards.KingdomCards.Spy),typeof(DominionCards.KingdomCards.Thief),typeof(DominionCards.KingdomCards.ThroneRoom),typeof(DominionCards.KingdomCards.Village),typeof(DominionCards.KingdomCards.Witch),typeof(DominionCards.KingdomCards.Woodcutter)};
        private static System.Type[] basiccard = new System.Type[] { typeof(DominionCards.KingdomCards.Gold), typeof(DominionCards.KingdomCards.Silver), typeof(DominionCards.KingdomCards.Copper) ,typeof(DominionCards.KingdomCards.Province),typeof(DominionCards.KingdomCards.Duchy),typeof(DominionCards.KingdomCards.Estate),typeof(DominionCards.KingdomCards.Curse)};
            
        public DominionCards.GameBoard board;
        public static SelectNumPlayers INSTANCE;
        Label discarddeck = new Label();
        CheckBox lastChecked;
        private int numberplayers = -1;
        public SelectNumPlayers()
        {
            
            board = new DominionCards.GameBoard(CreateRandomCardDictionary());
            INSTANCE = this;
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

        private void Playeroption(object sender, EventArgs e)
        {
            string movies = "";
            
            if (checkBox1.Checked)
            {
                movies = movies + checkBox1.Text;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                lastChecked = checkBox1;
                numberplayers = 2;
            }
            else if (checkBox2.Checked)
            {
                movies = movies + checkBox2.Text;
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                lastChecked = checkBox2;
                numberplayers = 3;
            }
            else if (checkBox3.Checked)
            {
                movies = movies + checkBox3.Text;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                lastChecked = checkBox3;
                numberplayers = 4;
            }
            if(!lastChecked.Equals(null))
                if (lastChecked.Equals(checkBox1) && !checkBox1.Checked)
                {
                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                }
                if (lastChecked.Equals(checkBox2) && !checkBox2.Checked)
                {
                    checkBox1.Enabled = true;
                    checkBox3.Enabled = true;
                }
                if (lastChecked.Equals(checkBox3) && !checkBox3.Checked)
                {
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                }
            if(movies.Length>0)
                MessageBox.Show(movies);
        }
        public void createplayers(int numberplayer)
        {
            for (int i = 0; i < numberplayer; i++)
            {
                this.board.AddPlayer(new DominionCards.HumanPlayer(i + 1));
            }
        }

        public DominionCards.GameBoard getboard()
        {
            return this.board;
        }
        private void CardSelectOption(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                createplayers(numberplayers);
                var myForm = MainBoard.getinstance();
                myForm.determine();
                myForm.Update();
                myForm.Show();
            }
            else if (checkBox5.Checked)
            {
                var myFrom = new KingdomCardSelection();
                myFrom.Update();
                myFrom.Show();
                
            }
            else if (checkBox6.Checked)
            {
                var myFrom = new KingdomCardSelection();
                myFrom.Update();
                myFrom.Show();
            }
        }
        private void gameplay(Object sender, EventArgs e)
        {
            /*Button clickedButton = (Button)sender;
            discardsize = discardsize + 1;
            discarddeck.Text = "Discard Cards Size: " + discardsize;
            clickedButton.Visible = false;   */       
        }
        private Dictionary<DominionCards.Card, int> CreateRandomCardDictionary()
        {
            Dictionary<DominionCards.Card, int> dict = new Dictionary<DominionCards.Card, int>();
            List<int> numList = new List<int>();
            dict.Add(new DominionCards.KingdomCards.Copper(), 100);
            dict.Add(new DominionCards.KingdomCards.Silver(), 50);
            dict.Add(new DominionCards.KingdomCards.Gold(), 30);
            dict.Add(new DominionCards.KingdomCards.Estate(), 30);
            dict.Add(new DominionCards.KingdomCards.Duchy(), 15);
            dict.Add(new DominionCards.KingdomCards.Province(), 10);
            dict.Add(new DominionCards.KingdomCards.Curse(), 30);


            numList = RandomGenerateCards.GenerateRandom.GenerateRandomList(25, 10);
            for (int i = 0; i < 25; i++)
            {
                if (numList.Contains(i))
                {
                    DominionCards.Card card = (DominionCards.Card)Activator.CreateInstance(cardsadd[i]);
                    dict.Add(card, 10);
                }
            }
            return dict;
        }
        public void addRandomCards()
        {
                var myForm = MainBoard.getinstance();
                myForm.determine();
                //DominionGUI.MainBoard.
                /*
                List<int> numList = new List<int>();
                numList = RandomGenerateCards.GenerateRandom.GenerateRandomList(25,5);
                numList.Add(24);
                
              
                int xValue = 95;
                int yValue = 50;

               
                
                discarddeck.Location = new Point(500, 650);
                discarddeck.Width = 1000;
                discarddeck.Parent = myForm;
                myForm.Update();
                myForm.Show();
                    
                Label countCard1Remaining = new Label();
                countCard1Remaining.Text = "Cards Remaining: " + board.getCardsLeft(woodcutter);
                countCard1Remaining.Location = new Point(500, 500);
                countCard1Remaining.Width = 1000;
                countCard1Remaining.Parent = myForm;
                myForm.Update();
                myForm.Show();
                */
                
         } 
    }
            

}
    

