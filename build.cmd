@echo off

"tools\nuget\nuget.exe" "install" "xunit.runner.console" "-OutputDirectory" "tools" "-ExcludeVersion"
"tools\nuget\nuget.exe" "install" "FAKE.Core" "-OutputDirectory" "tools" "-ExcludeVersion"

:Build
cls

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%1")

SET BUILDMODE="RELEASE"

IF NOT [%2]==[] (set BUILDMODE="%2")

if %TARGET%=="Default" (SET RunBuild=1)
if %TARGET%=="RunUnitTests" (SET RunBuild=1)
if %TARGET%=="RunIntegrationTests" (SET RunBuild=1)
if %TARGET%=="CreatePackages" (SET RunBuild=1)

if NOT "%RunBuild%"=="" (
"tools\FAKE.Core\tools\Fake.exe" "build.fsx" "target=BuildApp" "buildMode=%BUILDMODE%"
)

"tools\FAKE.Core\tools\Fake.exe" "build.fsx" "target=%TARGET%" "buildMode=%BUILDMODE%"

:Quit
exit /b %errorlevel%