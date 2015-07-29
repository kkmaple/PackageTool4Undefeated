using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            InitData();
            RefreshUIData();
        }

        private void BasePathBrowserBtn_Click(object sender, EventArgs e)
        {

        }

        private void NewVerBtn_Click(object sender, EventArgs e)
        {
            VersionUpgrade();
        }

        private void GoGoGo_Click(object sender, EventArgs e)
        {
            DoPack();
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            DiffTowFile();
        }

        private void testSynBtn_Click(object sender, EventArgs e)
        {
            SynVersion();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
