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
            string kingdomCards = "";

            if (checkBox4.Checked)
            {
                List<int> tempList = new List<int>();
                tempList.Add(5);
                tempList.Add(10);
                tempList.Add(12);
                tempList.Add(13);
                tempList.Add(1);
                tempList.Add(25);
                tempList.Add(14);
                tempList.Add(7);
                tempList.Add(21);
                tempList.Add(2);

                var myForm = new MainBoard();
                myForm.Show();

                int xValue = 95;
                int yValue = 50;


                if (tempList.Contains(1)){
                    kingdomCards = kingdomCards + "Adventurer" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Adventurer;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue = xValue + 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                    
                }

                if (tempList.Contains(2))
                {
                    kingdomCards = kingdomCards + "Bureaucrat" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Bureaucrat;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(3))
                {
                    kingdomCards = kingdomCards + "Cellar" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Cellar;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(4))
                {
                    kingdomCards = kingdomCards + "Chancellor" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Chancellor;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(5))
                {
                    kingdomCards = kingdomCards + "Chapel" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Chapel;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(6))
                {
                    kingdomCards = kingdomCards + "Council Room" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Councilroom;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(7))
                {
                    kingdomCards = kingdomCards + "Feast" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Feast;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(8))
                {
                    kingdomCards = kingdomCards + "Festival" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Festival;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(9))
                {
                    kingdomCards = kingdomCards + "Gardens" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Gardens;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(10))
                {
                    kingdomCards = kingdomCards + "Laboratory" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Laboratory;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(11))
                {
                    kingdomCards = kingdomCards + "Library" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Library;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(12))
                {
                    kingdomCards = kingdomCards + "Market" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Market;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(13))
                {
                    kingdomCards = kingdomCards + "Militia" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Militia;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(14))
                {
                    kingdomCards = kingdomCards + "Mine" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Mine;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(15))
                {
                    kingdomCards = kingdomCards + "Moat" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Moat;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(16))
                {
                    kingdomCards = kingdomCards + "Moneylender" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Moneylender;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(17))
                {
                    kingdomCards = kingdomCards + "Remodel" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Remodel;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(18))
                {
                    kingdomCards = kingdomCards + "Smithy" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Smithy;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(19))
                {
                    kingdomCards = kingdomCards + "Spy" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Spy;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(20))
                {
                    kingdomCards = kingdomCards + "Thief" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Thief;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(21))
                {
                    kingdomCards = kingdomCards + "Throne Room" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Throneroom;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(22))
                {
                    kingdomCards = kingdomCards + "Village" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Village;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(23))
                {
                    kingdomCards = kingdomCards + "Witch" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Witch;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(24))
                {
                    kingdomCards = kingdomCards + "Woodcutter" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Woodcutter;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

                if (tempList.Contains(25))
                {
                    kingdomCards = kingdomCards + "Workshop" + "\n";
                    PictureBox newPicture = new PictureBox();
                    newPicture.Image = DominionGUI.Properties.Resources.Workshop;
                    newPicture.Height = 122;
                    newPicture.Width = 75;
                    newPicture.Location = new Point(xValue, yValue);
                    xValue += 90;
                    newPicture.Parent = myForm;
                    myForm.Update();
                }

            }

        }
    }
}
