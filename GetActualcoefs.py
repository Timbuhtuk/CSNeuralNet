import requests
from bs4 import BeautifulSoup as BS
import json
import time


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

        FileD.write('\n')
        FileAn.write('\n')

        FileD.close()
        FileAn.close()

        #break
    else:
        FileA.close()
    time.sleep(1)







    

