To run the service :
1. Install the windows service
   a. Open the IDE as Administrator
   b. Build the FileMoverService project
   c. Open the Developer Command prompt and navigate to the build directory \FileMoverService\Bin\Debug
   d. Run installutil FileMoverService.exe

2. Run the service
   a. open Services or run services.msc
   b. Locate File Mover Service, right click and Start
   c. Create a file or copy an existing file.
       i. right click the file and select properties
       ii. go to Sercurity tab and add the "Local Service" account to the Group or usernames by clicking Edit then Add the said account
       iii. click apply and ok.
   d. place the file to Folder 1 and it should automatically move to Folder 2
   e. Open the log.txt in FileMoverServiceLogs folder and check the logs.
