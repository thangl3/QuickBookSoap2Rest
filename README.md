# QuickBookSoap2Rest

A simple library written by C# ASP .NetCore web API application that communicates with QuickBooks via QBWebConnector

## Installation

Use `Package Manager` to install it.

```bash
Install-Package QuickBookSoap2Rest -Version 1.1.0
```

Or `.NET cli`

```bash
dotnet add package QuickBookSoap2Rest --version 1.1.0
```

Or `PackageReference `

```bash
<PackageReference Include="QuickBookSoap2Rest" Version="1.1.0" />
```

Or `Paket CLI`

```bash
paket add QuickBookSoap2Rest --version 1.1.0
```

## Usage

There are two interfaces for handling `Request` of .Net core API

`IWCWebMethod` and `IWCWebMethodAsync`

Implement from `IWCWebMethod` if you just want to a synchronous function
Implement from `IWCWebMethodAsync`if you just want to an asynchronous function

Example

- Implement `IWCWebMethod`

```csharp
using QuickBookSoap2Rest.Interfaces;

// ...

public class WCRequestHandler : IWCWebMethod
{
    // must implement all methods supporting WC Connector
    // In each method, you can write you business and return the type method need

    public string serverVersion(string strVersion)
    {
        return _config.GetValue<string>("App:Version");
    }

    public string clientVersion(string strVersion)
    {
        // maybe save client version or check for update
        return null;
    }

    // ...
}
```

- Implement `IWCWebMethodAsync`

```csharp
using QuickBookSoap2Rest.Interfaces;

// ...

public class WCRequestHandlerAsync : IWCWebMethodAsync
{
    // must implement all methods supporting WC Connector
    // In each method, you can write you business and return the type method need

    public async Task<string> serverVersionAsync(string strVersion)
    {
        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        var serviceVersion = assembly.GetName().Version.ToString();

        return serviceVersion;
    }

    public async Task<string> clientVersionAsync(string strVersion)
    {
        // maybe save client version or check for update
        return null;
    }

    // ...
}
```

Now in your Api Controller call `WCController` and passing WC handler to it.

Example:

```csharp

using Microsoft.AspNetCore.Mvc;
using QuickBookSoap2Rest;
using QuickBookSoap2Rest.Interfaces;

[Route("api")]
[ApiController]
[Produces("text/xml")]
public class SyncController : ControllerBase
{
    [HttpPost]
    public Task<XElement> Handle()
    {
        var wcController = new WCController(new WCRequestHandlerAsync());

        // Request from AspNetCore <Microsoft.AspNetCore.Http.HttpRequest> Request
        // a property of Controller Base
        return wcController.HandleAsync(Request);
    }
}


```


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
