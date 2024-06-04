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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();

            setBorder(Settings.Difficulty);
        }

        private void Easy_label_Click(object sender, EventArgs e)
        {
            Settings.Difficulty = 0;
            setBorder(0);
        }

        private void Normal_label_Click(object sender, EventArgs e)
        {
            Settings.Difficulty = 1;
            setBorder(1);
        }

        private void Hard_label_Click(object sender, EventArgs e)
        {
            Settings.Difficulty = 2;
            setBorder(2);
        }

        private void setBorder(int diff)
        {
            if (Settings.Difficulty == 0)
            {
                Easy_label.BorderStyle = BorderStyle.FixedSingle;
                Normal_label.BorderStyle = BorderStyle.None;
                Hard_label.BorderStyle = BorderStyle.None;
            }
            if (Settings.Difficulty == 1)
            {
                Easy_label.BorderStyle = BorderStyle.None;
                Normal_label.BorderStyle = BorderStyle.FixedSingle;
                Hard_label.BorderStyle = BorderStyle.None;
            }
            if (Settings.Difficulty == 2)
            {
                Easy_label.BorderStyle = BorderStyle.None;
                Normal_label.BorderStyle = BorderStyle.None;
                Hard_label.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            this.Hide();
            m.Show();
            
        }
    }
}
