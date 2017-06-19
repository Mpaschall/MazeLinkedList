using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maze
{
    class LLCreate
    {
        //this class created 6/18/17
        //creates a linked list of nodes
        private Node head;
        private Node tail;
        public int count;

        public LLCreate()
        {
            head = new Node();
            tail = head;
        }

        public void addToTail(object el)
        {
            Node added = new Node();
            added.info = el;
            tail.next = added;
            tail = added;
            count++;
        }

        public void printList()
        {
            Node current = head;
            while (current.next != null)
            {                
                current = current.next;
                Console.WriteLine(current.info);
                
                
            }
            
        }
    }
}
