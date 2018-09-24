# Trig Solver

 A desktop app that solves angles and side lengths for a triangle.

## Architecture (MVC / MVVM Patterns)

This section will describe the architecture of the solution.

The MVC or MVVM pattern is loosely implemented here.  The goal is to show seperation of concerns.  The core library exposes a controller.  The controller is handed data, validates the data, and computes a solution for the given inputs.  The action that triggers this behavior is a button click on the view.

## Resources:

- [CodeProject.com: Specification Pattern in C#](https://www.codeproject.com/Articles/670115/Specification-pattern-in-Csharp)
- [Coding Blocks: Episode 63](https://www.codingblocks.net/podcast/explicit-constraints-processes-specification-pattern-and-more/)
- [Martin Fowler: Specifications](https://www.martinfowler.com/apsupp/spec.pdf)
- [System.Collections.BitArray](https://docs.microsoft.com/en-us/dotnet/api/system.collections.bitarray.-ctor?view=netframework-4.7.2)
- [btye - C# Reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/byte)
- [SO thread](https://stackoverflow.com/q/3058/7969520)
- [Another sample project on GitHub](https://github.com/mrts/winforms-mvp)


# Dev Notes

## TODO

- Need to figure out how to set up testing.