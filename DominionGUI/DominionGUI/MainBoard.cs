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
    public partial class MainBoard : Form
    {

        

        public MainBoard()
        {
            InitializeComponent();
            button1.Image = DominionGUI.Properties.Resources.WorkshopHalf;
            drawCorrectImage(button1);
        }

        private void drawCorrectImage(Button button)
        {
            if (2 != 0)
            {
                button.Image = DominionGUI.Properties.Resources.WitchHalf;
            }
            {

            }
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

        
    }
}
