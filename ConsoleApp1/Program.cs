using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Specify the starting directory (e.g., @"c:\users\kevin\OneDrive")
        string startLocation = @"c:\users\kevin\OneDrive";
        processDirectory(startLocation);
    }

    private static void processDirectory(string startLocation)
    {
        foreach (var directory in Directory.GetDirectories(startLocation))
        {
            processDirectory(directory);

            // Check if the directory is empty (no files or subdirectories)
            if (!Directory.EnumerateFileSystemEntries(directory).Any())
            {
                try
                {
                    Directory.Delete(directory);
                    Console.WriteLine($"Deleted empty directory: {directory}");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., access denied)
                    Console.WriteLine($"Error deleting directory {directory}: {ex.Message}");
                }
            }
        }
    }
}
