# groupsharekit - GroupShare API Client Library for .NET [![Build status](https://ci.appveyor.com/api/projects/status/7ckqg155ap8rknls?svg=true)](https://ci.appveyor.com/project/cromica/groupsharekit-net)

Groupsharekit is a client library targeting .NET 4.5 and above that provides an easy way to interact with [GroupShare Rest API](http://sdldevelopmentpartners.sdlproducts.com/documentation/api)

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
