

// Contains the root App component and other Razor components
using BlazorInvoice.Components;
// Contains InvoiceDbContext (Entity Framework Core database context)
using BlazorInvoice.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Components.Routing;

/*
This creates an object called builder
Its function: Read settings from appsettings.json
Processing services
Server preparation
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.// Register Services in Dependency Injection
/*
Add Razor Components support to the application
Enables Blazor components rendering
 */
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();//Enables Interactive Server Mode (Blazor Server behavior)// UI is rendered on the server and updates via SignalR

// Register BlazorBootstrap UI component library
// Allows usage of ready Bootstrap-based components
builder.Services.AddBlazorBootstrap();

// Register SQL Server Database Context (Entity Framework Core)
// - InvoiceDbContext: custom DbContext class
// - Reads connection string from appsettings.json
builder.Services.AddSqlServer<InvoiceDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

/*
This line registers an adapter that connects QuickGrid to EF Core inside the DI Container.
Its purpose is to perform paging and sorting operations at the database level instead of loading
all the data into memory, which significantly improves performance, especially with large datasets.
*/
builder.Services.AddQuickGridEntityFrameworkAdapter();


//Build the Application
//Builds the application after registering all services

//builder.Services.AddSignalR();




var app = builder.Build();


// Configure the HTTP request pipeline.// Configure HTTP Request Pipeline (Middleware)
if (!app.Environment.IsDevelopment())
{
    // Redirects unhandled exceptions to /Error page
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.//HTTP Strict Transport Security
    /*
     This is a security mechanism that makes the browser:
     Force the website to open only with HTTPS
     Block any attempt to connect via unencrypted HTTP
        */
    app.UseHsts();
}

// Redirect all HTTP requests to HTTPS automatically
app.UseHttpsRedirection();

// Enables serving static files from wwwroot folder
// (CSS, JS, images, etc.)
app.UseStaticFiles();

/*
 The UseAntiforgery() function enables Middleware to verify the Anti-Forgery Token to prevent CSRF attacks. 
 Any data modification request must contain a valid token, otherwise it will be rejected. This protects 
 logged-in users from unintentional actions.
 */
app.UseAntiforgery();

// Map Razor Components to the Application

// Maps the root Razor component (App.razor)
// This is the starting point of the Blazor UI
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Enables Interactive Server Render Mode
                                       // UI updates handled via server connection


//app.MapHub<InvoiceHub>("/invoiceHub");

// Run the Application
// Starts the web server and begins listening for requests

app.Run();


/*
Loads configuration

Registers services (Blazor, EF Core, Bootstrap, QuickGrid)

Builds the app

Configures middleware pipeline

Maps the root Blazor component  //The main component (such as App.razor) is linked to the application so that it becomes the starting point for the interface.

Starts the server
 * */



/*
In Program.cs, the application goes through several steps.
First, it loads configuration settings from configuration files.

Then it registers services like Blazor for the UI and Entity Framework Core for database access inside the Dependency Injection container.

After that, it builds the application using Build().


Next, it configures the middleware pipeline to define how HTTP requests are processed, such as HTTPS redirection and authentication.

Then it maps the root Blazor component as the entry point of the UI.

Finally, it starts the server using Run() and begins listening for requests.
*/









//Basics 

//In Blazor After the first load:

//A connection is established using SignalR

//So interaction can happen without a full page reload.








/*User → Kestrel → Middleware → App.razor → (Routes ONE if them in the . 6 .7 Router → RouteView → MainLayout → `@Body` → Page Content*/

//When the user types the website URL in the browser, the first thing that happens is that the 
//request reaches Kestrel Web Server, which is responsible for receiving HTTP requests and creating the 
//HttpContext. After that, the request enters the Middleware Pipeline in the order defined inside Program.cs,
//such as UseHttpsRedirection, UseStaticFiles, and the other configured middleware components.

//If the request is not for a static file (like CSS, JavaScript, or an image), it eventually reaches 
//MapRazorComponents<App>(). At this point, App.razor is invoked as the root component of the user interface.
//    Then, the Router inside App.razor searches for the first component that contains @page "/", which becomes 
//    the page rendered and displayed to the user. Finally, a SignalR connection is established to enable interactivity,
//    allowing the application to handle user actions without reloading the entire page.



//The sequence works like this: MainLayout contains<NavMenu />, and NavMenu contains NavLink.
//When you click a NavLink, the Router changes the page, and RouteView renders it inside @Body.
//So the menu itself does not change the Layout; it only changes the content inside @Body.


//NavLink integrates with the Blazor Router.It prevents full page reload and automatically appliesan active CSS class when the route matche


//A Navigation System is responsible for moving between pages within an application without a full page reload.
//In Blazor, this is done using NavLink and Router to seamlessly update the content displayed inside @Body.








//DB All time  then online all time
//Secure
//













//I built this project using ASP.NET Core Blazor Server with Interactive Server render mode.
//I used Entity Framework Core with SQL Server for database operations.
//The UI is built using Bootstrap and BlazorBootstrap components.
//I implemented Dependency Injection, Routing, Layouts, and Component-based architecture.
//I also used Protected Session Storage for saving temporary browser data, and applied business logic for installment payments calculation



//Component - Based Architecture

//Dependency Injection

//Entity Framework Core

//LINQ

//Change Tracking

//Two-Way Binding

//Routing & Layouts

//Lifecycle Methods

//State Management

//Business Logic Layer inside components



//Program.cs
/*
Set Environment  Developmentعرض أخطاء مفصلة للمبرمج.Staging.Production
The application determines or reads the operating environment (Development / Production)
to change the behavior of the program according to the stage in which it is running.




Register services
run blazer server mode
Register DB
Bulid the syetem after combine the last things 
way to deal with http and enable using statice file  and Antiforgery
say from where our app start 
basically any thing or any concept we will applu in the project should be regitered in progeam.cs 
Finally run server 
**/