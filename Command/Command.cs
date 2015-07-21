using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTool
{
    /// <summary> 
    /// Command 的摘要说明。 
    /// </summary> 
    public class Command
    {
        private Process proc = null;
        /// <summary> 
        /// 构造方法 
        /// </summary> 
        public Command()
        {
            proc = new Process();
        }
        /// <summary> 
        /// 执行CMD语句 
        /// </summary> 
        /// <param name="cmd">要执行的CMD命令</param> 
        public void RunCmd(string cmd)
        {
            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = " /c " + cmd;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.WaitForExit();
            proc.Close();
        }

        /// <summary>
        /// 打开控制台执行拼接完成的批处理命令字符串
        /// </summary>
        /// <param name="inputAction">需要执行的命令委托方法：每次调用 <paramref name="inputAction"/> 中的参数都会执行一次</param>
        public static void ExecBatCommand(Action<Action<string>> inputAction)
        {
            Process pro = null;
            StreamWriter sIn = null;
            StreamReader sOut = null;

            try
            {
                pro = new Process();
                pro.StartInfo.FileName = "cmd.exe";
                pro.StartInfo.UseShellExecute = false;
                pro.StartInfo.CreateNoWindow = true;
                pro.StartInfo.RedirectStandardInput = true;
                pro.StartInfo.RedirectStandardOutput = true;
                pro.StartInfo.RedirectStandardError = true;

                pro.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                pro.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);

                pro.Start();
                sIn = pro.StandardInput;
                sIn.AutoFlush = true;

                pro.BeginOutputReadLine();
                inputAction(value => sIn.WriteLine(value));

                pro.WaitForExit();
            }
            finally
            {
                if (pro != null && !pro.HasExited)
                    pro.Kill();

                if (sIn != null)
                    sIn.Close();
                if (sOut != null)
                    sOut.Close();
                if (pro != null)
                    pro.Close();
            }
        }
    }
}
