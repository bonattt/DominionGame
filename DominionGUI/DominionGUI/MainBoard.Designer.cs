namespace DominionGUI
{
    partial class MainBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBoard));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.deck = new System.Windows.Forms.Label();
            this.actionleft = new System.Windows.Forms.Label();
            this.buyleft = new System.Windows.Forms.Label();
            this.moneyleft = new System.Windows.Forms.Label();
            this.discarddeck = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 500);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 95);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1787, 874);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 32);
            this.button2.TabIndex = 16;
            this.button2.Text = "Play!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(57, 802);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1635, 817);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(127, 185);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // deck
            // 
            this.deck.AutoSize = true;
            this.deck.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.deck.Location = new System.Drawing.Point(51, 751);
            this.deck.Name = "deck";
            this.deck.Size = new System.Drawing.Size(148, 31);
            this.deck.TabIndex = 19;
            this.deck.Text = "Deck size: " + DominionCards.GameBoard.getInstance().turnOrder.Peek().getDeck().Count;
            // 
            // actionleft
            // 
            this.actionleft.AutoSize = true;
            this.actionleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.actionleft.Location = new System.Drawing.Point(303, 751);
            this.actionleft.Name = "actionleft";
            this.actionleft.Size = new System.Drawing.Size(158, 31);
            this.actionleft.TabIndex = 20;
            this.actionleft.Text = "Action Left: ";
            // 
            // buyleft
            // 
            this.buyleft.AutoSize = true;
            this.buyleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buyleft.Location = new System.Drawing.Point(681, 751);
            this.buyleft.Name = "buyleft";
            this.buyleft.Size = new System.Drawing.Size(129, 31);
            this.buyleft.TabIndex = 21;
            this.buyleft.Text = "Buy Left: ";
            // 
            // moneyleft
            // 
            this.moneyleft.AutoSize = true;
            this.moneyleft.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.moneyleft.Location = new System.Drawing.Point(1067, 751);
            this.moneyleft.Name = "moneyleft";
            this.moneyleft.Size = new System.Drawing.Size(163, 31);
            this.moneyleft.TabIndex = 22;
            this.moneyleft.Text = "Money Left: ";
            // 
            // discarddeck
            // 
            this.discarddeck.AutoSize = true;
            this.discarddeck.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.discarddeck.Location = new System.Drawing.Point(1579, 751);
            this.discarddeck.Name = "discarddeck";
            this.discarddeck.Size = new System.Drawing.Size(248, 31);
            this.discarddeck.TabIndex = 23;
            this.discarddeck.Text = "Discard Deck size: ";
            // 
            // MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1874, 1054);
            this.Controls.Add(this.discarddeck);
            this.Controls.Add(this.deck);
            this.Controls.Add(this.actionleft);
            this.Controls.Add(this.buyleft);
            this.Controls.Add(this.moneyleft);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainBoard";
            this.Text = "Dominion Game Board";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label deck;
        private System.Windows.Forms.Label actionleft;
        private System.Windows.Forms.Label buyleft;
        private System.Windows.Forms.Label moneyleft;
        private System.Windows.Forms.Label discarddeck;
      
    }
}