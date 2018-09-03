# Trig Solver

 A desktop app that solves angles and side lengths for a triangle.

## To Do / Progress Notes

- Now that I have the DTOs set up the next thing to do is start a test project.  From there I'll stub up some data and start working on integrating the math and the validation


## Actors

### Data

This is a data transfer object (DTO).  This object has no behavior, the member list includes only 6  properties, 3 lengths and 3 angles.

### Data Set

This object is a wrapper for the 'data' DTO.  This object will provide the "looks" at the data that will be needed for validation.  This class has a default constructor that takes one argument, a data object.  This is dependancy injection.

### Specifications

There are a number of *Specification* classes that explicitly define requirements to be met by the data set before a solution can be calculated.

### Trig

This is a static 'helper' class that defines the trigonmetric functions used throughout the application.

### Triple

This class can be returned from the DataSet class.  This class is constructed by passing in an array of doubles.  The array passed in should only ever have 3 elements, though there is no validation done on this because the class is only constructed by the DataSet object.

### Validation

This class is a sort of wrapper for the specifications.  When a Data object is validated, it is checked against all specifications.  Once validated, a solution can be calculated.


## Links

- [CodeProject.com: Specification Pattern in C#](https://www.codeproject.com/Articles/670115/Specification-pattern-in-Csharp)
- [Coding Blocks: Episode 63](https://www.codingblocks.net/podcast/explicit-constraints-processes-specification-pattern-and-more/)
- [Martin Fowler: Specifications](https://www.martinfowler.com/apsupp/spec.pdf)