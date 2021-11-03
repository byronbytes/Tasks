<# 
Creator: byronbytes
Last Updated: 10/26/21
Repo: https://github.com/LiteTools/Tasks
#>

Write-Host "Just in case the scripts fail to work, running this may fix any issues."

  if (-not(Check-IsElevated))
 { 
  Write-Host "WARNING: It is highly suggested you run this script as administrator." 
 }

$CurrentPolicy = Get-ExecutionPolicy

<#This is currently a WIP.#>

  if ($CurrentPolicy = Restricted)
 {
   try 
      {
        Set-ExecutionPolicy -ExecutionPolicy Bypass
        Write-Host "Execution Policy has changed to Bypass."
        Write-Host "Press any key to continue ....."
        $x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
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
        Write-Host "Press any key to continue ....."
        $x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
      }
      catch
        {
          Write-Host "An error occurred."
          Write-Host $_
        }
  }
