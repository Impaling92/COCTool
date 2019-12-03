import requests
from bs4 import BeautifulSoup
import re

headers = {
    'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3',
    'Accept-Encoding': 'gzip, deflate',
    'Accept-Language': 'zh-CN,zh;q=0.9',
    'Cookie': 'xf_user=15819%2C9cb5406f5957d4c36620c1cc70c424d6e6a08605; xf_session=14aa3e308c605034afe321882df74a44',
    'Host': 'forums.cardhunter.com',
    'Proxy-Connection': 'keep-alive',
    'Upgrade-Insecure-Requests': '1',
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36',
}

url = 'http://forums.cardhunter.com/threads/coc-pcs.9397/'
url2 = 'http://forums.cardhunter.com/threads/coc-pcs.9397/page-2'
response = requests.get(url, headers=headers)
print(response.status_code)
response.encoding = 'GBK'
soup = BeautifulSoup(response.text, 'lxml')
#print(soup.prettify())
print(soup.title)
#print(soup.head.contents)
# for k in soup.find_all('blockquote'):
#     print(k)
for k in soup.find_all('blockquote'):
    text_list = k.text.split('\n')
    # print(k.text)
    # print(k.text)
    img_url = str(k.contents[1])
    print(img_url)
    nstr = img_url.find('http://live.cardhunter.com/assets/large_portraits/')
    nend = img_url.find('.png')
    print(nstr)
    print(nend)

class CCard:
    def __init__(self,name,count):
        self.name = name
        self.count = count

class CFigure:
    cardlist = []
    name = ''
    def __init__(self,figure_name):
        self.name = figure_name
    def addCard(self,name,count):
        card = CCard(name,count)
        self.cardlist.append(card)


