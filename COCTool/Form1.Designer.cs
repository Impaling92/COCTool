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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_portrait)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_portrait
            // 
            this.pictureBox_portrait.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox_portrait.Location = new System.Drawing.Point(12, 99);
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
            this.radioButton_Human.Size = new System.Drawing.Size(70, 24);
            this.radioButton_Human.TabIndex = 7;
            this.radioButton_Human.TabStop = true;
            this.radioButton_Human.Text = "人类";
            this.radioButton_Human.UseVisualStyleBackColor = true;
            this.radioButton_Human.CheckedChanged += new System.EventHandler(this.radioButton_Human_CheckedChanged);
            // 
            // radioButton_Elf
            // 
            this.radioButton_Elf.AutoSize = true;
            this.radioButton_Elf.Location = new System.Drawing.Point(187, 29);
            this.radioButton_Elf.Name = "radioButton_Elf";
            this.radioButton_Elf.Size = new System.Drawing.Size(70, 24);
            this.radioButton_Elf.TabIndex = 8;
            this.radioButton_Elf.TabStop = true;
            this.radioButton_Elf.Text = "精灵";
            this.radioButton_Elf.UseVisualStyleBackColor = true;
            this.radioButton_Elf.CheckedChanged += new System.EventHandler(this.radioButton_Elf_CheckedChanged);
            // 
            // radioButton_Dwarf
            // 
            this.radioButton_Dwarf.AutoSize = true;
            this.radioButton_Dwarf.Location = new System.Drawing.Point(15, 29);
            this.radioButton_Dwarf.Name = "radioButton_Dwarf";
            this.radioButton_Dwarf.Size = new System.Drawing.Size(70, 24);
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
            this.radioButton_Warrior.Size = new System.Drawing.Size(70, 24);
            this.radioButton_Warrior.TabIndex = 6;
            this.radioButton_Warrior.TabStop = true;
            this.radioButton_Warrior.Text = "战士";
            this.radioButton_Warrior.UseVisualStyleBackColor = true;
            this.radioButton_Warrior.CheckedChanged += new System.EventHandler(this.radioButton_Warrior_CheckedChanged);
            // 
            // radioButton_Priest
            // 
            this.radioButton_Priest.AutoSize = true;
            this.radioButton_Priest.Location = new System.Drawing.Point(101, 29);
            this.radioButton_Priest.Name = "radioButton_Priest";
            this.radioButton_Priest.Size = new System.Drawing.Size(70, 24);
            this.radioButton_Priest.TabIndex = 7;
            this.radioButton_Priest.TabStop = true;
            this.radioButton_Priest.Text = "牧师";
            this.radioButton_Priest.UseVisualStyleBackColor = true;
            this.radioButton_Priest.CheckedChanged += new System.EventHandler(this.radioButton_Priest_CheckedChanged);
            // 
            // radioButton_Wizard
            // 
            this.radioButton_Wizard.AutoSize = true;
            this.radioButton_Wizard.Location = new System.Drawing.Point(187, 29);
            this.radioButton_Wizard.Name = "radioButton_Wizard";
            this.radioButton_Wizard.Size = new System.Drawing.Size(70, 24);
            this.radioButton_Wizard.TabIndex = 8;
            this.radioButton_Wizard.TabStop = true;
            this.radioButton_Wizard.Text = "法师";
            this.radioButton_Wizard.UseVisualStyleBackColor = true;
            this.radioButton_Wizard.CheckedChanged += new System.EventHandler(this.radioButton_Wizard_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(131, 99);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.Location = new System.Drawing.Point(250, 99);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(81, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox3.Location = new System.Drawing.Point(369, 99);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(81, 103);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox4.Location = new System.Drawing.Point(488, 99);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(81, 103);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 314);
            this.panel1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 555);
            this.Controls.Add(this.panel1);
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
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Panel panel1;
    }
}
