@echo off
SET sn="%programfiles%\Microsoft SDKs\Windows\V6.0A\Bin\sn.exe"
set gacutil="%programfiles%\Microsoft SDKs\Windows\V6.0A\Bin\gacutil.exe"
set msbuild="%windir%\Microsoft.NET\Framework\v3.5\MSBuild.exe"
REM set lib="\lib"
REM set configuration=Debug
REM if exist commonfiles\uNhAddIns.snk goto build
REM echo Generating strong key...
REM %sn% -k commonfiles\uNhAddIns.snk
:build
%msbuild% uNhAddIns.Everythings.build /v:m /p:BUILD_NUMBER=2.0.0.0
:end
echo -------------------------------
pause