using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DominionCards
{
    public partial class SelectCardsForm : Form
    {
        public void GetSelection()
        {
            ShowDialog();
            while (this.Visible)
            {
                Thread.Sleep(10);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SelectAndMutate(object sender, EventArgs e)
        {
            cardsToList.Clear();
            for (int i = 0; i < checkboxes.Count; i++)
            {
                if (checkboxes[i].Checked)
                {
                    cardsToList.Add(checkboxes[i].card);
                }
            }

            Console.WriteLine("Action handler called.");
            Visible = false;
            Close();
        }

        /*public ArrayList SelectFrom()
        {
            ArrayList list = new ArrayList();

            return list;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


                Close();
        }
         */
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
