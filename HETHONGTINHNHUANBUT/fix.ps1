$lines = Get-Content ".\FrmTrangChinh.cs"
$newLines = @()
$newLines += $lines[0..292]
$newLines += $lines[492..($lines.Length-1)]
Set-Content -Path ".\FrmTrangChinh.cs" -Value $newLines
