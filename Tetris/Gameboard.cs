using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Gameboard
    {
        public int[,] gameboard = new int[22, 12];
        const int size = 18;
        const int gap = 1;
        private int score = 0;
        public bool game_over = false;
        public void setup()
        {
            game_over = false;
            score = 0;
            for (int i = 0; i < 22; i++)
            {
                gameboard[i, 0] = 1;
                gameboard[i, 11] = 1;
                
            }
            for(int i = 0; i < 12; i++)
            {
                gameboard[21, i] = 1;
            }
            for(int i = 0; i < 21; i++)
            {
                for(int j = 1; j < 11; j++)
                {
                    gameboard[i, j] = 0;
                }
            }
        }
        public int GetScore()
        {
            return score;
        }
        public  void addtetro(int [,] tetromino, int x, int y)
        {
            for (int i = 0; i < 21; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if(gameboard[i,j] == 2)
                    {
                        gameboard[i, j] = 0;
                    }
                    
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0 ; j < 4; j++)
                {

                    if ((x - 4 + i) >= 0 && (x - 4 + i) < 22 && (y - 4 + j) >= 0 && (y - 4 + j) < 12)
                    {
                        if (gameboard[x - 4 + i, y - 4 + j] != 1)
                        {
                            gameboard[x - 4 + i, y - 4 + j] = tetromino[i, j];

                        }
                    }
                   
                }
            }

        }

        public void printtetro(int [,] tetromino, int x, int y)
        {
            for (int i = 0; i < 21; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (gameboard[i, j] == 2)
                    {
                        gameboard[i, j] = 0;
                    }
                    
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((x - 4 + i) >= 0 && (x - 4 + i) < 22 && (y - 4 + j) >= 0 && (y - 4 + j) < 12)
                    {
                        if (gameboard[x - 4 + i, y - 4 + j] != 1)
                        {
                            if (tetromino[i, j] == 2)
                            {
                                gameboard[x - 4 + i, y - 4 + j] = 1;

                            }
                            else
                            {
                                gameboard[x - 4 + i, y - 4 + j] = 0;
                            }

                        }
                    }
                        
                }
            }
            bool complete = true;
            for(int i = 0; i < 21; i++)
            {
                complete = true;
                for (int j = 1; j < 11; j++)
                {
                    if(gameboard[i,j]==0)
                    {
                        complete = false;
                    }

                }
                if (complete == true)
                {
                    score = score + 100;
                    
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            gameboard[k, j] = gameboard[k - 1, j];


                        }
                    }
                }
                lost();

                
            }

               
        }

        public void lost()
        {
            for (int j = 1; j < 11; j++)
            {
                if (gameboard[0, j] == 1)
                {
                    game_over = true;
                }
            }
        }

        public void render(Graphics g)
        {
            Brush brush;
            for(int i = 0; i < 22; i++)
            {
                for(int j = 0; j < 12; j++)
                {
                    brush = Brushes.Black;
                    if( gameboard[i,j] == 1)
                    {
                        brush = Brushes.Red;
                    }
                    if(gameboard[i,j] == 0)
                    {
                        brush = Brushes.LightGray;
                    
                    }
                    if(gameboard[i,j] == 2)
                    {
                        brush = Brushes.Green;
                    }

                    g.FillRectangle(brush, j * (size + gap), i * (size + gap), size, size);       
                }
            }
        }
    }
}
