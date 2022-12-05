using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Notebook
    {
        List<IPageable> pages = new List<IPageable>();
        public const string IntroMessage = "Welcome to the Notebook program v1";
        public const string OutroMessage = "Thank you for using the Notebook program v1";

        public delegate void simpleFunction(string command);
        public delegate void BooleanFunction(bool isOn);
        public event simpleFunction ItemAdded, ItemRemoved, InputBadCommand;
        public event BooleanFunction LoggingToggled;
        private Dictionary<string, simpleFunction> commandLineArgs = new Dictionary<string, simpleFunction>();

        public readonly string show = "show", _new = "new", delete = "delete", log = "logger";

        public simpleFunction this[string command]
        {
            get { return commandLineArgs[command]; }
        }


        public Notebook()
        {
            commandLineArgs.Add(show, Show);
            commandLineArgs.Add(_new, New);
            commandLineArgs.Add(delete, Delete);
            commandLineArgs.Add(log, Log);

        }

        //Summary: creates a new notebook with input commands instead of default ones 
        public Notebook(params string[] commandLineKeyWords) : this()
        { 
        for (int i = 0; i < commandLineKeyWords.Length; ++i)
            {

                if (commandLineKeyWords == "")
                {
                    continue;
                }

                switch (i)
                {
                    //show
                    case 0:
                        commandLineArgs.Remove(show);
                        commandLineArgs.Add(show = commandLineKeyWords[i], Show);
                        break;

                    //New
                    case 1:
                        commandLineArgs.Remove(_new);
                        commandLineArgs.Add(_new = commandLineKeyWords[i], New);
                        break;

                    //Delete
                    case 2:
                        commandLineArgs.Remove(delete);
                        commandLineArgs.Add(delete = commandLineKeyWords[i], Delete);
                        break;
                }
            }
        }

       public void New(string command)
        {
            Console.WriteLine("New Method" + command);
            switch (command)
            {
                case "":
                    Console.WriteLine("New commands:");
                    Console.WriteLine("message     create new message page");
                    Console.WriteLine("list     create new list page");
                    Console.WriteLine("image     create new image page");
                    break;

                case "message":
                    pages.Add(new TextualMessage().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("Textual Message");
                    }
                    break;

                case "list":
                    pages.Add(new MessageList().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("Message List");
                    }
                    break;

                case "image":
                    pages.Add(new Image().Input());
                    if (ItemAdded != null)
                    {
                        ItemAdded("Image");
                    }
                    break;
                default:
                    if (InputBadCommand != null)
                    {
                        InputBadCommand("you didn't enter a message, list, or image.. Please try again");
                    }
                    break;
            }
        }

        public void Show(string command)
        {
            Console.WriteLine("Show Method" + command);
            switch (command)
            {
                case "":
                    Console.WriteLine("Show commands:");
                    Console.WriteLine("pages         lits all created pages");
                    Console.WriteLine("id of page    displays that page");
                    break;

                case "pages":
                    Console.WriteLine("--------------Pages--------------");
                    for (int i = 0; i < pages.Count; ++i)
                    {
                        Console.WriteLine("ID" + i + " " + pages[i].MyData.title);
                    }
                    break;
            
                 default:
                    int number;
                    if (int.TryParse(command, out number))
                    {
                        Console.WriteLine("Showing pages" + number);
                        if (number < pages.Count)
                        {
                            pages[number].Output();
                        }
                        else
                        {
                            if (InputBadCommand != null)
                            {
                                InputBadCommand("Your number was outside of the range of pages. Please try again");
                            }
                        }
                    }
                    else
                    {
                        if (InputBadCommand != null)
                        {
                            InputBadCommand("You didn't enter pages or a valid number try again");
                        }
                    }
                    break;
            }
        }
 
        public void Delete(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("Delete commands:");
                    Console.WriteLine("all         delete all pages");
                    Console.WriteLine("id of page    deletes that page");
                    break;

                case "all":
                    if (ItemRemoved != null)
                    {
                        ItemRemoved("");
                    }
                    pages.Clear();
                    break;

                default:
                    int number;
                    if (int.TryParse(command, out number))
                    {
                        if (number < pages.Count)
                        {
                            pages.RemoveAt(number);

                            if (ItemRemoved != null)
                            {
                                ItemRemoved(number + "");
                            }
                        }
                        else
                        {
                            if (InputBadCommand != null)
                            {
                                InputBadCommand("Your numbers was outside the range of pages, please try again");
                            }
                        }
                     }                   
                        else
                     {
                        if (InputBadCommand != null)
                        {
                            InputBadCommand("You didn't input all, or your number was outside the range of pages. Please try again!");
                        }
                    }

                    break;

            }
            
        }

        private void Log(string command)
        {
            switch (command)
            {
                case "":
                    Console.WriteLine("on         turn logger on");
                    Console.WriteLine("off        turn logger off");
                    break;

                case "on":
                    if (LoggingToggled != null)
                    {
                        LoggingToggled(true);
                    }
                    break;

                case "off":
                    if (LoggingToggled != null)
                    {
                        LoggingToggled(false);
                    }
                    break;

                default:
                    if(InputBadCommand!= null)
                    {
                        InputBadCommand("please enter on or off after inputting this command");
                    }
                    break;

            }

        }
    }
}

