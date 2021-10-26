<# 
Creator: byronbytes
Last Updated: 10/26/21
Repository: https://github.com/LiteTools/Tasks
#>

Write-Host "This is the proprietary Tasks powershell patching tool, this tool will attempt to fix Remove Bloat issues and bugs with powershell."

$CurrentPolicy = Get-ExecutionPolicy
$BlockedPolicy = "Restricted"

<#This is currently a WIP, I have little to no resources, and will be changed throughout time.#>

  if ($CurrentPolicy = Restricted)
 {
    Set-ExecutionPolicy -ExecutionPolicy Bypass
    Write-Host "Execution Policy has now changed to bypass."
 }
  
  if ($CurrentPolicy = Bypass)
 {
    Write-Host "Execution Policy is already set to Bypass, no need for patching."
 }
