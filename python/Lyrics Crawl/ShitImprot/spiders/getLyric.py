# -*- coding:utf-8 -*-
# --------- version 0.2 ------------
# --------- inoth ----------
import scrapy,re,os
from urllib.parse import quote, unquote, urlencode
from datetime import datetime
# //div[@class="medium"]/text()|//div[@class="medium"]/span[@class="ruby"]/span[@class="rt"]/text()


class LyricSpider(scrapy.Spider):
    name = 'suna'

    def start_requests(self):
        # https://utaten.com/search/=/sort=popular_sort%3Aasc/artist_name={name}/title={title}/beginning=/body=/lyricist=/composer=/sub_title=/form_open=1/show_artists=1/
        data = {'米津': "flamingo"}

        for k,v in data.items():
            yield scrapy.Request(f'https://utaten.com/search/=/sort=popular_sort%3Aasc/artist_name={k}/title={v}/beginning=/body=/lyricist=/composer=/sub_title=/form_open=1/show_artists=1/', callback=self.parse)

    def parse(self, response):
        # //main//table//p[contains(@class,"searchResult__name")]/a[contains(text(),{name})]/../../p[contains(@class,"searchResult__title")]/a/@href
        # .*artist_name=(.*)/title.*?
        tit = unquote(re.findall('.*artist_name=(.*)/title.*?',response.url)[0])
        newurl = response.xpath(f'//main//table//p[contains(@class,"searchResult__name")]/a[contains(text(),{tit})]/../../p[contains(@class,"searchResult__title")]/a/@href').extract_first()
        if newurl:
            yield response.follow(newurl, callback=self.ly_parse)

    def ly_parse(self, response):
        lyric = response.xpath(
            '//div[@class="medium"]/text()|//div[@class="medium"]/span/span[@class="rt"]|//div[@class="medium"]/span/span[@class="rb"]/text()').extract()
        name = unquote(response.url.split('/')[-2])
        sss = ""
        for item in lyric:
            if re.match('.*>(.*)?<.*', item):
                sss += '「' + re.findall('.*>(.*)?<.*', item)[0] + '」'
            else:
                sss += item
        with open(f'lyric/{name}.txt', 'wt', encoding="utf-8") as f:
            f.write(sss.strip())
