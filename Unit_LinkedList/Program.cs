using System;
using System.Collections;
using System.Collections.Generic;

namespace Unit_LinkedList
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var list = new DoubleLinkList<string>();
            
            list.Add("first");
            list.Add("second");
            list.Add("third");
            list.Add("fourth");
            list.Add("fifth");
            list.Add("sixth");

            list.Print();
            Console.WriteLine();

            ForwardPrint(list);
            BackwardPrint(list);

            list.Add("new element");
            list.AddFirst("new first element");
            try
            {
                list.AddBefore("fourth", "before fourth");
                list.AddBefore("4th", "before 4th");
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            ForwardPrint(list);
            
            try
            {
                list.Replace("fourth", "4th");
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            
            ForwardPrint(list);
            
            list.RemoveFirst();
            list.RemoveLast();
            try
            {
                list.Remove("4th");
                list.Remove("fourth");
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            
            ForwardPrint(list);
            list.Clear();
            list.Print();
        }
       
        private static void ForwardPrint(DoubleLinkList<string> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }
        
        private static void BackwardPrint(DoubleLinkList<string> list)
        {
            foreach (var element in list.BackwardEnumerator())
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }

    }
}