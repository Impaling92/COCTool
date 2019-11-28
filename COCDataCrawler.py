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
k = soup.find_all('blockquote')
print(k[1])