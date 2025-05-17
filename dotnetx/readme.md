# DotNet AI Explorations

A collection of **exploratory** DotNet/C# AI projects and tools.

## Links

- https://learn.microsoft.com/en-us/semantic-kernel/get-started/quick-start-guide?pivots=programming-language-csharp

## Project Creation

### Install DotNet 9 on macOS M2 with Homebrew

```
$ brew uninstall --cask dotnet

$ brew install dotnet

$ brew list | grep dotnet
dotnet

$ dotnet --version
9.0.106

$ which dotnet
/opt/homebrew/bin/dotnet

$ dotnet --version
9.0.106
```

### Create Project and Add Packages

See https://www.nuget.org.  Search for packages in the UI.

```
$ dotnet new console
The template "Console App" was created successfully.

$ dotnet add package Microsoft.SemanticKernel
$ dotnet add package Microsoft.Azure.Cosmos
$ dotnet add package Azure.Storage.Blobs
$ dotnet add package Newtonsoft.Json

$ dotnet list package
Project 'dotnet_ai_explorations' has the following package references
   [net9.0]:
   Top-level Package               Requested   Resolved
   > Azure.Storage.Blobs           12.24.0     12.24.0
   > Microsoft.Azure.Cosmos        3.51.0      3.51.0
   > Microsoft.SemanticKernel      1.51.0      1.51.0
   > Newtonsoft.Json               13.0.3      13.0.3
   
$ dotnet build

$ dotnet run
Hello, World!
```
