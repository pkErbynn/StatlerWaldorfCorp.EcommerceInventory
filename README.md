## Service Discovery 

Demonstration of creating a resilient and discoverable microservices architecture using .NET 6, Steeltoe, and Eureka. 

This setup allows services to dynamically discover and communicate with each other, enhancing scalability and resilience.

*Using Netflix Eureka as broker/registry to register this inventory service.*

**Aim**: 
1. To allow this service to register itself and
2. To be dynamically discovered by other service at runtime to provide real-time inventory status

### Benefits:
- Provides high availability of the service
- Supports failover
- Provides load balancing

### Core Technologies Used
- Steeltoe Discovery library
- C# / .NET
- Docker
- Postman


## Setup
Demonstration of creating a resilient and discoverable microservices architecture using .NET 6, Steeltoe, and Eureka. 

This setup allows services to dynamically discover and communicate with each other, enhancing scalability and resilience.

#### 1. Setting Up Eureka Server
1. Run a Eureka server using Docker:

```bash
$ docker run -d --name eureka -p 8761:8761 netflixoss/eureka:1.1.147
```
**Why**: Eureka server act as our service registry. It allows services to register themselves and discover other services dynamically.

#### 2. Creating the Inventory Service
1. Create the Web API project
2. Add Steeltoe Discovery Client dependency to csproj

```c#
<ItemGroup>
  <PackageReference Include="Steeltoe.Discovery.ClientCore" Version="3.1.4" />
</ItemGroup>
```
*Why*: The Steeltoe Discovery Client package integrates Eureka with .NET applications, enabling service registration and discovery.

3. Configure Eureka in appsettings.json
```c#
{
  "eureka": {
    "client": {
      "serviceUrl": "http://localhost:8761/eureka/",
      "shouldRegisterWithEureka": true,
      "shouldFetchRegistry": false,
      "validate_certificates": false
    },
    "instance": {
      "appname": "inventory",
          "nonSecurePort": 5001,
          "port": 5001,
          "instanceId": "localhost:inventory:5001"
    }
  }
}
```
**Why**: This configuration specifies the Eureka server's URL and sets the application name, which Eureka uses to register and discover services.

#### 4. Configure the services and middleware in Program.cs:

```bash
...
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddControllers();
...
```
**Why**: This sets up the necessary configurations and middleware for the Inventory Service, including integrating Steeltoe Discovery Client for Eureka.

#### 5. Run `dotnet run` and access
```bash
GET http://localhost:5290/api/SKUStatus/{123}
```



