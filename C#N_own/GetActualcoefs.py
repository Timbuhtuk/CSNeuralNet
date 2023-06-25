from bs4 import BeautifulSoup as BS
import requests
import json
import time

files = {
    "data_actual" : "DataActual.txt",
    "data_2" : "Data 2.txt",
    "answers" : "Ansers.txt"
}

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

    with open(files["data_actual"], 'w+') as data_file, open(files["data_2"], 'a+') as data_file2, open(files["answers"], 'a+') as answers_file:
        data = []
        for item in json_text['data']['game']['history']:
            data.append(item['crash'])

        for q in range(len(data) - 1, -1, -1):
            data_file.write(str(data[q]))
            if q != 0:
                data_file.write('/')

        data_file.write('\n')
        data_file.write(str(last_id))

        for q in range(len(data) - 1, 0, -1):
            data_file2.write(str(data[q]))
            if q != 1:
                data_file2.write('/')

        data_file2.write('\n\n')
        answers_file.write(str(int(data[0] > 2)))

    time.sleep(1)
