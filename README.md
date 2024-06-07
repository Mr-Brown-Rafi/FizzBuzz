**Steps to run the application**  
**--> Visual studio**  
**step 1:** clone the repository  
**step 2:** build and run the project  
**step 3:** provide inputs in swagger  ["1", "3", "5", "", "15", "A", "23"]  
![image](https://github.com/Mr-Brown-Rafi/FizzBuzz/assets/61969034/43bde037-78df-4ecf-8612-b8b67657e8e5)
  
**output:**  
![image](https://github.com/Mr-Brown-Rafi/FizzBuzz/assets/61969034/912c001c-f1db-443e-834d-6a8853504e7f)  
**step 4:** Run test cases in test explorer  
![image](https://github.com/Mr-Brown-Rafi/FizzBuzz/assets/61969034/c2d6c039-e06e-4c4a-adc8-2c8928b3ade5)  


**--> Terminal or command prompt**    
**clone the project to local from git repo**  
```git clone https://github.com/Mr-Brown-Rafi/FizzBuzz.git```
  
**Build the application**  
```dotnet build```
  
**Run the application**  
```dotnet run --project CodingExercise```
  
Open swagger in browser - https://localhost:7119/swagger/index.html

provide the input

Sample Input -   
```{  "values": ["1", "3", "5", "", "15", "A", "23"] }```
 
you will get the sample output below in response  
Sample Output -    
```["Divided 1 by 3 & Divided 1 by 5",  "Fizz",  "Buzz",  "Invalid Item",  "FizzBuzz",  "Invalid Item",  "Divided 23 by 3 & Divided 23 by 5"]```


