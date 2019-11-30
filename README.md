## Get Started

1. **Install [.NET Core SDK v3.0.0 ](https://dotnet.microsoft.com/download/dotnet-core/3.0)** or newer.
2. **Install [Visual Studio Community 2019](https://visualstudio.microsoft.com/vs/community/).**
3. **Clone [JobNetworkAPI](https://github.com/zoharngo/JobNetworkAPI)**
4. **Clone [Client React App](https://github.com/zoharngo/jobnetwork)**

## Create DB and Perform Migration:
1. **Make sure the config.json (JobNetworkAPI/config.json) connectionString setup to one of your local db instace** - 
***default connection string configured as follow:***

`server=(localdb)\\ProjectsV13;Database=jobsDb;Integrated Security=true;MultipleActiveResultSets=true;`

2. **Open commandLine inside the project root `JobNetworkAPI` folder:** 
3. **Install dotnet-ef** -`dotnet tool install --version 3.0.0 dotnet-ef -g`
4. **update database** - `dotnet ef database update`
5. **Create migrations** - `dotnet ef migrations add InitalDb`
6. **Re-run update database** - `dotnet ef database update`

**(Ignore warnning 
***"The EF Core tools version '3.0.0' is older than that of the runtime '3.0.1'. Update the tools for the latest features and bug fixes.***" => There is [open issue](https://github.com/aspnet/EntityFrameworkCore/issues/18977))** 

## Start Server Application:
1. **Open commandLine inside project root folder** - `JobNetworkAPI`

2. **Run** - `dotnet run` - API Server listen to port 5000.

**server startup output example:**

`info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
  info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001   
  info: Microsoft.Hosting.Lifetime[0]`
  
****Alternately you can launch server in debug mode from visual studio*** 

**(In debug mode API Server will listen to port 8888).** 

## Start Client Application:
4. **Refer to [README.md](https://github.com/zoharngo/jobnetwork/blob/master/README.md)**

