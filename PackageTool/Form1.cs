using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath); 

        private void Form1_Load(object sender, EventArgs e)
        {
            InitUIData();
        }

        private void BasePathBrowserBtn_Click(object sender, EventArgs e)
        {
            Command cmd = new Command();
            //cmd.RunCmd(@"file_generator.py");
            //cmd.RunCmd(@"md5cmp.py");
            //cmd.RunCmd(@"tool.py");
            //Command.ExecBatCommand(p =>
            //    {
            //        p(@"dir");
            //        p("pause");
            //    });
            cmd.RunCmd(@"dir");
            DiffTool.Diff("1.6.05.0.txt", "1.6.06.0.txt", @"F:\1.6.0.0_ios\package-ios\restmd5xt");
        }

        private void InitUIData()
        {
            StringBuilder temp = new StringBuilder(255);
#if DEBUG
            GetPrivateProfileString("init_value", "basepath", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("init_value", "basepath", "", temp, 255, "./pkgconf.ini");
#endif
            BasePathTxt.Text = temp.ToString();
#if DEBUG
            GetPrivateProfileString("init_value", "current_base", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("init_value", "current_base", "", temp, 255, "./pkgconf.ini");
#endif
            CurVerTxt.Text = temp.ToString();
#if DEBUG
            GetPrivateProfileString("init_value", "basepath", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("init_value", "basepath", "", temp, 255, "./pkgconf.ini");
#endif
        }
    }
}
