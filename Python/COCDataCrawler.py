import requests
from bs4 import BeautifulSoup
import re
from enum import Enum

LOG_LEVEL = Enum('LOG_LEVEL',('Trace','Log'))
CURR_LOG_LEVEL = LOG_LEVEL.Log

class CFunTrace:
    __funName_ = ''
    def __init__(self,funName):
        self.__funName = funName
        if CURR_LOG_LEVEL.value <= LOG_LEVEL.Trace.value:
            print(self.__funName + ' Entered...')
    def __del__(self):
        if CURR_LOG_LEVEL.value <= LOG_LEVEL.Trace.value:
            print(self.__funName + ' Exited...')

class CLog:
    __funName_ = ''
    def __init__(self,funName):
        self.__funName = funName
        if CURR_LOG_LEVEL.value <= LOG_LEVEL.Log.value:
            print(self.__funName)

class CCard:
    def __init__(self,name,count):
        self.name = name
        self.count = count

class CFigure:
    cardlist = []
    name = ''
    def __init__(self,figure_name):
        funLog = CFunTrace('CFigure:__init__')
        self.name = figure_name
        log = CLog('添加人物：{nameStr}'.format(nameStr = figure_name))
    def addCard(self,name,count):
        funLog = CFunTrace('CFigure:addCard()')
        card = CCard(name,count)
        self.cardlist.append(card)
        log = CLog('添加卡牌，名称：{nameStr},数量：{countStr}'.format(nameStr = name,countStr = count))

class CGetWebData:
    headers = {
    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3',
    'Accept-Encoding': 'gzip, deflate',
    'Accept-Language': 'zh-CN,zh;q=0.9',
    'Cookie': 'xf_user=15819%2C9cb5406f5957d4c36620c1cc70c424d6e6a08605; xf_session=14aa3e308c605034afe321882df74a44',
    'Host': 'forums.cardhunter.com',
    'Proxy-Connection': 'keep-alive',
    'Upgrade-Insecure-Requests': '1',
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36',}
    
    urls = ['http://forums.cardhunter.com/threads/coc-pcs.9397/',
    'http://forums.cardhunter.com/threads/coc-pcs.9397/page-2']

    firstFindString = 'http://live.cardhunter.com/assets/large_portraits/'
    # 人物列表
    figureList = []

    def ProcessUrl(self,url):
        response = requests.get(url, headers=self.headers)
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

    def ProcessAllUrls(self):
        for eachUrl in self.urls:
            self.ProcessUrl(eachUrl)
        log = CLog('人物数据采集完成，数量：{count}'.format(count = len(self.figureList)))

g_GetWebData = CGetWebData()
g_GetWebData.ProcessAllUrls()


