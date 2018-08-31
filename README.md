# Trig Solver

A desktop app that solves angles and side lengths for a triangle.

## To Do / Progress Notes

- Now that I have the DTOs set up the next thing to do is start a test project.  From there I'll stub up some data and start working on integrating the math and the validation


## Actors

### Data Set

This object is a wrapper for the 'data' DTO.  This object will provide the "looks" at the data that will be needed for validation.  This class has a default constructor that takes one argument, a data object.  This is dependancy injection.

Future work: Perhaps it would be better to use an IEnumerable?
