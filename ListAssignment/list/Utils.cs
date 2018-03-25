using System;
using System.IO;
using System.Globalization;
using ListAssignment;

namespace Utils
{

    public class UtilsCLass
    {
        public String[] readFile(String file) {
            return System.IO.File.ReadAllLines(file);
        }

        public Student[] loadStudents(String file) {
            Student[] students = new Student[400];

            var path = Path.Combine(Directory.GetCurrentDirectory(), file);
            String[] lines = this.readFile(file);
            String cleanedLine;
            int i = 0;
            foreach (string line in lines)
            {
                // Console.WriteLine(line);
                cleanedLine = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ");
                string[] tokens = cleanedLine.Split(' ');
                students[i] = new Student(tokens[0], Int32.Parse(tokens[1]), Int32.Parse(tokens[2]), Double.Parse(tokens[3], CultureInfo.InvariantCulture));
                i++;
            }

            return students;
        }

        public ListStudent createListFromFile(String file) {
            Student[] students = this.loadStudents(file);

            ListStudent list = new ListStudent();

            int i = 0;
            while(students[i] != null) {
                list.addAtEnd(new ListElement<Student>(students[i]));
                i++;
            }

            return list;
        }
    }
}
