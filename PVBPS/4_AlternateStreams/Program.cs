using CodeFluent.Runtime.BinaryServices;
using System;
using System.Collections;
using System.IO;

namespace MIC0378AltStream
{
    class Program
    {

        static void Main(string[] args)
        {
            string filePath = @"D:\Users\granders\Desktop\AltStreams\test.txt:altstream.txt";
            FileStream stream = NtfsAlternateStream.Open(filePath, FileAccess.Write, FileMode.OpenOrCreate, FileShare.None);
            stream.Close();

            NtfsAlternateStream.WriteAllText(filePath, "MIC0378; " + DateTime.Now);
            Console.WriteLine("Proběhl zápis do alternativního streamu.");

            string altStreamContent = NtfsAlternateStream.ReadAllText(filePath);
            Console.WriteLine("Výpis alternativního streamu: " + altStreamContent);

            Console.ReadLine();
        }
    }
}