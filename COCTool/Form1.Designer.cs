﻿namespace COCTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox_portrait = new System.Windows.Forms.PictureBox();
            this.radioButton_Human = new System.Windows.Forms.RadioButton();
            this.radioButton_Elf = new System.Windows.Forms.RadioButton();
            this.radioButton_Dwarf = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_Warrior = new System.Windows.Forms.RadioButton();
            this.radioButton_Priest = new System.Windows.Forms.RadioButton();
            this.radioButton_Wizard = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label_FigureName = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button_ShowImg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_portrait)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_portrait
            // 
            this.pictureBox_portrait.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox_portrait.Location = new System.Drawing.Point(12, 86);
            this.pictureBox_portrait.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_portrait.Name = "pictureBox_portrait";
            this.pictureBox_portrait.Size = new System.Drawing.Size(81, 103);
            this.pictureBox_portrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_portrait.TabIndex = 1;
            this.pictureBox_portrait.TabStop = false;
            this.pictureBox_portrait.Click += new System.EventHandler(this.pictureBox_portrait_Click);
            // 
            // radioButton_Human
            // 
            this.radioButton_Human.AutoSize = true;
            this.radioButton_Human.Location = new System.Drawing.Point(101, 29);
            this.radioButton_Human.Name = "radioButton_Human";
            this.radioButton_Human.Size = new System.Drawing.Size(58, 20);
            this.radioButton_Human.TabIndex = 7;
            this.radioButton_Human.TabStop = true;
            this.radioButton_Human.Text = "人类";
            this.radioButton_Human.UseVisualStyleBackColor = true;
            this.radioButton_Human.CheckedChanged += new System.EventHandler(this.radioButton_Dwarf_CheckedChanged);
            // 
            // radioButton_Elf
            // 
            this.radioButton_Elf.AutoSize = true;
            this.radioButton_Elf.Location = new System.Drawing.Point(187, 29);
            this.radioButton_Elf.Name = "radioButton_Elf";
            this.radioButton_Elf.Size = new System.Drawing.Size(58, 20);
            this.radioButton_Elf.TabIndex = 8;
            this.radioButton_Elf.TabStop = true;
            this.radioButton_Elf.Text = "精灵";
            this.radioButton_Elf.UseVisualStyleBackColor = true;
            this.radioButton_Elf.CheckedChanged += new System.EventHandler(this.radioButton_Dwarf_CheckedChanged);
            // 
            // radioButton_Dwarf
            // 
            this.radioButton_Dwarf.AutoSize = true;
            this.radioButton_Dwarf.Location = new System.Drawing.Point(15, 29);
            this.radioButton_Dwarf.Name = "radioButton_Dwarf";
            this.radioButton_Dwarf.Size = new System.Drawing.Size(58, 20);
            this.radioButton_Dwarf.TabIndex = 6;
            this.radioButton_Dwarf.TabStop = true;
            this.radioButton_Dwarf.Text = "矮人";
            this.radioButton_Dwarf.UseVisualStyleBackColor = true;
            this.radioButton_Dwarf.CheckedChanged += new System.EventHandler(this.radioButton_Dwarf_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Dwarf);
            this.groupBox1.Controls.Add(this.radioButton_Human);
            this.groupBox1.Controls.Add(this.radioButton_Elf);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 70);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "种族";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_Warrior);
            this.groupBox2.Controls.Add(this.radioButton_Priest);
            this.groupBox2.Controls.Add(this.radioButton_Wizard);
            this.groupBox2.Location = new System.Drawing.Point(298, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 70);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "职业";
            // 
            // radioButton_Warrior
            // 
            this.radioButton_Warrior.AutoSize = true;
            this.radioButton_Warrior.Location = new System.Drawing.Point(15, 29);
            this.radioButton_Warrior.Name = "radioButton_Warrior";
            this.radioButton_Warrior.Size = new System.Drawing.Size(58, 20);
            this.radioButton_Warrior.TabIndex = 6;
            this.radioButton_Warrior.TabStop = true;
            this.radioButton_Warrior.Text = "战士";
            this.radioButton_Warrior.UseVisualStyleBackColor = true;
            this.radioButton_Warrior.CheckedChanged += new System.EventHandler(this.radioButton_Dwarf_CheckedChanged);
            // 
            // radioButton_Priest
            // 
            this.radioButton_Priest.AutoSize = true;
            this.radioButton_Priest.Location = new System.Drawing.Point(101, 29);
            this.radioButton_Priest.Name = "radioButton_Priest";
            this.radioButton_Priest.Size = new System.Drawing.Size(58, 20);
            this.radioButton_Priest.TabIndex = 7;
            this.radioButton_Priest.TabStop = true;
            this.radioButton_Priest.Text = "牧师";
            this.radioButton_Priest.UseVisualStyleBackColor = true;
            this.radioButton_Priest.CheckedChanged += new System.EventHandler(this.radioButton_Dwarf_CheckedChanged);
            // 
            // radioButton_Wizard
            // 
            this.radioButton_Wizard.AutoSize = true;
            this.radioButton_Wizard.Location = new System.Drawing.Point(187, 29);
            this.radioButton_Wizard.Name = "radioButton_Wizard";
            this.radioButton_Wizard.Size = new System.Drawing.Size(58, 20);
            this.radioButton_Wizard.TabIndex = 8;
            this.radioButton_Wizard.TabStop = true;
            this.radioButton_Wizard.Text = "法师";
            this.radioButton_Wizard.UseVisualStyleBackColor = true;
            this.radioButton_Wizard.CheckedChanged += new System.EventHandler(this.radioButton_Dwarf_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(131, 86);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox_portrait_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.Location = new System.Drawing.Point(250, 86);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(81, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox_portrait_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox3.Location = new System.Drawing.Point(369, 86);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(81, 103);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox_portrait_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox4.Location = new System.Drawing.Point(488, 86);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(81, 103);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox_portrait_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 26);
            this.textBox1.TabIndex = 15;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 281);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 244);
            this.listBox1.TabIndex = 16;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "卡牌名缩写";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "数量";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(199, 249);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 26);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "卡牌列表";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(275, 249);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(230, 276);
            this.listBox2.TabIndex = 22;
            // 
            // label_FigureName
            // 
            this.label_FigureName.AutoSize = true;
            this.label_FigureName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label_FigureName.Location = new System.Drawing.Point(15, 197);
            this.label_FigureName.Name = "label_FigureName";
            this.label_FigureName.Size = new System.Drawing.Size(72, 16);
            this.label_FigureName.TabIndex = 24;
            this.label_FigureName.Text = "人物名称";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Control;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(520, 249);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(515, 250);
            this.listView1.TabIndex = 25;
            this.listView1.TileSize = new System.Drawing.Size(62, 37);
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button_ShowImg
            // 
            this.button_ShowImg.Location = new System.Drawing.Point(520, 197);
            this.button_ShowImg.Name = "button_ShowImg";
            this.button_ShowImg.Size = new System.Drawing.Size(149, 46);
            this.button_ShowImg.TabIndex = 26;
            this.button_ShowImg.Text = "显示图片";
            this.button_ShowImg.UseVisualStyleBackColor = true;
            this.button_ShowImg.Click += new System.EventHandler(this.button_ShowImg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 555);
            this.Controls.Add(this.button_ShowImg);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label_FigureName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox_portrait);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "COC助手";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_portrait)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_portrait;
        private System.Windows.Forms.RadioButton radioButton_Human;
        private System.Windows.Forms.RadioButton radioButton_Elf;
        private System.Windows.Forms.RadioButton radioButton_Dwarf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_Warrior;
        private System.Windows.Forms.RadioButton radioButton_Priest;
        private System.Windows.Forms.RadioButton radioButton_Wizard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label_FigureName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button_ShowImg;
    }
}

