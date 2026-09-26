using System;

class Teacher : Person
{
    private string address;

    public string Address
    {
        get => address;
        set => address = value;
    }

    public Teacher()
    {
    }

    public Teacher(
        string id,
        string fullName,
        string address)
        : base(id, fullName)
    {
        this.address = address;
    }

    public override void Nhap()
    {
        base.Nhap();

        Console.Write("Nhap dia chi: ");
        Address = Console.ReadLine();
    }

    public override void Xuat()
    {
        Console.WriteLine(
            "MSGV: {0} - Ho ten: {1} - Dia chi: {2}",
            ID, FullName, Address);
    }
}