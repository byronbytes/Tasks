@echo on

echo Clearing your ipconfig will temporarily disconnect you from the internet, you can proceed or close out of the prompt and nothing will happen.

pause


ipconfig /release6
ipconfig /release

ipconfig /renew6
ipconfig /renew

echo Finished Clearing.
pause

