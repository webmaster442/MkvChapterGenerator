//-----------------------------------------------------------------------------
// (c) 2019 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
//-----------------------------------------------------------------------------

using MkvChapterGenerator.XmlObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MkvChapterGenerator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                PrintHelp(); 
                Environment.Exit(ExitCodes.ExitHelp);
            }

            try
            {
                if (!File.Exists(args[0]))
                {
                    Console.WriteLine("Error: Input file doesn't exist.");
                    Environment.Exit(ExitCodes.InputFileNotExist);
                }

                List<string> lines = ReadInputFile(args[0]);
                
                Chapters xml = XmlFactory.BuildChapters(lines);

                SerializeXML(xml, args[1]);

                Environment.Exit(ExitCodes.ExitOk);
            }
            catch (Exception e)
            {
                PrintException(e);
                Environment.Exit(ExitCodes.Exception);
            }
        }

        private static void SerializeXML(Chapters xml, string target)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Chapters));
            var Namespaces = new XmlSerializerNamespaces();
            //no namespaces
            Namespaces.Add("", "");
            using var outp = File.Create(target);
            xs.Serialize(outp, xml, Namespaces);
        }

        private static List<string> ReadInputFile(string source)
        {
            List<string> lines = new List<string>(50);
            using (var tx = File.OpenText(source))
            {
                string? line = null;
                do
                {
                    line = tx.ReadLine();
                    if (line != null)
                    {
                        string trimed = line.Trim();
                        if (string.IsNullOrEmpty(trimed))
                        {
                            lines.Add(trimed);
                        }
                    }
                }
                while (line != null);
            }
            return lines;
        }

        private static void PrintException(Exception e)
        {
            var current = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e);
            Console.ForegroundColor = current;
        }

        private static void PrintHelp()
        {
            Console.WriteLine("TXT to MKV chapter converter v.1.0");
            Console.WriteLine("Written by: webmaster442");
            Console.WriteLine("Usage: ");
            Console.WriteLine("MkvChapterGenerator [input.txt] [output.xml]");
        }
    }
}
