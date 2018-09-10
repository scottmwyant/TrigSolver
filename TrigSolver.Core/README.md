# TrigSolver.Core

This is the class library that holds the core logic for the app.

## Public Memmbers

### Controller

The controller is the core component of the app.  The controller component is used in the following manner.  You hand over a set of inputs using the 'Data' DTO, then look at the state of the response object.  The response is reutrned from the controller.  This object that is returned should implement an interface since the view needs to know how to use it.

This way, the controller takes the input and generates a response, but itself holds no state.

### ControllerResponse

This is the object returned from the controller's `Invoke` method.

### Data

This is a data transfer object (DTO).  This object has no behavior, the member list includes only 6  properties, 3 lengths and 3 angles.

## Non-Public Members

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



# Development Notes

## The I/O Problem

- There are 19 different cases.  In each case there is a list of 3 inputs, and 3 calculations are made to find the missing values.  Struggling with how to code this in OOP manner.  Perhaps we need some sort of adapter factory.  You pass in the profile ID ("110011") and get back an adapter?  The adapter would have to know, for 1 specific case, which 3 properties of the data object constitute the input and in which order they are expected.  It would also need to know what piece of data is coming back at each step.

#### RESOLVED : 

-  This problem was solved by defining an interface, a factory, and 19 implementations of the interface.  The primary object we're talking about here is the 'Solver'.  The interface ISolver defines one method, a method that takes one argument of type 'Data' and returns type 'Data'.  The object that is returned is not "new-ed up" but is a copy of the argument.  Then there are 3 steps taken to write values to the 3 missing properties in that 'Data' object.  

### View

- 9/9 - Trying to decide if the view *is* the form or if it goes between the controller and the form.  Leaning toward making the form the view, as different views may implement different functionalities.  There would be a console app view, winforms view, electron view, etc...

- The view is responsible for passing a 'Data' object to the controller then presenting the controller's response to the user.

- The view could also be responsible for formatting the forms textboxes, updating sketch, etc.