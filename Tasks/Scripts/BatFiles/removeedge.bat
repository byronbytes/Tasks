@echo off

:: Creator: ShadowWhisperer
:: GitHub: https://github.com/ShadowWhisperer
:: Updated: 11/18/2021

:: TODO: Check and show which versions were installed. 


:: Check if ran as Admin
net session >nul 2>&1
if %errorLevel% == 0 (
 cls
) else (
 echo. & echo Run Script As Admin & echo.
 pause & exit
)

:: Set Exist Variable - Check if Edge is intalled  *Show Message, if not installed
set "EXIST=0"

:: Stop Edge
taskkill /im "msedge.exe" /f  >nul 2>&1

::Do not reinstall Edge from Windows Update
reg add HKLM\SOFTWARE\Microsoft\EdgeUpdate /t REG_DWORD /v DoNotUpdateToEdgeWithChromium /d 1 /f >nul 2>&1

:: Uninstall - 32Bit
if exist "C:\Program Files (x86)\Microsoft\Edge\Application\" (
set "EXIST=1"
echo Microsoft Edge (32bit) has been found and will start removing.
for /f "delims=" %%a in ('dir /b "C:\Program Files (x86)\Microsoft\Edge\Application\"') do (
cd /d "C:\Program Files (x86)\Microsoft\Edge\Application\%%a\Installer\"
if exist "setup.exe" (
echo - Removing Microsoft Edge
start /w setup.exe --uninstall --system-level --force-uninstall)
echo Finished.
timeout /t 3 & exit
))

:: Uninstall - 64Bit
if exist "C:\Program Files\Microsoft\Edge\Application\" (
set "EXIST=1"
echo Microsoft Edge (64bit) has been found and will start removing.
for /f "delims=" %%a in ('dir /b "C:\Program Files\Microsoft\Edge\Application\"') do (
cd /d "C:\Program Files\Microsoft\Edge\Application\%%a\Installer\"
if exist "setup.exe" (
echo - Removing Microsoft Edge
start /w setup.exe --uninstall --system-level --force-uninstall)
echo Finished.
timeout /t 3 & exit
))


:: Not Installed
if "%EXIST%"=="0" (
echo. & echo Edge is not installed. & echo.
timeout /t 3 & exit)
