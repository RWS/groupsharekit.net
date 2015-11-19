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
