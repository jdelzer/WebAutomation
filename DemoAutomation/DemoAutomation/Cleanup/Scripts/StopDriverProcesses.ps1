If (-NOT ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))
	{
		$arguments = "& '" + $myinvocation.mycommand.definition + "'"
		Start-Process powershell -Verb runAs -ArgumentList $arguments
		Break
	}

# PowerShell Kill Process
Write-Host 'Checking for processes...'

$chromedriver = Get-Process chromedriver -ErrorAction SilentlyContinue
if ($chromedriver) {
    $chromedriver | Stop-Process -Force
    Write-Host 'Chrome Processes stopped'
}
Else {
    'No chrome process found'
}

$iedriverserver = Get-Process iedriverserver -ErrorAction SilentlyContinue
if ($iedriverserver) {
    $iedriverserver | Stop-Process -Force
    Write-Host 'IE Processes stopped'
}
Else {
    'No IE process found'
}

Sleep 1p-Process -Force