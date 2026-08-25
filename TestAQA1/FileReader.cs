
namespace HelpClasses
{
    public static class FileReader
    {
        public static string ReadFile(string filePath)
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, filePath);
            return File.ReadAllText(fullPath);
        }

        public static string[] ReadLines(string filePath)
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, filePath);
            return File.ReadAllLines(fullPath);
        }
    }
}
