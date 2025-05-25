using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    class Student
    {
        private string index_no ;
        private string name;
        private double GPA;
        private string admission_year;
        private string NIC;

        public string Index_no { get => index_no; set => index_no = value; }
        public string Name { get => name; set => name = value; }
        public double GPA1 { get => GPA; set => GPA = value; }
        public string Admission_year { get => admission_year; set => admission_year = value; }
        public string NIC1 { get => NIC; set => NIC = value; }

        public Student(string index_number, string name, double GPA, string admission_year, string NIC)    
        {
            Index_no = admission_year+index_number;
            Name = name;
            GPA1 = GPA;
            Admission_year = admission_year;
            NIC1 = NIC;
            
        }
    }
}
