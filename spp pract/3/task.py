from bs4 import BeautifulSoup
import requests 


def count_words_in_html(html_content: str) -> int:
    soup = BeautifulSoup(html_content, 'html.parser')
    text_tags = ['p', 'h1', 'h2', 'h3', 'h4', 'h5', 'h6']
    count = 0

    for tag in text_tags:
        tags = soup.find_all(tag)
        for i in tags:
            count += count_words_in_text(i)
        
    return count


def count_words_in_text(text: str) -> int:
    words = str(text).split(' ')
    return len(words)
    

url = 'https://www.lipsum.com/'
response = requests.get(url)
html_content = response.text
count = count_words_in_html(html_content)
print(count)