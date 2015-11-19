# GroupShareKit - GroupShare Rest API Client Library for .NET [![Build status](https://ci.appveyor.com/api/projects/status/7ckqg155ap8rknls?svg=true)](https://ci.appveyor.com/project/cromica/groupsharekit-net)

GroupShareKit is a client library targeting .NET 4.5 and above that provides an easy way to interact with [GroupShare Rest API](http://sdldevelopmentpartners.sdlproducts.com/documentation/api)

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

* .NET 4.5 (Desktop / Server)
* Windows 8 / 8.1 /10 Store Apps

## Getting started

GroupShareKit is available on [NuGet](https://www.nuget.org/packages/GroupShareKit/).

```
Install-Package GroupShareKit
```

## Documentation

Please see http://sdldevelopmentpartners.sdlproducts.com/documentation/api for details about the GroupShare Rest API.

## Build

GroupShareKit is a single assembly designed to be easy to deploy anywhere. If you prefer to compile it yourself, you'll need:

*Visual Studio 2015
*Windows 8.1 or higher to build and test windows store projects

To clone it locally click the "Clone in Desktop" button above or run the following git commands:

```
https://github.com/sdl/groupsharekit.net.git
cd groupsharekit.net
.\build.cmd
```

## Copyright and License

Copyright 2015 SDL plc.

Licensed under the [MIT License](https://github.com/sdl/groupsharekit.net/blob/master/LICENSE)
