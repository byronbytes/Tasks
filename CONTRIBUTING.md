# Contributing Guidelines

## Prerequisites
To contribute, you will need the following:

- A decent knowledge of C#
- A decent knowledge of WinForms (if working with the interface)
- A decent knowledge of how to use an IDE.
- Debug and test your code before contributing.
- Visual Studio IDE (2019 or 2022)
  - .NET Desktop Development
  - .NET Core 5.0


# Code Format
Our code formatting is very specific, and it is recommended to follow these guidelines.


#### If Statements ####

If statements should follow the following format.


```csharp

if(Equation)
{
   Something();
   SomethingElse(true);
}
else
{
   SomethingElse();
   Something(false);
}
````


#### Single Code Lines ####

When coming across a single code statement, you should follow the following format.

```csharp

public static void Example
{
  CheckSomething();
}
````


#### Try/Catch Statements ####

When using a try/catch statement, use the following code. If you are debugging, it is recommended to put a `Debug.Print` in the statements while testing.


```csharp
try
 {
    DoSomething();
 }
 catch(Exception ex)
 {
    Error();
 }
```
