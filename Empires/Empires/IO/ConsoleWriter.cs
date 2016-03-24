namespace Empires.IO
{
    using System;

    using Contracts;

    public class ConsoleWriter : IOutputWriter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
