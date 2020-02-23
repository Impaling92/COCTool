import requests
from requests.adapters import HTTPAdapter
from bs4 import BeautifulSoup
import bs4
import re
from enum import Enum
from xml.dom.minidom import Document
from xml.dom.minidom import parse
import xml.dom.minidom
import os

LOG_LEVEL = Enum('LOG_LEVEL',('Trace','Log'))
CURR_LOG_LEVEL = LOG_LEVEL.Log

class CFunTrace:
    def __init__(self,funName):
        self.__funName = funName
        if CURR_LOG_LEVEL.value <= LOG_LEVEL.Trace.value:
            print(self.__funName + ' Entered...')
    def __del__(self):
        if CURR_LOG_LEVEL.value <= LOG_LEVEL.Trace.value:
            print(self.__funName + ' Exited...')

class CLog:
    def __init__(self,funName):
        self.__funName = funName
        if CURR_LOG_LEVEL.value <= LOG_LEVEL.Log.value:
            print(self.__funName)

class CCard:
    def __init__(self,name,count):
        self.name = name
        self.count = count

class CFigure:
    def __init__(self,figure_name):
        funLog = CFunTrace('CFigure:__init__')
        self.cardlist = []
        self.name = figure_name
        log = CLog('添加人物：{nameStr}'.format(nameStr = figure_name))
    def addCard(self,name,count):
        funLog = CFunTrace('CFigure:addCard()')
        card = CCard(name,count)
        self.cardlist.append(card)
        log = CLog('添加卡牌，名称：{nameStr},数量：{countStr}'.format(nameStr = name,countStr = count))

class CMonster:
    def __init__(self,name=''):
        self.name = name
        self.inGameNames = []
        self.hp = ''
        self.draw = ''
        self.vpWorth = ''
        self.defaultMove = ''
        self.cardList = []
        self.pngName = ''
        self.bGetAllInfo = False

class CGetWebData:
    def __init__(self):
        self.figureHeaders = {
            'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3',
            'Accept-Encoding': 'gzip, deflate',
            'Accept-Language': 'zh-CN,zh;q=0.9',
            'Cookie': 'xf_user=15819%2C9cb5406f5957d4c36620c1cc70c424d6e6a08605; xf_session=14aa3e308c605034afe321882df74a44',
            'Host': 'forums.cardhunter.com',
            'Proxy-Connection': 'keep-alive',
            'Upgrade-Insecure-Requests': '1',
            'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36', }

        self.fugureURLs = ['http://forums.cardhunter.com/threads/coc-pcs.9397/',
                      'http://forums.cardhunter.com/threads/coc-pcs.9397/page-2']

        self.firstFindString = 'http://live.cardhunter.com/assets/large_portraits/'
        # 人物列表
        self.figureList = []

        # 怪物卡组相关变量
        self.monsterXMLPath = 'output/MonsterBuild.xml'
        self.monsterNameHtmPaths = ['input/MonsterName1.htm','input/MonsterName2.htm']
        self.monsterList = [] # 怪物列表
        self.eachMonsterHeaders = {
              'Host': 'wiki.cardhuntria.com',
              'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:73.0) Gecko/20100101 Firefox/73.0',
              'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8',
              'Accept-Language': 'zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2',
              'Accept-Encoding': 'gzip, deflate',
              'Connection': 'keep-alive',
              'Cookie': '_ga=GA1.2.216598363.1582447086; _gid=GA1.2.1486757786.1582447086; _gat=1',
              'Upgrade-Insecure-Requests': '1',
              'Cache-Control': 'max-age=0',}

    def ProcessFigureUrl(self, url):
        response = requests.get(url, headers=self.figureHeaders)
        response.encoding = 'GBK'
        soup = BeautifulSoup(response.text, 'lxml')
        firstFindStringLength = len(self.firstFindString)
        for k in soup.find_all('blockquote'):
            img_url = str(k.contents[1])
            nstr = img_url.find(self.firstFindString)
            nend = img_url.find('.png')
            if nstr >= 0 and nend > nstr :
                figureName = img_url[nstr + firstFindStringLength:nend]
                newFigure = CFigure(figureName)
                for i in range(2,len(k.contents),3):
                    tmpStr = str(k.contents[i + 1])
                    endIndex = tmpStr.find('x ')
                    if endIndex >= 0:
                        cardCount = int(tmpStr[1:endIndex]) # 求卡牌数量
                        tmpStr = str(k.contents[i + 2])
                        nCardStart = tmpStr.find(';">')
                        nCardEnd = tmpStr.find('</a>')
                        if nCardStart >= 0 and nCardEnd > nCardStart :
                            cardName = tmpStr[nCardStart + 3:nCardEnd]
                            newFigure.addCard(cardName,cardCount)
                self.figureList.append(newFigure)

    def ProcessAllFigureUrls(self):
        for eachUrl in self.fugureURLs:
            self.ProcessFigureUrl(eachUrl)
        log = CLog('人物数据采集完成，数量：{count}'.format(count = len(self.figureList)))

    def AddTestData(self):
        newFigure = CFigure("DwarfWizardF04C")
        newFigure.addCard("Hard to Pin Down", 1)
        newFigure.addCard("Vulnerable", 2)
        self.figureList.append(newFigure)
        newFigure1 = CFigure("ElfWizardF01C")
        newFigure1.addCard("Elven Trickery", 4)
        newFigure1.addCard("Powerful Spark", 3)
        self.figureList.append(newFigure1)

    def WriteFigureDataToXML(self,filename):
        doc = Document() #创建doc
        root = doc.createElement("FigureBuild") #创建根节点
        root.setAttribute("URL", self.fugureURLs[0])
        doc.appendChild(root)
        for eachFigure in self.figureList:
            figureNode = doc.createElement("Figure")
            figureNode.setAttribute("name", eachFigure.name)
            for eachCard in eachFigure.cardlist:
                cardNode = doc.createElement("Card")
                cardNode.setAttribute("Name", eachCard.name)
                cardNode.setAttribute("Count", str(eachCard.count))
                figureNode.appendChild(cardNode)
            root.appendChild(figureNode)
        with open(filename, 'w') as f:
            f.write(doc.toprettyxml(indent='\t'))

    def ReadMonsterName(self):
        for eachPath in self.monsterNameHtmPaths:
            bStart = False
            for line in open(eachPath):
                if not bStart:
                    if line.find('<!-- bodycontent -->') != -1:
                        bStart = True
                else:
                    if line.find('<li><a href=') != -1:
                        startPos = line.find('title="')
                        endPos = line.find('">',startPos, len(line))
                        if startPos != -1 and endPos != -1:
                            newMonster = CMonster(line[startPos + 7:endPos])
                            # newMonster.inGameNames.append("ingame1")
                            # newMonster.inGameNames.append("ingame2")
                            # newCard1 = CCard("card1", 1)
                            # newCard2 = CCard("card2", 2)
                            # newMonster.cardList.append(newCard1)
                            # newMonster.cardList.append(newCard2)
                            self.monsterList.append(newMonster)
                    else:
                        if line.find('<!-- /bodycontent -->') != -1:
                            break

    def WriteMonsterBuildsToXML(self):
        doc = Document()  # 创建doc
        root = doc.createElement("MonsterBuild")  # 创建根节点
        doc.appendChild(root)
        for eachMonster in self.monsterList:
            monsterNode = doc.createElement("Monster")
            monsterNode.setAttribute("Name", eachMonster.name)
            monsterNode.setAttribute("HP", eachMonster.hp)
            monsterNode.setAttribute("Draw", eachMonster.draw)
            monsterNode.setAttribute("VPWorth", eachMonster.vpWorth)
            monsterNode.setAttribute("DefaultMove", eachMonster.defaultMove)
            monsterNode.setAttribute("bGetAllInfo", str(eachMonster.bGetAllInfo))
            for eachInGameName in eachMonster.inGameNames:
                inGameNameNode = doc.createElement("InGameName")
                inGameNameNode.setAttribute("Name", eachInGameName)
                monsterNode.appendChild(inGameNameNode)
            for eachCard in eachMonster.cardList:
                cardNode = doc.createElement("Card")
                cardNode.setAttribute("Name", eachCard.name)
                cardNode.setAttribute("Count", str(eachCard.count))
                monsterNode.appendChild(cardNode)
            root.appendChild(monsterNode)
        with open(self.monsterXMLPath, 'w') as f:
            f.write(doc.toprettyxml(indent='\t'))

    def ReadMonsterBuildFromXML(self):
        self.monsterList.clear();
        dom = xml.dom.minidom.parse(self.monsterXMLPath)
        root = dom.documentElement
        monsters = root.getElementsByTagName("Monster") # 获取Monster节点
        # print(len(monsters))
        for eachMonster in monsters:
            newMonster = CMonster()
            newMonster.name = eachMonster.getAttribute("Name")
            newMonster.hp = eachMonster.getAttribute("HP")
            newMonster.draw = eachMonster.getAttribute("Draw")
            newMonster.vpWorth = eachMonster.getAttribute("VPWorth")
            newMonster.defaultMove = eachMonster.getAttribute("DefaultMove")
            newMonster.bGetAllInfo = eachMonster.getAttribute("bGetAllInfo") == "True"
            inGameNames = eachMonster.getElementsByTagName("InGameName")
            for eachInGameName in inGameNames:
                newMonster.inGameNames.append(eachInGameName.getAttribute("Name"))
            cards = eachMonster.getElementsByTagName("Card")
            for eachCard in cards:
                newCard = CCard(eachCard.getAttribute("Name"),int(eachCard.getAttribute("Count")))
                newMonster.cardList.append(newCard)
            self.monsterList.append(newMonster)

    def CollectMonsterDataFromURL(self):
        bAllDone = True
        for eachMonster in self.monsterList:
            if eachMonster.bGetAllInfo:
                continue
            bAllDone = False
            url = "http://wiki.cardhuntria.com/wiki/" + eachMonster.name
            try:
                response = requests.get(url, headers=self.eachMonsterHeaders,timeout=20)
            except:
                print("请求" + url +"超时")
                continue
            if response.status_code == 200:
                print(url + "请求成功")
                response.encoding = 'GBK'
                soup = BeautifulSoup(response.text, 'lxml')
                self.GetOneMonsterData(soup,eachMonster)
            else:
                print("{}请求失败，返回值为{}".format(url,response.status_code))
        if bAllDone:
            print("所有怪物卡已经抓取完成")
        else:
            print("仍有怪物卡未抓取完成")
    def GetOneMonsterData(self,soup,newMonster):
        for tr in soup.find_all('tr'):
            for th in tr.find_all('th'):
                if th.contents[0].find("In-game Name") != -1:
                    tds = tr.find_all('td')
                    totalStr = tds[0].contents[0].rstrip()
                    newMonster.inGameNames = totalStr.split(',')
                    # print(newMonster.inGameNames)
                elif th.contents[0].find("HP") != -1:
                    tds = tr.find_all('td')
                    newMonster.hp = tds[0].contents[0].rstrip()
                    newMonster.pngName = tds[1].contents[0].contents[0]['alt']
                    # print(newMonster.hp)
                    # print(newMonster.pngName)
                elif th.contents[0].find("Draw") != -1:
                    tds = tr.find_all('td')
                    newMonster.draw = tds[0].contents[0].rstrip()
                    # print(newMonster.draw)
                elif th.contents[0].find("VP worth") != -1:
                    tds = tr.find_all('td')
                    newMonster.vpWorth = tds[0].contents[0].rstrip()
                    # print(newMonster.vpWorth)
                elif th.contents[0].find("Default Move") != -1:
                    tds = tr.find_all('td')
                    if len(tds) > 0 and len(tds[0].contents) > 1 and len(tds[0].contents[1].contents) > 0:
                        newMonster.defaultMove = tds[0].contents[1].contents[0].rstrip()
                        # print(newMonster.defaultMove)
                else:
                    tds = tr.find_all('td')
                    if len(tds) > 0 and tds[0].contents[0].find(' x ') != -1:
                        for i in range(0, len(tds[0].contents) - 1, 3):
                            tmp = tds[0].contents[i].rstrip()
                            count = int(tmp.replace(' x', ''))
                            cardName = tds[0].contents[i+1].contents[0].rstrip()
                            newCard = CCard(cardName,count)
                            newMonster.cardList.append(newCard)
                newMonster.bGetAllInfo = True

    def ProcessAllMonsterUrls(self):
        if not os.path.exists(self.monsterXMLPath):
            self.ReadMonsterName();
            self.WriteMonsterBuildsToXML();
        else:
            self.ReadMonsterBuildFromXML();
            self.CollectMonsterDataFromURL();
            self.WriteMonsterBuildsToXML();

g_GetWebData = CGetWebData()

# # 1.测试写xml文件
# g_GetWebData.AddTestData()
# g_GetWebData.WriteFigureDataToXML("test.xml")

# # 2.抓取COC人物卡组并写到xml文件
# g_GetWebData.ProcessAllFigureUrls()
# g_GetWebData.WriteFigureDataToXML("FigureBuild.xml")

# 3.抓取COC怪物卡组并写到xml文件
g_GetWebData.ProcessAllMonsterUrls()

# 数据结构：
# n个人物名称：
#   卡牌
#       名称
#       数量


