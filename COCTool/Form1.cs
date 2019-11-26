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
        long g_nRace = 0, g_nCareer = 0;
        string g_sXmlDirPath = "Data/";
        string g_sXmlName = "UserConfig.xml";
        //当前展示的人物名称列表
        List<string> g_FigureNameList = new List<string>();
        //用于搜索卡牌缩略名的全局类
        CSearchCard g_SearchCard = new CSearchCard();
        //存储所有人物的全局链表
        List<CFigure> g_FigureList = new List<CFigure>();
        //存储当前编辑的人物
        CFigure g_CurrEditFigure = null;

        //写xml
        private void WriteXml()
        {
            if (!Directory.Exists(g_sXmlDirPath)) return;

            XDocument doc = new XDocument();
            XElement root = new XElement("SaveData");
            //保存用户配置
            XElement UserConfig = new XElement("UserConfig");
            XElement ControlSelect = new XElement("ControlSelect");
            ControlSelect.SetElementValue("nRace", g_nRace);
            ControlSelect.SetElementValue("nCareer", g_nCareer);
            UserConfig.Add(ControlSelect);
            root.Add(UserConfig);
            
            //保存角色数据
            XElement FigureData = new XElement("FigureData");
            int nFigureCount = g_FigureList.Count;
            FigureData.SetElementValue("nFigureCount", nFigureCount);
            for (int i = 0; i < nFigureCount; i++)
            {
                CFigure tempiFigure = g_FigureList[i];
                FigureData.SetElementValue(string.Format("FigureName{0}", i), tempiFigure.sName);
                XElement tempElement = new XElement(tempiFigure.sName);
                long nCardCount = tempiFigure.CardList.Count;
                FigureData.SetElementValue(string.Format("CardCount{0}", i), nCardCount);
                for (int j = 0; j < nCardCount; j++) 
                {
                    tempElement.SetElementValue(string.Format("CardName{0}", j), tempiFigure.CardList[j].m_sName);
                    tempElement.SetElementValue(string.Format("Count{0}", j), tempiFigure.CardList[j].m_nCount);
                }
                FigureData.Add(tempElement);
            }    
            root.Add(FigureData);

            doc.Add(root);
            doc.Save(g_sXmlDirPath + g_sXmlName);
            //保存角色类

        }

        //读xml
        private void ReadXml()
        {
            if (!File.Exists(g_sXmlDirPath + g_sXmlName)) return;

            XDocument doc = XDocument.Load(g_sXmlDirPath + g_sXmlName);
            XElement root = doc.Root;
            XElement UserConfig = root.Element("UserConfig");
            XElement ControlSelect = UserConfig.Element("ControlSelect");

            XElement Param = ControlSelect.Element("nRace");
            g_nRace = long.Parse(Param.Value);
            g_nRace = g_nRace < 0 ? 0 : g_nRace;
            g_nRace = g_nRace > 2 ? 2 : g_nRace;

            Param = ControlSelect.Element("nCareer");
            g_nCareer = long.Parse(Param.Value);
            g_nCareer = g_nCareer < 0 ? 0 : g_nCareer;
            g_nCareer = g_nCareer > 2 ? 2 : g_nCareer;

            //读取角色数据
            g_FigureList.Clear();
            XElement FigureData = root.Element("FigureData");
            if(FigureData != null)
            {
                int nFigureCount = int.Parse(FigureData.Element("nFigureCount").Value);
                for (int i = 0; i < nFigureCount; i++)
                {
                    string sFigureName = FigureData.Element(string.Format("FigureName{0}", i)).Value;
                    CFigure tempFigure = new CFigure(sFigureName);
                    long nCardCount = int.Parse(FigureData.Element(string.Format("CardCount{0}", i)).Value);
                    XElement tempElement = FigureData.Element(sFigureName);
                    for (int j = 0; j < nCardCount; j++)
                    {
                        string sCardName = tempElement.Element(string.Format("CardName{0}", j)).Value;
                        long nCount = long.Parse(tempElement.Element(string.Format("Count{0}", j)).Value);
                        tempFigure.AddCard(sCardName, nCount);
                    }
                    g_FigureList.Add(tempFigure);
                }
            }
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

            //选中一个空的人物
            LoadFigureOperation(null);
        }

        private void radioButton_Dwarf_CheckedChanged(object sender, EventArgs e)
        {
            CheckSelect();
        }

        //private void radioButton_Human_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckSelect();
        //}

        //private void radioButton_Elf_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckSelect();
        //}

        //private void radioButton_Warrior_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckSelect();
        //}

        //private void radioButton_Priest_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckSelect();
        //}

        //private void radioButton_Wizard_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckSelect();
        //}

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteXml();
        }

        //双击人物图
        private void pictureBox_portrait_Click(object sender, EventArgs e)
        {
            LoadFigureOperation(sender);
        }

        private void LoadFigureOperation(object sender)
        {
            PictureBox[] picboxs = { pictureBox_portrait, pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            for (int i = 0; i < 5; i++)
            {
                if (sender == picboxs[i])
                {
                    if (i >= 0 && i < g_FigureNameList.Count)
                    {
                        LoadFigure(g_FigureNameList[i]);
                        //将图片修改颜色
                        picboxs[i].BackColor = Color.FromArgb(128, 255, 128);
                    }
                }
                else
                {
                    picboxs[i].BackColor = Color.FromArgb(160, 160, 160);
                }
            }
        }

        //加载角色
        private void LoadFigure(string sFigureName)
        {
            //先搜索角色列表，打开该角色
            CFigure tempFig = g_FigureList.Find(x => x.sName == sFigureName);
            if (tempFig == null)
            {
                CFigure newFigure = new CFigure(sFigureName);
                g_FigureList.Add(newFigure);
                g_CurrEditFigure = newFigure;
            }
            else
            {
                g_CurrEditFigure = tempFig;
            }

            //刷新控件显示
            listBox2.DataSource = null;
            listBox2.DisplayMember = "m_sShowText";
            listBox2.DataSource = g_CurrEditFigure.CardList;

            //显示人物名
            label_FigureName.Text = sFigureName;

            //加载任务的卡牌图片
            LoadCardImgList();
        }

        private void SearchCard(string sShortName)
        {
            //小写转大写
            sShortName = sShortName.ToUpper();

            //listBox1.Items.Clear();
            g_SearchCard.FoundList.Clear();
            foreach (CCardName Name in g_SearchCard.ShortNameList)
            {
                if(sShortName == Name.sShort)
                {
                    g_SearchCard.FoundList.Add(Name);
                    //listBox1.Items.Add(Name.sFull);
                }
            }
            //刷新控件显示
            //listBox1.DataSource = null;
            //listBox1.DisplayMember = "sFull";
            //listBox1.DataSource = g_SearchCard.FoundList;
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            foreach (CCardName card in g_SearchCard.FoundList)
            {
                listBox1.Items.Add(card.sFull);
            }
            listBox1.EndUpdate();
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
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (g_CurrEditFigure == null || listBox1.SelectedItem == null) return;

            string sFull = listBox1.SelectedItem.ToString();
            long nCount = Convert.ToInt32(numericUpDown1.Value);

            g_CurrEditFigure.AddCard(sFull, nCount);

            //刷新控件显示
            listBox2.DataSource = null;
            listBox2.DisplayMember = "m_sShowText";
            listBox2.DataSource = g_CurrEditFigure.CardList;
            listBox2.SelectedIndex = listBox2.Items.Count - 1;
        }

        //加载卡牌图片列表
        private void LoadCardImgList()
        {
            if (g_CurrEditFigure == null) return;

            ImageList CardImgList = new ImageList();
            foreach (CCard card in g_CurrEditFigure.CardList)
            {
                Image image = Image.FromFile("Data/card_thumbnails/" + card.m_sName + ".png");
                CardImgList.Images.Add(image);
            }
            CardImgList.ImageSize = new Size(41, 24);

            listView1.View = View.SmallIcon;
            listView1.SmallImageList = CardImgList;

            listView1.BeginUpdate();
            listView1.Clear();
            int nIndex = 0; 
            foreach (CCard card in g_CurrEditFigure.CardList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = nIndex;
                nIndex++;
                lvi.Text = string.Format(" × {0}", card.m_nCount);

                lvi.SubItems.Add("123");

                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void button_ShowImg_Click(object sender, EventArgs e)
        {
            LoadCardImgList();
        }
    }

    //角色类
    public class CFigure
    {
        //角色名称
        public string sName;

        //此角色拥有的所有卡牌
        public List<CCard> CardList = new List<CCard>();

        //构造函数
        public CFigure(string sName)
        {
            this.sName = sName;
        }

        public void AddCard(string sName,long nCount)
        {
            //先检查有没有重复的，若有，先删除
            int oldIndex = CardList.FindIndex(x => x.m_sName == sName);
            if (oldIndex != -1)
            {
                if(nCount == 0)
                {
                    CardList.RemoveAt(oldIndex);
                }
                else
                {
                    CCard newCard = new CCard(sName, nCount);
                    CardList[oldIndex] = newCard;
                }
            }
            else
            {
                if(nCount > 0)
                {
                    CCard newCard = new CCard(sName, nCount);
                    CardList.Add(newCard);
                }
            }
        }
    }

    //卡牌类
    public class CCard
    {
        public string m_sName { get; set; } //卡牌名称
        public long m_nCount { get; set; }  //卡牌数量
        public string m_sShowText { get; set; }  //展示文本
        //构造函数
        public CCard(string sName,long nCount)
        {
            m_sName = sName;
            m_nCount = nCount;
            m_sShowText = string.Format("{0} × ", m_nCount) + m_sName;
        }
    }

    public class CCardName
    {
        public string sShort { get; set; }
        public string sFull { get; set; }
        public CCardName(string sFull)
        {
            this.sFull = sFull;
            GetShort();
        }
        private void GetShort()
        {
            this.sShort = "";
            string[] mm = Regex.Split(this.sFull, " ");
            for (long i = 0; i < mm.Length; i++)
            {
                if (mm[i].Length > 0)
                {
                    this.sShort += mm[i][0];
                }
            }
            this.sShort = this.sShort.ToUpper();
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
