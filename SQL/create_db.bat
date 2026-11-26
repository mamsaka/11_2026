@echo off
setlocal
chcp 65001 >nul
pushd "%~dp0"

if not exist "logs\" mkdir "logs\"

rem
set "SQLITE=sqlite3"
if exist "%~dp0sqlite3.exe" (
    set "SQLITE=%~dp0sqlite3.exe"
) else if exist "%~dp0packages\sqlite3.exe" (
    set "SQLITE=%~dp0packages\sqlite3.exe"
)

if not exist "..\db" mkdir "..\db"
"%SQLITE%" "..\db\repair.db" ".read init_db.sql"
if errorlevel 1 (
    echo [ERROR] Не удалось создать БД. >> "logs\log.txt"
    echo Положите sqlite3.exe рядом с create_db.bat или добавьте его в PATH.
    popd
    exit /b 1
)
echo [OK] База создана: %~dp0..\db\repair.db >> "logs\log.txt"
popd
endlocal
