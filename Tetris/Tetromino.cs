using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetromino

    {
        public int[,] tetromino = new int[4, 4];
        public int x = 1;
        public int y = 8;
        public bool print = false;
        Random rnd = new Random();
        public void generate_new()
        {
            x = 1;
            y = 8;
            print = false;

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    tetromino[i, j] = 0;
                }
            }
            
            int ktere = rnd.Next(1,10);
            if (ktere == 1 || ktere == 7)
            {
                tetromino[1, 1] = 2;
                tetromino[1, 2] = 2;
                tetromino[2, 1] = 2;
                tetromino[2, 2] = 2;
            }

            if (ktere == 2 || ktere == 8)
            {
                tetromino[0, 1] = 2;
                tetromino[1, 1] = 2;
                tetromino[2, 1] = 2;
                tetromino[3, 1] = 2;
            }
            if (ktere == 9 || ktere == 10)
            {
                tetromino[0, 1] = 2;
                tetromino[1, 1] = 2;
                tetromino[2, 1] = 2;
                tetromino[1, 2] = 2;
            }
            if (ktere == 3)
            {
                tetromino[1, 1] = 2;
                tetromino[2, 1] = 2;
                tetromino[0, 1] = 2;
                tetromino[0, 2] = 2;
            }
            if (ktere == 4 )
            {
                tetromino[1, 2] = 2;
                tetromino[2, 2] = 2;
                tetromino[0, 1] = 2;
                tetromino[0, 2] = 2;
            }
            if (ktere == 5)
            {
                tetromino[1, 1] = 2;
                tetromino[2, 1] = 2;
                tetromino[2, 2] = 2;
                tetromino[3, 2] = 2;
            }
            if (ktere == 6)
            {
                tetromino[1, 2] = 2;
                tetromino[2, 2] = 2;
                tetromino[2, 1] = 2;
                tetromino[3, 1] = 2;
            }
        }


        //


        public void move_down(int[,] gameboard)
        {
            bool blocked = false;

            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if((x+1) > 22)
                    {
                        blocked = true;
                    }
                    else
                    {
                        if ((x - 3 + i) >= 0 && (x - 3 + i) < 22 && (y - 4 + j) >= 0 && (y - 4 + j) < 12)
                        {
                            if (gameboard[i + x - 3, j + y - 4] == 1 && tetromino[i, j] == 2)
                            {
                                blocked = true;
                            }
                        }
                      
                    }


                }
            }
            if(blocked == false)
            {
                x++;
            }
            else
            {

                print = true;
            }
        }

        //


        public void rotate_right(int[,] gameboard)
        {
            int[,] temporary = new int[4, 4];
            bool blocked = false;
            temporary[3, 0] = tetromino[0, 0];
            temporary[3, 1] = tetromino[1, 0];
            temporary[3, 2] = tetromino[2, 0];
            temporary[3, 3] = tetromino[3, 0];
            temporary[2, 0] = tetromino[0, 1];
            temporary[2, 1] = tetromino[1, 1];
            temporary[2, 2] = tetromino[2, 1];
            temporary[2, 3] = tetromino[3, 1];
            temporary[1, 0] = tetromino[0, 2];
            temporary[1, 1] = tetromino[1, 2];
            temporary[1, 2] = tetromino[2, 2];
            temporary[1, 3] = tetromino[3, 2];
            temporary[0, 0] = tetromino[0, 3];
            temporary[0, 1] = tetromino[1, 3];
            temporary[0, 2] = tetromino[2, 3];
            temporary[0, 3] = tetromino[3, 3];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((x - 4 + i) >= 0 && (x - 4 + i) < 22 && (y - 4 + j) >= 0 && (y - 4 + j) < 12)
                    {
                        if ((gameboard[x - 4 + i, y - 4 + j] == 1) && (temporary[i, j] == 2))
                        {
                            blocked = true;
                        }
                    }

                    
                }
            }
            if(blocked==false)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        tetromino[i, j] = temporary[i, j];
                    }
                }
            }
            

        }

        //

        public void move_left(int [,] gameboard)
        {
            bool blocked = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((j + y - 5) >= 0 && (i + x - 4) >=0)
                    {
                       
                    
                    
                    
                        if (gameboard[i + x - 4, j + y - 5] == 1 && tetromino[i, j] == 2)
                        {
                            blocked = true;
                        }
                    }

                    

                }
            }
            if (blocked == false)
            {
                y--;
            }
        }
        public void move_right(int[,] gameboard)
        {
            bool blocked = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if ((j + y - 3) < 12 && (i + x - 4) >= 0)
                    {


                        if (gameboard[i + x - 4, j + y - 3] == 1 && tetromino[i, j] == 2)
                        {
                            blocked = true;
                        }
                    }



                }
            }
            if (blocked == false)
            {
                y++;
            }
        }


        public void render(Graphics g)
        {
            Brush brush;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    brush = Brushes.Black;
                    if (tetromino[i, j] == 1)
                    {
                        brush = Brushes.Red;
                    }
                    if (tetromino[i, j] == 0)
                    {
                        brush = Brushes.LightGray;

                    }
                    if (tetromino[i, j] == 2)
                    {
                        brush = Brushes.Green;
                    }

                    g.FillRectangle(brush, j * (10 + 1), i * (10 + 1), 10, 10);
                }
            }
        }

    }
}
