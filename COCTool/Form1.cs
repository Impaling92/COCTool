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

using System.Text.RegularExpressions;

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
        //当前展示的人物名称列表
        List<string> g_FigureNameList = new List<string>();
        //用于搜索卡牌缩略名的全局类
        CSearchCard g_SearchCard = new CSearchCard();
        //存储所有人物的全局链表
        List<CFigure> g_FigureList = new List<CFigure>();

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

            g_FigureNameList.Clear();
            string[] sFiles = Directory.GetFiles(sPicPath, "*.png");
            PictureBox[] PicCtrls = { pictureBox_portrait, pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            for (long i = 0; i < 5; i++)
            {
                if (i < sFiles.Length)
                {
                    PicCtrls[i].Load(sFiles[i]);
                    
                    g_FigureNameList.Add(Path.GetFileNameWithoutExtension(sFiles[i]));
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

        //双击人物图
        private void pictureBox_portrait_Click(object sender, EventArgs e)
        {
            int nIndex = 0;
            if(nIndex >= 0 && nIndex < g_FigureNameList.Count)
            {
                label_FigureName.Text = g_FigureNameList[nIndex];
            }
        }

        private void SearchCard(string sShortName)
        {
            //小写转大写
            sShortName = sShortName.ToUpper();

            listBox1.Items.Clear();
            g_SearchCard.FoundList.Clear();

            foreach (CCardName Name in g_SearchCard.ShortNameList)
            {
                if(sShortName == Name.sShort)
                {
                    g_SearchCard.FoundList.Add(Name);
                    listBox1.Items.Add(Name.sFull);
                }
            }
        }

        //输入完毕触发搜索
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return)
            {
                SearchCard(textBox1.Text);
            }
        }

        //双击初次搜索列表添加一个卡
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }

    //角色类
    public class CFigure
    {
        public List<CCard> CardList;
        public void AddCard(string sName,long nCount)
        {
            CCard newCard = new CCard(sName, nCount);
            CardList.Add(newCard);
        }
    }

    //卡牌类
    public class CCard
    {
        private string m_sName; //卡牌名称
        private long m_nCount;  //卡牌数量
        //构造函数
        public CCard(string sName,long nCount)
        {
            m_sName = sName;
            m_nCount = nCount;
        }
    }

    public class CCardName
    {
        public string sShort;
        public string sFull;
        public CCardName(string sFull)
        {
            this.sFull = sFull;
            GetShort();
        }
        private void GetShort()
        {
            sShort = "";
            string[] mm = Regex.Split(this.sFull, " ");
            for (long i = 0; i < mm.Length; i++)
            {
                if (mm[i].Length > 0)
                {
                    this.sShort += mm[i][0];
                }
            }
        }
    }

    //搜索卡牌类
    public class CSearchCard
    {
        public List<CCardName> ShortNameList;   //所有名称

        public List<CCardName> FoundList;       //每次搜索到的列表
        public CSearchCard()
        {
            ShortNameList = new List<CCardName>();
            FoundList = new List<CCardName>();

            //构造函数即加载缩略图目录的所有卡片简称
            string sThumbnailsPath = "Data/card_thumbnails/";
            //文件夹存在判断
            if (!Directory.Exists(sThumbnailsPath)) return;
            string[] sFiles = Directory.GetFiles(sThumbnailsPath, "*.png");
            for(long i=0;i<sFiles.Length;i++)
            {
                string name = Path.GetFileNameWithoutExtension(sFiles[i]);
                CCardName cardName = new CCardName(name);
                ShortNameList.Add(cardName);
            }
            return;
        }
    }
}
