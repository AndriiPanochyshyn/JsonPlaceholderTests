# JsonPlaceholderTests

Solution for automatization testing process

Projects Includes With This Solution:
  - Api:
      - Interface for api autotesting
      - Rest interface for communication with http://jsonplaceholder.typicode.com/ website
  - UI.Core: 
      - Selenium web driver page interface provider for UI autotesting
      - Selenium web driver navigation interface provider for work with Chrome browser
  - UI.JsonPlaceholder:
      - http://jsonplaceholder.typicode.com/ website interaction interface, implemented with Page Object pattern approach
  - Models:
      - Objects that can be used during automation testing process in both Api and UI autotests
  - API.Test
      - Some autotests to demonstrate automation api testing process implemented with NUnit
  - UI.Tests
      - Some autotests to demonstrate automation UI testing process implemented with Specflow and NUnit
      
Exceptions:

Error: Chrome browser and chromedriver.exe for automation UI testing can be incompatible on a certain environment.
Solution: Find out what version of Chrome browser is installed and then just replace chromedriver.exe with appropriate webdriver version from here https://chromedriver.storage.googleapis.com/index.html, set chromedriver.exe "Copy to Ouput Directory" property to "Copy always" and build project.

Error: Unable to copy file "...\chromedriver.exe" to "bin\Debug\chromedriver.exe". The process cannot access the file 'bin\Debug\chromedriver.exe' because it is being used by another process. Error can be occured when you manually will stop UI autotest during execution.
Solution: Manually shut down all chromedriver.exe processes in Task Manager.

Error: Invalid Resx file. Could not find a part of the path '...\d32776.png'.
Solution: Add d32776.png file to resources.


To avoid all errors and for convenient reporting autotesting process can be executed with CI remotely on some customized environment
    
# Tests

http://jsonplaceholder.typicode.com/posts
Check that new post can be added into the system

http://jsonplaceholder.typicode.com/posts
Check that new post can be updated into the system

http://jsonplaceholder.typicode.com/posts
Check that new post can be deleted from the system

https://jsonplaceholder.typicode.com/comments
Check if email of user who left a comment with "ipsum dolorem" text in comment's body is "Marcia@name.biz"

https://jsonplaceholder.typicode.com/posts
Check if user who posted a post with title "eos dolorem iste accusantium est eaque quam" 
name is "Patricia Lebsack"

https://jsonplaceholder.typicode.com/photos
Check if photo with title "ad et natus qui" belongs to user with email "Sincere@april.biz"

https://jsonplaceholder.typicode.com/todos 
check that  Leanne Graham has more than 3 "completed" TODOs than Ervin Howell

https://jsonplaceholder.typicode.com/photos <<Need to implement binary comparison, should pass
check if image of photo with id 4 isn't corrupted.Use file d32776.png for referrence (see attachment). 
      
  
