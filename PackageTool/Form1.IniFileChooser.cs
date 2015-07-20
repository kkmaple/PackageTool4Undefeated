using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            WritePrivateProfileString("init_value", "current_base", newVer, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
            //添加旧版本
            WritePrivateProfileString("resource_list", "base" + (verCount+1), newVer, "F:/1.6.0.0_ios/package-ios/pkgconf.ini");
            //刷新数据,源界面显示
            RefreshUIData();
        }
    }
}
