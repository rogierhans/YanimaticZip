using System;
using System.IO.Compression;
using System.IO;

class Program
{
    static void Main()
    {
        string currentPath = @"C:\Users\4001184\Desktop\Lil_Test_Folder";
        Console.WriteLine("Naam zipfile aub...");
        string zipPath = currentPath +@"\"+ Console.ReadLine();
        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                string subfolder = entry.FullName.Split('.').First().Split('_').Last();
                Directory.CreateDirectory(currentPath + @"\" + subfolder);
                string destinationPath = currentPath + @"\" + subfolder + @"\" + entry.FullName;
                entry.ExtractToFile(destinationPath,true);
            }
        }
    }
}