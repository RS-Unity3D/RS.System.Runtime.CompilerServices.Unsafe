@echo off
setlocal enabledelayedexpansion

set ILASM=
set IL_FILE=System.Runtime.CompilerServices.Unsafe.il
set DLL_NAME=RS.System.Runtime.CompilerServices.Unsafe.dll

echo Building RS.System.Runtime.CompilerServices.Unsafe for .NET 4.0
echo.

rem Use .NET 4.0 ILASM for .NET 4.0 target
if exist "C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe" (
  set ILASM="C:\Windows\Microsoft.NET\Framework\v4.0.30319\ilasm.exe"
  goto found_ilasm
)

if exist "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ilasm.exe" (
  set ILASM="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\ilasm.exe"
  goto found_ilasm
)

:found_ilasm
if not defined ILASM (
  echo ERROR: Cannot find ilasm.exe
  exit /b 1
)

echo Using ILASM: %ILASM%
echo.

if "%1"=="" goto build_all
if "%1"=="debug" goto build_debug
if "%1"=="release" goto build_release
if "%1"=="all" goto build_all
goto usage

:usage
echo Usage: Build.bat [debug|release|all]
exit /b 0

:build_all
call :build_debug
if errorlevel 1 goto error
call :build_release
if errorlevel 1 goto error
goto success

:build_debug
echo Building Debug version...
if not exist "bin\Debug" mkdir "bin\Debug"
%ILASM% /dll /debug /out:"bin\Debug\%DLL_NAME%" "%IL_FILE%"
if errorlevel 1 goto error
echo Debug build completed: bin\Debug\%DLL_NAME%
goto end

:build_release
echo Building Release version...
if not exist "bin\Release" mkdir "bin\Release"
%ILASM% /dll /optimize /out:"bin\Release\%DLL_NAME%" "%IL_FILE%"
if errorlevel 1 goto error
echo Release build completed: bin\Release\%DLL_NAME%
goto end

:error
echo.
echo ERROR: Build failed!
exit /b 1

:success
echo.
echo SUCCESS: All builds completed!
goto end

:end
endlocal
