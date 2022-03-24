using System;
using System.IO.Compression;
using System.IO;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines(@".\paths.txt");
        string currentPath = lines[0].Split('=').Last();
        string zipPath = lines[1].Split('=').Last();
        using (ZipArchive archive = ZipFile.OpenRead(currentPath + @"\" + zipPath))
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