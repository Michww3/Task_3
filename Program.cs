using System.IO.Compression;

class Programm
{
    static void Main(string[] args)
    {
        string fileName = "TextFile.txt";
        string pathToFile = FindFile("TextDocument.txt", "D:\\С#\\PRACTICE_N\\Task_3\\bin\\Debug\\net8.0");
        if (pathToFile == null)
            Console.WriteLine("File not found");

        else
        {
            string fileText = OpenFile(pathToFile);
            CompressedFile(pathToFile, fileText);
        }
    }

    static string FindFile(string fileName, string filePath = "")
    {
        string pathToFile = filePath == "" ? fileName : Path.Combine(filePath, fileName);
        if (File.Exists(pathToFile))
            return pathToFile;

        return null;
    }


    static string OpenFile(string fileName)
    {
        string fileText = File.ReadAllText(fileName);
        Console.WriteLine(fileText);
        return fileText;
    }

    static void CompressedFile(string filePath, string fileText)
    {
        using FileStream originalFileStream = File.OpenRead(filePath);
        using FileStream compressedFileStream = File.Create(filePath + ".gz");
        using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
        originalFileStream.CopyTo(compressor);
    }

}
