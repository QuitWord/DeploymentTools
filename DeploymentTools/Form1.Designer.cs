using System.IO;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace DeploymentTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSourceFolder;
        private Button btnSelectSourceFolder;
        private DateTimePicker dateTimePicker;
        private TextBox txtTargetFolder;
        private Button btnSelectTargetFolder;
        private Button btnCopyFiles;
        private Label label1;
        private Label label2;
        private Label label3;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private readonly static List<string> skipDirList = new List<string> { "App_Logs", "Logs", "Export", "UploadFiles" };
        private readonly static List<string> skipFilePreList = new List<string> { "log" };

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.btnSelectTargetFolder = new System.Windows.Forms.Button();
            this.btnCopyFiles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.Location = new System.Drawing.Point(147, 20);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.ReadOnly = true;
            this.txtSourceFolder.Size = new System.Drawing.Size(300, 28);
            this.txtSourceFolder.TabIndex = 0;
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(458, 18);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(94, 30);
            this.btnSelectSourceFolder.TabIndex = 1;
            this.btnSelectSourceFolder.Text = "选择文件夹";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(157, 60);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker.TabIndex = 2;
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.Location = new System.Drawing.Point(162, 100);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.ReadOnly = true;
            this.txtTargetFolder.Size = new System.Drawing.Size(300, 28);
            this.txtTargetFolder.TabIndex = 3;
            // 
            // btnSelectTargetFolder
            // 
            this.btnSelectTargetFolder.Location = new System.Drawing.Point(467, 98);
            this.btnSelectTargetFolder.Name = "btnSelectTargetFolder";
            this.btnSelectTargetFolder.Size = new System.Drawing.Size(105, 30);
            this.btnSelectTargetFolder.TabIndex = 4;
            this.btnSelectTargetFolder.Text = "选择目标";
            this.btnSelectTargetFolder.UseVisualStyleBackColor = true;
            this.btnSelectTargetFolder.Click += new System.EventHandler(this.btnSelectTargetFolder_Click);
            // 
            // btnCopyFiles
            // 
            this.btnCopyFiles.Location = new System.Drawing.Point(27, 140);
            this.btnCopyFiles.Name = "btnCopyFiles";
            this.btnCopyFiles.Size = new System.Drawing.Size(100, 30);
            this.btnCopyFiles.TabIndex = 5;
            this.btnCopyFiles.Text = "拷贝文件";
            this.btnCopyFiles.UseVisualStyleBackColor = true;
            this.btnCopyFiles.Click += new System.EventHandler(this.btnCopyFiles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "选择源文件夹：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "选择日期筛选：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "选择目标文件夹：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 235);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCopyFiles);
            this.Controls.Add(this.btnSelectTargetFolder);
            this.Controls.Add(this.txtTargetFolder);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.btnSelectSourceFolder);
            this.Controls.Add(this.txtSourceFolder);
            this.Name = "Form1";
            this.Text = "文件拷贝工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnSelectTargetFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtTargetFolder.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnCopyFiles_Click(object sender, EventArgs e)
        {
            string sourceFolder = txtSourceFolder.Text;
            string targetFolder = txtTargetFolder.Text;
            DateTime selectedDate = dateTimePicker.Value;

            if (string.IsNullOrEmpty(sourceFolder) || string.IsNullOrEmpty(targetFolder))
            {
                MessageBox.Show("请先选择源文件夹和目标文件夹。");
                return;
            }

            try
            {
                bool hasFilesCopied = CopyFiles(sourceFolder, targetFolder, selectedDate);
                if (hasFilesCopied)
                {
                    MessageBox.Show("文件拷贝完成！");
                }
                else
                {
                    MessageBox.Show("没有符合条件的文件，未执行拷贝操作。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"拷贝文件时出错: {ex.Message}");
            }
        }

        private bool CopyFiles(string sourceFolder, string targetFolder, DateTime selectedDate)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourceFolder);
            DirectoryInfo targetDir = new DirectoryInfo(targetFolder);

            // 检查源文件夹是否存在
            if (!sourceDir.Exists)
            {
                MessageBox.Show("源文件夹不存在！");
                return false;
            }

            // 标记是否有文件被拷贝
            bool hasFilesToCopy = false;

            // 创建目标文件夹（如果不存在）
            if (!targetDir.Exists)
            {
                targetDir.Create();
                targetDir = new DirectoryInfo(targetFolder);
            }

            // 遍历源文件夹中的文件
            foreach (FileInfo file in sourceDir.GetFiles())
            {
                if (skipFilePreList.Any(m => file.Name.StartsWith(m)))
                {
                    continue;
                }
                if (file.LastWriteTime >= selectedDate)
                {
                    string relativePath = file.FullName.Substring(sourceDir.FullName.Length + 1);
                    string targetFilePath = Path.Combine(targetDir.FullName, relativePath);
                    Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath));
                    file.CopyTo(targetFilePath, true);
                    hasFilesToCopy = true; // 标记有文件被拷贝
                }
            }

            // 递归处理子文件夹
            foreach (DirectoryInfo subDir in sourceDir.GetDirectories())
            {
                if (skipDirList.Any(m => subDir.Name.Equals(m)))
                {
                    continue;
                }
                string relativePath = subDir.FullName.Substring(sourceDir.FullName.Length + 1);
                string targetSubDir = Path.Combine(targetDir.FullName, relativePath);

                // 递归调用，检查子文件夹是否有文件被拷贝
                bool hasSubFilesToCopy = CopyFiles(subDir.FullName, targetSubDir, selectedDate);
                if (hasSubFilesToCopy)
                {
                    hasFilesToCopy = true; // 如果子文件夹有文件被拷贝，则标记为 true
                }
            }

            // 如果当前文件夹没有文件被拷贝，则删除该文件夹
            if (!hasFilesToCopy && targetDir.Exists)
            {
                targetDir.Delete(true); // 删除文件夹及其内容
            }

            return hasFilesToCopy;
        }
    }
}

