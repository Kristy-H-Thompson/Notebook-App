using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class NotebookLogger
    {
        private Notebook trackedNotebook;
        private bool logging = true;

        public NotebookLogger(Notebook trackedNotebook) 
        { 
            this.trackedNotebook = trackedNotebook;
            Attach();
            trackedNotebook.LoggingToggled += ToggleLogging;

        }
        private void PrintAdded(string typeItemAdded)
        {
            Console.WriteLine(typeItemAdded + "was added to the notebook");
        }
        private void PrintDeleted(string idOfDeleted)
        {
            if (idOfDeleted != "")
            {
                Console.WriteLine("Item" + idOfDeleted + "was deleted from the notebook");
            }
            else
            {
                Console.WriteLine("Everything was deleted from the notebook");
            }
        }

        private void IncorrectCommand(string messageToPrint)
        {
            Console.WriteLine("Bad command" + messageToPrint);
        }

        public void ToggleLogging(bool turnon)
        {
            string output = "logger is already" + ((turnon) ? "on" : "off") + ".";

            if (logging )
            {
                if (!turnon)
                {
                    Detach();
                    logging =false;
                    output = "logger turned off";
                }
            }
            else
            {
                if (turnon)
                {
                    Attach();
                    logging = true;
                    output = "Logger turned on.";
                }
            }
            Console.WriteLine(output);
        }

        private void Attach()
        {
            trackedNotebook.ItemAdded += PrintAdded;
            trackedNotebook.ItemRemoved += PrintDeleted;
            trackedNotebook.InputBadCommand += IncorrectCommand;
        }

        private void Detach()
        {
            trackedNotebook.ItemAdded -= PrintAdded;
            trackedNotebook.ItemRemoved -= PrintDeleted;
            trackedNotebook.InputBadCommand -= IncorrectCommand;
        }
    }
}
