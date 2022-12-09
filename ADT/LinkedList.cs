using System.Collections.Generic;

namespace ADT
{
    public class LinkedList
    {
        // code provided by our educators
        private class Node
        {
            public object Data { get; set; }
            public Node Next { get; set; }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        private Node head = new Node();

        private int _count;
        public int Count { get { return _count; } }

        public object First
        {
            get
            {
                //if (Count != 0)
                //{
                //    return ItemAt(0);
                //}
                //else
                //{
                //    return null;
                //}

                // ternary conditional operator
                // condition ? if true : if false
                return (Count == 0) ? null : ItemAt(0);
            }
        }

        public object Last
        {
            get
            {
                return (Count == 0) ? null : ItemAt(Count - 1);
            }
        }

        public void InsertAt(int index, object o)
        {
            if (index > Count && index < 0)
                throw new IndexOutOfRangeException();

            Node currentNode = head;

            for (int i = 0; i < index; i++)
                currentNode = currentNode.Next;

            Node newNode = new Node(); // create new node
            newNode.Data = o; // assign data as object 'o'

            newNode.Next = currentNode.Next; // assign the next reference of our newNode to the currentNodes next reference
            currentNode.Next = newNode; // set the headers next node to our new node

            _count++;
        }

        public void Insert(object o)
        {
            InsertAt(0, o);
        }

        public void Append(object o)
        {
            InsertAt(Count, o);
        }

        public void DeleteAt(int index)
        {
            Node currentNode = head;

            for (int i = 0; i < index; i++)
                currentNode = currentNode.Next;

            currentNode.Next = currentNode.Next.Next;

            _count--;
        }

        public object ItemAt(int index)
        {
            Node currentNode = head;

            for (int i = 0; i <= index; i++)
                currentNode = currentNode.Next;

            return currentNode.Data;
        }

        public override string ToString()
        {
            // return the sum of all 'ToString' from all nodes

            Node currentNode = head.Next; // first node that holds data
            string result = string.Empty; // initialize the final string

            while (currentNode != null) // while we're not at the end of the linked list
            {
                result += currentNode.ToString(); // add the node's ToString() to our string

                if (currentNode.Next != null) // if the currentNode is not the last
                    result += "\n"; // add a newline

                currentNode = currentNode.Next; // go to next node
            }

            return result;
        }
    }
}