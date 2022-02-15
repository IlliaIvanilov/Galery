using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace Galereya
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Text = "Gallery";
            this.BackColor = System.Drawing.Color.LightCyan;
            if (File.Exists("images.txt"))
                PathToFile.AddRange(File.ReadAllLines("images.txt"));

            label.Font = new System.Drawing.Font("Time New Roman", 50, System.Drawing.FontStyle.Bold);
            label.Location = new System.Drawing.Point(480, 10);
            label.Size = new System.Drawing.Size(130, 80);
            this.Controls.Add(label);



            //saveBtn.Click += SaveBtn_Click;
            //saveBtn.Text = "Save";
            //saveBtn.Location = new System.Drawing.Point(150, 50);
            //this.Controls.Add(saveBtn);

            dowloadBtn.Click += DowloadBtn_Click;
            dowloadBtn.Text = "+";
            dowloadBtn.Font = new System.Drawing.Font("Time New Roman", 40, System.Drawing.FontStyle.Bold);
            dowloadBtn.Location = new System.Drawing.Point(10, 20);
            dowloadBtn.Size = new System.Drawing.Size(60, 60);
            dowloadBtn.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(dowloadBtn);


            LeftBtn.Click += LeftBtn_Click;
            LeftBtn.Text = "<";
            LeftBtn.Location = new System.Drawing.Point(0, 400);
            LeftBtn.Font = new System.Drawing.Font("Time New Roman", 50, System.Drawing.FontStyle.Bold);
            LeftBtn.Size = new System.Drawing.Size(100, 100);
            LeftBtn.BackColor = System.Drawing.Color.LightGray;
            LeftBtn.Enabled = false;
            this.Controls.Add(LeftBtn);


            RightBtn.Click += RightBtn_Click;
            RightBtn.Text = ">";
            RightBtn.Location = new System.Drawing.Point(900, 400);
            RightBtn.Font = new System.Drawing.Font("Time New Roman", 50, System.Drawing.FontStyle.Bold);
            RightBtn.Size = new System.Drawing.Size(100, 100);
            RightBtn.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(RightBtn);
            this.FormClosing += Form1_FormClosing;

            delete.Click += DeleteBtn_Click;
            delete.Text = "x";
            delete.Location = new System.Drawing.Point(10, 100);
            delete.Font = new System.Drawing.Font("Time New Roman", 50, System.Drawing.FontStyle.Bold);
            delete.Size = new System.Drawing.Size(60, 60);
            delete.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(delete);

            picture.Location = new System.Drawing.Point(50, 50);
            picture.Size = new System.Drawing.Size(800, 500);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(picture);
            SetImage(num);

        }
        static int num = 0;
        string last_num = File.ReadAllText("last_photo.txt");
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllLines("images.txt", PathToFile);
            File.WriteAllText("last_photo.txt", num.ToString());
        }
        private void DeleteBtn_Click(object sender, System.EventArgs e)
        {
            if (num >= 1)
            {
                PathToFile.Remove(PathToFile[num]);
            }
            else
            {
                label.Text += "Delete ";
            }
        }

        private void RightBtn_Click(object sender, System.EventArgs e)
        {
            LeftBtn.Enabled = true;
            if (PathToFile.Count == num + 2)
            {
                RightBtn.Enabled = false;
            }
            num++;
            SetImage(num);
            if (PathToFile.Count == 1)
            {
                RightBtn.Enabled = false;
            }
        }

        private void LeftBtn_Click(object sender, System.EventArgs e)
        {

            RightBtn.Enabled = true;
            num--;
            if (num == 0)
            {
                LeftBtn.Enabled = false;
            }
            else
            {
                LeftBtn.Enabled = true;
            }
            SetImage(num);
            if (PathToFile.Count == 1)
            {
                LeftBtn.Enabled = false;
            }

        }
        private void DowloadBtn_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PathToFile.Add(dialog.FileName);

                }
            }
        }
        void SetImage(int indx)
        {
            label.Text = $"{num + 1}/{PathToFile.Count.ToString()}";
            if (PathToFile.Count == 1)
            {
                LeftBtn.Enabled = false;
                RightBtn.Enabled = false;
                delete.Enabled = false;
            }
            if (PathToFile.Count > 1)
            {
                LeftBtn.Enabled = true;
                RightBtn.Enabled = true;
                delete.Enabled = true;
            }
            try
            {

                picture.Image = System.Drawing.Image.FromFile(PathToFile[num]);
            }
            catch
            {
                label.Text = "X ";
            }
        }

        Button LeftBtn = new Button();
        Button RightBtn = new Button();
        Button saveBtn = new Button();
        Button dowloadBtn = new Button();

        List<string> PathToFile = new List<string>();
        Label label = new Label();
        Label labels = new Label();
        PictureBox picture = new PictureBox();
        Button delete = new Button();

        #endregion
    }
}

