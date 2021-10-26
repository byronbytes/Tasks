<# 
Creator: byronbytes
Last Updated: 10/26/21
Repository: https://github.com/LiteTools/Tasks
#>

Write-Host "This is the propriatary Tasks powershell patching tool, this tool will attempt to fix Remove Bloat issues and bugs with powershell."

  if (-not(Check-IsElevated))
 { 
  Write-Host "WARNING: It is highly suggested you run this script as administrator." 
 }
 
$CurrentPolicy = Get-ExecutionPolicy
$BlockedPolicy = "Restricted"


<#This is currently a WIP, I have little to no resources, and will be changed throughout time.#>

  if ($CurrentPolicy = Restricted)
 {
   try 
      {
        Set-ExecutionPolicy -ExecutionPolicy Bypass
        Write-Host "Execution Policy has changed to Bypass."
      }
      catch
        {
          Write-Host "An error has occurred and Tasks was unable to patch."
          Write-Host $_         
        }
 }
 
 
  if ($CurrentPolicy = Bypass)
 {
    try
      {
        Write-Host "Execution Policy is already set to Bypass, no need for patching."
      }
      catch
        {
          Write-Host "An error occurred."
          Write-Host $_
        }
  }
