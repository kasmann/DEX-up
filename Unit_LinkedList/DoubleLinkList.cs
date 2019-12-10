using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Unit_LinkedList
{
    public class DoubleLinkList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }

        public ListElement<T> Head;
        public ListElement<T> Tail;

        public void AddFirst(T data)
        {
            var element = new ListElement<T>(data);
            
            if (Head == null)
            {
                Head = element;
                Tail = Head;
            }
            else
            {
                var tmp = Head;
               
                Head = element;
                Head.Next = tmp;
            }
            Count++;
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                AddFirst(data);
            }
            else
            {
                var tmp = Tail;

                var element = new ListElement<T>(data);
                Tail = element;
                Tail.Previous = tmp;
                tmp.Next = element;
                Count++;
            }
        }

        public void AddBefore(T before, T data)
        {
            var tmp = findElement(before);

            var newElement = new ListElement<T>(data);
            if (tmp == Head)
            {
                Head = newElement;
                Head.Next = tmp;
                tmp.Previous = Head;
            }
            else
            {
                tmp.Previous.Next = newElement;

                newElement.Previous = tmp.Previous;
                newElement.Next = tmp;

                tmp.Previous = newElement;
            }
            Count++;
        }

       

        public void RemoveFirst()
        {
            Head = Head.Next;
            Head.Previous = null;
            Count--;
        }

        public void Remove(T data)
        {
            var tmp = findElement(data);
            tmp.Previous.Next = tmp.Next;
            tmp.Next.Previous = tmp.Previous;
            Count--;
        }

        public void RemoveLast()
        {
            Tail = Tail.Previous;
            Tail.Next = null;
            Count--;
        }

        public void Replace(T replaceWhat, T replaceWith)
        {
            var tmp = findElement(replaceWhat);
            tmp.Value = replaceWith;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        
        public void Print()
        {
            if (Head == null) return;
            
            var tmp = Head;
            while (tmp != null)
            {
                Console.WriteLine(tmp.Value);
                tmp = tmp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackwardEnumerator()
        {
            var current = Tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        private ListElement<T> findElement(T element)
        {
            var tmp = Head;

            while (tmp != null && !tmp.Value.Equals(element))
            {
                tmp = tmp.Next;
            }

            if (tmp == null)
            {
                throw new NotFoundException($"List doesn't contain element with value \"{element}\"");
            }

            return tmp;
        }
    }
}