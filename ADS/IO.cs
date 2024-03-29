﻿namespace ADS
{
    internal static class IO
    {
        internal static string Get(string Description)
        {
            Console.Write($"{Description} ");
            var tmp = Console.ReadLine();
            return tmp ?? string.Empty;
        }

        internal static void Send(string value = "")
        {
            Console.Write(value);
        }

        internal static void SendLine(string value = "")
        {
            Console.WriteLine(value);
        }
    }
}
