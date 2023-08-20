namespace ADT
{
    public class LinkedList<T>
    {
        // code provided by our educators
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        private Node head = new Node();

        private int _count;
        public int Count { get { return _count; } }

        public T First
        {
            get
            {
                return (Count == 0) ? default : ItemAt(0);
            }
        }

        public T Last
        {
            get
            {
                return (Count == 0) ? default : ItemAt(Count - 1);
            }
        }

        public void InsertAt(int index, T o)
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

        public void Insert(T o)
        {
            InsertAt(0, o);
        }

        public void Append(T o)
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

        public T ItemAt(int index)
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
            string finalString = string.Empty; // initialize the final string

            while (currentNode != null) // while we're not at the end of the linked list
            {
                finalString += currentNode.ToString(); // add the nodes ToString() to our string

                if (currentNode.Next != null) // if the currentNode is not the last
                    finalString += "\n"; // add a newline

                currentNode = currentNode.Next; // go to next node
            }

            return finalString;
        }
    }
}