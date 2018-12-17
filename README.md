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
- Use the following format to create an integer representation of a specific case: `Convert.ToInt32("1000", 2);`
- Use the following format to decode a integer to a binary string `Convert.ToString(10, 2);`


## Flow

### Program.Main()

The user interacts with the view.  When the application is opened, the *Main* method on the *Program* class is called.  Within this method, a new view is instantiated.  The view is passed into the *GetController* method on the *Core.Factory*.

#### How is the controller and the model related to the view?

The factory is passed the view, and it in turn passes the view to the constructor for the controller.   The controller injects itself to the view.  This is implemented by having the controller call a *SetController* method on the view that is defined on the IView interface.  Then, finally, the controller is returned to the view.

The key here is that the view and the controller each hold a reference to the other, but this relationship is explicitly defined using the IViwe and IController interfaces.

### View.TextBox_TextChanged(object sender, EventArgs e)

This is the handler for the user input event.  This handler immidiately defers control to IController.Solve().

### Controller.Solve()

The controller reads the data from the view then compares the data to a number of specifications.  There are a few more calls here, they are all internal to the core project.  There is a call to *Validation.Test*, which returns a *ValidationResponse* object.  The validation response object is then traversed by the controller to hand data back to the view.