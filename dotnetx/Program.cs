using System;
using System.IO;
using System.Collections.Generic;

using Microsoft.SemanticKernel;

using JoakimSoftware.Core;
using JoakimSoftware.IO;

namespace JoakimSoftware {

    class Program {

        static void Main(string[] args) {

            string func = GetRunFunction(args);
            Log("run function: " + func);

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
                    SKSimplePrompt();
                    break;
                default:
                    Log("Undefined function given on command-line; " + func);
                    break;
            }
            PromptUser("Hit enter to contine");
        }

        private static void EnvExamples() {

            Console.WriteLine("pwd:        " + Env.Pwd());
            Console.WriteLine("home:       " + Env.HomeDir());
            Console.WriteLine("os arch:    " + Env.OsArch());
            Console.WriteLine("os desc:    " + Env.OsDesc());
            Console.WriteLine("is windows: " + Env.IsWindows());
            Console.WriteLine("is macos:   " + Env.IsMacOS());
            Console.WriteLine("is linux:   " + Env.IsLinux());
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

        private static async void SKSimplePrompt()
        {
            string apiUrl = Env.EnvVar("AZURE_OPENAI_URL", "none");
            string apiKey = Env.EnvVar("AZURE_OPENAI_KEY", "none");
            string depName = Env.EnvVar("AZURE_OPENAI_COMPLETIONS_DEPLOYMENT", "gpt-3.5-turbo");
            Console.WriteLine("apiUrl: " + apiUrl);
            Console.WriteLine("apiKey: " + apiKey);
            Console.WriteLine("depName: " + depName);
            
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
            Console.WriteLine("prompt: " + prompt);
            
            if (prompt.Trim().Length > 0)
            {
                var result = await kernel.InvokePromptAsync(prompt);
                Console.WriteLine("result: " + result);
            }
            else {
                Console.WriteLine("no prompt given");
            }
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

        private static string PromptUser(string message) {

            Console.WriteLine(message);
            return "" + Console.ReadLine();
        }
    }
}

