using System;

namespace Events_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"Start\" to raise event!");
            string command = Console.ReadLine().ToLower();

            if (command == "start")
            {
                EventPublisher eventPublisher = new EventPublisher();
                EventHandler eventHandler = new EventHandler(eventPublisher);

                eventPublisher.RaiseEvent("EVENT PARAMETER");
            }
        }
    }
}
