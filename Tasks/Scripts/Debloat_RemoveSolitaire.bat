@echo on
rem Written by Solirs for Tasks (https://github.com/LiteTools/Tasks)
powershell -Command "& {Get-AppxPackage *solitairecollection* | Remove-AppxPackage}"
pause
