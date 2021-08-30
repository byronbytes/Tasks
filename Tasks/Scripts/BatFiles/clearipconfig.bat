@echo on

echo Clearing your ipconfig will temporarily disconnect you from the internet for 30 seconds, you can proceed now or close out of the prompt and nothing will happen.

pause


ipconfig /release6
ipconfig /release
echo Released ipconfig info, internet will be temporarily disabled until it renews.
ipconfig /renew6
ipconfig /renew
echo Renewed ipconfig info, it will take a moment for internet to come back.

echo Finished Task. 
pause

