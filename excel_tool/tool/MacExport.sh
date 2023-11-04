#!/bin/bash

set -x

cd `dirname $0`

dotnet --version
dotnet ./NanoModule.ExcelToBytes.dll
