@echo off
setlocal
chcp 65001 >nul
pushd "%~dp0"
if not exist "..\db" mkdir "..\db"
sqlite3 "..\db\repair.db" ".read init_db.sql"
if errorlevel 1 (
    echo [ERROR] Не удалось создать БД.
    popd
    exit /b 1
)
echo [OK] База создана: %~dp0..\db\repair.db
popd
endlocal
