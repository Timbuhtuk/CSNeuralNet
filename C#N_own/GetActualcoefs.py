from bs4 import BeautifulSoup as BS
import requests
import json
import time

while (True):
    query = requests.get("https://api.csgorun.io/current-state?montaznayaPena=null")
    json_text = json.loads(query.text)
    last_id = int(json_text['data']['game']['history'][0]['id'])

    with open("DataActual.txt", 'r+') as data_file:
        data_file.readline()
        try:
            if last_id == int(data_file.readline()):
                continue
        except ValueError:
            pass

    with open("DataActual.txt", 'w+') as data_file, open("Data 2.txt", 'a+') as data_file2, open("Answers.txt", 'a+') as answers_file:
        data = []
        for item in json_text['data']['game']['history']:
            data.append(item['crash'])

        for i in range(len(data), -1, -1):
            data_file.write(str(data[q]))
            if i != 0:
                data_file.write('/')

        data_file.write('\n')
        data_file.write(str(last_id))

        for q in range(13,0,-1):
            data_file2.write(str(data[q]))
            if q != 1:
                data_file2.write('/')

        data_file2.write('\n\n')
        answers_file.write(str(int(data[0] > 2)))

    time.sleep(1)





