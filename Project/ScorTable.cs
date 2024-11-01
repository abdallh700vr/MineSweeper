using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project
{
    public partial class ScorTable : Form
    {   
        public List<Player> PlayerList = new List<Player>();   
        
        
        public ScorTable()
        {
            InitializeComponent();
            
        }


        public void AddPlayer(string name, int score)
        {
            label1.Text =  $"{name}:{score}";
            PlayerList.Add(new Player(name, score));
            PlayerList.Sort((x, y) => y.score.CompareTo(x.score));
            if (PlayerList.Count > 10)
            {
                PlayerList.RemoveAt(PlayerList.Count-1);
            }

            ShowList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();   
            form.Show();
            this.Hide();
        }


        public void ShowList()
        {
            int xLoc = 6;
            int yLoc = 9;

            panel1.Controls.Clear();

            foreach (Player player in PlayerList) 
            {
                Label lb = new Label();
                lb.Parent = panel1;
                lb.BackColor = Color.Blue;
                lb.Location = new Point(xLoc, yLoc);
                lb.Text = $"{player.name} : {player.score}";
                yLoc += 30;
            }
        }
    }


    public class Player
    {   
        public string name;
        public int score;
        public Player(string name ,int score)
        {
            this.name = name;
            this.score = score;
        }



    }



}
