mkdir .\bin
copy psvince.dll .\bin\
copy msbuildlaunchpad.exe.manifest .\bin\
copy msbuildlaunchpadadmin.exe.manifest .\bin\
copy launchpad.iss .\bin\
cd .\bin
copy msbuildlaunchpad.exe msbuildlaunchpadAdmin.exe
copy msbuildlaunchpad.exe.config msbuildlaunchpadAdmin.exe.config
