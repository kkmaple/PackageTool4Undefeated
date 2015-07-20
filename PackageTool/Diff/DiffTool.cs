using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTool
{
    class DiffTool
    {
        public static void Diff(string file1, string file2, string folder)
        {
            Command.ExecBatCommand(p =>
            {
                p(folder.Substring(0,2));
                p(@"cd " + folder);
                p("TortoiseMerge " + file1 + " " + file2);
            });
        }
    }
}
