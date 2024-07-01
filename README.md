# Address-Book-Template-Code
This is practically the same thing but instead, it only hold the scripts needed for the address book template. This can help provide flexibility on your software even further

Recommended .NET Version 7.0+

There are files under "Core Files" folder. They will be explained here

# Documentation

### Core Files
There is a folder named "Core Files" that holds the important scripts needed to run the program overall

- AddressBook.cs
- CheckFile.cs
- RequireDependencies.cs

## AddressBook.cs
This is the main script needed to run. Without it, then you practically have nothing then the tools needed to make somethig. 

There are "#pragma warning disable" to ignore certain warnings because there already measures to ensure the field/s will not be null. 

##### disabled Warnings
- CS8600
- CS8602
- CS0649
- CS8601

These are Resolve nullable warnings and more information about them can be found here [Resolve Nullable Warnings](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8602))

#### Lists of Methods
1. `public static void GetFile(string path = "", bool writeToTempData = false, bool useTempData=false)`
    > This brings in the contents from the file into temporary data, effectively copying it so it can be manipulated directly without changing anything to <br>
    > the original file. Once finished, the temp data will be stored under the "temp" folder, which can be reused when needed to (can only store 1 temp file at a time)

2. `private static void Input(JObject _content) `
    > This method gets the temporary data to be process. Once it is process. the data will be ready to be manipulated <br>
    > this follows after the GetFile() method

3. `public static void Show()`
    > This method can be used to show the temporary data without all the Json Mess; Making it easier to read the temp data in human readable form<br>

4. `private static void _CreateTempFile([NotNull]string contents)`
    > This gests called in the GetFile() method. The temporary data will be reprocessed back to json in a file called tempData.json and will be found under the <br>
    > "\temp" folder 


5. `public static void Add(string _name=DEFAULT, string _address=DEFAULT, string _phone=DEFAULT, string _email=DEFAULT)` (Overload)
    > whenever you want to put in information that you do and don't know, this can be used. It is an overload version of Add(Information information) <br>
    > data can be added separately and you do not need to worry whether or not the information is going to be used

6. `internal static void _DeleteTempFile()`
    > May not need to be used but when in doubt, it can be used to delete the temp file if the file is corrupted or other reasons

7. `private static string GetTempFile() ` (may not be needed)
    > This gets the temporary data file.

8. `public static void Delete(Information _information)`
    > This deletes a specific Information data

9. `public static void Add(Information information)`
    > If you already have all the information needed, this can be used without having to meticulously add each and every parameters. 

Note: They can all be re-edited into your own way. This is meant to be a template and can be used in variety of applications. <br>
*Warning: there are no measures to encrypt and decrypt data. this is supposed to be as barebones as possible and you may need to implement it*
## CheckFile.cs
This file is used to check if the file is Json. That is really it and can be used with other things.

It does contain
1. #pragma warning disable CS8605

## RequireDependencies.cs
I could write this in the same script in AddressBook.cs but if I really wanted to document my code with clarity (which I am), it is better that I store <br>some custom types in their own respective file/s.

This file contains the custom type/s needed in the "AddressBook.cs" file. Without it, the whole thing breaks.

***
I do not really have any plan on working on more features. This is meant to be as barebones as possible so <br> 
that it can be wrapped on any .NET application or can be used to learn how C# works. I am not a 10x <br>
programmer/developer or the best programmer out here so expect some malpractices on my code, bad written code, or bad documentation.

**Note: Due to the barebone nature of this program, there are tons of tools missing that you may need like directly manipulate a certain<br>**
**data in a specific index, and you may need to implement it. (It is really easy but I cannot assume what the developer may need)**

This project is licensed under the terms of the Unlicensed license.

