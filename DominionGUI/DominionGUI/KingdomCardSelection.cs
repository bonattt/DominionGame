﻿using System;
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
    public partial class KingdomCardSelection : Form
    {

       
        public KingdomCardSelection()
        {
            InitializeComponent();
            List<int> numList = new List<int>();
            numList.Add(1);
            numList.Add(2);
            numList.Add(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void KingdomCardSelection_Load(object sender, EventArgs e)
        {

        }


    }
}
