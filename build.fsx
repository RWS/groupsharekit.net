#r @"tools/FAKE.Core/tools/FakeLib.dll"

open Fake
open System

let authors = ["Sdl Community"]

//project details
let projectName = "GroupShareKit"
let projectDescription="A GroupShare API client library for .NET"
let projectSummary = projectDescription

//directories
let buildDir = "./Sdl.Community.GroupShareKit/bin"
let testResultsDir ="./testresults"
let packagingRoot = "./packaging"
let packagingDir = packagingRoot @@ "groupsharekit"

let releaseNotes = 
    ReadFile "ReleaseNotes.md"
    |> ReleaseNotesHelper.parseReleaseNotes

let buildMode = getBuildParamOrDefault "buildMode" "Release"

MSBuildDefaults <-{
    MSBuildDefaults with 
        ToolsVersion = Some "14.0"
        Verbosity = Some MSBuildVerbosity.Minimal
}

Target "Clean"(fun _ ->
    CleanDirs[buildDir;testResultsDir;packagingRoot;packagingDir]
)

open Fake.AssemblyInfoFile
open Fake.Testing

Target "AssemblyInfo" (fun _ ->
    CreateCSharpAssemblyInfo "./SolutionInfo.cs"
      [ Attribute.Product projectName
        Attribute.Version releaseNotes.AssemblyVersion
        Attribute.FileVersion releaseNotes.AssemblyVersion
        Attribute.ComVisible false ]
)

let setParams defaults = {
    defaults with
        ToolsVersion = Some("14.0")
        Targets = ["Build"]
        Properties =
            [
                "Configuration", buildMode
            ]
    }

Target "BuildApp" (fun _ ->
    build setParams "./Sdl.Community.GroupShareKit.sln"
        |> DoNothing
)

Target "CreateGroupSharePackage" (fun _ ->
    let portableDir = packagingDir @@ "lib/portable-net45+wp80+win+wpa81/"
    CleanDirs [portableDir]

    CopyFile portableDir (buildDir @@ "Release/Portable/Sdl.Community.GroupShareKit.dll")
    CopyFile portableDir (buildDir @@ "Release/Portable/Sdl.Community.GroupShareKit.XML")
    CopyFile portableDir (buildDir @@ "Release/Portable/Sdl.Community.GroupShareKit.pdb")
    CopyFiles packagingDir ["LICENSE"; "README.md"; "ReleaseNotes.md"]

    NuGet (fun p -> 
        {p with
            Authors = authors
            Project = projectName
            Description = projectDescription
            OutputPath = packagingRoot
            Summary = projectSummary
            WorkingDir = packagingDir
            Version = releaseNotes.AssemblyVersion
            ReleaseNotes = toLines releaseNotes.Notes
            AccessKey = getBuildParamOrDefault "nugetkey" ""
            Publish = hasBuildParam "nugetkey" }) "groupsharekit.nuspec"
)

Target "Default" DoNothing

Target "CreatePackages" DoNothing

"Clean"
   ==> "AssemblyInfo"
   ==> "BuildApp"

RunTargetOrDefault "Default"