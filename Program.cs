using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
     class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook("see", "create", "remove");
            const string ExitProgramKeyword = "exit";
            string commandPrompt = "Please enter " + notebook.show + ", " + notebook.delete + notebook._new; _ = ", or " + notebook.log;
            Console.WriteLine (Notebook.IntroMessage);
            Console.WriteLine(commandPrompt);
            string input = "";
            do 
            { 
                input = Console.ReadLine();
                string[] commnads = input.Split();
                try
                {
                    notebook[commnads[0]]((commnads.Length > 1) ? commnads[1] : "");
                }
                catch(KeyNotFoundException) 
                {
                    Console.WriteLine(commandPrompt);
                    if  (input != ExitProgramKeyword)
                    {
                        Console.WriteLine(commandPrompt);
                    }
                }
                Console.WriteLine();
            }
            while (input != ExitProgramKeyword);
            Console.WriteLine(Notebook.OutroMessage);
        }
    }
}
