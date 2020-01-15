namespace Regedit_Learn {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.buttonQueryFromDB = new System.Windows.Forms.Button();
            this.buttonAddToReg = new System.Windows.Forms.Button();
            this.buttonFindFromReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "向注册表中写入信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(202, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "连接sqlserver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonQueryFromDB
            // 
            this.buttonQueryFromDB.Location = new System.Drawing.Point(202, 79);
            this.buttonQueryFromDB.Name = "buttonQueryFromDB";
            this.buttonQueryFromDB.Size = new System.Drawing.Size(75, 23);
            this.buttonQueryFromDB.TabIndex = 9;
            this.buttonQueryFromDB.Text = "查找";
            this.buttonQueryFromDB.UseVisualStyleBackColor = true;
            this.buttonQueryFromDB.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonAddToReg
            // 
            this.buttonAddToReg.Location = new System.Drawing.Point(202, 109);
            this.buttonAddToReg.Name = "buttonAddToReg";
            this.buttonAddToReg.Size = new System.Drawing.Size(121, 23);
            this.buttonAddToReg.TabIndex = 10;
            this.buttonAddToReg.Text = "添加至注册表";
            this.buttonAddToReg.UseVisualStyleBackColor = true;
            this.buttonAddToReg.Click += new System.EventHandler(this.buttonAddToReg_Click);
            // 
            // buttonFindFromReg
            // 
            this.buttonFindFromReg.Location = new System.Drawing.Point(202, 139);
            this.buttonFindFromReg.Name = "buttonFindFromReg";
            this.buttonFindFromReg.Size = new System.Drawing.Size(121, 23);
            this.buttonFindFromReg.TabIndex = 11;
            this.buttonFindFromReg.Text = "从注册表中获取信息";
            this.buttonFindFromReg.UseVisualStyleBackColor = true;
            this.buttonFindFromReg.Click += new System.EventHandler(this.buttonFindFromReg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 234);
            this.Controls.Add(this.buttonFindFromReg);
            this.Controls.Add(this.buttonAddToReg);
            this.Controls.Add(this.buttonQueryFromDB);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonQueryFromDB;
        private System.Windows.Forms.Button buttonAddToReg;
        private System.Windows.Forms.Button buttonFindFromReg;
    }
}

