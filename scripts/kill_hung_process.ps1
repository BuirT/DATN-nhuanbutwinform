param(
    [int]$Pid = $null,
    [string]$Name = "HETHONGTINHNHUANBUT"
)

if ($Pid) {
    Write-Host "Stopping process with PID $Pid..."
    Stop-Process -Id $Pid -Force -ErrorAction SilentlyContinue
} else {
    Write-Host "Stopping processes named $Name..."
    Get-Process -Name $Name -ErrorAction SilentlyContinue | Stop-Process -Force -ErrorAction SilentlyContinue
}   