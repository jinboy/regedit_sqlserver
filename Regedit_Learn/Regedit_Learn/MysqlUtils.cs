﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
//Add MySql Library
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Regedit_Learn {
    public class MysqlUtils {
        private static MySqlConnection connection;
        private static string server;
        private static string db;
        private static string uid;
        private static string password;
        public MysqlUtils() {
            // 初始化连接
            Initialize();
        }
        private static void Initialize() {
            server = "localhost";
            db = "face-reco";
            uid = "root";
            password = "zj258025";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + db + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";charset=utf8";

            connection = new MySqlConnection(connectionString);
        }
        // 打开数据库连接
        //open connection to database
        public static bool OpenConnection() {
            try {
                connection.Open();
                return true;
            }
            catch (MySqlException ex) {
                switch (ex.Number) {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        //Close connection
        public static bool CloseConnection() {
            try {
                connection.Close();
                return true;
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 插入用户特征值
        /// </summary>
        /// <param name="users"></param>
        //public void InsertUserFaceFeature(Users users) {
        //    string id = users.Id;
        //    string name = users.Name;
        //    string uToken = users.Utoken;
        //    string department = users.Department;
        //    //byte[] featureByte = users.Feature;

        //    string query = "INSERT INTO `face-reco`.`face`(`id`, `name`, `utoken`, `department`, `feature`) VALUES (@id, @name, @uToken,@department,@feature)";

        //    //open connection
        //    if (this.OpenConnection() == true) {
        //        //create command and assign the query and connection from the constructor
        //        using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
        //            // 参数插入
        //            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
        //            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
        //            cmd.Parameters.Add("@uToken", MySqlDbType.VarChar).Value = uToken;
        //            cmd.Parameters.Add("@department", MySqlDbType.VarChar).Value = department;
        //            cmd.Parameters.Add("@feature", MySqlDbType.MediumBlob).Value = users.Feature;
        //            /*
        //            MySqlParameter par = new MySqlParameter("@feature", MySqlDbType.Blob);
        //            par.Value = users.Feature;
        //            cmd.Parameters.Add(par);
        //             */

        //            //Execute command
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("数据存储完成");

        //            //close connection
        //            this.CloseConnection();
        //        }
        //    }
        //}

        /// <summary>
        /// 通过特征比对用户
        /// </summary>
        /// <returns></returns>
        //public List<byte[]> SelectUserFaceByFeature() {
        //    string query = "SELECT `feature` FROM `face-reco`.`face`";// 全部查询

        //    // 创建list存储数据
        //    List<byte[]> list = new List<byte[]>();
        //    byte[] faceFeature = null;
        //    byte[] finalFaceFeature = null;

        //    //Open connection
        //    if (OpenConnection() == true) {
        //        // 创建命令
        //        MySqlCommand cmd = new MySqlCommand(query, connection);
        //        // 读取数据
        //        MySqlDataReader dataReader = cmd.ExecuteReader();

        //        // 存储数据
        //        while (dataReader.Read()) {

        //            faceFeature = TabConvert.ObjectToBytes(dataReader["feature"]);
        //            finalFaceFeature = faceFeature.Skip(27).Take(1032).ToArray();// 从第5位开始截取3个字节
        //            list.Add(finalFaceFeature);
        //        }

        //        //close Data Reader
        //        dataReader.Close();

        //        //close Connection
        //        this.CloseConnection();

        //        //return list to be displayed
        //        return list;
        //    }
        //    else {
        //        return list;
        //    }
        //}

        /// <summary>
        /// 通过id精确查找用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] PriciseSelectById(string id) {

            string query = "SELECT * FROM `face-reco`.`face` WHERE id='" + id + "'";

            // 创建list存储数据
            List<string> list = new List<string>();
            string str = "";
            byte[] feature = null;
            //Open connection
            if (OpenConnection() == true) {
                // 创建命令
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // 读取数据
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // 存储数据
                while (dataReader.Read()) {
                    /*
                    str = dataReader["id"] + ","
                        + dataReader["name"] + ","
                        + dataReader["utoken"] + ","
                        + dataReader["department"] + ","
                        + dataReader["feature"] + ","
                        + dataReader["create_time"] + ",";
                     */
                    feature = (byte[])dataReader["feature"];
                    string[] strArray = str.Split(',');
                    list.Add(str);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return feature;
            }
            else {
                return feature;
            }
        }


        public void InsertResult(int result) {


            string query = "INSERT INTO `face-reco`.`result`(`result`) VALUES (@result)";

            //open connection
            if (OpenConnection() == true) {
                //create command and assign the query and connection from the constructor
                using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
                    // 参数插入
                    cmd.Parameters.Add("@result", MySqlDbType.Int32).Value = result;
                    /*
                    MySqlParameter par = new MySqlParameter("@feature", MySqlDbType.Blob);
                    par.Value = users.Feature;
                    cmd.Parameters.Add(par);
                     */

                    //Execute command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("数据存储完成");

                    //close connection
                    CloseConnection();
                }
            }
        }
    }
}
