;------------------------------------------------------------------------------
;   Определяем некоторые константы
;------------------------------------------------------------------------------

; Имя приложения
#define   Name       GetStringFileInfo("..\..\..\MindMapping\bin\Debug\MindMapping.exe", "ProductName")
; Версия приложения
#define   Version    GetStringFileInfo("..\..\..\MindMapping\bin\Debug\MindMapping.exe", "FileVersion")
; Фирма-разработчик
#define   Publisher  GetFileCompany("..\..\..\MindMapping\bin\Debug\MindMapping.exe")
; Имя исполняемого модуля
#define   ExeName    "MindMapping.exe"

[Setup]

; Уникальный идентификатор приложения, 
;сгенерированный через Tools -> Generate GUID
AppId={{1333A9A5-5A27-49B5-A230-26AE27057ED9}}

; Прочая информация, отображаемая при установке
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}

; Путь установки по-умолчанию
DefaultDirName={pf}\{#Name}
; Имя группы в меню "Пуск"
DefaultGroupName={#Name}

; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir=..\..\..\Setup
OutputBaseFileName={#Name}_{#Version}

;SetupIconFile=F:\Installed Programs\Artua-Mac-Activity-Monitor.ico

; Параметры сжатия
Compression=lzma
SolidCompression=yes

[Languages]

Name: "english"; MessagesFile: "compiler:Default.isl"; 
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; 


;------------------------------------------------------------------------------
;   Опционально - некоторые задачи, которые надо выполнить при установке
;------------------------------------------------------------------------------
[Tasks]

Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked


;------------------------------------------------------------------------------
;   Файлы, которые надо включить в пакет установщика
;------------------------------------------------------------------------------
[Files]

Source: "..\..\..\MindMapping\bin\Debug\MindMapping.exe"; DestDir: "{app}"; Flags: ignoreversion

Source: "..\..\..\MindMapping\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

;Source: "dotNetFx40_Full_x86_x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsDotNetDetected

;------------------------------------------------------------------------------
;   Указываем установщику, где он должен взять иконки
;------------------------------------------------------------------------------ 
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon


;------------------------------------------------------------------------------
;   Секция кода включенная из отдельного файла
;------------------------------------------------------------------------------
;#include "dotnet.pas"
[Code]
function GetUninstallString: string;
var
  sUnInstPath: string;
  sUnInstallString: String;
begin
  Result := '';
  sUnInstPath := ExpandConstant('Software\Microsoft\Windows\CurrentVersion\Uninstall\{{1333A9A5-5A27-49B5-A230-26AE27057ED9}_is1'); //Your App GUID/ID
  sUnInstallString := '';
  if not RegQueryStringValue(HKLM, sUnInstPath, 'UninstallString', sUnInstallString) then
    RegQueryStringValue(HKCU, sUnInstPath, 'UninstallString', sUnInstallString);
  Result := sUnInstallString;
end;

function IsUpgrade: Boolean;
begin
  Result := (GetUninstallString() <> '');
end;

function InitializeSetup: Boolean;
var
  V: Integer;
  iResultCode: Integer;
  sUnInstallString: string;
begin
  Result := True; // in case when no previous version is found
  if RegValueExists(HKEY_LOCAL_MACHINE,'Software\Microsoft\Windows\CurrentVersion\Uninstall\{1333A9A5-5A27-49B5-A230-26AE27057ED9}_is1', 'UninstallString') then  //Your App GUID/ID
  begin
    V := MsgBox(ExpandConstant('Hey! An old version of app was detected. Do you want to uninstall it?'), mbInformation, MB_YESNO); //Custom Message if App installed
    if V = IDYES then
    begin
      sUnInstallString := GetUninstallString();
      sUnInstallString :=  RemoveQuotes(sUnInstallString);
      Exec(ExpandConstant(sUnInstallString), '', '', SW_SHOW, ewWaitUntilTerminated, iResultCode);
      Result := True; //if you want to proceed after uninstall
                //Exit; //if you want to quit after uninstall
    end
    else
      Result := False; //when older version present and not uninstalled
  end;
end;

[Run]
;------------------------------------------------------------------------------
;   Секция запуска после инсталляции
;------------------------------------------------------------------------------
;Filename: {tmp}\dotNetFx40_Full_x86_x64.exe; Parameters: "/q:a /c:""install /l /q"""; Check: not IsDotNetDetected; StatusMsg: Microsoft Framework 4.0 is installed. Please wait...