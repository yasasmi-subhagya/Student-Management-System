using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    class Node
    {
        private Student data;
        private Node next;

        internal Student Data { get => data; set => data = value; }
        internal Node Next { get => next; set => next = value; }

        public Node(Student data)
        {
            Data = data;
            Next = null;
        }
    }


}
