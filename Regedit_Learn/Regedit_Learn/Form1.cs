using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using Regedit_Learn.initUser.model;
using Regedit_Learn.initUser.pojo;
using Regedit_Learn.initUser.vo;

namespace Regedit_Learn {
    public partial class Form1 : Form {
        #region 构造函数
        public Form1() {
            InitializeComponent();
        }
        #endregion

        #region 窗体加载事件
        private void Form1_Load(object sender, EventArgs e) {
            RegistryKey mreg = Registry.LocalMachine.OpenSubKey("HARDWARE", true).CreateSubKey("Baidu").CreateSubKey("BaiduYunGuanjia");// 有则读取，无则创建
            if (mreg.GetValue("Version") != null) {
                //textBox1.Text = "键值项：Version 值：" + mreg.GetValue("Version").ToString();
            }
            else {
                mreg.SetValue("Version", "6.8.10");
            }
        }
        #endregion

        #region 向注册表中写入信息
        private void button1_Click(object sender, EventArgs e) {
            //RegistryKey rkSoftware = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            //RegistryKey rkDayang = rkSoftware.CreateSubKey("Dayang");
            RegistryKey mreg = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey("Baidu").CreateSubKey("BaiduYunGuanjia");// 有则读取，无则创建


        }
        #endregion

        #region 退出按钮事件
        private void button2_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        #endregion

        private void button3_Click(object sender, EventArgs e) {

        }

        #region
        private void button4_Click(object sender, EventArgs e) {
            string _connString = "server=178.20.10.85;database=Net2Dynetmanage2019;uid=sa;pwd=lq612176()";
            SQLServer_Connector con = new SQLServer_Connector(_connString);
            con.query();
        }
        #endregion

        #region 添加至注册表
        private void buttonAddToReg_Click(object sender, EventArgs e) {
            string _baseKey = "HARDWARE";
            string _subKey = @"Dayang\dydatabase\NetManageDBSetting";
            RegisterInfo registerInfo = new RegisterInfo("178.20.10.85", "Net2Dynetmanage2019", "sa", "lq612176()", 00000001);
            Register register = new Register(_baseKey, _subKey, registerInfo);
            register.AddInfoToRegedit();
        }
        #endregion

        #region 从注册表中获取信息按钮事件
        private void buttonFindFromReg_Click(object sender, EventArgs e) {
            //string _baseKey = "HARDWARE";
            //string _subKey = @"Dayang\dydatabase\NetManageDBSetting";
            //RegisterInfo registerInfo = new RegisterInfo("178.20.10.85", "Net2Dynetmanage2019", "sa", "lq612176()", 00000001);
            //Register register = new Register(_baseKey, _subKey, registerInfo);
            //RegisterInfoVO registerInfoVO = register.GetInfoFromRegedit();

            string _baseKey = "HARDWARE";
            string _subKey = @"Dayang\dydatabase\NetManageDBSetting";
            RegisterInfo registerInfo = new RegisterInfo("178.20.10.85", "Net2Dynetmanage2019", "sa", "lq612176()", 00000001);
            Auth auth = new Auth(_baseKey, _subKey, registerInfo);
            RegisterInfoVO registerInfoVO = auth.authCheck();//ok

        }
        #endregion

    }
}