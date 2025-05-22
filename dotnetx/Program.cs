using System;
using System.IO;
using System.Collections.Generic;

using Microsoft.SemanticKernel;

using DotNetEnv;
using Joakimsoftware.M26;         // This is a NuGet Package
using Joakimsoftware.Plugins;  // This is in this codebase

using Joakimsoftware.Core;
using Joakimsoftware.IO;
using Microsoft.SemanticKernel.Plugins.Core;

namespace Joakimsoftware {

    class Program {
        
        static async Task<int> Main(string[] args) {

            string func = GetRunFunction(args);
            Log("run function: " + func);
            DotNetEnv.Env.Load();

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
                case "m26":
                    M26Examples();
                    break;
                case "sk_simple_prompt":
                    await SKSimplePrompt();
                    break;
                case "sk_simple_plugins":
                    await SKSimplePlugins();
                    break;
                default:
                    Log("Undefined function given on command-line; " + func);
                    break;
            }
            return 0;
        }

        private static void EnvExamples() {

            Console.WriteLine("pwd:        " + Core.Env.Pwd());
            Console.WriteLine("home:       " + Core.Env.HomeDir());
            Console.WriteLine("os arch:    " + Core.Env.OsArch());
            Console.WriteLine("os desc:    " + Core.Env.OsDesc());
            Console.WriteLine("is windows: " + Core.Env.IsWindows());
            Console.WriteLine("is macos:   " + Core.Env.IsMacOS());
            Console.WriteLine("is linux:   " + Core.Env.IsLinux());
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

        private static void M26Examples()
        {
            // See https://www.nuget.org/packages/Joakimsoftware.M26
            // This method explores the Joakimsoftware.M26 package before 
            // implementing its' functionality in a Semantic Kernel plugin.
            
            Distance d = new Distance(26.2);
            double m = d.asMiles();
            double k = d.asKilometers();
            double y = d.asYards();
            Console.WriteLine($"Distance - miles:        {m}");
            Console.WriteLine($"Distance - kilometers:   {k}");
            Console.WriteLine($"Distance - yards:        {y}");
          
            ElapsedTime et1 = new ElapsedTime("3:47:30");
            ElapsedTime et2 = new ElapsedTime(3, 47, 30);
            ElapsedTime et3 = new ElapsedTime(13650.0);
            Console.WriteLine($"ElapsedTime - et1 hhmmss: {et1.asHHMMSS()}");
            Console.WriteLine($"ElapsedTime - et2 hhmmss: {et2.asHHMMSS()}");
            Console.WriteLine($"ElapsedTime - et3 hhmmss: {et3.asHHMMSS()}");
            
            // Construct a Speed from a Distance and ElapsedTime
            Speed sp = new Speed(d, et1);
            double mph = sp.mph();
            double kph = sp.kph();
            double yph = sp.yph();
            double spm = sp.secondsPerMile();
            string ppm = sp.pacePerMile();
            Console.WriteLine($"Speed - mph:             {mph}");
            Console.WriteLine($"Speed - kph:             {kph}");
            Console.WriteLine($"Speed - yph:             {yph}");
            Console.WriteLine($"Speed - secondsPerMile:  {spm}");
            Console.WriteLine($"Speed - pacePerMile:     {ppm}");
            
            // Project the Speed to another Distance, simple formula
            ElapsedTime etp1 = sp.projectedTime(new Distance(31.0));
            Console.WriteLine($"Speed projected to 31m:  {etp1.asHHMMSS()}");

            // Project the Speed to another Distance, riegel exponential formula
            ElapsedTime etp2 = sp.projectedTime(new Distance(31.0), Constants.SpeedFormulaRiegel);
            Console.WriteLine($"Speed projected to 31m:  {etp2.asHHMMSS()}");

            Age a1 = new Age(42.4);
            Age a2 = new Age(67.5);

            Speed agsp = sp.ageGraded(a1, a2);
            Console.WriteLine($"age-graded to 67.5:      {agsp.elapsedTime.asHHMMSS()}");

            RunWalkCalculator rwc = new RunWalkCalculator();
            // method signature: calculate(runHHMMSS, runPPM, walkHHMMSS, walkPPM, miles)
            // returns a RunWalkCalculation struct
            RunWalkCalculation calc = rwc.calculate("4:30", "9:30", "00:30", "17:00", 26.2);
            Console.WriteLine($"RunWalkCalc - mph:       {calc.averageSpeed.mph()}");
            Console.WriteLine($"RunWalkCalc - proj time: {calc.projectedTime}");
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
        
        private static async Task<string> SKSimplePlugins()
        {
            string apiUrl = ReadEnvVar("AZURE_OPENAI_URL", "none");
            string apiKey = ReadEnvVar("AZURE_OPENAI_KEY", "none");
            string depName = ReadEnvVar("AZURE_OPENAI_COMPLETIONS_DEPLOYMENT", "gpt-3.5-turbo");
            string cat = ReadEnvVar("CAT", "Betty");
            string resultText = "none";
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
            builder.Plugins.AddFromType<TimePlugin>();     // TimePlugin is a SK built-in plugin
            builder.Plugins.AddFromType<RunningPlugin>();  // RunningPlugin is a custom native plugin
            Console.WriteLine("builder: " + builder);
            
            Kernel kernel = builder.Build();
            Console.WriteLine("kernel: " + kernel);
            
            // Invoke the built-in TimePlugin - several methods
            // See docs at https://learn.microsoft.com/en-us/dotnet/api/microsoft.semantickernel.plugins.core.timeplugin
            var date = await kernel.InvokeAsync("TimePlugin", "Date");
            Console.WriteLine("date: " + date);
            var today = await kernel.InvokeAsync("TimePlugin", "DayOfWeek");
            Console.WriteLine("today: " + today);
            var tz = await kernel.InvokeAsync("TimePlugin", "TimeZoneName");
            Console.WriteLine("tz: " + tz);      

            // Invoke the custom native RunningPlugin - several methods
            var dist = await kernel.InvokeAsync(
                "RunningPlugin", "MarathonDistance", new KernelArguments());
            Console.WriteLine("marathon distance: " + dist);
            
            var args = new KernelArguments();
            args.Add("distance", "26.2");
            args.Add("hhmmss", "3:47:30");
            var ppm = await kernel.InvokeAsync(
                "RunningPlugin", "CalculatePacePerMile", args);
            Console.WriteLine("ppm: " + ppm);
            
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

            return Core.Env.EnvVar(name, defaultValue);
        }

        private static string PromptUser(string message) {

            Console.WriteLine(message);
            return "" + Console.ReadLine();
        }
    }
}

