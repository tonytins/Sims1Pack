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
namespace S1Util;

public class Options
{
    [Option('d', "destination")]
    public string Destination { get; set; } = string.Empty;

    [Option('f', "file", Required = true)]
    public string File { get; set; } = string.Empty;

    [Option('v', "verbose")]
    public bool Verbose { get; set; } = false;

    [Option('s', "simulate", HelpText = "Simulate the extraction or compression process.")]
    public bool Simulate { get; set; } = false;
}

[Verb("extract", HelpText = "Extract .s1pk archives.")]
public class Extract : Options { }

[Verb("compress", HelpText = "Compress .s1pk files.")]
public class Compress : Options { }