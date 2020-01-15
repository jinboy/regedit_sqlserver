using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Regedit_Learn.initUser.pojo;
using Regedit_Learn.initUser.vo;

namespace Regedit_Learn.initUser.model {
    public class Register {
        string _baseKey = "HARDWARE";
        string _subKey = @"Dayang\dydatabase\NetManageDBSetting";
        RegisterInfo _registerInfo;
        public Register(string baseKey, string subKey, RegisterInfo registerInfo) {
            _baseKey = baseKey;
            _subKey = subKey;
            _registerInfo = registerInfo;
        }
        #region 添加信息到注册表
        public void AddInfoToRegedit() {
            RegistryKey rkLocalMachine = Registry.LocalMachine;
            RegistryKey rkChild = rkLocalMachine.OpenSubKey(_baseKey, true).CreateSubKey(_subKey);
            var abc = this._registerInfo;
            rkChild.SetValue("uuid", "");
            rkChild.SetValue("Server Name", _registerInfo.serverName);
            rkChild.SetValue("Datbase Type", _registerInfo.databaseType, RegistryValueKind.DWord);
            rkChild.SetValue("Database Name", _registerInfo.databaseName);
            rkChild.SetValue("User Name", _registerInfo.userName);
            rkChild.SetValue("Password", _registerInfo.password);
        }
        #endregion

        #region 从注册表中获取信息
        public RegisterInfoVO GetInfoFromRegedit() {
            RegistryKey rkLocalMachine = Registry.LocalMachine;
            RegistryKey rkChild = rkLocalMachine.OpenSubKey(_baseKey, true).CreateSubKey(_subKey);

            RegisterInfoVO registerInfoVO = new RegisterInfoVO();
            if (rkChild.GetValue("Server Name").ToString().Length!=0) {
                registerInfoVO.serverName = rkChild.GetValue("Server Name").ToString();
            }
            
            registerInfoVO.databaseType = Convert.ToInt64(rkChild.GetValue("Datbase Type"));
            registerInfoVO.databaseName = rkChild.GetValue("Database Name").ToString();
            registerInfoVO.userName = rkChild.GetValue("User Name").ToString();
            registerInfoVO.password = rkChild.GetValue("Password").ToString();
            registerInfoVO.uuid = rkChild.GetValue("uuid").ToString();
            return registerInfoVO;
        }
        #endregion

        #region 修改注册表信息
        public void UpdateRegInfo() {
            RegistryKey rkLocalMachine = Registry.LocalMachine;
            RegistryKey rkChild = rkLocalMachine.OpenSubKey(_baseKey, true).CreateSubKey(_subKey);
            var abc = this._registerInfo;
            rkChild.SetValue("uuid", "");
            rkChild.SetValue("Server Name", _registerInfo.serverName);
            rkChild.SetValue("Datbase Type", _registerInfo.databaseType, RegistryValueKind.DWord);
            rkChild.SetValue("Database Name", _registerInfo.databaseName);
            rkChild.SetValue("User Name", _registerInfo.userName);
            rkChild.SetValue("Password", _registerInfo.password);
        }
        #endregion

        #region 从注册表中删除信息
        public void DeleteRegeditInfo() {

        }
        #endregion
    }
}
