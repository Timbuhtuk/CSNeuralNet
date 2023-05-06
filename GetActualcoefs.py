from bs4 import BeautifulSoup as BS
import requests
import json
import time

files = {
    "data_actual" : "DataActual.txt",
    "data_2" : "Data 2.txt",
    "answers" : "Ansers.txt"
}

<<<<<<< HEAD:C#N_own/GetActualcoefs.py
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
=======
while(True):
    FileA = open('DataActual.txt','r')
    r = requests.get("https://api.csgorun.io/current-state?montaznayaPena=null")
    JsonText = json.loads(r.text)
    Last_id = int(JsonText['data']['game']['history'][0]['id'])

    FileA.readline()
    if(Last_id!=int(FileA.readline())):
        print(Last_id)
        FileA.close()
        Data = []
        for item in JsonText['data']['game']['history']:
            Data.append(item['crash'])

        FileA = open('DataActual.txt','w')

        for q in range (12,-1,-1):
            
            FileA.write(str(Data[q]))
            
            if(q!=0):
                FileA.write('/')
        FileA.write('\n') 
        FileA.write(str(Last_id))       
        FileA.close()

        FileD = open('Data — копия.txt','a')
        FileAn = open('Answers — копия.txt','a')
        for q in range (13,0,-1):
            FileD.write(str(Data[q]))
            if(q!=1):
                
                FileD.write('/')
        FileAn.write(str(int(Data[0]>2)))   
>>>>>>> fab0069abd84176bcbb25e4a87b5765e23bd439c:GetActualcoefs.py

        for q in range(len(data) - 1, 0, -1):
            data_file2.write(str(data[q]))
            if q != 1:
                data_file2.write('/')

<<<<<<< HEAD:C#N_own/GetActualcoefs.py
        data_file2.write('\n\n')
        answers_file.write(str(int(data[0] > 2)))

=======
        FileD.close()
        FileAn.close()

        #break
    else:
        FileA.close()
>>>>>>> fab0069abd84176bcbb25e4a87b5765e23bd439c:GetActualcoefs.py
    time.sleep(1)
