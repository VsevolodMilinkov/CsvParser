using CommandLine;

namespace CsvParser
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Options
    {
        [Option("in", Required = true, Separator = ' ', HelpText = "Имя/путь входящего файла, подлежащего парсингу.")]
        public string In { get; set; }

        [Option("out",
            Required = true,
            Separator = ' ',
            HelpText = "Имя/путь исходящего файла, в который записывается результат парсинга (при отсутствии файла/каталогов будут созданы автоматически).")]
        public string Out { get; set; }

        [Option("enc", Required = true, Separator = ' ', HelpText = "Кодировка исходящего файла.")]
        public string Enc { get; set; }

        [Option("col", Required = true, Separator = ' ',
            HelpText = "Колонка входящего файла, по которой производится отсев данных.")]
        public string Col { get; set; }

        [Option("exp", Required = true, Separator = ' ',
            HelpText = "Искомое выражение из колонки, указываемой в параметре col.")]
        public string Exp { get; set; }
    }
}