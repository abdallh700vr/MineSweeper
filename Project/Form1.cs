namespace Project
{
    public partial class Form1 : Form
    {
        public string name;
        public int grid;
        public int mine;
        public static Form1 Form1Data;
        public Form1()
        {
            InitializeComponent();
            Form1Data = this;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.name = textBox1.Text;
            this.grid = Convert.ToInt32(textBox2.Text);
            this.mine = Convert.ToInt32(textBox3.Text);

            if (this.mine < 10)
            {
                MessageBox.Show("en az 10 bomba koyulabilir");

            }
            else if (this.grid > 30 || this.grid < 10)
            {
                MessageBox.Show("sadece 10-30 arasýnda oyun destekleniyor");
            }
            else
            {

                Oyun form2 = new Oyun();
                form2.Show();

                this.Hide();
            }

        }
    }
}
