using System.IO.Compression;
using S1Util;

Parser.Default.ParseArguments<Options>(args)
    .WithNotParsed(options =>
    {
        var dirPath = string.Empty;
        var zipPath = string.Empty;

        // Check if the s1pk file exists
        if (File.Exists(zipPath))
        {
            // Extract the s1pk file
            using var archive = ZipFile.OpenRead(zipPath);

            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                // Check if the entry has the .iff extension
                if (entry.FullName.EndsWith(".iff", StringComparison.OrdinalIgnoreCase))
                {
                    // Build the full path for the extracted file
                    string extractFilePath = Path.Combine(dirPath, entry.FullName);

                    // Create the directory structure if needed
                    Directory.CreateDirectory(Path.GetDirectoryName(extractFilePath));

                    // Extract the file
                    entry.ExtractToFile(extractFilePath, true);
                }
            }
            Console.WriteLine("Extraction completed successfully.");
        }
        else
        {
            Console.WriteLine("The s1pk file does not exist.");
        }
    });