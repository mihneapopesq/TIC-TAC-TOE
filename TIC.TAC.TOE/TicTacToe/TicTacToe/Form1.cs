using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Board : Form
    {
        int player = 1;
        int moves = 0;

        public Board()
        {
            InitializeComponent();
        }

        private int Verificare(object sender, EventArgs e)
        {
            string playerCh;
            if (player == 1)
                playerCh = "x";
            else
                playerCh = "0";
            if ((button1.Text == playerCh && button2.Text == playerCh && button3.Text == playerCh)
                || (button4.Text == playerCh && button5.Text == playerCh && button6.Text == playerCh)
                || (button7.Text == playerCh && button8.Text == playerCh && button9.Text == playerCh)
                || (button1.Text == playerCh && button5.Text == playerCh && button9.Text == playerCh)
                || (button1.Text == playerCh && button4.Text == playerCh && button7.Text == playerCh)
                || (button2.Text == playerCh && button5.Text == playerCh && button8.Text == playerCh)
                || (button3.Text == playerCh && button6.Text == playerCh && button9.Text == playerCh)
                || (button3.Text == playerCh && button5.Text == playerCh && button7.Text == playerCh))
            {
                if (playerCh == "x")
                    return 1;
                else
                    return -1;
            }
            else
                return 0;
        }

        private void Response(int moves, object sender, EventArgs e)
        {
            int rs = Verificare(sender, e);
            if (rs == 1)
            {
                DialogResult r = MessageBox.Show("Player 1 won, would you like to play again?", "Winner", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                    newGameToolStripMenuItem_Click(sender, e);
            }
                
            else
                if (rs == -1)
                {
                    DialogResult r = MessageBox.Show("Player 2 won, would you like to play again?", "Winner", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (r == DialogResult.Yes)
                        newGameToolStripMenuItem_Click(sender, e);
                }
                else
                    if (rs == 0)
                        if (moves == 9)
                        {   DialogResult r = MessageBox.Show("Draw, would you like to play again?", "Draw", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (r == DialogResult.Yes)
                                newGameToolStripMenuItem_Click(sender, e);
                        }
                            
        }

        private void PlayerClick(object sender, EventArgs e)
        {
            moves++;
            
            Button b = (Button) sender;
            if (player == 1)
                b.Text = "x";
            else
                b.Text = "0";
            b.Enabled = false;
            Response(moves, sender, e);
            player = -player;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player = 1;
            moves = 0;
            foreach (Control b in Controls)
                if (b.GetType() == typeof(Button))
                {
                    b.Text = "";
                    b.Enabled = true;
                }

        }


        private void Board_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
                Application.Exit();
        }
    }
}
