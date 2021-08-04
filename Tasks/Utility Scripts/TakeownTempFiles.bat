@echo off 
color 02
echo This script will take ownership of the directories C:\Windows\Temp and C:\Windows\Prefetch.
echo You may need to run this prompt as administrator.
pause 1
takeown /F "C:\Windows\Temp" /A /R /D Y
takeown /F "C:\Windows\Prefetch" /A /R /D Y

echo The task finished successfully.
