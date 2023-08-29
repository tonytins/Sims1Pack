# Sims1Pack (s1pk)

Sims1Pack, or ``s1pk``, is a custom ZIP-based s1pk format designed to enhance the Sims 1 modding experience.

## S1Util

S1Util is a simple command-line package manager designed to work with the s1pk format. At this stage, it provides support for extracting s1pk files. Packaging functionality will need to be performed manually for now. Below are the basic usage instructions:

### Usage

To extract an s1pk file, use the following command:

```shell
s1util --file <file_path> --directory <output_directory>
```

- `<file_path>` should be replaced with the path to the s1pk file you want to extract.
- `<output_directory>` is the location where the contents of the ``s1pk`` file will be extracted to.

### Platform Specifics

#### Windows

On Windows, S1Util defaults to the Ultimate Edition install directory for The Sims 1. This makes it convenient to work with mods and custom content in the Windows environment.

#### Other Platforms

For platforms other than Windows, you will need to specify the game's installation directory manually in the command line.

## License

I license this project under the GPL 3 (GNU General Public License, version 3) - see [LICENSE](./LICENSE) for details.

<hr>

Happy Simming!