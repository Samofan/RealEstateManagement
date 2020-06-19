![build](https://github.com/Samofan/RealEstateManagement/workflows/build/badge.svg)
![tests](https://github.com/Samofan/RealEstateManagement/workflows/tests/badge.svg)
![GitHub repo size](https://img.shields.io/github/repo-size/Samofan/RealEstateManagement)
![GitHub issues](https://img.shields.io/github/issues/Samofan/RealEstateManagement)
![GitHub](https://img.shields.io/github/license/Samofan/RealEstateManagement)
![GitHub last commit](https://img.shields.io/github/last-commit/Samofan/RealEstateManagement)

A software to manage real estates.

# Usage

## Command line interface

```
Usage
  dotnet RealEstateManagementCLI.dll [command]

Options
  -h|--help         Shows help text.
  --version         Shows version information.

Commands
  add               Add a new real estate.
  list              List available real estates.
  path              Specify the path of the file.
  remove            Remove a real estate.
  serialization     Specify the serialization type. (Xml is standard).
  update            Update an existing real estate.

You can run `dotnet RealEstateManagementCLI.dll [command] --help` to show help on a specific command.
```

### Warning

Make sure to change the file extension (\*.dat or \*.xml) if you change the type of serialization with the path command.

# Contribute

At the moment there is no possibility to contribute because I have to do the software on my own. A guide how to contribute
is replacing this text after I got my grade.

# Dependendencies

* [CliFx](https://github.com/Tyrrrz/CliFx)
* [xUnit](https://github.com/xunit/xunit)
