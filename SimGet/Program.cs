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
using S1Util;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(opts =>
    {
        var dirPath = opts.Directory;
        var zipPath = opts.File;

        var platform = Environment.OSVersion;

        // Automatically set to default game location on Windows
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
            Console.WriteLine("Game not found.");
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

                // Extract the file
                entry.ExtractToFile(extractFilePath, true);
            }
        }

        Console.WriteLine("Extraction completed successfully.");
    });