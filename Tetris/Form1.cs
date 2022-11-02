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
            tetromino.generate_new();
            next_tetromino.generate_new();
            timer1.Enabled = false;

            Net.Refresh();
        }

        private void Net_Paint(object sender, PaintEventArgs e)
        {
            gameboard.render(e.Graphics);
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            gameboard.setup();
            tetromino.generate_new();
            next_tetromino.generate_new();
            /*
            if(!ai.IsEnabled())
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
            */
            timer1.Enabled = true;
            Net.Refresh();
        }

        private void AI_button_Click(object sender, EventArgs e)
        {
            if(ai.IsEnabled())
            {
                ai.Disable();
                button3.BackColor = Color.Red;
            }
            else
            {
                ai.Enable();
                button3.BackColor = Color.Green;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tetromino.move_down(gameboard.GetGameboard());
            if(tetromino.print == true)
            {
                gameboard.printtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                label1.Text = gameboard.GetScore().ToString();
                if(gameboard.game_over == false)
                {
                    copytetro();
                    if(ai.IsEnabled())
                    {
                        ai.evaluate(tetromino.tetromino, next_tetromino.tetromino, tetromino.x, tetromino.y, gameboard.GetGameboard(), true);
                        gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);


                        for (int i = 0; i < 25; i++)
                        {
                            if (ai.Solution[i] == 1 &&  (gameboard.game_over == false))
                            {
                                tetromino.rotate_right(gameboard.GetGameboard());
                                gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                                Net.Refresh();
                            }
                            if(ai.Solution[i] == 2 && (gameboard.game_over == false))
                            {
                                tetromino.move_left(gameboard.GetGameboard());
                                gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                                Net.Refresh();
                            }
                            if(ai.Solution[i] == 3 && (gameboard.game_over == false))
                            {
                                tetromino.move_right(gameboard.GetGameboard());
                                gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                                Net.Refresh();
                            }
                            if(ai.Solution[i] == 4)
                            {
                                tetromino.move_down(gameboard.GetGameboard());
                                if (tetromino.print == true)
                                {
                                    gameboard.printtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                                    label1.Text = gameboard.GetScore().ToString();
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


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!ai.IsEnabled())
            {
                if (keyData == Keys.Up)
                {

                    tetromino.rotate_right(gameboard.GetGameboard());
                        gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                        Net.Refresh();
                   

                    return true;
                }
                //down arrow
                if (keyData == Keys.Down)
                {
                    
                        tetromino.move_down(gameboard.GetGameboard());
                        if (tetromino.print == true)
                        {
                            gameboard.printtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                            label1.Text = gameboard.GetScore().ToString();
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

                        Net.Refresh();
                    return true;
                }

                    
                
                //left arrow
                if (keyData == Keys.Left)
                {

                        tetromino.move_left(gameboard.GetGameboard());
                        gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                        Net.Refresh();
                    return true;
                }
                //right arrow
                if (keyData == Keys.Right)
                {
                   
                        tetromino.move_right(gameboard.GetGameboard());
                        gameboard.addtetro(tetromino.tetromino, tetromino.x, tetromino.y);
                        Net.Refresh();
                    

                    return true;
                }


            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Decrease_Speed_button_Click(object sender, EventArgs e)
        {
            if(timer1.Interval > 25)
            {
                timer1.Interval = timer1.Interval - 25;


            }else
            {
                timer1.Interval = 1;
            }
        }

        private void Increase_Speed_button_Click(object sender, EventArgs e)
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
