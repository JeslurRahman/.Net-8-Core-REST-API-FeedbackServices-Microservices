1. Introduction to Clean Architecture
   - Understanding the Fundamentals
   - Goals and Purpose of Clean Architecture
   - Tracing the History of Clean Architecture
   - Advantages and Benefits
   - Overview of the Clean Architecture Structure

2. Layers of Clean Architecture
   - Exploring the Different Layers
   - Discussion on the Importance of Each Layer
   - Emphasizing Testing in Clean Architecture

3. Deep Dive into Clean Architecture
   - Detailed Overview of the UI Project
   - In-depth Look at the API Project
   - Understanding the Core Project
   - Insights into the Infrastructure Project
   - Management of Shared Nuget Packages
   - Overview of Solution Structure

4. Technology Stack
   - Highlighting the Technology Stack Used
   - Incorporating SOLID Principles
   - Utilizing Clean Architecture References

5. Prerequisites and Development Tools
   - Gathering the necessary tools for development
   - Ensuring you have a suitable environment

6. Setting Up Your Azure DevOps Project
   - Creating a new project for your service
   - Establishing a new Git repository
   - Cloning the source code from the repository
   - Opening projects in admin mode
   - Organizing folders and creating source and test directories

7. Creating Components for Your Project
   - Developing a .NET Core 5 Web API
   - Designing class libraries for the Core logic
   - Building class libraries for the Infrastructure layer
   - Creating Xunit projects for API, Core, and Infrastructure
   - Pushing your code into the Git repository
   - Pulling the code from the repository
   - Committing changes to the remote Git repository
   - Setting up feature branches for development

8. Structuring Folders and Files
   - Establishing a structured folder hierarchy for the API
   - Defining folders and files for the Core components
   - Creating the necessary structure for Infrastructure
   - Incorporating project references within the solution
   - Adding external references using NuGet packages

9. Important Files and Elements
   - Creating the .gitignore file
   - Setting up the .gitattribute file
   - Adding the DbContext class for database interactions
   - Introducing database entities
   - Developing Core Dto models
   - Incorporating constants for consistency
   - Defining interfaces
   - Implementing Repository and Service classes
   - Crafting Controller classes for API endpoints
10. *Automapper*
   - Installing the NuGet Package
   - Configuring Automapper
   - Creating a Mapper Profile
   - Using Automapper in Your Project
   - Reversing Mapping
   - Best Practices for Using Automapper

11. *API Request Flow and EF In Memory Database*
   - Discussing the Flow of API Requests
   - Utilizing EF In Memory Database
   - Cleaning Up the WeatherForecastController

12. *Program Class Configurations and .NET Generic Host*
   - Understanding Logging Configuration
   - Exploring the .NET Generic Host
   - Introducing ASP.NET Core Web Host & Advantages

13. *Creating Essential Components*
   - Crafting ApiConstants.cs
   - Developing AppSettings.cs
   - Crafting ServiceDescription.md File
   - Creating Service Extensions

14. *Configuring Startup Class*
   - Step-by-Step Cors Configuration
   - Handling Environment Configuration
   - Implementing Error Handling
   - Routing Setup
   - Configuring Dependency Injection
   - Middleware Configuration

15. *Logging and Security*
   - Setting Up Logging Using NLog
   - Configuring Dependency Injection
   - Implementing Swagger for API Documentation
   - Adding Routing
   - Handling Exceptions
   - Local and Environment-Based Exception Handling
   - Enhancing Security with HSTS (HTTP Strict Transport Security Protocol)

17. *API Versioning and Swagger Integration*
   - Installing the API Versioning Package
   - Configuring API Versioning
   - Applying Versioning to APIs
   - Adding Versioning to Swagger
   - Incorporating XML Comments for API Documentation
   - Hiding Properties in Swagger
   - Enabling JWT Bearer Authorization (Future Steps)
   - Lowercasing API URLs for Consistency

18. *Azure Key Vault*
   - Setting Up Azure Key Vault Service (aklab-kv-dev)
   - Configuring Access Policies (feedbackservice-kv)
   - Utilizing Managed Identities for Azure Resources
   - Creating Keys in Azure Key Vault
   - Installing Key Vault NuGet Packages in Your Project
   - Configuring Key Vault in program.cs
   - Reading Key Vault Values from Your API
   - Caching Key Vault Values
   - Exploring Configuration Options
   - DefaultAzureCredential Method Usage
   - ClientSecretCredential Method Usage
   - Bypassing Key Vault Locally
   - Employing Key Name Prefix
   - Incorporating Key Vault Name in AppSettings
   - Registering a New Azure AD App with a Secret
   - Keyvault-connector: Certificates & Secrets
   - Keyvault-connector: API Permissions
   - Troubleshooting & Fixing Common Errors
     - Access Denied Issues
     - Permissions for Secrets List on Key Vault

19. *Health Check*
   - Introduction to Health Check Concept
   - Installing Health Check NuGet Packages
   - Basic Health Check Configuration in Startup.cs
   - Adding SQL Database Health Check
   - Incorporating Remote Health Check
   - Implementing Memory Health Check
   - Adding UrlGroup Health Check
   - Introducing Healthcheck-ui
   - Customizing Default Health Check UI
   - Future Additions
     - Redis Health Check
     - Azure Storage Health Check
     - Azure Key Vault Health Check
     - Azure DocumentDb Health Check
     - Kubernetes Health Check

20. *SQL Server Database Project*
   - Establishing a New Git Repository for the Database Project
   - Cloning the Git Repository
   - Managing Files with .gitignore and .gitattribute
   - Creating a SQL Server Database Project
   - Structuring the Database Project's Folders
   - Crafting Files for Tables, Stored Procedures, and Lookup Data
   - Crafting Post Deployment Script Files
   - Crafting Pre Deployment Script File
   - Writing a Script for Feedback Table with Primary Key
   - Scripting Lookup Data
   - Sample Change Script File
   - Publishing SQL Database Locally
   - Committing Changes to Remote Git Repository

21. *Entity Framework CRUD Operations*
   - Discussing the Flow of API Requests
   - Installing NuGet Packages for Entity Framework Core
   - Setting Up Dependency Injection
   - Configuring Entity Framework Core DbContext
   - Creating Repository and Interface
   - Implementing Read Operation for the GetFeedbacks Endpoint
   - Implementing Read Operation for the GetFeedbackById Endpoint
   - Implementing Create Operation for the CreateFeedback Endpoint
   - Implementing Delete Operation for the DeleteFeedback Endpoint
   - Implementing Update Operation for the UpdateFeedback Endpoint
   - Mapping Database Entities to DTO Models
   - Adding Exception Handling in the Service Class
   - Enhancing Swagger Documentation at Endpoint Level
   - Employing Automapper for Reverse Mapping in Create Endpoint
   - Testing API Endpoints Using Swagger
   - Discussing Basic API Best Practices

22. *Azure App Service*
   - Explaining the Azure Portal Account Setup Process
   - Different Approaches to Creating Azure App Service
   - Establishing an Azure Resource Group: aklab-rg-dev
   - Creating an Azure App Service Plan: aklab-aspln-dev
   - Setting Up an Azure App Service: feedback-api-dev
   - Creating an Azure Key Vault: aklab-kv-dev
   - Deploying and Publishing the API to App Service
   - Diagnosing and Troubleshooting API Issues After Publishing
   - Generating a Managed Identity
   - Granting Key Vault Access to the API
   - Including the Missing API Swagger XML File
   - Exploring Advanced Tools in the App Service (Kudu Portal)
   - Locating App Settings in Azure
   - Navigating to Event Logs in Azure
   - Identifying Site Files in Azure
   - Launching Swagger URL
   - Activating App Service Logs for Log Streaming Access
   - Configuring Azure App Service Logging in program.cs
   - Displaying Supported Runtime Versions
   - Identifying the Current Runtime Version
   - Modifying Runtime Version
   - Accessing Environment Variables
   - Enabling Detailed Exceptions Page
   - Gaining Access to Diagnostic Logs

23. *Azure SQL Database*
   - Creating a SQL Database Server: aklab-sqlserver-dev
   - Establishing a SQL Database: feedbacksdev
   - Publishing a Database from Visual Studio 2019 to Azure SQL
   - Obtaining the Public IP Address of Your Laptop
   - Configuring a SQL Server Firewall Rule
   - Adapting the Target Platform of the SQL Database Project

24. *Azure DevOps*
   - Delving into Feedback Service Deployment View
   - Discussion on Continuous Integration (CI) & Continuous Deployment (CD) in Deployment Center
   - Crafting a Build Pipeline for API (CI): FeedbackService-CI
   - Developing a Release Pipeline for API (CD): FeedbackService-CD
   - Defining Stages for Development, QA, and Production in Release
   - Addressing Naming Conventions for Microservices' CI & CD
   - Automation and Enablement of CI & CD
   - Pre-Deployment Approvals
   - In-depth Conversation about DACPAC Deployment Options
   - Formulating a Build Pipeline for DB Project: FeedbackDatabase-CI
   - Establishing Release Variables and Users in CD
   - Creating a Release Pipeline for DB Project: FeedbackDatabase-CD

REST API Best Practices

- Understanding REST API and its Purpose
- Exploring the Meanings of HTTP Methods
- Managing API Versions Effectively
- Choosing Plural Noun Usage
- Dealing with JSON: Sending and Receiving Data
- Selecting Nouns for Resource Naming
- Properly Structuring Nested Resources
- Communicating Status with Appropriate Status Codes
- Enabling Filtering, Sorting, and Pagination
- Ensuring Security through Best Practices
- Implementing Caching Mechanisms
- Incorporating HATEOAS Principles
- Creating Comprehensive API Documentation
- Establishing Rate Limiting Mechanisms
- Implementing Secure Authentication

- Avoiding Plain Text Responses
- Utilizing the AddNewtonsoftJson Feature
- Exploring Serialization in ASP.NET Core
- Handling Enum Serialization as Strings
- Effective Error Handling in ASP.NET Core Web API
- Expanding Swagger Documentation for Clearer Insight
- Emphasizing Plural Noun Usage for Resource Names
