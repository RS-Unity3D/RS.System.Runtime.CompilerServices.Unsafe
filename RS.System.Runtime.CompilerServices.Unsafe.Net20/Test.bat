@echo off
setlocal

set CSC=
set DLL_PATH=bin\Debug

rem Use .NET 2.0 C# compiler for testing
if exist "C:\Windows\Microsoft.NET\Framework\v2.0.50727\\csc.exe" (
  set CSC="C:\Windows\Microsoft.NET\Framework\v2.0.50727\\csc.exe"
  goto found_csc
)

if exist "C:\Windows\Microsoft.NET\Framework\v2.0.50727\\csc.exe" (
  set CSC="C:\Windows\Microsoft.NET\Framework\v2.0.50727\\csc.exe"
  goto found_csc
)

:found_csc
if not defined CSC (
  echo ERROR: Cannot find csc.exe
  exit /b 1
)

echo Compiling test program...
echo Using C#: %CSC%
echo.

%CSC% /unsafe+ /out:FullTest.exe /reference:"%DLL_PATH%\RS.System.Runtime.CompilerServices.Unsafe.dll" FullTest.cs

if errorlevel 1 (
  echo Compilation failed!
  exit /b 1
)

echo.
echo Running test program...
echo.
FullTest.exe
