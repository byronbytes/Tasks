@echo on

rem Written by Solirs for the Tasks Project (https://github.com/LiteTools/Tasks)

powershell -Command "& {Get-AppxPackage *solitairecollection* | Remove-AppxPackage}"

pause
