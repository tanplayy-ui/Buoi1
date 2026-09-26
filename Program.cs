using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        List<Person> danhSach = new List<Person>();

        bool thoat = false;

        while (!thoat)
        {
            Console.WriteLine("\n========== MENU ==========");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Them giao vien");
            Console.WriteLine("3. Xuat danh sach sinh vien");
            Console.WriteLine("4. Xuat danh sach giao vien");
            Console.WriteLine("5. So luong sinh vien va giao vien");
            Console.WriteLine("6. Xuat sinh vien thuoc khoa CNTT");
            Console.WriteLine("7. Xuat giao vien co dia chi chua Quan 9");
            Console.WriteLine("8. Sinh vien co diem TB cao nhat thuoc khoa CNTT");
            Console.WriteLine("9. Thong ke so luong tung xep loai");
            Console.WriteLine("0. Thoat");

            Console.Write("Chon chuc nang: ");
            string luaChon = Console.ReadLine();

            switch (luaChon)
            {
                case "1":
                    ThemSinhVien(danhSach);
                    break;

                case "2":
                    ThemGiaoVien(danhSach);
                    break;

                case "3":
                    XuatDanhSachSinhVien(danhSach);
                    break;

                case "4":
                    XuatDanhSachGiaoVien(danhSach);
                    break;

                case "5":
                    DemSinhVienVaGiaoVien(danhSach);
                    break;

                case "6":
                    XuatSinhVienTheoKhoa(danhSach, "CNTT");
                    break;

                case "7":
                    XuatGiaoVienTheoDiaChi(danhSach, "Quan 9");
                    break;

                case "8":
                    XuatSinhVienDiemCaoNhat(danhSach, "CNTT");
                    break;

                case "9":
                    DemXepLoaiSinhVien(danhSach);
                    break;

                case "0":
                    thoat = true;
                    Console.WriteLine("Ket thuc chuong trinh.");
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
        }
    }

    static void ThemSinhVien(List<Person> danhSach)
    {
        Console.WriteLine("\n=== NHAP THONG TIN SINH VIEN ===");

        Student sinhVien = new Student();
        sinhVien.Nhap();

        danhSach.Add(sinhVien);

        Console.WriteLine("Them sinh vien thanh cong!");
    }

    static void ThemGiaoVien(List<Person> danhSach)
    {
        Console.WriteLine("\n=== NHAP THONG TIN GIAO VIEN ===");

        Teacher giaoVien = new Teacher();
        giaoVien.Nhap();

        danhSach.Add(giaoVien);

        Console.WriteLine("Them giao vien thanh cong!");
    }

    static void XuatDanhSachSinhVien(List<Person> danhSach)
    {
        Console.WriteLine("\n=== DANH SACH SINH VIEN ===");

        var danhSachSinhVien = danhSach
            .OfType<Student>()
            .ToList();

        foreach (Student sinhVien in danhSachSinhVien)
        {
            sinhVien.Xuat();
        }
    }

    static void XuatDanhSachGiaoVien(List<Person> danhSach)
    {
        Console.WriteLine("\n=== DANH SACH GIAO VIEN ===");

        var danhSachGiaoVien = danhSach
            .OfType<Teacher>()
            .ToList();

        foreach (Teacher giaoVien in danhSachGiaoVien)
        {
            giaoVien.Xuat();
        }
    }

    static void DemSinhVienVaGiaoVien(List<Person> danhSach)
    {
        int soSinhVien = danhSach
            .OfType<Student>()
            .Count();

        int soGiaoVien = danhSach
            .OfType<Teacher>()
            .Count();

        Console.WriteLine("\n=== SO LUONG ===");
        Console.WriteLine("Tong so sinh vien: " + soSinhVien);
        Console.WriteLine("Tong so giao vien: " + soGiaoVien);
    }

    static void XuatSinhVienTheoKhoa(
        List<Person> danhSach,
        string khoa)
    {
        Console.WriteLine(
            "\n=== SINH VIEN THUOC KHOA {0} ===",
            khoa);

        var danhSachSinhVien = danhSach
            .OfType<Student>()
            .Where(s =>
                BoDauTiengViet(s.Faculty)
                .Equals(
                    BoDauTiengViet(khoa),
                    StringComparison.OrdinalIgnoreCase))
            .ToList();

        foreach (Student sinhVien in danhSachSinhVien)
        {
            sinhVien.Xuat();
        }
    }

    static void XuatGiaoVienTheoDiaChi(
        List<Person> danhSach,
        string diaChi)
    {
        Console.WriteLine(
            "\n=== GIAO VIEN CO DIA CHI CHUA {0} ===",
            diaChi);

        var danhSachGiaoVien = danhSach
            .OfType<Teacher>()
            .Where(g =>
                BoDauTiengViet(g.Address)
                .Contains(
                    BoDauTiengViet(diaChi),
                    StringComparison.OrdinalIgnoreCase))
            .ToList();

        foreach (Teacher giaoVien in danhSachGiaoVien)
        {
            giaoVien.Xuat();
        }
    }

    static void XuatSinhVienDiemCaoNhat(
        List<Person> danhSach,
        string khoa)
    {
        Console.WriteLine(
            "\n=== SINH VIEN CO DIEM CAO NHAT KHOA {0} ===",
            khoa);

        var danhSachSinhVien = danhSach
            .OfType<Student>()
            .Where(s =>
                BoDauTiengViet(s.Faculty)
                .Equals(
                    BoDauTiengViet(khoa),
                    StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (danhSachSinhVien.Count == 0)
        {
            Console.WriteLine(
                "Khong co sinh vien thuoc khoa " + khoa);
            return;
        }

        float diemCaoNhat = danhSachSinhVien
            .Max(s => s.AverageScore);

        var ketQua = danhSachSinhVien
            .Where(s => s.AverageScore == diemCaoNhat)
            .ToList();

        foreach (Student sinhVien in ketQua)
        {
            sinhVien.Xuat();
        }
    }

    static void DemXepLoaiSinhVien(
        List<Person> danhSach)
    {
        var danhSachSinhVien = danhSach
            .OfType<Student>()
            .ToList();

        int xuatSac = danhSachSinhVien.Count(
            s => s.AverageScore >= 9 &&
                 s.AverageScore <= 10);

        int gioi = danhSachSinhVien.Count(
            s => s.AverageScore >= 8 &&
                 s.AverageScore < 9);

        int kha = danhSachSinhVien.Count(
            s => s.AverageScore >= 7 &&
                 s.AverageScore < 8);

        int trungBinh = danhSachSinhVien.Count(
            s => s.AverageScore >= 5 &&
                 s.AverageScore < 7);

        int yeu = danhSachSinhVien.Count(
            s => s.AverageScore >= 4 &&
                 s.AverageScore < 5);

        int kem = danhSachSinhVien.Count(
            s => s.AverageScore < 4);

        Console.WriteLine("\n=== THONG KE XEP LOAI ===");
        Console.WriteLine("Xuat sac: " + xuatSac);
        Console.WriteLine("Gioi: " + gioi);
        Console.WriteLine("Kha: " + kha);
        Console.WriteLine("Trung binh: " + trungBinh);
        Console.WriteLine("Yeu: " + yeu);
        Console.WriteLine("Kem: " + kem);
    }

    static string BoDauTiengViet(string chuoi)
    {
        if (string.IsNullOrEmpty(chuoi))
            return chuoi;

        string chuoiDaChuanHoa =
            chuoi.Normalize(NormalizationForm.FormD);

        StringBuilder ketQua = new StringBuilder();

        foreach (char kyTu in chuoiDaChuanHoa)
        {
            UnicodeCategory loai =
                CharUnicodeInfo.GetUnicodeCategory(kyTu);

            if (loai != UnicodeCategory.NonSpacingMark)
            {
                ketQua.Append(kyTu);
            }
        }

        return ketQua
            .ToString()
            .Replace("đ", "d")
            .Replace("Đ", "D");
    }
}