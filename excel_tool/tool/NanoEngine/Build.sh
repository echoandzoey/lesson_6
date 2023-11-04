#!/bin/bash

set -x

cd `dirname $0`

dotnet --version
dotnet publish ./NanoModule.ExcelToBytes/NanoModule.ExcelToBytes.csproj -c Release -o ./Output/NanoModule.ExcelToBytes/
