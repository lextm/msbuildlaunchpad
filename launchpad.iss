#define MyAppID "{CF9D7790-D286-4CAA-B8DA-7CE78B067E25}"
#define MyAppCopyright "Copyright (C) 2010-2011 Lex Li"
#define MyAppName "MSBuild Launch Pad"
#define MyAppVersion GetFileVersion("MSBuildLaunchPad.exe")
#define ConflictingProcess "msbuildlaunchpad.exe"
#define ConflictingApp "MSBuild Launch Pad"
#pragma message "Detailed version info: " + MyAppVersion

#define ShellExtensionAppID "MSBuild Shell Extension"

[Setup]
AppName={#MyAppName}
AppVerName={#MyAppName}
AppPublisher=Lex Li (lextm)
AppPublisherURL=http://lextm.com
AppSupportURL=http://lextm.com
AppUpdatesURL=http://msbuildlaunchpad.codeplex.com
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=.
SolidCompression=true
AppCopyright={#MyAppCopyright}
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany=LeXtudio
VersionInfoDescription={#MyAppName} Setup
VersionInfoTextVersion=1.0
InternalCompressLevel=max
VersionInfoCopyright={#MyAppCopyright}
Compression=zip
PrivilegesRequired=admin
ShowLanguageDialog=yes
WindowVisible=false
AppVersion={#MyAppVersion}
AppID={{#MyAppID}
UninstallDisplayName={#MyAppName}
SetupIconFile=MSBuild_APPICON.ico
UninstallDisplayIcon={app}\MSBuild_APPICON.ico

[Languages]
Name: english; MessagesFile: compiler:Default.isl
[Types]
Name: Full; Description: All components are installed; Languages: 
Name: Custom; Description: Custom; Flags: iscustom
[Components]
Name: LaunchPad; Description: Launch Pad components; Types: Custom Full; Languages: 
[Files]
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

; dll used to check running notepad at install time
Source: "processviewer.exe"; Flags: dontcopy

;psvince is installed in {app} folder, so it will be
;loaded at uninstall time ;to check if notepad is running
Source: "processviewer.exe"; DestDir: "{app}"

Source: "DomainModel.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad
Source: "LaunchPadCore.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad
Source: "MSBuildLaunchPad.exe"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad
Source: "MSBuildLaunchPad.exe.config"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad
Source: "MSBuildLaunchPad.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad
Source: "MSBuildLaunchPad.exe"; DestDir: "{app}"; DestName: "MSBuildLaunchPadAdmin.exe"; Flags: ignoreversion; Components: LaunchPad
Source: "MSBuildLaunchPad.exe.config"; DestDir: "{app}"; DestName: "MSBuildLaunchPadAdmin.exe.config"; Flags: ignoreversion; Components: LaunchPad
Source: "MSBuildLaunchPadAdmin.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad
Source: "MSBuildShellExtension.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad
Source: "NLog.dll"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad
Source: "MSBuild_APPICON.ico"; DestDir: "{app}"; Flags: ignoreversion; Components: LaunchPad

[Icons]
Name: {group}\{cm:UninstallProgram,MSBuild Launch Pad}; Filename: {uninstallexe}; Components: LaunchPad
Name: {group}\Author's Blog; Filename: http://lextm.com; Components: LaunchPad
Name: {group}\Report A Bug; Filename: http://msbuildlaunchpad.codeplex.com/workitem/list/basic; Components: LaunchPad
Name: {group}\Homepage; Filename: http://msbuildlaunchpad.codeplex.com; Components: LaunchPad

[Run]
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\ngen.exe; Parameters: "install ""{app}\MSBuildLaunchPad.exe"""; WorkingDir: {app}; StatusMsg: Optimising Performance; Flags: runhidden skipifdoesntexist

[UninstallRun]
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\ngen.exe; Parameters: "uninstall ""{app}\MSBuildLaunchPad.exe"""; WorkingDir: {app}; StatusMsg: Optimising Performance; Flags: runhidden skipifdoesntexist

[Registry]
Root: HKCR; Subkey: SystemFileAssociations\.sln\shell\MSBuild; ValueType: string; Flags: uninsdeletekey deletekey; ValueName: Icon; ValueData: """{app}\MSBuild_APPICON.ico"""
Root: HKCR; Subkey: SystemFileAssociations\.csproj\shell\MSBuild; ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.vbproj\shell\MSBuild; ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.vcxproj\shell\MSBuild; ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.oxygene\shell\MSBuild; ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.shfbproj\shell\MSBuild; ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.ccproj\shell\MSBuild; ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.proj\shell\MSBuild; ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon

Root: HKCR; Subkey: SystemFileAssociations\.sln\shell\MSBuild\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPad.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.csproj\shell\MSBuild\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPad.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.vbproj\shell\MSBuild\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPad.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.vcxproj\shell\MSBuild\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPad.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.oxygene\shell\MSBuild\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPad.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.shfbproj\shell\MSBuild\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPad.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.ccproj\shell\MSBuild\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPad.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.proj\shell\MSBuild\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPad.exe"" ""%1"""; Flags: uninsdeletekey deletekey

Root: HKCR; Subkey: SystemFileAssociations\.sln\shell\MSBuild (Admin); ValueType: string; Flags: uninsdeletekey deletekey; ValueName: Icon; ValueData: """{app}\MSBuild_APPICON.ico"""
Root: HKCR; Subkey: SystemFileAssociations\.csproj\shell\MSBuild (Admin); ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.vbproj\shell\MSBuild (Admin); ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.vcxproj\shell\MSBuild (Admin); ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.oxygene\shell\MSBuild (Admin); ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.shfbproj\shell\MSBuild (Admin); ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.ccproj\shell\MSBuild (Admin); ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon
Root: HKCR; Subkey: SystemFileAssociations\.proj\shell\MSBuild (Admin); ValueType: string; ValueData: """{app}\MSBuild_APPICON.ico"""; Flags: uninsdeletekey deletekey; ValueName: Icon

Root: HKCR; Subkey: SystemFileAssociations\.sln\shell\MSBuild (Admin)\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPadAdmin.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.csproj\shell\MSBuild (Admin)\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPadAdmin.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.vbproj\shell\MSBuild (Admin)\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPadAdmin.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.vcxproj\shell\MSBuild (Admin)\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPadAdmin.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.oxygene\shell\MSBuild (Admin)\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPadAdmin.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.shfbproj\shell\MSBuild (Admin)\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPadAdmin.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.ccproj\shell\MSBuild (Admin)\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPadAdmin.exe"" ""%1"""; Flags: uninsdeletekey deletekey
Root: HKCR; Subkey: SystemFileAssociations\.proj\shell\MSBuild (Admin)\command; ValueType: string; ValueData: """{app}\MSBuildLaunchPadAdmin.exe"" ""%1"""; Flags: uninsdeletekey deletekey

[Code]
// =======================================
// Testing if under Windows safe mode
// =======================================
function GetSystemMetrics( define: Integer ): Integer; external
'GetSystemMetrics@user32.dll stdcall';

Const SM_CLEANBOOT = 67;

function IsSafeModeBoot(): Boolean;
begin
  // 0 = normal boot, 1 = safe mode, 2 = safe mode with networking
 Result := ( GetSystemMetrics( SM_CLEANBOOT ) <> 0 );
end;

// ======================================
// Testing version number string
// ======================================
function GetNumber(var temp: String): Integer;
var
  part: String;
  pos1: Integer;
begin
  if Length(temp) = 0 then
  begin
    Result := -1;
    Exit;
  end;
	pos1 := Pos('.', temp);
	if (pos1 = 0) then
	begin
	  Result := StrToInt(temp);
	temp := '';
	end
	else
	begin
	part := Copy(temp, 1, pos1 - 1);
	  temp := Copy(temp, pos1 + 1, Length(temp));
	  Result := StrToInt(part);
	end;
end;

function CompareInner(var temp1, temp2: String): Integer;
var
  num1, num2: Integer;
begin
	num1 := GetNumber(temp1);
  num2 := GetNumber(temp2);
  if (num1 = -1) or (num2 = -1) then
  begin
    Result := 0;
    Exit;
  end;
  if (num1 > num2) then
  begin
	Result := 1;
  end
  else if (num1 < num2) then
  begin
	Result := -1;
  end
  else
  begin
	Result := CompareInner(temp1, temp2);
  end;
end;

function CompareVersion(str1, str2: String): Integer;
var
  temp1, temp2: String;
begin
	temp1 := str1;
	temp2 := str2;
	Result := CompareInner(temp1, temp2);
end;

function ProductRunning(): Boolean;
var
  ResultCode: Integer;
begin  
  ExtractTemporaryFile('processviewer.exe');
  if Exec(ExpandConstant('{tmp}\processviewer.exe'), '{#ConflictingApp}', '', SW_HIDE,
     ewWaitUntilTerminated, ResultCode) then
  begin
    Result := ResultCode > 0;
    Exit;    
  end;  
  
  MsgBox('failed to check process', mbError, MB_OK);
end;

function ProductRunningU(): Boolean;
var
  ResultCode: Integer;
begin  
  if Exec(ExpandConstant('{app}\processviewer.exe'), '{#ConflictingApp}', '', SW_HIDE,
     ewWaitUntilTerminated, ResultCode) then
  begin
    Result := ResultCode > 0;
    Exit;    
  end;  
  
  MsgBox('failed to check process.', mbError, MB_OK);
end;

function LaunchPadInstalled(): Boolean;
begin
  Result := RegKeyExists(HKEY_LOCAL_MACHINE,
	'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID}_is1');
end;

function ShellExtensionInstalled(): Boolean;
begin
  Result := RegKeyExists(HKEY_LOCAL_MACHINE,
	'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#ShellExtensionAppID}');
end;

function InitializeSetup(): Boolean;
var
  oldVersion: String;
  uninstaller: String;
  ResultCode, ErrorCode: Integer;
  compareResult: Integer;
begin
  if IsSafeModeBoot then
  begin
    MsgBox( 'Cannot install under Windows Safe Mode.', mbError, MB_OK);
    Result := False;
    Exit;
  end;

  if (not RegKeyExists(HKLM, 'Software\Microsoft\.NETFramework\policy\v2.0')) then
  begin
    if (not RegKeyExists(HKLM, 'Software\Microsoft\.NETFramework\policy\v4.0')) then
    begin
      MsgBox('{#MyAppName} needs the Microsoft .NET Framework 2.0 or 4.0 to be installed', mbInformation, MB_OK);
      Result := False;
      Exit;
    end;
  end;

  while ProductRunning do
  begin
    if MsgBox( '{#ConflictingApp} is running. Click Yes to shut it down and continue installation, or click No to exit.', mbConfirmation, MB_YESNO ) = IDNO then
    begin
      Result := False;
      Exit;
    end;

    Exec('cmd.exe', '/C "taskkill /F /IM {#ConflictingProcess}"', '', SW_HIDE,
     ewWaitUntilTerminated, ResultCode);
  end;

  if not LaunchPadInstalled then
  begin
    Result := True;
    Exit;
  end;

  RegQueryStringValue(HKEY_LOCAL_MACHINE,
    'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID}_is1',
    'DisplayVersion', oldVersion);
  compareResult := CompareVersion(oldVersion, '{#MyAppVersion}');
  if (compareResult > 0) then
  begin
    MsgBox('Version ' + oldVersion + ' of {#MyAppName} is already installed. It is newer than {#MyAppVersion}. This installer will exit.',
	  mbInformation, MB_OK);
    Result := False;
    Exit;
  end
  else if (compareResult = 0) then
  begin
    if (MsgBox('{#MyAppName} ' + oldVersion + ' is already installed. Do you want to repair it now?',
	  mbConfirmation, MB_YESNO) = IDNO) then
	begin
	  Result := False;
	  Exit;
    end;
  end
  else
  begin
    if (MsgBox('{#MyAppName} ' + oldVersion + ' is already installed. Do you want to override it with {#MyAppVersion} now?',
	  mbConfirmation, MB_YESNO) = IDNO) then
	begin
	  Result := False;
	  Exit;
    end;
  end;
  // remove old version
  RegQueryStringValue(HKEY_LOCAL_MACHINE,
	'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppID}_is1',
	'UninstallString', uninstaller);
  ShellExec('runas', uninstaller, '/SILENT', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode);
  if (ErrorCode <> 0) then
  begin
	MsgBox( 'Failed to uninstall {#MyAppName} version ' + oldVersion + '. Please restart Windows and run setup again.',
	 mbError, MB_OK );
	Result := False;
	Exit;
  end;

  Result := True;
end;

function InitializeUninstall(): Boolean;
var
  ResultCode: Integer;
begin
  if IsSafeModeBoot then
  begin
    MsgBox( 'Cannot uninstall under Windows Safe Mode.', mbError, MB_OK);
    Result := False;
    Exit;
  end;

  while ProductRunningU do
  begin
    if MsgBox( '{#ConflictingApp} is running. Click Yes to shut it down and continue installation, or click No to exit.', mbConfirmation, MB_YESNO ) = IDNO then
    begin
      Result := False;
      Exit;
    end;

    Exec('cmd.exe', '/C "taskkill /F /IM {#ConflictingProcess}"', '', SW_HIDE,
     ewWaitUntilTerminated, ResultCode)
  end;
end;
