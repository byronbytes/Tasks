# RunFile
**RunFile is a class that executes a file, in this case, a .bat file.**

## Usage
`RunFile.RunBat("batfiledir", true);`

## RunBat
RunBat is a class that runs a bat file.

## Expressions
The **string** is supposed to input the directory to the bat file.

The **bool** is supposed to input if you want to wait for the file to exit or not.

**Example:**

`  if (waitexit == true)
                {
                    process.WaitForExit();
                }`
