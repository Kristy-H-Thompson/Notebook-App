using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public struct PageData {
        public string title;
        public string author;
    };

    public interface IPageable
    {
        PageData MyData { get; set; }

        //How we are going to input our item
        IPageable Input();
        
        //How we output the page
        void Output();
    }
}
