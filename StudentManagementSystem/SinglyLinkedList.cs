using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    using System;


    class SinglyLinkedList
    {
        private Node head;
        private Node tail;

        internal Node Head { get => head; private set => head = value; }
        internal Node Tail { get => tail; private set => tail = value; }

        public SinglyLinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddItemToHead(Node item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.Next = head;
            head = item;
            if (tail == null)
                tail = item;
        }

        public void AddItemToTail(Node item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.Next = null;
            if (head == null)
            {
                head = item;
                tail = item;
            }
            else
            {
                tail.Next = item;
                tail = item;
            }
        }

        public void AddItemPosition(Node item, int position)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (position <= 1 || head == null)
            {
                AddItemToHead(item);
                return;
            }

            Node current = head;
            int currentIndex = 1;
            while (current.Next != null && currentIndex < position - 1)
            {
                current = current.Next;
                currentIndex++;
            }

            item.Next = current.Next;
            current.Next = item;

            if (item.Next == null)
                tail = item;
        }

        public Node SearchNode(string index_no)
        {
            if (string.IsNullOrEmpty(index_no)) return null;
            Node current = head;
            while (current != null)
            {
                if (current.Data.Index_no == index_no)
                    return current;
                current = current.Next;
            }
            return null;
        }

        public void DelItem(string index_no)
        {
            if (head == null || string.IsNullOrEmpty(index_no)) return;

            // If head needs to be removed
            if (head.Data.Index_no == index_no)
            {
                head = head.Next;
                if (head == null)
                    tail = null;
                return;
            }

            Node current = head;
            while (current.Next != null && current.Next.Data.Index_no != index_no)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                if (current.Next == tail)
                    tail = current;
                current.Next = current.Next.Next;
            }
        }

        public void DelLastItem()
        {
            if (head == null) return;
            if (head == tail)
            {
                head = null;
                tail = null;
                return;
            }
            Node current = head;
            while (current.Next != tail)
            {
                current = current.Next;
            }
            current.Next = null;
            tail = current;
        }

        public void DelFirstItem()
        {
            if (head == null) return;
            head = head.Next;
            if (head == null)
                tail = null;
        }

        public void ShowList()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            Node current = head;
            Console.WriteLine("Index_no\tName\tGPA\tAdmission_year\tNIC");
            while (current != null)
            {
                var s = current.Data;
                Console.WriteLine($"{s.Index_no}\t{s.Name}\t{s.GPA1}\t{s.Admission_year}\t{s.NIC1}");
                current = current.Next;
            }
            Console.WriteLine("..");
        }


        public void AddItemAscending(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            // Use string comparison for Index_no to support both numeric and alphanumeric
            string newIndex = student.Index_no;

            // Check for uniqueness
            Node current = head;
            while (current != null)
            {
                if (current.Data.Index_no == newIndex)
                {
                    // Duplicate found, do not insert
                    return;
                }
                current = current.Next;
            }

            Node newNode = new Node(student);

            // Insert at head if list is empty or newIndex is less than head's Index_no
            if (head == null || string.Compare(newIndex, head.Data.Index_no, StringComparison.Ordinal) < 0)
            {
                newNode.Next = head;
                head = newNode;
                if (tail == null)
                    tail = newNode;
                return;
            }

            current = head;
            // Find the node after which to insert the new node
            while (current.Next != null && string.Compare(current.Next.Data.Index_no, newIndex, StringComparison.Ordinal) < 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;

            if (newNode.Next == null)
                tail = newNode;
        }


    }
}







