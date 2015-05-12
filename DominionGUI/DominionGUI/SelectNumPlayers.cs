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
        public DominionCards.GameBoard board;
        public static SelectNumPlayers INSTANCE;
        int discardsize = 0;
        Label discarddeck = new Label();
        CheckBox lastChecked;
        private int numberplayers = -1;
        public SelectNumPlayers()
        {
            board = new DominionCards.GameBoard(new Dictionary<DominionCards.Card, int>(), new Queue<DominionCards.Player>());
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
    

