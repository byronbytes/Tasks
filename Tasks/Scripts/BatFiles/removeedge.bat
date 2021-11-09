@echo off

:: Creator: ShadowWhisperer
:: GitHub: https://github.com/ShadowWhisperer
:: Updated: 11/18/2021

:: TODO: Check and show which versions were installed. 


:: Check if the user ran the script as admin.
net session >nul 2>&1
if %errorLevel% == 0 
(
 cls
) 
else 
(
 echo You need to run this script as administrator.
 pause 
 exit
)

:: Pre Warning message (Since this is the "Tasks" edit)
echo This script uninstalls Microsoft Edge. This means the "Microsoft Edge" option in "Cleanup" will no longer be available if you proceed.
echo If you are sure about this, or do not use Edge, you may continue, if you do not want to do this you can close out of the script.
pause

:: Set Exist Variable - Check if Edge is intalled  *Show Message, if not installed
set "EXIST=0"

:: Kill Edge Process
taskkill /im "msedge.exe" /f  >nul 2>&1

::Do not reinstall Edge from Windows Update
reg add HKLM\SOFTWARE\Microsoft\EdgeUpdate /t REG_DWORD /v DoNotUpdateToEdgeWithChromium /d 1 /f >nul 2>&1

:: Uninstall - 32Bit

if exist "C:\Program Files (x86)\Microsoft\Edge\Application\" 
(
set "EXIST=1"
echo Microsoft Edge (32bit) has been found and will start removing.
for /f "delims=" %%a in ('dir /b "C:\Program Files (x86)\Microsoft\Edge\Application\"') do 
(
cd /d "C:\Program Files (x86)\Microsoft\Edge\Application\%%a\Installer\"
if exist "setup.exe" 
(
echo - Removing Microsoft Edge
start /w setup.exe --uninstall --system-level --force-uninstall
)
echo Finished.
timeout /t 3 & exit
)
)

:: Uninstall - 64Bit

if exist "C:\Program Files\Microsoft\Edge\Application\" 
(
set "EXIST=1"
echo Microsoft Edge (64bit) has been found and will start removing.
for /f "delims=" %%a in ('dir /b "C:\Program Files\Microsoft\Edge\Application\"') do
(
cd /d "C:\Program Files\Microsoft\Edge\Application\%%a\Installer\"
if exist "setup.exe" 
(
echo - Removing Microsoft Edge
start /w setup.exe --uninstall --system-level --force-uninstall
)
echo Finished.
timeout /t 3 & exit
)
)


:: Not Installed

if "%EXIST%"=="0" 
(
echo Edge is not installed.
timeout /t 3 & exit
)
