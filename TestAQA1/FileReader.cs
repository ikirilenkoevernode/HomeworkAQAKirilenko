public static class FileReader
{
    public static string ReadFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }
    public static string[] ReadLines(string filePath)
    {
        return File.ReadAllLines(filePath);
    }
}