using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//操作文件夹
using System.IO;
//操作XML
using System.Xml.Linq;

namespace COCTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //读配置文件
            ReadXml();
            //初始化控件选择
            InitRaceCareer();
            ////初始化窗口
            //InitDlgs();
        }

        //全局变量
        long g_nRace = -1, g_nCareer = -1;
        string g_sXmlDirPath = "Data/";
        string g_sXmlName = "UserConfig.xml";

        //写xml
        private void WriteXml()
        {
            if (!Directory.Exists(g_sXmlDirPath)) return;

            XDocument doc = new XDocument();
            XElement root = new XElement("UserConfig");
            XElement ControlSelect = new XElement("ControlSelect");
            ControlSelect.SetElementValue("nRace", g_nRace);
            ControlSelect.SetElementValue("nCareer", g_nCareer);
            root.Add(ControlSelect);
            root.Save(g_sXmlDirPath + g_sXmlName);
        }

        //读xml
        private void ReadXml()
        {
            if (!File.Exists(g_sXmlDirPath + g_sXmlName)) return;

            XDocument doc = XDocument.Load(g_sXmlDirPath + g_sXmlName);
            XElement root = doc.Root;
            XElement ControlSelect = root.Element("ControlSelect");

            XElement Param = ControlSelect.Element("nRace");
            g_nRace = long.Parse(Param.Value);
            g_nRace = g_nRace < 0 ? 0 : g_nRace;
            g_nRace = g_nRace > 2 ? 2 : g_nRace;

            Param = ControlSelect.Element("nCareer");
            g_nCareer = long.Parse(Param.Value);
            g_nCareer = g_nCareer < 0 ? 0 : g_nCareer;
            g_nCareer = g_nCareer > 2 ? 2 : g_nCareer;
        }

        //初始化种族和职业选择
        private void InitRaceCareer()
        {
            RadioButton[] BtnRace = { radioButton_Dwarf, radioButton_Human, radioButton_Elf };
            RadioButton[] BtnCareer = { radioButton_Warrior, radioButton_Priest, radioButton_Wizard };
            BtnRace[g_nRace].Checked = true;
            BtnCareer[g_nCareer].Checked = true;
            CheckSelect();
        }

        //加载肖像
        private void LoadPortrait(long nRace,long nCareer)
        {
            if(nRace < 0 || nRace >=3 || nCareer < 0 || nCareer >= 3)   return;

            string[] sRace = new string[3] { "Dwarf", "Human", "Elf" };
            string[] sCareer = new string[3] { "Warrior/", "Priest/", "Wizard/" };
            string sPicPath = "Data/large_portraits/" + sRace[nRace] + sCareer[nCareer];
            
            //文件夹存在判断
            if (!Directory.Exists(sPicPath)) return;

            string[] sFiles = Directory.GetFiles(sPicPath, "*.png");
            PictureBox[] PicCtrls = { pictureBox_portrait, pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            for (long i = 0; i < 5; i++)
            {
                if (i < sFiles.Length)
                {
                    PicCtrls[i].Load(sFiles[i]);
                }
                else
                {
                    PicCtrls[i].Image = null;
                }
            }
        }

        //确定选项
        private void CheckSelect()
        {
            RadioButton[] BtnRace = { radioButton_Dwarf, radioButton_Human, radioButton_Elf };
            RadioButton[] BtnCareer = { radioButton_Warrior, radioButton_Priest, radioButton_Wizard };
            for(long i=0;i<3;i++)
            {
                if (BtnRace[i].Checked) g_nRace = i;
                if (BtnCareer[i].Checked) g_nCareer = i;
            }
            LoadPortrait(g_nRace, g_nCareer);
        }

        private void radioButton_Dwarf_CheckedChanged(object sender, EventArgs e)
        {
            CheckSelect();
        }

        private void radioButton_Human_CheckedChanged(object sender, EventArgs e)
        {
            CheckSelect();
        }

        private void radioButton_Elf_CheckedChanged(object sender, EventArgs e)
        {
            CheckSelect();
        }

        private void radioButton_Warrior_CheckedChanged(object sender, EventArgs e)
        {
            CheckSelect();
        }

        private void radioButton_Priest_CheckedChanged(object sender, EventArgs e)
        {
            CheckSelect();
        }

        private void radioButton_Wizard_CheckedChanged(object sender, EventArgs e)
        {
            CheckSelect();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteXml();
        }

        //private void InitDlgs()
        //{
        //    this.IsMdiContainer = true;
        //    Deck DlgDeck = new Deck();
        //    DlgDeck.MdiParent = this;
        //    DlgDeck.Parent = panel1;
        //    DlgDeck.Show();
        //}

        private void pictureBox_portrait_Click(object sender, EventArgs e)
        {
            
        }
    }
}
