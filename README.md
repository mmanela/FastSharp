# FastSharp

FastSharp is a text editor which lets you quickly compile and run C#, F# and Visual Basic code without opening up Visual Studio.  The way FastSharp works is pretty simple. It takes whatever you enter and wraps it in a Main method which is then wrapped in a class which then has a list of import statements appended above it (configurable through the settings dialog). It then compiles the code using the each languages CodeDom provider  and executes it. Because FastSharp wraps the code inside of a method block you can only write code that would normally compile inside of a method.

FastSharp comes in two forms: a windows application and a desktop gadget.


## Features

* Quickly compile and run C# code
* Lightweight application with a small file size and opens almost instantly
* A windows gadget that lets you execute code right from your desktop.

## Links
* [FastSharp home page](http://matthewmanela.com/projects/fastsharp/)
