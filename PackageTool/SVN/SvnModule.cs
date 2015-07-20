using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTool
{
    class SVN
    {
        public static void Update(string folder)
        {
            Command.ExecBatCommand(p =>
                {
                    p(@"cd " + folder);
                    p("svn update");
                    //p("pause");
                });
        }
    };
}
