using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tetris
{
    public partial class Scoreboard : Form
    {
        public Scoreboard()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("records.txt");
            int place = 1;
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] words = line.Split(':');
                richTextBox1.Text += place + ". Name: " + words[0] + "    Score: " + words[1] + "\r\n";
                line = sr.ReadLine();
                place++;
            }
            sr.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            this.Hide();
            m.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
