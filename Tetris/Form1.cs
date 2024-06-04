using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris;
using System.IO;

namespace Tetris
{
    public partial class Form1 : Form
    {
        //FileStream fs = File.Create("records.txt");

        Bitmap panel;
        Graphics panelGraphic;
        int panelWidth = 8;
        int panelHeight = 8;


        SolidBrush testbrush;

        int score = 0;

        Bitmap canvas;
        Graphics Graphic;
        int canvasWidth = 15;
        int canvasHeight = 20;
        int[,] gameBoard;
        int bSize = 20;

        Bitmap drawing;
        Bitmap paneldrawing;

        Block nextblock;
        Block actualblock;
        Timer timer = new Timer();
        public int actualX;
        public int actualY;
        Brush color;

        int time = 500;

        public Brush[] myArray =
            {
                Brushes.Red,
                Brushes.YellowGreen,
                Brushes.Blue,
                Brushes.Orange,
                Brushes.DarkMagenta,
                Brushes.Violet,
                Brushes.Aqua,
                Brushes.Chocolate
            };
        public Form1()
        {
            InitializeComponent();
            
            loadCanvas();
            this.KeyDown += Form1_KeyDown;

            if (Settings.Difficulty == 0)
            {
                label6.Text = Convert.ToString("Easy");
            }
            if (Settings.Difficulty == 1)
            {
                label6.Text = Convert.ToString("Normal");
            }
            if (Settings.Difficulty == 2)
            {
                label6.Text = Convert.ToString("Hard");
            }


            label1.Text = "Score:";
            label2.Text = "0";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int moveS = 0;
            int moveD = 0;

            switch (e.KeyData)
            {
                case Keys.Escape:
                    this.Hide();
                    Menu m = new Menu();
                    m.Show();
                    return;

                case Keys.Right:
                    moveS++;
                    break;

                case Keys.Left:
                    moveS--;
                    break;

                case Keys.Down:
                    moveD++;
                    break;

                case Keys.Up:
                    if(label5.Enabled == false)
                    {
                        actualblock = actualblock.RotateBlock(actualblock);
                    }
                    
                    break;
            }
            
            if(label5.Enabled == false)
            {
                int move = moveBlock(moveD, moveS);

                if ((move == 1) && (e.KeyCode == Keys.Up))
                {
                    actualblock = actualblock.Back();
                }
            }
          
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int test = moveBlock(1);

            if(test == 1)
            {
                saveInArray();
                
                
                actualblock = nextblock;
                nextblock = getBlock();
                drawInPanel();
                canvas = new Bitmap(drawing);
                panel = new Bitmap(drawing);

                checkRows();
                
            }
            
        }



        

        private void loadCanvas()
        {
            pictureBox1.Width = canvasWidth * bSize;
            pictureBox1.Height = canvasHeight * bSize;

           
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphic = Graphics.FromImage(canvas);

            Graphic.FillRectangle(Brushes.Black, 0, 0, canvas.Width, canvas.Height);

           
            pictureBox1.Image = canvas;

 
            gameBoard = new int[canvasWidth, canvasHeight];




            pictureBox2.Width = panelWidth * bSize;
            pictureBox2.Height = panelHeight * bSize;

            panel = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            panelGraphic = Graphics.FromImage(panel);
            panelGraphic.FillRectangle(Brushes.Black, 0, 0, canvas.Width, canvas.Height);

            pictureBox2.Image = panel;


   /*         BlocksArray ba = new BlocksArray();
            Block b = ba.getRndBlock();
            Bitmap workingBitmap = new Bitmap(canvasBitmap);
            Graphics workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    if (b.Grids[j, i] == 1)
                        workingGraphics.FillRectangle(Brushes.YellowGreen, (7 + i) * dotSize, (0 + j) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox1.Image = workingBitmap;*/

            /*    Bitmap workingBitmap = new Bitmap(canvasBitmap);
                Graphics workingGraphics = Graphics.FromImage(workingBitmap);

                workingGraphics.FillRectangle(Brushes.Black, 7 * dotSize, 0, dotSize, dotSize);

                pictureBox1.Image = workingBitmap;*/




        }
        
        private Block getBlock()
        {
    /*        if (Settings.Difficulty == 0)
            {
                label6.Text = Convert.ToString("Easy");
            }
            if (Settings.Difficulty == 1)
            {
                label6.Text = Convert.ToString("Normal");
            }
            if (Settings.Difficulty == 0)
            {
                label6.Text = Convert.ToString("Hard");
            }*/



            BlocksArray ba = new BlocksArray();
            Block b = ba.getRndBlock(Settings.Difficulty);

            actualX = 7;
            actualY = -b.Height;
           

            color = PickBrush();

            return b;
        }



        private void drawInPanel()
        {
            panelGraphic = Graphics.FromImage(panel);
            panelGraphic.FillRectangle(Brushes.Black, 0, 0, canvas.Width, canvas.Height);

            pictureBox2.Image = panel;

            paneldrawing = new Bitmap(panel);
            Graphics newPanelGraphic = Graphics.FromImage(paneldrawing);

            for (int i = 0; i < nextblock.Width; i++)
            {
                for (int j = 0; j <  nextblock.Height; j++)
                {
                    if (nextblock.Grids[j, i] == 1)
                        newPanelGraphic.FillRectangle(Brushes.Red, (3 + i) * bSize, (2 + j) * bSize, bSize, bSize);
                  
                }
            }

            pictureBox2.Image = paneldrawing;
        }

        private int moveBlock(int moveDown = 0, int moveSide = 0)
        {
            
            int moveY = actualY + moveDown;
            int moveX = actualX + moveSide;

            if((moveY + actualblock.Height > canvasHeight) || (moveX + actualblock.Width > canvasWidth) || (moveX < 0))
            {
                return 1;
            }
            else
            {
                for (int i = 0; i < actualblock.Width; i++)
                {
                    for (int j = 0; j < actualblock.Height; j++)
                    {
                        if (actualblock.Grids[j, i] == 1)
                        {
                            if (moveY + j > 0)
                            {
                                if (gameBoard[moveX + i, moveY + j] == 1)
                                {
                                    return 1;
                                }
                            }              
                        }
                          

                        
                    }
                }

            }

            actualY = moveY;
            actualX = moveX;

            drawBlock();
            return 0;
        }

        
        private void drawBlock()
        {
            

            drawing = new Bitmap(canvas);
            Graphics newGraphic = Graphics.FromImage(drawing);

            for (int i = 0; i < actualblock.Width; i++)
            {
                for (int j = 0; j < actualblock.Height; j++)
                {
                    if (actualblock.Grids[j, i] == 1)
                        newGraphic.FillRectangle(color, (actualX + i) * bSize, (actualY + j) * bSize, bSize, bSize);
                }
            }
            //test 0, 0 kwadrat
            //newGraphic.FillRectangle(Brushes.Red, 0 * bSize, 0 * bSize, bSize, bSize);
            pictureBox1.Image = drawing;

            
        }
        int a;
        private void saveInArray()
        {
            /*            for(int i = 0; i < canvasHeight; i++)
                        {
                            for(int j = 0; j < canvasWidth; j++)
                            {
                                if((i == actualY) && (j == actualX))
                                {
                                    gameBoard[j, i] = 1;
                                }
                            }
                        }*/

           
            for (int i = 0; i < actualblock.Width; i++)
            {
                a = GameOver();
                if (a == 1)
                {
                    break;
                }

                for (int j = 0; j < actualblock.Height; j++)
                {
                    if (actualblock.Grids[j, i] == 1)

                
                    
                    gameBoard[actualX + i, actualY + j] = 1;
                }
            }

            //checking table in console
            for (int i = 0; i < canvasHeight; i++)
            {
                for (int j = 0; j < canvasWidth; j++)
                {
                    
                        Console.Write(gameBoard[j, i]);
                    
                }
                Console.WriteLine();
            }



            
        }


        private void checkRows()
        {
            int fullRows = 0;
            int count = 0;

            for(int i = canvasHeight; i > 0; i--)
            {
                
                for(int j = 0; j < canvasWidth; j++)
                {
                    if(gameBoard[j, i - 1] == 1)
                    {
                        count++;
                    }
          
                }
                if(count == 15)
                {
/*                    for (int k = 0; k < canvasWidth; k++)
                    {
                        
                        gameBoard[k, i - 1] = 0;
                    }*/
                    
                    fullRows++;

                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < canvasWidth; j++)
                        {
                            if (k - 2 >= 0)
                            {
                                gameBoard[j, k - 1] = gameBoard[j, k - 2];

                            }
                            
                        }
                    }
                    /*         for (int t = 0; t < canvasWidth; t++)
                             {
                                 for (int j = 0; j < canvasHeight; j++)
                                 {
                                     Color co = canvas.GetPixel(t * bSize, j * bSize);
                                     testbrush = new SolidBrush(co);
                                     Graphic = Graphics.FromImage(canvas);
                                     if(gameBoard[t, j] == 1)
                                     {
                                         Graphic.FillRectangle(testbrush, t * bSize, j * bSize, bSize, bSize);
                                     }
                                     else
                                     {
                                         Graphic.FillRectangle(Brushes.Black, t * bSize, j * bSize, bSize, bSize);
                                     }

                                 }
                             }*/
                    score = score + 100;
                    label2.Text = Convert.ToString(score);
                    time = time - 25;
                    timer.Interval = time;
       
                    // k = 19, j = 0
                    for (int k = i - 1; k >= 0; k--)
                    {
                        for (int j = 0; j < canvasWidth; j++)
                        {
                            if (k > 0)
                            {
                                Color co = canvas.GetPixel(j * bSize, (k * bSize) - bSize);
                                testbrush = new SolidBrush(co);
                                Graphic = Graphics.FromImage(canvas);

                                    Graphic.FillRectangle(testbrush, j * bSize, k * bSize, bSize, bSize);
                                


                            }

                        }
                    }
                    i = canvasHeight + 1;
                }

                

                

                count = 0;

            }

            


        }
       
        private int GameOver()
        {
            if(actualY <= 0)
            {
             
                timer.Stop();
                label3.Show();


                int s = 0;
                StreamReader sr = new StreamReader("records.txt");

                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(':');
                    if(Convert.ToInt32(words[1]) < score)
                    {
                        s = Convert.ToInt32(words[1]);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.WriteLine(s);
                if (score > s)
                {
                    /* StreamWriter sw = File.AppendText("records.txt");
                     sw.WriteLine("User:" + score);*/
                    string content = File.ReadAllText("records.txt");
                    content = "User:" + score + "\n" + content;
                    File.WriteAllText("records.txt", content);
                    //sw.Close();
                }

                return 1;
            }
            return 0;
        }
        

        private Brush PickBrush()
        {
            /*Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);*/


            Brush brushColor = myArray[new Random().Next(myArray.Length)];

            return brushColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            nextblock = getBlock();
            actualblock = getBlock();
            drawInPanel();
            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();

            

            label5.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

   
    }
}
