## What is ResellerLoungeMe ? 
ResellerLoungeMe is a web application where you can find the list of lounges for the selected airport and buy a ticket to have a meal there with extra benefits.
In the application, UI and backend client is implemented with .Net Core.

## Things you must have
- .Net 5.0 or later
- Visual Studio 2019
- Docker

## Run the app locally

Follow these steps to get your development environment set up:
1. Clone the repository
2. At the root directory, restore required packages by running:
```csharp
dotnet restore
```
3. Next, build the solution by running:
```csharp
dotnet build
```
4. Next, within the ResellerLoungeMe.Web directory, launch the backend by running:
```csharp
dotnet run
```
5. Launch http://localhost:5000/ in your browser to view the Web UI.


## Deployment

### Contunious Deployment

Things are deployed automatically when we merge things into the `master` branch. Pipelines are implemented in azure-pipeline yaml file.

### Manual Deployment
Build the dockerfile in the project directory
```docker build -t ulvilacinov/resellerloungeme .```

Push the build to docker hub by running following command 
```docker push ulvilacinov/resellerloungeme:latest```

Restart the service in the container on Azure. It will pull the latest docker image from docker hub and deploy.

## Structure of Project

![alt text](/backendStructure.jpeg?raw=true "Backend Structure")

### The code of the application divided by 4 project;

* Core - Keeps the data transfer objects for working with adapters
* Application - Handles the service layer with view models and utility classes which can be used in services. 
* Infrastructure -  Make the connection to the backend to fetch the data via adapters
* Web - Connect the backend with user inteface

## Test

All unit tests are implemented for Service layer. 

## Things to do:

- Add new environments on Azure for Testing and Development.
- Implement unit tests for controller and adapter layers.
- Implement integration tests.
- Cache the airports and lounges with a day expire time

























