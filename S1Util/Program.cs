using System.IO.Compression;
using S1Util;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(opts =>
    {
        var dirPath = opts.Directory;
        var zipPath = opts.File;

        var platform = Environment.OSVersion;

        if (platform.Platform == PlatformID.Win32NT && dirPath == string.Empty)
        {
            // TODO Presumed location. I haven't played the game in a while.
            var progFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            var gamePath = Path.Combine(progFiles, "The Sims Complete Collection", "Downloads");

            dirPath = gamePath;
        }

        // Check if game directory exists
        if (!Directory.Exists(dirPath))
        {
            Console.WriteLine("Directory not found.");
            Environment.Exit(Environment.ExitCode);
        }

        // Check if the s1pk file exists
        if (!File.Exists(zipPath))
        {
            Console.WriteLine("The s1pk file does not exist.");
            Environment.Exit(Environment.ExitCode);
        }

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
    });