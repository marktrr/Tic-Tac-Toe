/* Form1.cs 
 * Assignment 3  
 * Full Name: Hy Minh Tran 
 * Student #: 7910276 
 * Date created: 11/15/2018 
 * Finished: 10:45 PM 11/15/2018.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTranAssignment3
{
    public partial class myForm : Form
    {
        public myForm()
        {
            InitializeComponent();       
        }

        PictureBox[] myList = new PictureBox[9]; // List of pictureBox to keep track all pictureBox.
        private Boolean isX = true; // Check is X turn.

        /// <summary>
        /// Load form event. 
        /// Assign the pictureBox to pictureBox list.
        /// When pictureBox clicked. Run PBClick function.
        /// </summary>
        private void myForm_Load(object sender, EventArgs e)
        {          
            myList[0] = pictureBox00;
            myList[1] = pictureBox01;
            myList[2] = pictureBox02;
            myList[3] = pictureBox10;
            myList[4] = pictureBox11;
            myList[5] = pictureBox12;
            myList[6] = pictureBox20;
            myList[7] = pictureBox21;
            myList[8] = pictureBox22;

            for (int i = 0; i < myList.Length; i++)
            {
                myList[i].Click += PBClick;
            }
            
        }

        /// <summary>
        /// Assign the image X or O into pictureBox
        /// After assign the value to pictureBox, check winners.
        /// </summary>
        private void PBClick(object sender, EventArgs e)
        {         
            PictureBox PB = (PictureBox)sender;
           
            if (isX && PB.Image == null)
            {
                labelTurn.Text = "O";
                PB.Image = Properties.Resources.x;
                PB.Tag = "X";
                isX = false;
            }
            else if (!isX && PB.Image == null)
            {
                labelTurn.Text = "X";
                PB.Image = Properties.Resources.o;
                PB.Tag = "O";
                isX = true;
            }
            else
            {
                MessageBox.Show("Already selected", "Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            checkWinners();
        }

        /// <summary>
        /// Check winner conditions.
        /// Example: Check row, column, diagonal.
        /// </summary>
        private void checkWinners()
        {
            isWin(myList[0],myList[1],myList[2]);
            isWin(myList[3], myList[4], myList[5]);
            isWin(myList[6], myList[7], myList[8]);
            isWin(myList[0], myList[3], myList[6]);
            isWin(myList[1], myList[4], myList[7]);
            isWin(myList[2], myList[5], myList[8]);
            isWin(myList[0], myList[4], myList[8]);
            isWin(myList[2], myList[4], myList[6]);
            if (isFull()) // Draw result.
            {
                MessageBox.Show("DRAW", "Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }

        /// <summary>
        /// Method with 3 contructors. This method is check different kinds of win.
        /// </summary>
        private void isWin(PictureBox st, PictureBox nd, PictureBox rd)
        {
            if (st.Tag == nd.Tag && nd.Tag == rd.Tag)
            {
                XWin(st);
                Reset();
            }
        }

        /// <summary>
        /// Restart the game so that another game can be played.
        /// </summary>
        private void Reset()
        {
            for(int i = 0; i < myList.Length; i++)
            {
                myList[i].Tag = "0"+i;
                myList[i].Image = null;
            }
            labelTurn.Text = "";
            isX = true;
        }

        /// <summary>
        /// Function to display suitable message box to get player know who won.
        /// </summary>
        private void XWin(PictureBox pb)
        {
            if (pb.Tag == "X")
            {
                MessageBox.Show("X WIN", "Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            else
            {
                MessageBox.Show("O WIN", "Tic Tac Toe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }

        /// <summary>
        /// for DRAW, check all pictureBox is already assigned with value.
        /// </summary>
        private Boolean isFull()
        {
            Boolean output = true;
            for (int i = 0; i < myList.Length; i++)
            {
                if (myList[i].Image == null)
                {
                    output = false;
                }                  
            }
            return output;
        }

        /// <summary>
        /// button reset.
        /// </summary>
        private void btReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
