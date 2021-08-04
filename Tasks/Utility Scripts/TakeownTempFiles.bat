@echo off 
echo This script will take ownership of the directories C:\Windows\Temp and C:\Windows\Prefetch.
takeown /F "C:\Windows\Temp" /A /R /D Y

echo You may need to run this prompt as administrator.

echo Done.
pause 1