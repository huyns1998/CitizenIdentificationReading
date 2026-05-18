@echo off
set VERSION=1.0.0
set APP_ID=CCCDScannerPro
set APP_TITLE=CCCD Scanner Pro
set SQUIRREL_PATH=%USERPROFILE%\.nuget\packages\clowd.squirrel\2.11.1\tools\Squirrel.exe
set PUBLISH_DIR=.\publish
set RELEASE_DIR=.\Releases

if not exist "%SQUIRREL_PATH%" (
    set SQUIRREL_PATH=.\packages\Clowd.Squirrel.2.11.1\tools\Squirrel.exe
)

echo [1/3] Dang build va publish ung dung...
dotnet publish -c Release -r win-x64 --self-contained true -o %PUBLISH_DIR%

if errorlevel 1 (
    echo [ERRO] Build that bai!
    pause
    exit /b 1
)

echo [2/3] Dang dong goi voi Squirrel...
"%SQUIRREL_PATH%" pack --packId %APP_ID% --packVersion %VERSION% --packDir %PUBLISH_DIR% --packTitle "%APP_TITLE%" --releaseDir %RELEASE_DIR% --allowUnaware

if errorlevel 1 (
    echo [ERRO] Squirrel pack that bai!
    pause
    exit /b 1
)

if exist "%RELEASE_DIR%\%APP_ID%Setup.exe" (
    echo [RMN] Dang doi ten file Setup thanh "CCCD Scanner Pro Setup.exe"...
    ren "%RELEASE_DIR%\%APP_ID%Setup.exe" "CCCD Scanner Pro Setup.exe"
)

echo [3/3] Hoan thanh! Cac file da co trong thu muc %RELEASE_DIR%
pause