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
using S1Util;

Parser.Default.ParseArguments<Extract, Compress>(args)
    .WithParsed<Extract>(opts =>
    {
        var dirPath = opts.Destination;
        var zipPath = opts.File;

        var unpack = new PackUtil(zipPath, dirPath, opts.Simulate, opts.Verbose);
        unpack.Extract();

    })
    .WithParsed<Compress>(opts =>
    {
        var dirPath = opts.Destination;
        var zipPath = opts.File;

        var compress = new PackUtil(zipPath, dirPath, opts.Simulate, opts.Verbose);
        compress.Compress();

    });