@echo on

powershell -Command "& {Get-AppxPackage *solitairecollection* | Remove-AppxPackage}"

rem written by Solirs for the Tasks project (https://github.com/LiteTools/Tasks)

PAUSE
