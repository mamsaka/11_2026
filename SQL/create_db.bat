@echo off
setlocal
chcp 65001 >nul
pushd "%~dp0"

set "LOG=logs\log.txt"
if not exist "logs\" mkdir "logs\"

rem
>> "%LOG%" echo [%date% %time%] === create_db start ===

set "SQLITE=sqlite3"
if exist "%~dp0sqlite3.exe"          set "SQLITE=%~dp0sqlite3.exe"
if exist "%~dp0packages\sqlite3.exe" set "SQLITE=%~dp0packages\sqlite3.exe"

if not exist "..\db" mkdir "..\db"
"%SQLITE%" "..\db\repair.db" ".read init_db.sql" >> "%LOG%" 2>&1
if errorlevel 1 (
    >> "%LOG%" echo [%date% %time%] [ERROR] sqlite завершился с ошибкой
    echo [ERROR] Не удалось создать БД. Смотреть %LOG%
    popd & endlocal & exit /b 1
)

>> "%LOG%" echo [%date% %time%] [OK] База создана: %~dp0..\db\repair.db
echo [OK] База создана: %~dp0..\db\repair.db
popd
endlocal