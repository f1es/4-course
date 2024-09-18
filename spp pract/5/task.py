from requests_oauthlib import OAuth1Session
import json


def get_text_from_file(path: str) -> str:
    file = open(path, 'r')
    text = file.read()
    return text


def get_user_info() -> str:
    API_KEY = get_text_from_file("consumer_key.txt")
    API_SECRET_KEY = get_text_from_file("consumer_secret.txt")
    ACCESS_TOKEN = get_text_from_file("access_token.txt")
    ACCESS_TOKEN_SECRET = get_text_from_file("access_token_secret.txt")

    oauth = OAuth1Session(API_KEY, API_SECRET_KEY, ACCESS_TOKEN, ACCESS_TOKEN_SECRET)
    
    url = "https://api.x.com/2/users/me"
    response = oauth.get(url)

    if response.status_code == 200:
        user_info = response.json()
        formatted = json.dumps(user_info, indent=4, sort_keys=True)
        return formatted
    else:
        raise Exception(f"Ошибка запроса: {response.status_code} {response.text}")


def main():
    try:
        user_info = get_user_info()
        print("Информация о пользователе:", user_info)
    except Exception as e:
        print(e)


if __name__ == "__main__":
    main()
