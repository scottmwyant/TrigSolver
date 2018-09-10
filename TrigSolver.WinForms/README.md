# TrigSolver.WinForms

Source code in this directory compiles to a Windows executable (.exe) file.  The executable file includes an embedded copy of the *TrigSolver.Core.dll* class library.

This project is one implementation of the View.

## View

- 9/9 - Trying to decide if the view *is* the form or if it goes between the controller and the form.  Leaning toward making the form the view, as different views may implement different functionalities.  There would be a console app view, winforms view, electron view, etc...

- The view is responsible for passing a 'Data' object to the controller then presenting the controller's response to the user.

- The view could also be responsible for formatting the forms textboxes, updating sketch, etc.