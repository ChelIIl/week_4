using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        PO[] soft = new PO[]{new Free ("word", "tba"),
                            new Shareware("excel", "microsoft", "12.03.1989", 50, 100),
                            new Shareware("notepad", "net", "05.05.1990", 30, 20),
                            new Commercial("NFS most wonted", "EArts", "27.09.2008", 50, 200, 3650),
                            new Free("paint", "microsoft")};

        Console.WriteLine("Весь список ПО:");
        foreach (PO p in soft)
            p.Info();

        Console.WriteLine("Список ПО, которое можно использовать на сегодняшний день: ");
        foreach (PO p in soft)
            if (p.ItIsAWorks()) Console.WriteLine(p.ProgramName);

        Console.ReadLine();
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

    public virtual void Info()
    {
        Console.WriteLine("\nИмя продукта: " + name + " Производитель: "
                             + company + " дата установки ПО: " + dateOfInstall
                             + "Период бесплатного использования: " + demo_preiod
                             + " стоимость продукта: " + cost + "\n");
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

    public override void Info()
    {
        Console.WriteLine("Имя продукта: " + name + "\nПроизводитель: "
                             + company + "\n");
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

    public override void Info()
    {
        Console.WriteLine("Имя продукта: " + name + "\nПроизводитель: "
                             + company + "\nДата установки ПО: " + dateOfInstall.ToShortDateString()
                             + "\nПериод бесплатного использования: " + demo_preiod
                             + "\nCтоимость продукта: " + cost + "euro\n");
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

    public override void Info()
    {
        Console.WriteLine("Имя продукта: " + name + "\nПроизводитель: "
                             + company + "\nДата установки ПО: " + dateOfInstall.ToShortDateString()
                             + "\nСтоимость продукта: " + cost + "euro \nПериод использования: " + period + "\n");
    }

    public override bool ItIsAWorks()
    {
        if (dateOfInstall.AddDays(period) >= DateTime.Now) return true;
        return false;
    }
}