import requests
from bs4 import BeautifulSoup as BS
import json
import time


def ask_for_continue(additional_text=""):
    print("Do you want to continue? " + additional_text)
    text = input()
    if (text.lower() == 'y'):
        return True
    else:
        return False
    
    
while (True):
    if (not ask_for_continue()):
        break;

    query = requests.get("https://api.csgorun.io/current-state?montaznayaPena=null")
    json_text = json.loads(query.text)
    last_id = int(json_text['data']['game']['history'][0]['id'])

    with open("data.txt", 'r') as data_file:
        data_file.readline()
        if (last_id == int(data_file.readline())):
            continue

    with open("DataActual.txt", 'w') as data_file, open("Data 2.txt", 'a') as data_file2, open("Answers.txt", 'a') as file_answers:

        data = []
        for item in json_text['data']['game']['history']:
            data.append(item['crash'])

        for i in range (len(data), -1, -1):
            data_file.write(str(data[q]))
            if(i != 0):
                data_file.write('/')
                
        data_file.write('\n')
        data_file.write(str(last_id))
        
        
        for q in range (13,0,-1):
            data_file2.write(str(data[q]))
            if(q != 1):
                data_file2.write('/')
                
                
        file_answers.write(str(int(data[0] > 2)))

        file_data2.write('\n')
        file_data2.write('\n')

    time.sleep(1)


    

