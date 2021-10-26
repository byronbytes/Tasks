Write-Host "This is the proprietary Tasks patching tool, this tool will attempt to fix Remove Bloat issues and bugs."

$CurrentPolicy = Get-ExecutionPolicy
$BlockedPolicy = "Restricted"

<#This is currently a WIP, I have little to no resources, and will be changed throughout time.#>

  if ($CurrentPolicy = Restricted)
  {
  Set-ExecutionPolicy -ExecutionPolicy Bypass
  }
  
  if ($CurrentPolicy = Bypass)
  {
  Write-Host "Policy is set to bypass, no need for patching."
  }
