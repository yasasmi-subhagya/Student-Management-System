using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace StudentManagementSystem
{
    class Program
    {
        public static void ShowWelcome()
        {
            Console.WriteLine("Welcome to the student management system");
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt + " : ");
            return Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            ShowWelcome();
            SinglyLinkedList list = new SinglyLinkedList();
            int answer;
            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1 - Add student");
                Console.WriteLine("2 - Search student");
                Console.WriteLine("3 - Delete student");
                Console.WriteLine("4 - Print students");
                Console.WriteLine("0 - Exit");
                Console.Write("answer : ");
                if (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (answer == 1)
                {
                    Console.WriteLine("Enter student details");
                    string index_number = ReadString("Enter the index number");
                    string name = ReadString("Enter the name");
                    double GPA;
                    while (true)
                    {
                        string gpaInput = ReadString("Enter the GPA");
                        if (double.TryParse(gpaInput, out GPA))
                            break;
                        Console.WriteLine("Invalid GPA. Please enter a valid number.");
                    }
                    string admission_year = ReadString("Enter the admission year");
                    string NIC = ReadString("Enter the NIC");

                    Student student = new Student(index_number, name, GPA, admission_year, NIC);

                    
                    int countBefore = 0, countAfter = 0;
                    Node temp = list.Head;
                    while (temp != null) { countBefore++; temp = temp.Next; }

                    list.AddItemAscending(student);

                    temp = list.Head;
                    while (temp != null) { countAfter++; temp = temp.Next; }

                    if (countAfter == countBefore)
                        Console.WriteLine("Student with this index number already exists. Not added.");
                    else
                        Console.WriteLine("Student added successfully.");
                }
                else if (answer == 2)
                {
                    string searchIndex = ReadString("Enter the index number to search");
                    Node found = list.SearchNode(searchIndex);
                    if (found != null)
                    {
                        Console.WriteLine("Student found:");
                        Console.WriteLine($"Index: {found.Data.Index_no}, Name: {found.Data.Name}, GPA: {found.Data.GPA1}, Year: {found.Data.Admission_year}, NIC: {found.Data.NIC1}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                else if (answer == 3)
                {
                    string delIndex = ReadString("Enter the index number to delete");
                    int countBefore = 0, countAfter = 0;
                    Node temp = list.Head;
                    while (temp != null) { countBefore++; temp = temp.Next; }

                    list.DelItem(delIndex);

                    temp = list.Head;
                    while (temp != null) { countAfter++; temp = temp.Next; }

                    if (countAfter < countBefore)
                        Console.WriteLine("Student deleted successfully.");
                    else
                        Console.WriteLine("Student not found.");
                }
                else if (answer == 4)
                {
                    list.ShowList();
                }
                else if (answer != 0)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }

            } while (answer != 0);

            Console.WriteLine("Exiting program. Goodbye!");
        }
    }
}
