# Sims1Pack (s1pk)

Sims1Pack, or ``s1pk``, is a custom ZIP-based s1pk format designed to enhance the Sims 1 modding experience.

## SimGet


SimGet is a simple command-line package manager designed to work with the ``s1pk`` format. At this stage, it provides support for extracting files. Packaging will need to be performed manually for now. SimGet serves as a reference implementation for the format. Below are the basic usage instructions:

### Usage

To extract an ``s1pk`` file, use the following command:

```text
-d, --destination    

-f, --file           

-v, --verbose        

-s, --simulate       

--help               Display this help screen.

--version            Display version information.
```

- In simulation mode, the destination doesn't need to be specified

### Platform Specifics

#### Windows

On Windows, SimGet defaults to the Complete Collection install directory for The Sims 1.

#### Other Platforms

For platforms other than Windows, you will need to specify the game's installation directory manually in the command line.

## License

I license this project under the GPL 3 (GNU General Public License, version 3) - see [LICENSE](./LICENSE) for details.

<hr>

Happy Simming!