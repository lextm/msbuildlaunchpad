set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %MSBuildDir%\msbuild msbuildlaunchpad.sln /p:Configuration=Release /t:Rebuild
@IF %ERRORLEVEL% NEQ 0 PAUSE

mkdir .\bin
copy processviewer\processviewer.exe .\bin\
copy msbuildlaunchpad.exe.manifest .\bin\
copy msbuildlaunchpadadmin.exe.manifest .\bin\
copy launchpad.iss .\bin\

"C:\Program Files (x86)\Inno Setup 5\iscc.exe" bin\launchpad.iss