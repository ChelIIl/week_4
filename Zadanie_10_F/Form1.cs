using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Zadanie_10_F
{
    public partial class Form1 : Form
    {
        time time = new time();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time.date = dateTimePicker1.Value;
            n_d.Text = time.next_day();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            time.date = dateTimePicker1.Value;
            p_d.Text = time.prev_day();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            time.date = dateTimePicker1.Value;
            end_m.Text = time.end_month();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            time.date = dateTimePicker1.Value;
            
            v_y.Text = time.new_date;
        }
    }
}
