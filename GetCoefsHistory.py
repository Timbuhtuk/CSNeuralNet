import requests
from bs4 import BeautifulSoup as BS
import json

r = requests.get("https://api.csgorun.io/current-state?montaznayaPena=null")

JsonText = json.loads(r.text)

rowcount = 13 


Data = []
print(type(Data))
for item in JsonText['data']['game']['history']:
    Data.append(item['crash'])
DataSorted = []
Data.reverse()

for q in range (len(Data)-rowcount-1):
    DataSorted.append([])
    for e in range (rowcount):
        DataSorted[q].append(Data[q+e])

#for q in range (36):
#    for e in range (4):
 #       print("q = ",q,"coef =",DataSorted[q][e])

Writingmode = "w"

File = open('Answers.txt', Writingmode)
for q in range (1,len(Data)-rowcount-1):
    File.write(str(int(DataSorted[q][rowcount-1]>2.0)))
    File.write('\n')

file = open('Data.txt', Writingmode)
for q in range (len(Data)-rowcount-2):
    for e in range (rowcount):
        file.write(str(DataSorted[q][e]))
        if(e!=rowcount-1):
            file.write('/')
        
    file.write('\n')




