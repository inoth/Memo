
# # # sys.path.append('s:\\script\\spider\\ShitImprot\\ShitImprot')
# # from items import *

# # //div[@class="medium"]/text()|//div[@class="medium"]/span[@class="ruby"]/span[@class="rt"]/text()


# # from urllib3.request import urlencode
# from urllib.parse import quote, urlencode, unquote


# data = {
#     'name':'砂の惑星',
#     'sakusya':'米津玄师'
# }
# print(urlencode(data))
# print(quote('初音ミク'))
# # print(unquote('%E7%A0%82%E3%81%AE%E6%83%91%E6%98%9F'))

# import re

# l = '<span class="rt">おも</span>'
# print(re.findall('<span class="rt">(.*)?</span>',l))