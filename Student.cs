using System;

class Student : Person
{
    private float averageScore;
    private string faculty;

    public float AverageScore
    {
        get => averageScore;
        set => averageScore = value;
    }

    public string Faculty
    {
        get => faculty;
        set => faculty = value;
    }

    public Student()
    {
    }

    public Student(
        string id,
        string fullName,
        float averageScore,
        string faculty)
        : base(id, fullName)
    {
        this.averageScore = averageScore;
        this.faculty = faculty;
    }

    public override void Nhap()
    {
        base.Nhap();

        Console.Write("Nhap diem TB: ");
        AverageScore = float.Parse(Console.ReadLine());

        Console.Write("Nhap khoa: ");
        Faculty = Console.ReadLine();
    }

    public override void Xuat()
    {
        Console.WriteLine(
            "MSSV: {0} - Ho ten: {1} - Khoa: {2} - Diem TB: {3}",
            ID, FullName, Faculty, AverageScore);
    }
}