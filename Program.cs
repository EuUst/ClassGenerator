namespace Pare_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\79681\\source\\repos\\Pare_task\\Classes.txt";
            //Лучше используй условный путь, например ("/../Classes.txt")

            var converter = new ConverterFromText();
            ClassData classData = converter.ConvertFromTextToClassData(path);

            var writer = new CSFileCreater();
            writer.CreateCSFile(classData, "C:\\Users\\79681\\source\\repos\\Pare_task\\test.cs");
        }
    }
}