using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PackageTool
{
    public partial class Form1
    {
        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void RefreshUIData()
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
            curVer = CurVerTxt.Text = temp.ToString();
#if DEBUG
            GetPrivateProfileString("init_value", "xmlbasever", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("init_value", "xmlbasever", "", temp, 255, "./pkgconf.ini");
#endif
            BaseVerTxt.Text = temp.ToString();
#if DEBUG
            GetPrivateProfileString("gener_value", "md5txtpath", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("gener_value", "md5txtpath", "", temp, 255, "./pkgconf.ini");
#endif
            resmd5txtFolder = temp.ToString();
#if DEBUG
            GetPrivateProfileString("changexml_path", "changexmlpath", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("changexml_path", "changexmlpath", "", temp, 255, "./pkgconf.ini");
#endif
            changePath = temp.ToString();
#if DEBUG
            GetPrivateProfileString("changexml_path", "os", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("changexml_path", "os", "", temp, 255, "./pkgconf.ini");
#endif
            changeOs = temp.ToString();
#if DEBUG
            GetPrivateProfileString("online_folder", "onlinefolder", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("online_folder", "onlinefolder", "", temp, 255, "./pkgconf.ini");
#endif
            onlineFolder = temp.ToString();
#if DEBUG
            GetPrivateProfileString("localization", "locpath", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("localization", "locpath", "", temp, 255, "./pkgconf.ini");
#endif
            locPath = temp.ToString();
            #if DEBUG
            GetPrivateProfileString("localization", "respath", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("localization", "respath", "", temp, 255, "./pkgconf.ini");
#endif
            resPath = temp.ToString();
            //添加resource list
            ResList.Items.Clear();
            for (int i = 1; ; ++i)
            {
#if DEBUG
                GetPrivateProfileString("resource_list", "base" + i, "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
                GetPrivateProfileString("resource_list", "base" + i, "", temp, 255, "./pkgconf.ini");
#endif
                if (temp.ToString() == "")
                    break;

                verCount = i;
                ResList.Items.Add("base" + i + " = " + temp.ToString());
            }
        }

        private void VersionUpgrade()
        {
            //计算新版本
            string nowVer = CurVerTxt.Text;
            int verLen = nowVer.Split('.')[2].Length;
            string newVer = "";
            for (int i = 1; i < verLen && Int32.Parse(nowVer.Split('.')[2]) < 9; ++i)
            {
                newVer += "0";
            }
            newVer += Int32.Parse(nowVer.Split('.')[2]) + 1;
            newVer = nowVer.Split('.')[0] + "." + nowVer.Split('.')[1] + "." + newVer + "." + nowVer.Split('.')[3];
            //设置新版本
#if DEBUG
            WritePrivateProfileString("init_value", "current_base", newVer, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            WritePrivateProfileString("init_value", "current_base", newVer, "./pkgconf.ini");
#endif
            //添加旧版本
#if DEBUG
            WritePrivateProfileString("resource_list", "base" + (verCount+1), nowVer, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            WritePrivateProfileString("resource_list", "base" + (verCount+1), nowVer, "./pkgconf.ini");
#endif
            //刷新数据,源界面显示
            RefreshUIData();
        }

        private void InitData()
        {
            //获取当前工作目录
            curPath = System.IO.Directory.GetCurrentDirectory();
            //设置窗口名称
            this.Text = curPath;
            //拷贝pkgconf.ini文件
#if DEBUG
            File.Copy("F:/1.6.0.0_ios/package-ios/pkgconf-trunk.ini", "F:/1.6.0.0_ios/package-ios/pkgconf.ini", true);
#else
            File.Copy("./pkgconf-trunk.ini", "./pkgconf.ini", true);
#endif
        }

        private void DoPack()
        {
            //Svn 更新Media目录
            SVN.Update(resPath);
            UpdateLocalizationFile();
            CopyLocallizationFile();
            Command cmd = new Command();
            //删除之前的zip和zs5文件
            cmd.RunCmd(@"del /f /q *.zip *.zs5");
            //检查md5文件
            CheckMd5File();
            cmd.RunCmd(@"file_generator.py");
            cmd.RunCmd(@"md5cmp.py");
            cmd.RunCmd(@"tool.py");
            cmd.RunCmd(@"解压拷贝.bat");
            //拷贝最新的ini文件
#if DEBUG
            File.Copy("F:/1.6.0.0_ios/package-ios/pkgconf.ini", "F:/1.6.0.0_ios/package-ios/pkgconf-trunk.ini", true);
#else
            File.Copy("./pkgconf.ini", "./pkgconf-trunk.ini", true);
#endif
            //修改xml文件
            ModifyChangeXml();
            //拷贝最终的zip包
            //CopyFinalZipPack();
            MessageBox.Show(curPath.Split('\\')[curPath.Split('\\').Length - 1] + " 更新包已打出！");
        }

        private void CheckMd5File()
        {
            if (File.Exists(resmd5txtFolder + "/" + curVer + ".txt"))
            {
                for (int i = 1; ; ++i)
                {
                    if (File.Exists(resmd5txtFolder + "/" + curVer + "-" + i + ".txt"))
                        continue;
                    File.Move(resmd5txtFolder + "/" + curVer + ".txt", resmd5txtFolder + "/" + curVer + "-" + i + ".txt");
                    break;
                }
            }
        }

        private void ModifyChangeXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(changePath);
            var a = doc.SelectSingleNode("versionCfg/conf[@os='"+ changeOs + @"']").Attributes["version"].InnerXml = curVer;
            doc.Save(changePath);
        }

        private void CopyFinalZipPack()
        {
            DateTime now = DateTime.Now;
            if (!Directory.Exists(onlineFolder + @"\" + now.Year + now.Month + now.Day + "-" + curVer))
            {
                //Directory.Delete(onlineFolder + @"\" + now.Year + now.Month + now.Day + "-" + curVer, true);
                Directory.CreateDirectory(onlineFolder + @"\" + now.Year + now.Month + now.Day + "-" + curVer);
            }
            Command.ExecBatCommand(p =>
            {
#if DEBUG
                p("xcopy " + @"F:\1.6.0.0_ios\package-ios" + @"\*.zip " + onlineFolder + @"\" + now.Year + now.Month + now.Day + "-" + curVer + " /R /D /Y");
#else
                p("xcopy "+ curPath + "/*.zip " + onlineFolder + "/" + now.Year + now.Month + now.Day + "-" + curVer + " /R /D /Y");
#endif
                p("exit");
            });
        }

        private void UpdateLocalizationFile()
        {
            SVN.Update(locPath);
        }

        private void CopyLocallizationFile()
        {
            if ("" != locPath)
            {
                FileSystem.CopyDirectory(locPath, resPath, true);
                Command.ExecBatCommand(p =>
                {
                    p(resPath.Substring(0,2));
                    p("cd " + resPath);
                    p(@"del /f /q *.xlsx");
                    p("exit");
                });
            }
        }
    }
}
