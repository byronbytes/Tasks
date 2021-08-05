@echo off 
color 02
echo -----------------------------------------Warning:---------------------------------------------
echo This script will take ownership of the directories C:\Windows\Temp and C:\Windows\Prefetch.
echo You may need to run this prompt as administrator.
echo If you do not want to do this, you can close this prompt and nothing will happen.
echo -----------------------------------------Warning:---------------------------------------------
pause
takeown /F "C:\Windows\Temp" /A /R /D Y
takeown /F "C:\Windows\Prefetch" /A /R /D Y
echo The task finished successfully. Click anywhere to close.
pause 
