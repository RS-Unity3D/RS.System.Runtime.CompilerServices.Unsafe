@echo off
setlocal

set CSC=
set DLL_PATH=bin\Debug

rem Use .NET 4.0 C# compiler for testing
if exist "C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe" (
  set CSC="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
  goto found_csc
)

if exist "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" (
  set CSC="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
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
