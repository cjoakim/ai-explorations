#!/bin/bash

which dotnet

dotnet --version

#dotnet new console

# See https://www.nuget.org 
dotnet add package Microsoft.SemanticKernel
dotnet add package Microsoft.Azure.Cosmos
dotnet add package Azure.Storage.Blobs
dotnet add package Newtonsoft.Json
dotnet add package DotNetEnv
dotnet add package Microsoft.SemanticKernel.Plugins.Core --version 1.53.1-preview

dotnet list package
