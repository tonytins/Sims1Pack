namespace S1Util;

public class Options
{
    [Option('d', "dir")] public string Directory { get; set; } = string.Empty;
    [Option('f', "file")] public string File { get; set; } = string.Empty;
}

