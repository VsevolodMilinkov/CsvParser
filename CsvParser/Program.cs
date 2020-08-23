using System;
using System.Text;
using CommandLine;
using CsvParserLib;

namespace CsvParser
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // парсим входящие параметры и их аргументы, если парсятся - вызывается RunParsing()
                CommandLine.Parser
                    .Default
                    .ParseArguments<Options>(args)
                    .WithParsed(op => RunParsing(op));
            }
            catch (ParserException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (ProgramException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void RunParsing(Options opts)
        {
            Encoding encoding;
            try
            {
                encoding = Encoding.GetEncoding(opts.Enc);
            }
            catch (ArgumentException)
            {
                throw new ProgramException($"Кодировка \"{opts.Enc}\" либо не поддерживается, либо в названии кодировки допущена ошибка.");
            }
            var parser = new CsvParserLib.Parser(opts.In, opts.Out, encoding, opts.Col, opts.Exp);
            var success = parser.Parse();
            if (success)
                Console.WriteLine($"Парсинг файла {opts.In} завершен успешно!");
            Console.WriteLine("Чтобы закончить, нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}