using System;
using System.ComponentModel;
using System.Data;

namespace Unit14
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var queue = new NotificationQueue<string>(10);
            queue.Notification += ShowNotification;
            queue.PropertyChanged += ShowPropertyChanged;
            
            queue.Add("1st");
            queue.Add("2nd");
            queue.Add("3st");
            queue.Add("4th");
            queue.Add("5th");
            queue.Add("6th");
            queue.Add("7th");
            queue.Add("8th");
            queue.Add("9th");
            queue.Add("10th");
            queue.Add("11th");
            
            queue.Clear();
            
            queue.Notification -= ShowNotification;
            queue.PropertyChanged -= ShowPropertyChanged;
            
            Console.WriteLine();
            
            var analyzer = new Analyzer(0.6);
            analyzer.BlunderFound += OnBlunderFound; 
            
            var rand = new Random();
            
            for (var i = 0; i < 35; i++)
            {
                var newValue = rand.Next(1, 5) * rand.NextDouble();
                analyzer.Add(newValue);
            }

            analyzer.Print();
            analyzer.BlunderFound -= OnBlunderFound;
        }
        
        static void ShowNotification(string message)
        {
            Console.WriteLine(message);
        }
        
        static void ShowPropertyChanged(object sender, PropertyChangedEventArgs property)
        {
            Console.WriteLine($"{property.PropertyName} value changed");
        }

        static void OnBlunderFound(double value)
        {
            Console.WriteLine($"Value {value:f4} is rough blunder.");
        }
    }
}