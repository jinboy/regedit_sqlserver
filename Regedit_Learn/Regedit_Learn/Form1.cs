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
            this.comboBox1_load();
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
            //con.query();
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
            RegisterInfoVO registerInfoVO = auth.authCheck(SQLServer_Connector.query("2926C8D1-D7AF-4E85-939E-AB1759F69744"));//ok，校验用户信息
            //TODO 这边需要做的是将
            if (registerInfoVO != null) {// 人脸或者密码校验通过
                return;
            }
            // 继续人脸校验或者密码校验
        }
        #endregion

        #region 下拉选择框
        private void comboBox1_load() {
            comboBox1.Items.Add("城市高清网");
            comboBox1.Items.Add("生活高清网");
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

            MessageBox.Show("您选择的频道是：" + comboBox1.Text, "提示");
            if (comboBox1.Text.Length != 0) {
                RegisterInfo registerInfo = InitUserDBInfo.init(comboBox1.Text);

            }


        }
    }
}