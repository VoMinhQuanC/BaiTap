using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }  // Cho phép null
    public int Age { get; set; }
}

namespace Vd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tạo danh sách học sinh
            List<Student> students = new List<Student>()
            {
                new Student { Id = 1, Name = "An", Age = 15 },
                new Student { Id = 2, Name = "Binh", Age = 17 },
                new Student { Id = 3, Name = "Anh", Age = 16 },
                new Student { Id = 4, Name = "Cuong", Age = 18 },
                new Student { Id = 5, Name = "Dung", Age = 19 },
                new Student { Id = 6, Name = null, Age = 18 }  // Một sinh viên có tên null
            };

            // a. In toàn bộ danh sách học sinh
            Console.WriteLine("Danh sách toàn bộ học sinh:");
            foreach (var student in students)
            {
                // Sử dụng null-coalescing operator để in giá trị mặc định nếu Name là null
                Console.WriteLine($"ID: {student.Id}, Tên: {student.Name ?? "Chưa rõ"}, Tuổi: {student.Age}");
            }

            // b. Tìm và in ra danh sách học sinh có tuổi từ 15 đến 18
            var age15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
            if (age15to18.Any())
            {
                Console.WriteLine("\nHọc sinh có tuổi từ 15 đến 18:");
                foreach (var student in age15to18)
                {
                    Console.WriteLine($"ID: {student.Id}, Tên: {student.Name ?? "Chưa rõ"}, Tuổi: {student.Age}");
                }
            }
            else
            {
                Console.WriteLine("\nKhông có học sinh nào có tuổi từ 15 đến 18.");
            }

            // c. Tìm và in ra học sinh có tên bắt đầu bằng chữ "A"
            var nameStartsWithA = students.Where(s => s.Name != null && s.Name.StartsWith("A")).ToList();
            if (nameStartsWithA.Any())
            {
                Console.WriteLine("\nHọc sinh có tên bắt đầu bằng chữ 'A':");
                foreach (var student in nameStartsWithA)
                {
                    Console.WriteLine($"ID: {student.Id}, Tên: {student.Name}, Tuổi: {student.Age}");
                }
            }
            else
            {
                Console.WriteLine("\nKhông có học sinh nào có tên bắt đầu bằng chữ 'A'.");
            }

            // d. Tính tổng tuổi của tất cả học sinh
            var totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"\nTổng tuổi của tất cả học sinh: {totalAge}");

            // e. Tìm và in ra học sinh có tuổi lớn nhất
            var oldestStudent = students.OrderByDescending(s => s.Age).FirstOrDefault();
            if (oldestStudent != null)
            {
                Console.WriteLine($"\nHọc sinh có tuổi lớn nhất: ID: {oldestStudent.Id}, Tên: {oldestStudent.Name ?? "Chưa rõ"}, Tuổi: {oldestStudent.Age}");
            }

            // f. Sắp xếp danh sách học sinh theo tuổi tăng dần và in ra danh sách sau khi sắp xếp
            var sortedByAge = students.OrderBy(s => s.Age).ToList();
            Console.WriteLine("\nDanh sách học sinh theo tuổi tăng dần:");
            foreach (var student in sortedByAge)
            {
                Console.WriteLine($"ID: {student.Id}, Tên: {student.Name ?? "Chưa rõ"}, Tuổi: {student.Age}");
            }

            Console.ReadKey();
        }
    }
}
