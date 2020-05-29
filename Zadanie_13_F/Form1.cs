using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_13_F
{
    public partial class Form1 : Form
    {
        PO[] soft = new PO[]{new Free ("word", "tba"),
                            new Shareware("excel", "microsoft", "12.03.1989", 50, 100),
                            new Shareware("notepad", "net", "05.05.1990", 30, 20),
                            new Commercial("NFS most wonted", "EArts", "27.09.2008", 50, 200, 3650),
                            new Free("paint", "microsoft")};

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (PO p in soft)
            {
                all.Text += Environment.NewLine;
                all.Text += p.Info();
                all.Text += Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (PO p in soft)
                if (p.ItIsAWorks())
                {
                    all_t.Text += p.ProgramName;
                    all_t.Text += Environment.NewLine;
                }
        }
    }

    abstract class PO
    {
        protected string name;
        protected string company;
        protected DateTime dateOfInstall;
        protected byte demo_preiod;
        protected int cost;

        public PO(string name, string company, string date, byte demo_period, int cost)
        {
            this.name = name;
            this.company = company;
            this.dateOfInstall = DateTime.Parse(date);
            this.demo_preiod = demo_period;
            this.cost = cost;
        }

        public virtual string Info()
        {
            return "Имя продукта: " + name + "\nПроизводитель: "
                                 + company + "\nдата установки ПО: " + dateOfInstall
                                 + "\nПериод бесплатного использования: " + demo_preiod
                                 + "\nстоимость продукта: " + cost + "\n";
        }

        public virtual bool ItIsAWorks()
        {
            if (dateOfInstall.AddDays(demo_preiod) >= DateTime.Now) return true;
            return false;
        }

        public string ProgramName
        {
            get { return name; }
        }
    }

    class Free : PO
    {
        public Free(string name, string company) : base(name, company, "01.01.2000", 0, 0)
        { }

        public override string Info()
        {
            return "Имя продукта: " + name + "\nПроизводитель: "
                                 + company + "\n";
        }

        public override bool ItIsAWorks()
        {
            return true;
        }
    }
    class Shareware : PO
    {
        public Shareware(string name, string company, string date, byte demo_period, int cost)
            : base(name, company, date, demo_period, cost)
        { }

        public override string Info()
        {
            return "Имя продукта: " + name + "\nПроизводитель: "
                                 + company + Environment.NewLine + "\nДата установки ПО: " + dateOfInstall.ToShortDateString()
                                 + "\nПериод бесплатного использования: " + demo_preiod
                                 + Environment.NewLine + "\nCтоимость продукта: " + cost + "euro\n";
        }

        public override bool ItIsAWorks()
        {
            if (dateOfInstall.AddDays(demo_preiod) >= DateTime.Now) return true;
            return false;
        }
    }
    class Commercial : PO
    {
        int period;

        public Commercial(string name, string company, string date, byte demo_period, int cost, int period)
            : base(name, company, date, 0, cost)
        { this.period = period; }

        public override string Info()
        {
            return "Имя продукта: " + name + "\nПроизводитель: "
                                 + company + "\nДата установки ПО: " + dateOfInstall.ToShortDateString()
                                 + "\nСтоимость продукта: " + cost + "euro \nПериод использования: " + period + "\n";
        }

        public override bool ItIsAWorks()
        {
            if (dateOfInstall.AddDays(period) >= DateTime.Now) return true;
            return false;
        }
    }
}
