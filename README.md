# GroupShareKit - GroupShare Rest API Client Library for .NET 
[![NuGet Stats](https://img.shields.io/nuget/v/groupsharekit.svg)](https://www.nuget.org/packages/GroupShareKit)
[![Build Status](https://dev.azure.com/sdl/GroupShareKit/_apis/build/status/sdl.groupsharekit.net)](https://dev.azure.com/sdl/GroupShareKit/_build/latest?definitionId=808)

GroupShareKit is a client library targeting .NET 4.6 and above that provides an easy way to interact with [GroupShare Rest API](http://gs2017dev.sdl.com:41234/documentation/api/index#/)

There are, currently, 2 versions:
 * GroupShareKit
 * GroupShareKit-2017

## Usage examples

Get all users available in Groupshare.

```c#
var groupShareClient = await GroupShareClient.AuthenticateClient(userName,
                password,
                new Uri("http://yourgroupshareaddress"),
                GroupShareClient.AllScopes);

var users = await groupShareClient.User.GetAllUsers();

foreach (var user in users)
{
    Console.WriteLine(user.DisplayName +" loves Groupshare!");
}
```
## Supported platforms

* .NET 4.6.1 (Desktop / Server)
* .NET Core 1.0
* Mono 4.6
* Windows 10 Store Apps
* Xamarin.iOS 10 
* Xamarin.Android 7
* GroupShare 2017
* GroupShare 2020

## Getting started

GroupShareKit is available on NuGet: 
* GroupShareKit (https://www.nuget.org/packages/GroupShareKit/).
* GroupShareKit-2017 (https://www.nuget.org/packages/GroupShareKit-2017/).

```
Install-Package GroupShareKit
Install-Package GroupShareKit-2017
```

## Documentation

Please see http://gs2017dev.sdl.com:41234/documentation/api/index#/ for details about the GroupShare Rest API.
Please see http://gs2017dev.sdl.com:41235/docs/ui/index#/ for details about the Translation Memory Service.

## Build

GroupShareKit is a single assembly designed to be easy to deploy anywhere. If you prefer to compile it yourself, you'll need:

*Visual Studio 2017
*Windows 10 to build and test windows store projects

To clone it locally click the "Clone in Desktop" button above or run the following git commands:

```
http://gs2017dev.sdl.com:41234/documentation/api/index#/
cd groupsharekit.net
.\build.cmd
```
## Contribute

You can clone this repository locally from GitHub using the "Clone in Desktop" 
button from the main project site, or run this command in the Git Shell:

`git clone git@github.com:sdl/groupsharekit.net.git`

If you want to make contributions to the project, 
[forking the project](https://help.github.com/articles/fork-a-repo) is the 
easiest way to do this. 

After doing that, run the `.\build.cmd` script at the root of the repository 
to ensure all the tests pass.

### Running integration tests

GroupShareKit has integration tests that access the GroupShare Rest API, but they must be 
configured before they will be executed.

**Note:** To run the tests, we highly recommend you create a test GroupShare
account (i.e., don't use your real GroupShare account) and a test organization
owned by that account. Then set the following environment variables:

`GROUPSHAREKIT_USERNAME` (set this to the test account's username)
`GROUPSHAREKIT_PASSWORD` (set this to the test account's password)
`GROUPSHAREKIT_TESTORGANIZATION` (set this to the test account's organization)
`GROUPSHAREKIT_SERVERNAME` (set this to your sql server name)
`GROUPSHAREKIT_BASEURI` (set this to the url of your GroupShare instance)
`GROUPSHAREKIT_BEARERID` (optional, set to additional BearerId added to requests. If not provided, default connection is used)

Once these are set, the integration tests will be executed both when 
running the IntegrationTests MSBuild target, and when running the 
Sdl.Community.GroupShareKit.Tests.Integration assembly through an xUnit.net-friendly test runner.

## Problems?

If you find an issue please visit the [issue tracker](https://github.com/sdl/groupsharekit.net/issues) and report the issue. 

Please be kind and search to see if the issue is already logged before creating
a new one. If you're pressed for time, log it anyways.

When creating an issue, clearly explain

* What you were trying to do.
* What you expected to happen.
* What actually happened.
* Steps to reproduce the problem.

Also include any other information you think is relevant to reproduce the 
problem.

## Copyright and License

Copyright 2020 SDL plc.

Licensed under the [MIT License](https://github.com/sdl/groupsharekit.net/blob/master/LICENSE)
