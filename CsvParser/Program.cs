using System;
using System.Text;
using CommandLine;

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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static bool RunParsing(Options opts)
        {
            var parser = new CsvParserLib.Parser(opts.In, opts.Out, Encoding.GetEncoding(opts.Enc), opts.Col, opts.Exp);
            var success = parser.Parse();
            return success;
        }
    }
}