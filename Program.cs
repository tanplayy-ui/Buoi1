
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<Student> studentList = new List<Student>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Them SV");
            Console.WriteLine("2. Hien thi ds SV");
            Console.WriteLine("3. Xuat SV thuoc khoa CNTT");
            Console.WriteLine("4. Xuat SV co diem TB >= 5");
            Console.WriteLine("5. Sap xep SV theo diem TB tang dan");
            Console.WriteLine("6. Xuat SV co diem TB >= 5 thuoc khoa CNTT");
            Console.WriteLine("7. Xuat SV co diem TB cao nhat thuoc khoa CNTT");
            Console.WriteLine("8. Thong ke so luong SV theo xep loai");
            Console.WriteLine("0. Thoat");
            Console.Write("CHON CHUC NANG (TU 0 -> 8): ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddStudent(studentList);
                    break;

                case "2":
                    DisplayStudentList(studentList);
                    break;

                case "3":
                    DisplayStudentsByFaculty(studentList, "CNTT");
                    break;

                case "4":
                    DisplayStudentsWithHighAverageScore(studentList, 5);
                    break;

                case "5":
                    SortStudentsByAverageScore(studentList);
                    break;

                case "6":
                    DisplayStudentsByFacultyAndScore(
                        studentList, "CNTT", 5);
                    break;

                case "7":
                    DisplayStudentsWithHighestAverageScoreByFaculty(
                        studentList, "CNTT");
                    break;

                case "8":
                    CountStudentsByClassification(studentList);
                    break;

                case "0":
                    exit = true;
                    Console.WriteLine("Ket thuc chuong trinh.");
                    break;

                default:
                    Console.WriteLine(
                        "Tuy chon khong hop le. Vui long chon lai.");
                    break;
            }

            Console.WriteLine();
        }
    }
    static void AddStudent(List<Student> studentList)
    {
        Console.WriteLine("=== Nhap thong tin SV ===");

        Student student = new Student();

        student.Input();

        studentList.Add(student);

        Console.WriteLine("Them SV thanh cong!");
    }
    static void DisplayStudentList(List<Student> studentList)
    {
        Console.WriteLine(
            "=== Danh sach chi tiet thong tin SV ===");

        foreach (Student student in studentList)
        {
            student.Show();
        }
    }
    static void DisplayStudentsByFaculty(
        List<Student> studentList, string faculty)
    {
        Console.WriteLine(
            "=== Danh sach SV thuoc khoa {0} ===",
            faculty);

        var students = studentList
            .Where(s => s.Faculty.Equals(
                faculty,
                StringComparison.OrdinalIgnoreCase))
            .ToList();

        DisplayStudentList(students);
    }
    static void DisplayStudentsWithHighAverageScore(
        List<Student> studentList, float minDTB)
    {
        Console.WriteLine(
            "=== Danh sach sinh vien co diem TB >= {0} ===",
            minDTB);

        var students = studentList
            .Where(s => s.AverageScore >= minDTB)
            .ToList();

        DisplayStudentList(students);
    }
    static void SortStudentsByAverageScore(
        List<Student> studentList)
    {
        Console.WriteLine(
            "=== danh sach SV duoc sap xep " +
            "theo diem TB tang dan ===");

        var sortedStudents = studentList
            .OrderBy(s => s.AverageScore)
            .ToList();

        DisplayStudentList(sortedStudents);
    }
    static void DisplayStudentsByFacultyAndScore(
        List<Student> studentList,
        string faculty,
        float minDTB)
    {
        Console.WriteLine(
            "=== Danh sach SV co diem TB >= {0} " +
            "va thuoc khoa {1} ===",
            minDTB, faculty);

        var students = studentList
            .Where(s =>
                s.AverageScore >= minDTB &&
                s.Faculty.Equals(
                    faculty,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();

        DisplayStudentList(students);
    }
    static void DisplayStudentsWithHighestAverageScoreByFaculty(
        List<Student> studentList,
        string faculty)
    {
        Console.WriteLine(
            "=== SV co diem TB cao nhat " +
            "thuoc khoa {0} ===",
            faculty);

        var students = studentList
            .Where(s => s.Faculty.Equals(
                faculty,
                StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (students.Count == 0)
        {
            Console.WriteLine("Khong co SV thuoc khoa " + faculty);
            return;
        }

        float maxScore = students.Max(s => s.AverageScore);

        var result = students
            .Where(s => s.AverageScore == maxScore)
            .ToList();

        DisplayStudentList(result);
    }
    static void CountStudentsByClassification(
        List<Student> studentList)
    {
        int xuatSac = studentList.Count(
            s => s.AverageScore >= 9.0f &&
                 s.AverageScore <= 10.0f);

        int gioi = studentList.Count(
            s => s.AverageScore >= 8.0f &&
                 s.AverageScore < 9.0f);

        int kha = studentList.Count(
            s => s.AverageScore >= 7.0f &&
                 s.AverageScore < 8.0f);

        int trungBinh = studentList.Count(
            s => s.AverageScore >= 5.0f &&
                 s.AverageScore < 7.0f);

        int yeu = studentList.Count(
            s => s.AverageScore >= 4.0f &&
                 s.AverageScore < 5.0f);

        int kem = studentList.Count(
            s => s.AverageScore < 4.0f);

        Console.WriteLine("=== THONG KE XEP LOAI ===");

        Console.WriteLine("Xuất sắc: {0}", xuatSac);
        Console.WriteLine("Giỏi:     {0}", gioi);
        Console.WriteLine("Khá:      {0}", kha);
        Console.WriteLine("Trung bình: {0}", trungBinh);
        Console.WriteLine("Yếu:      {0}", yeu);
        Console.WriteLine("Kém:      {0}", kem);
    }
}