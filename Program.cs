// See https://aka.ms/new-console-template for more information

using OtusHomework17;


FileSearcher fileSearcher = new FileSearcher();
bool _cancelRequested = false;
List<string> files = new List<string>();

EventHandler<FileFoundArgs> OnFileFound = (sender, e) =>
{
    Console.WriteLine("Найден файл: " + e.FileName);
    files.Add(e.FileName);
    e.CancelRequested = _cancelRequested;
};

Action OnSearchCancelled = () => Console.WriteLine("Поиск файлов отменен.");

fileSearcher.FileFound += OnFileFound;
fileSearcher.SearchCancelled += OnSearchCancelled;



SearchFiles();


Console.WriteLine("Введите N для прекращения поиска:");
string input = Console.ReadLine();

if (input.ToLower() == "n")
{
    _cancelRequested = true;
}


Console.ReadKey();



async Task SearchFiles()
{
    Console.WriteLine("Укажите путь к каталогу:");
    string? path = Console.ReadLine();

    await Task.Run(() =>
        fileSearcher.Search(path));
        

    Console.WriteLine("Поиск файлов завершен.");

    string longName = files.GetMax(name => name.Length);

    Console.WriteLine($"Самое длинное имя файла: {longName}");
}




