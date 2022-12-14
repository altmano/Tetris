using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class AI
    {
        private int[] current_round = new int[100];
        public int[,] evaluated_moves = new int[100, 25];
        private int[] next_round = new int[100];
        private int[] solution = new int[25];
        private Tetromino imaginary_tetromino = new Tetromino();
        private Gameboard imaginary_gameboard = new Gameboard();
        
        private int serialnumber = 0;
        private int move = 1;

        private bool enabled = false;
        private int total = 0;
        private int secondary = 0;

        public int[] Solution { get => solution; set => solution = value; }

        //


        public void evaluate(int [,] real_tetromino, int[,] next_tetromino, int x, int y, int [,] real_gameboard, bool go_deeper)
        {
            if(go_deeper == true)
            {
                serialnumber = 0;
                move = 1;
            }
            else
            {
                secondary = 0;
            }
            for(int k = 0; k < 4; k++)
            {
                for(int l = -5; l < 6; l++)
                {
                    imaginary_tetromino.x = x;
                    imaginary_tetromino.y = y;
                    imaginary_tetromino.print = false;
                    if (go_deeper == true)
                    {
                        copy_tetromino(real_tetromino);

                    }
                    else
                    {
                        copy_tetromino(next_tetromino);
                    }
                    
                    copy_board(real_gameboard);
                    imaginary_gameboard.game_over = false;

                    for(int i = 0; i < 2; i++)
                    {
                        imaginary_tetromino.move_down(imaginary_gameboard.GetGameboard());
                        if (go_deeper == true)
                        {
                            evaluated_moves[serialnumber, move] = 4;
                            move++;
                        }

                    }

                    for (int n = k; n > 0; n--)
                    {
                        imaginary_tetromino.rotate_right(imaginary_gameboard.GetGameboard());
                        if (go_deeper == true)
                        {
                            evaluated_moves[serialnumber, move] = 1;
                            move++;
                        }

                    }

                    if (l<0)
                    {  
                        for(int m = l; m < 0; m++)
                        {
                            imaginary_tetromino.move_left(imaginary_gameboard.GetGameboard());
                            if (go_deeper == true)
                            {
                                evaluated_moves[serialnumber, move] = 2;
                                move++;
                            }

                        }
                    }
                    if(l > 0)
                    {
                        for(int m = 0; m < l; m++)
                        {
                            imaginary_tetromino.move_right(imaginary_gameboard.GetGameboard());
                            if(go_deeper == true)
                            {
                                evaluated_moves[serialnumber, move] = 3;
                                move++;
                            }

                        }
                    }

                    while (imaginary_tetromino.print == false)
                    {
                        imaginary_tetromino.move_down(imaginary_gameboard.GetGameboard());
                        if (go_deeper == true)
                        {
                            move++;
                        }

                    }

                    imaginary_gameboard.printtetro(imaginary_tetromino.tetromino, imaginary_tetromino.x, imaginary_tetromino.y);
                    if (go_deeper == true)
                    {
                        move = 1;
                        current_round[serialnumber] = evaluation_function(imaginary_gameboard.GetGameboard());
                        if(current_round[serialnumber] == 0)
                        {
                            evaluated_moves[serialnumber,0] = 0;
                        }else
                        {
                            int[,] copyofgameboard = new int[22, 12];
                            for(int i = 0; i < 22; i++)
                            {
                                for(int j = 0; j < 12; j++)
                                {
                                    copyofgameboard[i, j] = imaginary_gameboard.GetGameboard()[i, j];
                                }
                            }
                            evaluate(real_tetromino, next_tetromino, x, y, copyofgameboard, false);

                        }
                        serialnumber++;


                    }
                    else
                    {
                        next_round[secondary] = evaluation_function(imaginary_gameboard.GetGameboard());
                        secondary++;
                    }


                }
            }




            if (go_deeper == true)
            {
                int position = 0;
                int largest = 0;

                for (int i = 0; i < 100; i++)
                {
                    if(evaluated_moves[i,0] > largest)
                    {
                        position = i;
                        largest = evaluated_moves[i, 0];
                    }
                }


                    for (int i = 1; i < 25; i++)
                {
                    Solution[i - 1] = evaluated_moves[position, i];
                }
            }
            else
            {
                int largest = 0;
              
                for(int i = 0; i < 100; i++)
                {
                    if(next_round[i] > largest)
                    {
                        largest = next_round[i];
                    }
                }
                evaluated_moves[serialnumber, 0] = largest;
            }


        }
        

        private int evaluation_function(int [,] gameboard)
        {
            int x;
            int number_of_gaps;
            
            imaginary_gameboard.lost();
            if(imaginary_gameboard.game_over == false)
            {
                number_of_gaps = gaps(gameboard);
                x = 1000 -  number_of_gaps;              
                x = x - height_difference(gameboard);
            }
            else
            {
                x = 0;
            }

            return x;

        }

        private int gaps(int [,] gameboard)
        {
            int total = 0;
            int size = 0;
            for(int i = 1; i < 21; i++)
            {
                for(int j = 1; j <11; j++)
                {
                    if (gameboard[i, j] == 0 && gameboard[i - 1, j] == 1)
                    {
                        //only basic version, possible future upgrades
                        total++;
                        int k = i + 1;
                        while (gameboard[k, j] == 0)
                        {
                            size++;
                            k++;
                        }
                    }

                }
            }
                total = (total * 30) + (size * 7);
            return total;
        }

        private void copy_board(int[,] real_gameboard)
        {
            for (int i = 0; i < 22; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    imaginary_gameboard.GetGameboard()[i, j] = real_gameboard[i, j];

                }
            }
        }

        private void copy_tetromino(int [,] real_tetromino)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    imaginary_tetromino.tetromino[i, j] = real_tetromino[i, j];

                }
            }
        }

        private int height_difference(int [,] gameboard)
        {
            int x = 0;
            int[] pillars = new int[10];
            int highestpillar = 0;
            bool topfound = false;
            for(int j = 1; j <11; j++)
            {
                topfound = false;

                for (int i =1 ; i < 21; i++)
                {
                    if(gameboard[i,j] == 1 && topfound == false)
                    {
                        pillars[j - 1] = 21-i;
                        topfound = true;
                    }
                }
            }
            for(int i = 1; i < 10; i++)
            {
                x = x + Math.Abs(pillars[i - 1] - pillars[i]);
                total = total + pillars[i] * 100;
                if(pillars[i]>highestpillar)
                {
                    highestpillar = pillars[i];
                }

            }
            x = x * 2;
            x = x + highestpillar;
            if(highestpillar > 14)
            {
                x = x + highestpillar;
            }

            for(int i = 3; i < 7; i++)
            {
                if(pillars[i] >17)
                {
                    x = x + 150;
                }
            }
            return x;
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }

        public bool IsEnabled()
        {
            return enabled;
        }

    }
}
