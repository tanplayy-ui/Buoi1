using System;

class Person
{
    protected string id;
    protected string fullName;

    public string ID
    {
        get => id;
        set => id = value;
    }

    public string FullName
    {
        get => fullName;
        set => fullName = value;
    }

    public Person()
    {
    }

    public Person(string id, string fullName)
    {
        this.id = id;
        this.fullName = fullName;
    }

    public virtual void Nhap()
    {
        Console.Write("Nhap ma so: ");
        ID = Console.ReadLine();

        Console.Write("Nhap ho ten: ");
        FullName = Console.ReadLine();
    }

    public virtual void Xuat()
    {
        Console.WriteLine(
            "Ma so: {0} - Ho ten: {1}",
            ID, FullName);
    }
}