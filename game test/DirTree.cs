using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace game_test
{   
    internal class DirTree : Terminal.Gui.Trees.ITreeBuilder<string>
    {   
        public bool SupportsCanExpand => true;

        public bool CanExpand(string toExpand)
        {
            try { var test = Directory.GetFiles(toExpand).Length; } 
            catch (System.IO.IOException) { return false; }
            return (Directory.GetDirectories(toExpand).Length > 0)|| (Directory.GetFiles(toExpand).Length > 0);
           
        }

        public IEnumerable<string> GetChildren(string path)
        {
            var children = Directory.GetDirectories(path).Concat(Directory.GetFiles(path));
            return children;
        }
       
    }
}
