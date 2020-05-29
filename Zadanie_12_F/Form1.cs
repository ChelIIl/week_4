using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_12_F
{
    public partial class Form1 : Form
    {
        time time = new time();
        time da = new time();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time.date = dateTimePicker1.Value;

            if (!time)
                n_d.Text = "Не последний день месяца";

            else
                n_d.Text = "Последний день месяца";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            time.date = dateTimePicker1.Value;

            if (time)
                p_d.Text = "Начало года";

            else
                p_d.Text = "Не начало года";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            time.date = dateTimePicker1.Value;
            da.date = dateTimePicker2.Value;

            bool r = time & da;

            if (r == true)
                v_y.Text = "Даты равны";

            else
                v_y.Text = "Даты не равны";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = int.Parse(N.Text);

            time[n] = new DateTime();

            end_m.Text = time.date.ToString();
        }
    }
}
