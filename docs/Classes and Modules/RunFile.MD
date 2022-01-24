# RunFile
**RunFile is a class that executes files.**

## RunBat
RunBat is a class that runs a .bat file from the base directory.

## Expressions
The **string** is supposed to input the directory to the bat file. ``` 
RunFile("DirectoryHere"); ```

The **bool** is supposed to input if you want to wait for the file to exit or not. ```
RunFile("DirectoryHere", false);```


**Full Example:**

```csharp
RunFile("Scripts/BatFiles/byesolitaire.bat", false);
```
