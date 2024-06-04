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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 tetris = new Form1();
            this.Hide();
            tetris.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Options op = new Options();
            this.Hide();
            op.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Scoreboard sc = new Scoreboard();
            this.Hide();
            sc.Show();
        }
    }
}
