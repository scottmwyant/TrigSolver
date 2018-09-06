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
- [System.Collections.BitArray](https://docs.microsoft.com/en-us/dotnet/api/system.collections.bitarray.-ctor?view=netframework-4.7.2)
- [btye - C# Reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/byte)

## Working Notes

- The DataSet is the profiler.  This class encapsulates all the logic for determining the 123456 profile and the algorithm ("ASA", etc).

- Validation will return boolean.  Then there will be a response object on the validation class that can be explorted if the validation fails.

- The actual solving will be done with a static method in the Trig class.

- The general flow is as follows:

  - Generate data (view or view model is responsible for this)
  
  - Pass the data into the controller.
    
    - Inside the controller, the data is used to construct a DataSet object then that is passed into Validation.
    - If Validation fails, some error message is sent back to the view model
    - If validation passes, the controller calls on teh Solve method in the Trig class
    - The solved method is passed back to the view model.
    - So either the view model needs to know about the controller, meaning the view has to know how to explore the response, but it would probably be better to have the controller pass a response object back to the view model.  This class would have to have contain a Data, a ErrorText and some indicator which one to use.  Perhaps the "ErrorText" would just be "Text" then the text woudl be either positive or negative.   Also, there could be a responseId, something that numerically indicates the status of the response, if things went well or if things went south.


    ## The I/O Problem

    - There are 19 different cases.  In each case there is a list of 3 inputs, and 3 calculations are made to find the missing values.  Struggling with how to code this in OOP manner.  Perhaps we need some sort of adapter factory.  You pass in the profile ID ("110011") and get back an adapter?  The adapter would have to know, for 1 specific case, which 3 properties of the data object constitute the input and in which order they are expected.  It would also need to know what piece of data is coming back at each step.