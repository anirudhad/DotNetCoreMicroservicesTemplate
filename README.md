# DotNetCore Microservices Template v1.0
Building Generic Framework for rapid development for .Net Core Microservices using MongoDB Atlas
Firstly, I ended up creating multiple microservices with .Net Core and recently .Net 6.0 which were serving more or less the same purpose where it struck to me if we had a generic framework that would enable me to create the basic microservices very rapidly probably in few minutes and if I had a framework supporting the same. So I ended up creating this framework that serves the purpose.

Keeping in mind that the framework should be robust enough and also scalable and extendable in case we need to implement complex logic then it should allow me to do it.

So lets start….

**Step 1: Create your MongoDB Atlas Account**

Click this link for MongoDB Atlas, select try free and sign up providing your information.

No need to create a new collection explicitly as it would be directly created once the framework is in place and can be configured in the appsetting.json file.
Select the Network Access and add the IP Address as 0.0.0.0/0 which shall allow to connect to the MongoDB Collection from any IP Address.

Now get the valid connection string for MongoDB to be added in the appsettings.json file in the framework

**Step 2: Create a new Project in Visual Studio 2022 Community Edition**

Create a new ASP.NET Core WebAPI Project in Visual Studio 2022 Community Edition

  **->** Name the project as **DotNetCoreMicroservicesTemplate**
  
  **->** Click Next and keep the default settings as-is
  
  **->** Create the project by clicking on Create button
  
**Step 3: Start building the needed structure to create the framework**

  **->** Create desired folder structure
  
  **->** There would be a folder **Controllers** by default but we need to create the others like **Data**, **Entities** & **Repositories**
  
  **->** Add a Database Context to the project for which we first need to define the Interface to implement the Database Context and before that configure valid values in appsettings.development.json
  
  **->** Add a BaseEntity.cs abstract class
  
  **->** Any new entity that we would add in the code in future would be inherited from this abstract class.
  
  **->** Create IBaseRepository Interface to define the methods for Base Repository
  
  **->** Create a BaseRepository class implemented from IBaseRepository Interface
  
  **->** This base repository class has all the action methods implementation with CRUD operation for any new entity that this base class would take shape at runtime.
  
  **->** Create a BaseController which will prove to be foundation of the new entity controller we would want to have in future
  
Here the IBaseRepository & Base Controller is of type T which is generic where T can be any class. So when we create a new entity and implement the BaseRepository/BaseController to it the BaseRepository/BaseController will act as the entity class.

Refer this [link](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics) for more information on Generics in .Net

**->** Now the last bit before we have the framework ready to be used is to update the Program.cs file with injecting relevant dependencies needed for the code to work

That's it….we now have the generic framework ready to rapidly develop any .Net Core Microservice we desire to with only performing 3 steps.

For more details please follow the blog [here](https://medium.com/@dhaneshwar.anirudha/building-generic-framework-for-rapid-development-for-net-core-microservices-using-mongodb-atlas-f1e036099add) 





