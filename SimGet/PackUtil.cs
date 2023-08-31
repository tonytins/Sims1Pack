// A custom ZIP-based format designed to enhance the Sims 1 modding experience.
// Copyright (C) 2023 Tony Bark
//
// This program is free software: you can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the Free
// Software Foundation, either version 3 of the License, or (at your option)
// any later version.
//
// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of  MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
// more details.
//
// You should have received a copy of the GNU General Public License along with
// this program.  If not, see <http://www.gnu.org/licenses/>.
using System.IO.Compression;

namespace S1Util;

public class PackUtil
{
    public PackUtil(string directory, string file)
    {
        OutputPath = directory;
        FilePath = file;
    }

    string OutputPath { get; set; } = string.Empty;
    string FilePath { get; set; } = string.Empty;

    void PathDetection()
    {
        var os = Environment.OSVersion;

        if (os.Platform == PlatformID.Win32NT && OutputPath == string.Empty)
        {
            // TODO Presumed location. I haven't played the game in a while.
            var progFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            var gamePath = Path.Combine(progFiles, "The Sims Complete Collection", "Downloads");

            OutputPath = gamePath;
        }

        // Check if game directory exists
        if (!Directory.Exists(OutputPath))
        {
            Console.WriteLine("Game not found.");
            Environment.Exit(Environment.ExitCode);
        }

        // Check if the s1pk file exists
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("The s1pk file does not exist.");
            Environment.Exit(Environment.ExitCode);
        }

        // Check file extensions
        if (!FilePath.EndsWith("s1pk", StringComparison.InvariantCultureIgnoreCase)
        || !FilePath.EndsWith("sims1pack", StringComparison.InvariantCultureIgnoreCase)
        || !FilePath.EndsWith("zip", StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine("Invalid format");
            Environment.Exit(Environment.ExitCode);
        }
    }

    public void Extract(bool simulate = false)
    {
        PathDetection();

        // Extract the s1pk file
        using var archive = ZipFile.OpenRead(FilePath);

        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            // Check if the entry has the .iff extension
            if (entry.FullName.EndsWith(".iff", StringComparison.InvariantCultureIgnoreCase) && !simulate)
            {
                // Build the full path for the extracted file
                string extractFilePath = Path.Combine(OutputPath, entry.FullName);

                // Extract the file
                entry.ExtractToFile(extractFilePath, true);
            }
        }

        Console.WriteLine("Extraction completed successfully.");

    }
}