using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Notebook notebook = new Notebook("see", "create", "del");
            Notebook notebook = new Notebook();
            NotebookLogger notebookLogger = new NotebookLogger(notebook);
            const string ExitProgramKeyword = "exit";
            string commandPrompt = "Please enter " + notebook.show + ", " + notebook._new + ", " + notebook.delete + ", or " + notebook.log;

            Console.WriteLine(Notebook.IntroMessage);
            Console.WriteLine(commandPrompt);
            string input = "";
            do
            {
                input = Console.ReadLine();
                string[] commands = input.Split();

                // get the first command.... show, new, or delete
                // and pass the second command to the functions
                try
                {
                    notebook[commands[0]]((commands.Length > 1) ? commands[1] : "");
                } catch(KeyNotFoundException)
                {
                    if (input != ExitProgramKeyword)
                    {
                        Console.WriteLine(commandPrompt);
                    }
                }
                Console.WriteLine();

            } while (  input != ExitProgramKeyword );

            Console.WriteLine(Notebook.OutroMessage);
        }
    }
}