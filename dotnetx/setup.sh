#!/bin/bash

which dotnet

dotnet --version

#dotnet new console

dotnet add package Microsoft.SemanticKernel
dotnet add package Microsoft.Azure.Cosmos
dotnet add package Azure.Storage.Blobs
dotnet add package Newtonsoft.Json

dotnet list package
