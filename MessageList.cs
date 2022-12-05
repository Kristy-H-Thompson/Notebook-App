using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
     class MessageList : TextualMessage
    {
        private enum BulletType { Dashed, Numbered, Star};
        private BulletType bulletType;

        //Define Later
        public override IPageable Input()
        {
            Console.WriteLine("Please input your name");
            myData.author = Console.ReadLine();
            Console.WriteLine("Please input message title");
            myData.title = Console.ReadLine();
            Console.WriteLine("What type of bullet point would you like to use?");
            Console.WriteLine("Please enter dashed, numbered, or star");

            bool goodInput = false;
            while(!goodInput)
            {
                goodInput = true;
                switch (Console.ReadLine())
                {
                    case "dashed": 
                        bulletType = BulletType.Dashed;
                        break;
                    case "numbered":
                        bulletType = BulletType.Numbered;
                        break;
                    case "star":
                        bulletType= BulletType.Star; 
                        break;
                    default:
                        Console.WriteLine("Please enter dashed, numbered, or star");
                        goodInput = false;
                        break;
                }
            }

            Console.WriteLine("Star typing your list. Every time you hit enter a new item will be created");
            Console.WriteLine("Press enter with a blank list item to end your input");
            bool finishedlist = false;
            int i = 1;
            while (!finishedlist)
            {
                string input = Console.ReadLine();

                if (input == "")
                {
                    finishedlist = true;
                }
                else
                {
                    switch(bulletType)
                    {
                        case BulletType.Dashed:
                            message += "- " + input + "\n";
                            break;
                        case BulletType.Numbered:
                            message += "- " + i + ". "+ "\n";
                            i++;
                            break;
                        case BulletType.Star:
                            message += "* " + input + "\n";
                            break;
                    }
                }
            }
            return this;
        }
    }
}
