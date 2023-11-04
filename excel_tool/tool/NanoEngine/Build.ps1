$currentDir = Split-Path -Parent $MyInvocation.MyCommand.Definition
Set-Location $currentDir

dotnet publish ./NanoModule.ExcelToBytes/NanoModule.ExcelToBytes.csproj -c Release -o ./Output/NanoModule.ExcelToBytes/
