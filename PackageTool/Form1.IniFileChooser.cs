﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
            GetPrivateProfileString("gener_value", "svncodedir", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("gener_value", "svncodedir", "", temp, 255, "./pkgconf.ini");
#endif
            svnpath = temp.ToString();
#if DEBUG
            GetPrivateProfileString("init_value", "xmlbasever", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("init_value", "xmlbasever", "", temp, 255, "./pkgconf.ini");
#endif
            BaseVerTxt.Text = temp.ToString();
#if DEBUG
            GetPrivateProfileString("init_value", "version_len", "", temp, 255, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
#else
            GetPrivateProfileString("init_value", "version_len", "", temp, 255, "./pkgconf.ini");
#endif
            verLen = Int32.Parse(temp.ToString());
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
#if TEST
            //int verLen = nowVer.Split('.')[2].Length;
            string newVer = "" + (Int32.Parse(nowVer.Split('.')[3]) + 1);
            newVer = nowVer.Split('.')[0] + "." + nowVer.Split('.')[1] + "." + nowVer.Split('.')[2] + "." + newVer;
#else
            //int verLen = nowVer.Split('.')[2].Length;
            string newVer = "";
            for (int i = 1; i < verLen && Int32.Parse(nowVer.Split('.')[2]) < 9; ++i)
            {
                newVer += "0";
            }
            newVer += Int32.Parse(nowVer.Split('.')[2]) + 1;
            newVer = nowVer.Split('.')[0] + "." + nowVer.Split('.')[1] + "." + newVer + "." + nowVer.Split('.')[3];
#endif
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
            //设置ini文件名
#if TEST
            iniFileName = "pkgconf-test.ini";
            testSynBtn.Visible = true;
#else
            iniFileName = "pkgconf-trunk.ini";
            autoCompareCheckBox.Visible = true;
#endif
            //拷贝pkgconf.ini文件
#if DEBUG
            File.Copy("F:/1.6.0.0_ios/package-ios/" + iniFileName, "F:/1.6.0.0_ios/package-ios/pkgconf.ini", true);
#else
            File.Copy(iniFileName, "./pkgconf.ini", true);
#endif
        }

        private bool DoPack(bool showEnd = true)
        {
            
            //Svn 更新Media目录
            //MessageBox.Show(resPath);
            SVN.Update(resPath);
            UpdateLocalizationFile();
            CopyLocallizationFile();
            //BackupResDir();
            Command cmd = new Command();
            //删除之前的zip和zs5文件
            cmd.RunCmd(@"del /f /q *.zip *.zs5");
            //检查md5文件
            CheckMd5File();
            cmd.RunCmd(@"file_generator.py");
#if TEST
            DiffTowFile();
            var result = MessageBox.Show("继续么？", "提示",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                if (File.Exists(resmd5txtFolder + "/" + curVer + ".txt"))
                    File.Delete(resmd5txtFolder + "/" + curVer + ".txt");
                return false;
            }
#else
            if (autoCompareCheckBox.Checked)
            {
                DiffTowFile();
                var result = MessageBox.Show("继续么？", "提示",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning);

                // If the no button was pressed ...
                if (result == DialogResult.No)
                {
                    return false;
                }
            }
#endif
            cmd.RunCmd(@"md5cmp.py");
            cmd.RunCmd(@"tool.py");
            if (Directory.Exists("unzip"))
                Directory.Delete("unzip", true);
            cmd.RunCmd(@"解压拷贝.bat");
            //拷贝最新的ini文件
#if DEBUG
            File.Copy("F:/1.6.0.0_ios/package-ios/pkgconf.ini", "F:/1.6.0.0_ios/package-ios/" + iniFileName, true);
#else
            if(showEnd)
                File.Copy("./pkgconf.ini", iniFileName, true);
#endif
            //修改xml文件
            if (showEnd)
                ModifyChangeXml();
            //拷贝最终的zip包
            //CopyFinalZipPack();
            if(showEnd)
                MessageBox.Show(curPath.Split('\\')[curPath.Split('\\').Length - 1] + " 更新包已打出！");

            return true;
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
            if ("" != locPath)
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

        private void SynVersion()
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString("init_value", "basepath", "", temp, 255, "./pkgconf-trunk.ini");
            string trunkBasepath = temp.ToString();
            //MessageBox.Show("trunkBasepath" + trunkBasepath);
            GetPrivateProfileString("init_value", "basepath", "", temp, 255, "./pkgconf-test.ini");
            string testBasepath = temp.ToString();
            //MessageBox.Show("testBasepath" + testBasepath);
            if (Directory.Exists(testBasepath))
                Directory.Delete(testBasepath, true);
            FileSystem.CopyDirectory(trunkBasepath, testBasepath, true);
            GetPrivateProfileString("init_value", "current_base", "", temp, 255, "./pkgconf-trunk.ini");
            WritePrivateProfileString("init_value", "current_base", temp.ToString(), "./pkgconf-test.ini");
            WritePrivateProfileString("resource_list", null, null, "./pkgconf-test.ini");
            for (int i = 1; ; ++i)
            {
                GetPrivateProfileString("resource_list", "base" + i, "", temp, 255, "./pkgconf-trunk.ini");
                if (temp.ToString() == "")
                    break;
                WritePrivateProfileString("resource_list", "base" + i, temp.ToString(), "./pkgconf-test.ini");
            }
            InitData();
            RefreshUIData();
            MessageBox.Show("同步完成！");
        }

        private void DiffTowFile()
        {
#if TEST
            string lastVer = "";
            lastVer = curVer.Split('.')[0] + "." + curVer.Split('.')[1] + "." + curVer.Split('.')[2] + ".0";
            DiffTool.Diff(lastVer + ".txt", CurVerTxt.Text + ".txt", resmd5txtFolder);
#else
            string lastVer = "";
            if (verLen == 1 && Int32.Parse(curVer.Split('.')[2]) > 0)
                lastVer = curVer.Split('.')[0] + "." + curVer.Split('.')[1] + "." + (Int32.Parse(curVer.Split('.')[2]) - 1) + "." + curVer.Split('.')[3];
            else
            {
                if (Int32.Parse(curVer.Split('.')[2]) < 11 && Int32.Parse(curVer.Split('.')[2]) > 0)
                    lastVer = curVer.Split('.')[0] + "." + curVer.Split('.')[1] + ".0" + (Int32.Parse(curVer.Split('.')[2]) - 1) + "." + curVer.Split('.')[3];
                else if (Int32.Parse(curVer.Split('.')[2]) > 0)
                    lastVer = curVer.Split('.')[0] + "." + curVer.Split('.')[1] + (Int32.Parse(curVer.Split('.')[2]) - 1) + "." + curVer.Split('.')[3];
            }
            //MessageBox.Show("lastVer: " + lastVer + " curVer: " + CurVerTxt.Text);
            DiffTool.Diff(lastVer + ".txt", CurVerTxt.Text + ".txt", resmd5txtFolder);
#endif
        }

        private void BackupResDir()
        {
#if !TEST
            string destDir = Path.GetDirectoryName(BasePathTxt.Text);
            if (Directory.Exists(destDir + "\\" + curVer + " - formal"))
                Directory.Delete(destDir + "\\" + curVer + " - formal", true);
            if(Directory.Exists(BasePathTxt.Text))
                FileSystem.CopyDirectory(BasePathTxt.Text, destDir + "\\" + curVer + " - formal", true);
#endif
        }

        private void DoBigPatch()
        { 
#if !TEST
            Command cmd = new Command();
            cmd.RunCmd("generateBigPatch.py");
            MessageBox.Show(" 大包已打！");
            Application.Exit();
#endif
        }

        private void RedoBigPatch()
        {
#if !TEST
            VersionUpgrade();
            if (!DoPack(false))
                return;
            StringBuilder temp = new StringBuilder(255);
            XmlDocument doc = new XmlDocument();
            GetPrivateProfileString("version", "ver", "", temp, 255, "./bigPatch.ini");
            doc.Load(BasePathTxt.Text + "/version.xml");
            var a = doc.SelectSingleNode("versionCfg/Property[@name='" + "version" + @"']").Attributes["value"].InnerXml = temp.ToString();
            doc.Save(BasePathTxt.Text + "/version.xml");
            if (File.Exists(BasePathTxt.Text + "/Media_" + temp.ToString() + ".pak"))
                File.Delete(BasePathTxt.Text + "/Media_" + temp.ToString() + ".pak");
            Command cmd = new Command();
            //MessageBox.Show(svnpath + @"/Tools/ZLibTool.exe");
            cmd.RunCmd(svnpath + @"/Tools/ZLibTool.exe");
            File.Move(curPath + "/Paks/Media.pak", BasePathTxt.Text + "/Media_" + temp.ToString() + ".pak");
            String msdstringsass = MD5File(BasePathTxt.Text + "/Media_" + temp.ToString() + ".pak");
            FileStream fs = File.OpenWrite(BasePathTxt.Text + "/Media_" + temp.ToString() + ".zs5");
            byte[] data = new UTF8Encoding().GetBytes(MD5File(BasePathTxt.Text + "/Media_" + temp.ToString() + ".pak"));
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
            MessageBox.Show(" 大包已重打！");
            Application.Exit();
#endif
        }

        /// <summary>
        /// 计算文件的 MD5 值
        /// </summary>
        /// <param name="fileName">要计算 MD5 值的文件名和路径</param>
        /// <returns>MD5 值16进制字符串</returns>
        public static String MD5File(String fileName)
        {
            return HashFile(fileName, "md5");
        }

        /// <summary>
        /// 计算文件的哈希值
        /// </summary>
        /// <param name="fileName">要计算哈希值的文件名和路径</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值16进制字符串</returns>
        public static String HashFile(String fileName, String algName)
        {
            if (!System.IO.File.Exists(fileName))
                return String.Empty;

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] hashBytes = HashData(fs, algName);
            fs.Close();
            return ByteArrayToHexString(hashBytes);
        }

        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="stream">要计算哈希值的 Stream</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值字节数组</returns>
        public static byte[] HashData(Stream stream, String algName)
        {
            HashAlgorithm algorithm;
            if (algName == null)
            {
                throw new ArgumentNullException("algName 不能为 null");
            }
            if (String.Compare(algName, "sha1", true) == 0)
            {
                algorithm = SHA1.Create();
            }
            else
            {
                if (String.Compare(algName, "md5", true) != 0)
                {
                    throw new Exception("algName 只能使用 sha1 或 md5");
                }
                algorithm = MD5.Create();
            }
            return algorithm.ComputeHash(stream);
        }

        /// <summary>
        /// 字节数组转换为16进制表示的字符串
        /// </summary>
        public static String ByteArrayToHexString(byte[] buf)
        {
            String returnStr = "";
            if (buf != null)
            {
                for (int i = 0; i < buf.Length; i++)
                {
                    returnStr += buf[i].ToString("X2");
                }
            }
            return returnStr.ToLower();
        }
    }
}
