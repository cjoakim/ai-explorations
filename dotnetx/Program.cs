using System;
using System.IO;
using System.Collections.Generic;

using Microsoft.SemanticKernel;

using DotNetEnv;

using JoakimSoftware;
//using JoakimSoftware.Core;
using JoakimSoftware.IO;

namespace JoakimSoftware {

    class Program {
        
        static async Task<int> Main(string[] args) {

            string func = GetRunFunction(args);
            Log("run function: " + func);
            Env.Load();

            switch (func) {
                case "env":
                    EnvExamples();
                    break;
                case "io":
                    IoExamples();
                    break;
                case "paths":
                    PathsExamples();
                    break;
                case "sk_simple_prompt":
                    await SKSimplePrompt();
                    break;
                default:
                    Log("Undefined function given on command-line; " + func);
                    break;
            }
            return 0;
        }

        private static void EnvExamples() {

            Console.WriteLine("pwd:        " + JoakimSoftware.Core.Env.Pwd());
            Console.WriteLine("home:       " + JoakimSoftware.Core.Env.HomeDir());
            Console.WriteLine("os arch:    " + JoakimSoftware.Core.Env.OsArch());
            Console.WriteLine("os desc:    " + JoakimSoftware.Core.Env.OsDesc());
            Console.WriteLine("is windows: " + JoakimSoftware.Core.Env.IsWindows());
            Console.WriteLine("is macos:   " + JoakimSoftware.Core.Env.IsMacOS());
            Console.WriteLine("is linux:   " + JoakimSoftware.Core.Env.IsLinux());
        }

        private static void IoExamples() {

            string githubDir = Paths.GithubDir();
            Console.WriteLine("github dir:  " + githubDir);

            List<string> subpaths = new List<string> { "cj-dotnet", "Console1", "Console1" }; 
            String fullpath = Paths.Normalize(githubDir, subpaths);
            Console.WriteLine("fullpath:  " + fullpath);
            
            //Console.WriteLine("normalized:  " + Paths.Normalize("");

            FileIO fio = new FileIO();

            //string infile = pwd + @"\Program.cs";
            //Console.WriteLine("infile: " + infile);
            //Console.WriteLine(fio.ReadText(infile));
        }

        private static void PathsExamples() {

            Log("norm: " + Paths.Normalize(@"\"));
            Log("norm: " + Paths.Normalize(@"/"));
            Log("norm: " + Paths.Normalize(@"\Users\chris\github\cj-dotnet\Console1\Console1"));
            Log("norm: " + Paths.Normalize(@"/Users/chris/github/cj-dotnet/Console1/Console1"));
            Log("norm: " + Paths.Normalize(@"Program.cs"));
        }

        private static async Task<string> SKSimplePrompt()
        {
            string apiUrl = ReadEnvVar("AZURE_OPENAI_URL", "none");
            string apiKey = ReadEnvVar("AZURE_OPENAI_KEY", "none");
            string depName = ReadEnvVar("AZURE_OPENAI_COMPLETIONS_DEPLOYMENT", "gpt-3.5-turbo");
            string cat = ReadEnvVar("CAT", "Betty");
            Console.WriteLine("apiUrl:  " + apiUrl);
            Console.WriteLine("apiKey:  " + apiKey);
            Console.WriteLine("depName: " + depName);
            Console.WriteLine("cat:     " + cat);
            
            IKernelBuilder builder = Kernel.CreateBuilder();
            builder.AddAzureOpenAIChatCompletion(
                deploymentName: depName,
                apiKey: apiKey,
                endpoint: apiUrl
            );
            Console.WriteLine("builder: " + builder);
            
            Kernel kernel = builder.Build();
            Console.WriteLine("kernel: " + kernel);

            string prompt = PromptUser("enter a prompt, then enter: ");
            string resultText = "none";
            Console.WriteLine("prompt: " + prompt);
            
            if (prompt.Trim().Length > 0) {
                var result = await kernel.InvokePromptAsync(prompt);
                resultText = result.ToString();
                Console.WriteLine("resultText: " + resultText);
            }
            else {
                Console.WriteLine("no prompt given");
            }
            return resultText;
        }

        private static void Log(string msg) {

            Console.WriteLine(msg);
        }

        private static string GetRunFunction(string[] args) {

            if ((args != null) && (args.Length > 0)) {
                return args[0].ToLower();
            }
            else {
                return "";
            }
        }
        
        private static string ReadEnvVar(string name, string defaultValue) {

            return JoakimSoftware.Core.Env.EnvVar(name, defaultValue);
        }

        private static string PromptUser(string message) {

            Console.WriteLine(message);
            return "" + Console.ReadLine();
        }
    }
}

