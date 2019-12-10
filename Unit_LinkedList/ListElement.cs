namespace Unit_LinkedList
{
    public class ListElement<T>
    {
        public T Value { get; set; }
        
        public ListElement<T> Previous  { get; set; }
        public ListElement<T> Next { get; set; }

        public ListElement(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}