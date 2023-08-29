// Specify the path to the zip file with the ".s1pk" extension.
using System.IO.Compression;
using S1Util;

Parser.Default.ParseArguments<Options>(args)
    .WithNotParsed(options =>
    {
        var zipFilePath = "path_to_your_file.s1pk";

        // Specify the directory where you want to extract the ".iff" files.
        var extractionDirectory = "path_to_extraction_directory";

        // Check if the zip file exists.
        if (File.Exists(zipFilePath))
        {
            try
            {
                // Create the extraction directory if it doesn't exist.
                Directory.CreateDirectory(extractionDirectory);

                // Extract all files with the ".iff" extension from the zip file.
                using ZipArchive archive = ZipFile.OpenRead(zipFilePath);
                var iffFiles = archive.Entries
                    .Where(entry => entry.FullName.EndsWith(".iff", StringComparison.CurrentCultureIgnoreCase))
                    .ToList();

                foreach (var iffEntry in iffFiles)
                {
                    // Specify the full path to save the extracted file.
                    var extractPath = Path.Combine(extractionDirectory, iffEntry.Name);

                    // Extract the file from the zip archive.
                    iffEntry.ExtractToFile(extractPath, true);

                    // Optionally, you can perform further actions with the extracted file here.
                    // For example, you can process or manipulate the ".iff" files.
                }

                Console.WriteLine($"Extracted {iffFiles.Count} .iff files to {extractionDirectory}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("The specified zip file does not exist.");
        }

    });