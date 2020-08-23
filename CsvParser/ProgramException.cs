using System;

namespace CsvParser
{
    internal class ProgramException : Exception
    {
        public ProgramException(string message):base(message){}
    }
}