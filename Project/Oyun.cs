using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project
{
    public partial class Oyun : Form
    {
        int[,] Grid = new int[Form1.Form1Data.grid, Form1.Form1Data.grid];
        Button[,] ButtonsList = new Button[Form1.Form1Data.grid, Form1.Form1Data.grid];
        System.Timers.Timer counter;
        public double score = 0;
        public int HmlS = 0;
        public int s = 0;
        public int TrueFlaged = 0;
        public Oyun()
        {

            InitializeComponent();
            BombaDagitma();
            buttonDagitma();
            button1.BackColor = Color.Red;
            button1.Enabled = false;

           // label1.Text = $"{Form1.Form1Data.grid},{Form1.Form1Data.mine}";
            label3.Text = $"hamle sayısı : {HmlS}";

        }

        Random rand = new Random();
        private void BombaDagitma()
        {

            for (int i = 0; i < Form1.Form1Data.mine; i++)
            {
                int x = rand.Next(0, Form1.Form1Data.grid - 1);
                int y = rand.Next(0, Form1.Form1Data.grid - 1);

                if (Grid[x, y] == 0)
                {
                    Grid[x, y] = 10;
                }
            }
        }


        private void buttonDagitma()
        {
            int xLoc = 6;
            int yLoc = 9;

            for (int i = 0; i < Form1.Form1Data.grid; i++)
            {
                for (int j = 0; j < Form1.Form1Data.grid; j++)
                {
                    Button btn = new Button();
                    btn.Parent = pnlBody;
                    btn.BackColor = Color.Gray;
                    btn.Location = new Point(xLoc, yLoc);
                    btn.Tag = $"{j},{i}";
                    btn.Size = new Size(30, 27);
                    btn.Click += btnClick;
                    btn.MouseDown += btnflag;
                    ButtonsList[j, i] = btn;
                    xLoc += 30;
                }
                //bc when in new row thats why xloc = 6;
                yLoc += 27;
                xLoc = 6;
            }
        }



        private void btnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));

            HmlS++;
            label3.Text = $"hamle sayısı : {HmlS}";
            int value = Grid[x, y];


            if (value == 10)
            {
                
                btn.Image = Properties.Resources.bomb;
                btn.BackColor = Color.White;
                Lost();


            }
            else if (value == 0)
            {
                //this code make this clear the button
                btn.FlatStyle = FlatStyle.Flat;
                btn.Enabled = false;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.White;

                if (bombscounter(x, y) == 0)
                {
                    HucreTemizle(x, y);

                }
                else
                {
                    btn.Text = $"{bombscounter(x, y)}";
                }


            }


        }

        private void Oyun_Load(object sender, EventArgs e)
        {
            counter = new System.Timers.Timer();
            counter.Interval = 1000;
            counter.Elapsed += HandleTimer;
            counter.Start();
        }

        private void HandleTimer(object? sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() => { 
                s++; 
                label2.Text = s.ToString();
            }));
        }

        private int bombscounter(int x, int y)
        {
            // default values
            int bombs = 0;
            int endX = x + 1;
            int endY = y + 1;
            int iY = y - 1;
            int jX = x - 1;

            // this for to check if the x and y in 0 or last index case
            if (y == 0)
                iY = 0;
            else if (y == Form1.Form1Data.grid - 1)
                endY = y;

            if (x == 0)
                jX = 0;
            else if (x == Form1.Form1Data.grid - 1)
                endX = x;


            for (int i = iY; i <= endY; i++)
            {
                for (int j = jX; j <= endX; j++)
                {
                    if (Grid[j, i] == 10)
                        bombs++;

                }

            }

            return bombs;
        }

        private void Lost()
        {
            button1.BackColor = Color.Green;
            button1.Enabled = true;
            score = (float)TrueFlaged / s * 1000;
            counter.Stop();
            for (int y = 0; y < Form1.Form1Data.grid; y++)
            {
                for (int x = 0; x < Form1.Form1Data.grid; x++)
                {
                    Button btn = ButtonsList[x, y];
                    btn.Click -= btnClick;
                    btn.MouseDown -= btnflag;
                    if (Grid[x, y] == 10)
                    {

                        btn.Image = Properties.Resources.bomb;
                        btn.BackColor = Color.White;

                    }
                }
            }
        }



        private void btnflag(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));

            if (e.Button == MouseButtons.Right)
            {

                if (btn.Image == null)
                {

                    if (Grid[x, y] == 10)
                    {
                        TrueFlaged++;
                        Grid[x, y] = 11;
                    }
                    else
                    {
                        Grid[x, y] = 12;
                    }

                    HmlS++;
                    label3.Text = $"hamle sayısı : {HmlS}";
                    btn.BackColor = Color.White;
                    btn.Image = Properties.Resources.turkey__1_;
                }
                else
                {
                    if (Grid[x, y] == 11)
                    {
                        TrueFlaged--;
                        Grid[x, y] = 10;
                    }            
                    else
                    {
                        Grid[x, y] = 0;
                    }

                    HmlS--;
                    label3.Text = $"hamle sayısı : {HmlS}";
                    btn.BackColor = Color.Gray;
                    btn.Image = null;
                }

            }
        }


        private void HucreTemizle(int x, int y)
        {


            if (x < 0 || y < 0 || y > Form1.Form1Data.grid - 1 || x > Form1.Form1Data.grid - 1 || Grid[x, y] != 0 )
                return;

            
            Button btn1 = ButtonsList[x, y];
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Enabled = false;
            btn1.FlatAppearance.BorderSize = 0;
            btn1.BackColor = Color.White;
            btn1.Text = $"{bombscounter(x, y)}";


            int endX = x + 1;
            int endY = y + 1;
            int iY = y - 1;
            int jX = x - 1;

         
            if (y == 0)
                iY = 0;
            else if (y == Form1.Form1Data.grid - 1)
                endY = y;

            if (x == 0)
                jX = 0;
            else if (x == Form1.Form1Data.grid - 1)
                endX = x;


            if (bombscounter(x, y) == 0)
            {
                for (int i = iY; i <= endY; i++)
                {
                    for (int j = jX; j <= endX; j++)
                    {

                        if (ButtonsList[j, i].Enabled)
                        {
                            if (i == 0 && j == 0) continue;
                            HucreTemizle(j, i);
                        }

                    }

                }
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Program.scoreTable.AddPlayer(Form1.Form1Data.name,Convert.ToInt32(score));
            Program.scoreTable.Show();
            this.Hide();
        }

       
    }




}
