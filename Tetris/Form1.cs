using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Gameboard gameboard = new Gameboard();
        private Tetromino tetromino = new Tetromino();
        private Tetromino next_tetromino = new Tetromino();
        private AI ai = new AI();

        //private Old_AI oldai = new Old_AI();
        //private bool turn = true;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            tetromino.print = false;
            gameboard.setup();
            Net.Refresh();
        }

        private void Net_Paint(object sender, PaintEventArgs e)
        {
            gameboard.render(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameboard.setup();
            next_tetromino.generate_new();
            if(ai.enabled == false)
            {
                copytetro();
                gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                gameboard.score = 0;
                button3.BackColor = Color.Red;


            }
            else
            {
                tetromino.print = true;
            }
            timer1.Enabled = true;
            Net.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ai.enabled == false)
            {
                ai.enabled = true;
                button3.BackColor = Color.Green;

            }
            else
            {
                ai.enabled = false;
                button3.BackColor = Color.Red;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tetromino.move_down(gameboard.gameboard);
            if(tetromino.print == true)
            {
                gameboard.printtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                label1.Text = gameboard.score.ToString();
                if(gameboard.game_over == false)
                {
                    copytetro();
                    if(ai.enabled == true)
                    {
                        ai.evaluate(tetromino.tetromino, next_tetromino.tetromino, tetromino.x, tetromino.y, gameboard.gameboard, true);
                        /*
                        if (turn == true)
                        {
                            ai.evaluate(tetromino.tetromino, next_tetromino.tetromino, tetromino.x, tetromino.y, gameboard.gameboard, true);
                            button3.BackColor = Color.Green; 
                            turn = false;
                        }
                        else
                        {
                            button3.BackColor = Color.Red;
                            ai.evaluate(tetromino.tetromino, next_tetromino.tetromino, tetromino.x, tetromino.y, gameboard.gameboard, true);
                            
                            oldai.evaluate(tetromino.tetromino, tetromino.x, tetromino.y, gameboard.gameboard);
                            for(int i = 0; i < 25; i++)
                            {
                                ai.solution[i] = oldai.solution[i];
                            }
                            
                        turn = true;
                        }
                        */
                        gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);


                        for (int i = 0; i < 25; i++)
                        {
                            if (ai.Solution[i] == 1 &&  (gameboard.game_over == false))
                            {
                                tetromino.rotate_right(gameboard.gameboard);
                                gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                                Net.Refresh();
                            }
                            if(ai.Solution[i] == 2 && (gameboard.game_over == false))
                            {
                                tetromino.move_left(gameboard.gameboard);
                                gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                                Net.Refresh();
                            }
                            if(ai.Solution[i] == 3 && (gameboard.game_over == false))
                            {
                                tetromino.move_right(gameboard.gameboard);
                                gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                                Net.Refresh();
                            }
                            if(ai.Solution[i] == 4)
                            {
                                tetromino.move_down(gameboard.gameboard);
                                if (tetromino.print == true)
                                {
                                    gameboard.printtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                                    label1.Text = gameboard.score.ToString();
                                    if (gameboard.game_over == false)
                                    {
                                        tetromino.generate_new();

                                    }
                                    else
                                    {
                                        MessageBox.Show("game over");
                                        timer1.Enabled = false;
                                    }
                                }
                                else
                                {
                                    gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);

                                }
                                Net.Refresh();
                            }
                        }
                    }
                }
                else
                {
                    timer1.Enabled = false;

                    MessageBox.Show("game over");
                }
            }
            else
            {
                gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);

            }
            Net.Refresh();
            Nexttetromino.Refresh();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            tetromino.move_left(gameboard.gameboard);
            gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
            Net.Refresh();

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //up arrow 
            if (keyData == Keys.Up)
            {
                if(ai.enabled == false)
                {
                    tetromino.rotate_right(gameboard.gameboard);
                    gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                    Net.Refresh();
                }

                return true;
            }
            //down arrow
            if (keyData == Keys.Down)
            {
                if (ai.enabled == false)
                {
                    tetromino.move_down(gameboard.gameboard);
                    if (tetromino.print == true)
                    {
                        gameboard.printtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                        label1.Text = gameboard.score.ToString();
                        if (gameboard.game_over == false)
                        {
                            tetromino.generate_new();

                        }
                        else
                        {
                            MessageBox.Show("game over");
                            timer1.Enabled = false;
                        }
                    }
                    else
                    {
                        gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);

                    }
                    Net.Refresh();
                }
               
                return true;
            }
            //left arrow
            if (keyData == Keys.Left)
            {
                if(ai.enabled == false)
                {
                    tetromino.move_left(gameboard.gameboard);
                    gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                    Net.Refresh();
                }

                return true;
            }
            //right arrow
            if (keyData == Keys.Right)
            {
                if(ai.enabled == false)
                {
                    tetromino.move_right(gameboard.gameboard);
                    gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                    Net.Refresh();
                }

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(timer1.Interval > 25)
            {
                timer1.Interval = timer1.Interval - 25;


            }else
            {
                timer1.Interval = 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval + 25;

        }

        private void Next_Paint(object sender, PaintEventArgs e)
        {
            next_tetromino.render(e.Graphics);
        }

        private void copytetro()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    tetromino.tetromino[i, j] = next_tetromino.tetromino[i, j];

                       
                }
            }
            tetromino.print = false;
            tetromino.x = next_tetromino.x;
            tetromino.y = next_tetromino.y;
            next_tetromino.generate_new();

        }

    }
}
