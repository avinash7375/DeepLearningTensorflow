### **C# ASP.NET Core Web Development Tutorial (Visual Studio Community)**

This step-by-step guide will walk you through creating a full **ASP.NET Core** web application with **Visual Studio Community** for **Windows**, including setting up the environment, database connections, and authentication.

---

### **Step 1: Install Required Tools**

1. **Install Visual Studio Community Edition**  
   Download from [Visual Studio Official Site](https://visualstudio.microsoft.com/).  
   During installation, select:
   - **ASP.NET and Web Development**
   - **.NET Desktop Development**

2. **Install SQL Server Express** (Optional for database management)  
   Download from [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

---

### **Step 2: Create a New ASP.NET Core Project**

1. Open **Visual Studio**.
2. Click **"Create a new project"**.
3. Select **"ASP.NET Core Web App"**, then click **Next**.
4. Configure your project:
   - **Project Name**: `MyWebApp`
   - **Location**: Choose your preferred folder.
   - **Framework**: `.NET 7.0` (or any supported version).
5. Click **Create**.

---

### **Step 3: Project Structure Overview**

Your project will include:
- **`Program.cs`**: Configures services and middleware.
- **`appsettings.json`**: Stores configuration settings (e.g., database connection).
- **`Pages/`**: Contains Razor Pages (`.cshtml` and `.cshtml.cs` files).
- **`wwwroot/`**: Stores static files (CSS, JavaScript, images).

---

### **Step 4: Configuring a Database with Entity Framework Core**

#### **1. Add Entity Framework Core Packages**
1. **Manage NuGet Packages**:
   - Right-click the project → **Manage NuGet Packages**.
   - Search and install:
     - **Microsoft.EntityFrameworkCore.SqlServer**
     - **Microsoft.EntityFrameworkCore.Tools**
     - **Microsoft.AspNetCore.Identity.EntityFrameworkCore**

#### **2. Configure the Database Connection**

- Open `appsettings.json` and add your connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MyWebAppDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

#### **3. Create a Database Context Class**

1. Right-click **Solution Explorer** → **Add** → **New Folder** → Name it `Data`.
2. Inside `Data`, add **AppDbContext.cs**:
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyWebApp.Data {
    public class AppDbContext : IdentityDbContext {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
```

#### **4. Register Database Context in `Program.cs`**
```csharp
using MyWebApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
```

---

### **Step 5: Create Razor Pages with CRUD Functionality**

#### **1. Add a Razor Page for Users**
1. Right-click **`Pages`** → **Add** → **Razor Page** → Name it **Users**.

#### **2. Update `Users.cshtml`**
```html
@page
@model MyWebApp.Pages.UsersModel
<h1>User List</h1>
<form method="post">
    <input type="text" name="Name" placeholder="Enter user name" />
    <button type="submit">Add User</button>
</form>
<ul>
    @foreach (var user in Model.Users) {
        <li>@user.Name</li>
    }
</ul>
```

#### **3. Update `Users.cshtml.cs`**
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Data;

namespace MyWebApp.Pages {
    public class UsersModel : PageModel {
        private readonly AppDbContext _db;
        public List<User> Users { get; set; } = new();
        [BindProperty] public string Name { get; set; }

        public UsersModel(AppDbContext db) {
            _db = db;
        }

        public void OnGet() {
            Users = _db.Users.ToList();
        }

        public IActionResult OnPost() {
            if (!string.IsNullOrEmpty(Name)) {
                _db.Users.Add(new User { Name = Name });
                _db.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
```

---

### **Step 6: Add Authentication with Identity**

#### **1. Scaffold Identity Pages**
1. Right-click the project → **Add** → **New Scaffolded Item**.
2. Choose **Identity** → Select all pages and click **Add**.

#### **2. Configure Identity in `Program.cs`**
```csharp
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();
```

#### **3. Use Authentication Middleware**
Ensure you have:
```csharp
app.UseAuthentication();
app.UseAuthorization();
```

---

### **Step 7: Migrations and Database Setup**

#### **1. Open Package Manager Console**
In Visual Studio, go to **Tools** → **NuGet Package Manager** → **Package Manager Console**.

#### **2. Apply Migrations**
```bash
Add-Migration InitialCreate
Update-Database
```

---

### **Step 8: Testing the Application**

1. **Run** the application (F5).
2. Test:
   - User management on `/Users`.
   - Authentication pages (Register, Login, Logout).

---

### **Step 9: Deploy to IIS (Optional)**

#### **1. Install IIS**
- Go to **Control Panel** → **Programs** → **Turn Windows features on or off** → Enable **Internet Information Services**.

#### **2. Publish the Project**
- Right-click the project → **Publish** → **Folder** → **Create a new publish profile** → Publish.

#### **3. Host on IIS**
1. Open **IIS Manager**.
2. Add a new site pointing to your published folder.
3. Access via `http://localhost/YourSiteName`.

---

Let me know if you'd like more detailed steps for deployment, working with APIs, or any other .NET feature!

### **Basic ASP.NET Core Web Hosting Project on IIS (With Code)**

Here’s how to create a **basic ASP.NET Core** web application, publish it, and host it on **IIS** on a **Windows** machine, with complete code for every part of the process.

---

### **Step 1: Set Up the Development Environment**

1. **Install .NET SDK & Visual Studio Community Edition**
   - Download and install the **.NET SDK**: [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet).
   - Install **Visual Studio Community Edition**: [Download Visual Studio](https://visualstudio.microsoft.com/). Ensure you select the **ASP.NET and Web Development** workload during installation.

2. **Enable IIS on Windows**
   - Go to **Control Panel** → **Programs** → **Turn Windows features on or off**.
   - Enable **Internet Information Services (IIS)** and **ASP.NET Core Hosting Bundle**.

---

### **Step 2: Create the ASP.NET Core Project**

#### **1. Create a New Project in Visual Studio**

1. Open **Visual Studio**.
2. Click **"Create a new project"**.
3. Select **"ASP.NET Core Web App"** and click **Next**.
4. Name your project: `BasicWebHostProject`.
5. Set the target framework to **.NET 7.0** (or whichever version you prefer) and click **Create**.

#### **2. Modify the Default `Index.cshtml` Page**

1. In the **Solution Explorer**, go to **Pages/Index.cshtml**.
2. Replace the existing content with this HTML code:

```html
@page
@model IndexModel

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Welcome to My Hosted ASP.NET Core Web App</title>
</head>
<body>
    <h1>Welcome to My Hosted ASP.NET Core Web App!</h1>
    <p>This website is hosted on IIS.</p>
</body>
</html>
```

#### **3. Modify the `Index.cshtml.cs` (Page Model)**

1. Go to **Pages/Index.cshtml.cs**.
2. Replace its contents with the following C# code:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicWebHostProject.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // Any server-side logic can be added here.
        }
    }
}
```

---

### **Step 3: Publish the Application**

#### **1. Configure Publish Profile in Visual Studio**

1. Right-click your project in **Solution Explorer** → **Publish**.
2. Choose **Folder** as the target and select a folder path (e.g., `C:\inetpub\wwwroot\BasicWebHostProject`).
3. Click **Next**, then **Publish**.

Your application files will now be available in the folder you specified.

---

### **Step 4: Set Up IIS for Hosting**

#### **1. Open IIS Manager**

- Press **Win + R**, type `inetmgr`, and press **Enter** to open **IIS Manager**.

#### **2. Set Up a New Website in IIS**

1. In **IIS Manager**, right-click **Sites** → **Add Website**.
2. Set the following:
   - **Site Name**: `BasicWebHostSite`
   - **Physical Path**: Browse to your published folder (`C:\inetpub\wwwroot\BasicWebHostProject`).
   - **Port**: Set it to **80** (or any available port).
   - **Host name**: Leave it blank (for local use, use `localhost`).
   - Click **OK**.

#### **3. Configure Application Pool for .NET Core**

1. In **IIS Manager**, click **Application Pools**.
2. Find the pool for your website (`BasicWebHostSite`).
3. Make sure **.NET Core** is set to **No Managed Code** and **Pipeline Mode** is **Integrated**.

---

### **Step 5: Run and Test the Web Application**

1. Open a browser and go to **http://localhost** (or **http://localhost:80** if using a custom port).
2. You should see the message:
   - **"Welcome to My Hosted ASP.NET Core Web App!"**

---

### **Optional: Allow Access From Remote Machines**

#### **1. Configure Windows Firewall**

1. Open **Windows Firewall** and click **Allow an app through firewall**.
2. Enable **IIS** and **Web Management**.

#### **2. Access via Remote IP**

1. Find your **machine's IP address** by running `ipconfig` in **Command Prompt**.
2. Access the site remotely by navigating to `http://<your-ip-address>:80`.

---

### **Step 6: Troubleshooting**

1. **500 Internal Server Error**
   - Ensure the **ASP.NET Core Hosting Bundle** is installed on the server.
   - Check **Event Viewer** for error logs.
   
2. **403 Forbidden**
   - Make sure that **IIS_IUSRS** has the appropriate file permissions to the published directory.

3. **404 Not Found**
   - Double-check the **Physical Path** in IIS to ensure it's pointing to the correct directory.
   - Ensure the **site name** and port are correctly configured.

---

### **Complete Example Code for Reference**

#### **Program.cs**

```csharp
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BasicWebHostProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
```

#### **Startup.cs**

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicWebHostProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapRazorPages();
        }
    }
}
```

#### **Index.cshtml**

```html
@page
@model IndexModel

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Welcome to My Hosted ASP.NET Core Web App</title>
</head>
<body>
    <h1>Welcome to My Hosted ASP.NET Core Web App!</h1>
    <p>This website is hosted on IIS.</p>
</body>
</html>
```

#### **Index.cshtml.cs**

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BasicWebHostProject.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // Server-side logic can be added here, if needed.
        }
    }
}
```

---

### **Conclusion**

Your **ASP.NET Core Web Application** is now created, published, and hosted on IIS. You can access the site locally or configure it for external access.

Let me know if you need more details or help with more advanced topics like **SSL configuration**, **custom domains**, or **deploying with a CI/CD pipeline**!



---------------------------------
### **Building a Dynamic ASP.NET Core Web Application with Login, Home, and Contact Us Pages (With Code)**

This guide will walk you through creating a **dynamic ASP.NET Core Web Application** with a **Login Page**, **Home Page**, and **Contact Us Page**. We'll use **ASP.NET Core Identity** for authentication and routing.

---

### **Step 1: Set Up the Development Environment**

1. **Install .NET SDK & Visual Studio Community Edition**:
   - Download the **.NET SDK**: [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet).
   - Install **Visual Studio Community Edition**: [Download Visual Studio](https://visualstudio.microsoft.com/). Select the **ASP.NET and Web Development** workload during installation.

2. **Enable IIS on Windows**:
   - Go to **Control Panel** → **Programs** → **Turn Windows features on or off**.
   - Enable **Internet Information Services (IIS)** and **ASP.NET Core Hosting Bundle**.

---

### **Step 2: Create the ASP.NET Core Web Application**

#### **1. Create a New Project in Visual Studio**

1. Open **Visual Studio**.
2. Click **Create a new project**.
3. Select **ASP.NET Core Web Application** and click **Next**.
4. Name your project: `DynamicWebApp`.
5. Choose **.NET 7.0** (or your preferred version) and select the **Web Application (Model-View-Controller)** template.
6. Click **Create**.

#### **2. Add Authentication Using ASP.NET Core Identity**

1. Right-click the project → **Add** → **New Scaffolded Item**.
2. Select **Identity**.
3. Choose **Account** and select the following:
   - **Login**
   - **Register**
   - **Logout**
   - **Forgot Password** (optional)
4. Click **Add** to scaffold the Identity pages.

---

### **Step 3: Set Up Pages**

#### **1. Add a Home Page (Index)**

1. Open **Pages/Index.cshtml** and replace its content with this HTML:

```html
@page
@model IndexModel
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home Page</title>
</head>
<body>
    <h1>Welcome to the Home Page</h1>
    <p>This is the main landing page of your dynamic ASP.NET Core Web App.</p>
    <a href="/Contact">Go to Contact Us</a>
</body>
</html>
```

#### **2. Add a Contact Us Page**

1. In **Pages**, add a new Razor Page called **Contact.cshtml**.
2. Replace the content of `Contact.cshtml` with the following HTML code:

```html
@page
@model ContactModel
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Contact Us</title>
</head>
<body>
    <h1>Contact Us</h1>
    <form method="post">
        <label for="Name">Name</label>
        <input type="text" id="Name" name="Name" required /><br/>
        
        <label for="Email">Email</label>
        <input type="email" id="Email" name="Email" required /><br/>
        
        <label for="Message">Message</label>
        <textarea id="Message" name="Message" required></textarea><br/>
        
        <button type="submit">Submit</button>
    </form>
</body>
</html>
```

3. Add a **ContactModel.cs** file in **Pages** to handle form submissions:

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DynamicWebApp.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Message { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            // Here you would typically save the form data to a database or send an email
            // For now, we just redirect to a thank you page
            return RedirectToPage("/ThankYou");
        }
    }
}
```

#### **3. Add a Thank You Page**

1. Add a new Razor Page called **ThankYou.cshtml** in **Pages**.

```html
@page
@model ThankYouModel
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Thank You</title>
</head>
<body>
    <h1>Thank You for Contacting Us!</h1>
    <p>Your message has been submitted successfully.</p>
    <a href="/Home">Go to Home Page</a>
</body>
</html>
```

---

### **Step 4: Configure Authentication (Login & Logout)**

#### **1. Register and Login**

The Identity pages (Login, Register, etc.) are scaffolded by default and will allow you to register, log in, and log out.

1. **Register**: Go to `/Identity/Account/Register` to create a new account.
2. **Login**: Go to `/Identity/Account/Login` to log in.

#### **2. Configure Authorization in Startup.cs**

1. Open **Startup.cs** and make sure you have the following code to configure authentication and authorization:

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DynamicWebApp.Data;

namespace DynamicWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); // Adds authentication middleware
            app.UseAuthorization(); // Adds authorization middleware

            app.MapRazorPages();
        }
    }
}
```

---

### **Step 5: Database Configuration for Identity**

1. Open **appsettings.json** and add the connection string for your database:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DynamicWebAppDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

2. Create the database by running the following commands in the **Package Manager Console**:

```bash
Add-Migration InitialCreate
Update-Database
```

---

### **Step 6: Running the Application Locally**

1. Press **Ctrl + F5** or click **Run** to start the application.
2. Navigate to:
   - **Home Page**: `/Home`
   - **Login Page**: `/Identity/Account/Login`
   - **Contact Us Page**: `/Contact`
   - **Thank You Page**: After submitting the contact form, you will be redirected to `/ThankYou`.

---

### **Step 7: Publishing and Hosting on IIS**

1. **Publish** the application:
   - Right-click the project → **Publish** → Select **Folder** → Choose a location like `C:\inetpub\wwwroot\DynamicWebApp`.
   - Click **Publish**.

2. **Set Up IIS**:
   - Follow the previous IIS configuration steps to set up a new site and point to the published folder.

3. **Testing**:
   - Open a browser and visit `http://localhost` to see the app in action.

---

### **Conclusion**

Your dynamic ASP.NET Core Web Application now includes:
- A **Home Page** that serves as the landing page.
- A **Contact Us** page with form submission.
- Basic **Login** and **Registration** functionality using ASP.NET Core Identity.

Let me know if you'd like to expand this with additional features such as email confirmation, user roles, or API integration!

----
[07/12, 18:50] Avinash R. Kauran: file:```Here’s a structured C# tutorial covering beginner to intermediate levels. Each section introduces key concepts, practical examples, and suggested exercises for reinforcement.


---

C# Tutorials: Beginner to Intermediate


---

1. Introduction to C#

Overview: History, uses, and features of C#.

Setup: Install Visual Studio Code or Visual Studio, set up .NET SDK.

First Program: Create and run a simple "Hello, World!" program.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}


Exercises:

Modify the "Hello, World!" program to display your name.



---

2. Variables, Data Types, and Constants

Variables: int, float, double, string, bool.

Constants: Use const keyword.

Type Conversion: Implicit and explicit conversion.


Example:

int age = 25;
float height = 5.9f;
string name = "John";
const double Pi = 3.14159;

Console.WriteLine($"Name: {name}, Age: {age}, Height: {height}, Pi: {Pi}");

Exercises:

Create variables for your name, age, and favorite number and display them.



---

3. Operators and Expressions

Arithmetic Operators: +, -, *, /, %.

Comparison Operators: ==, !=, >, <, >=, <=.

Logical Operators: &&, ||, !.


Example:

int a = 10, b = 20;
bool result = (a < b) && (a > 5);
Console.WriteLine($"Is {a} less than {b} and greater than 5? {result}");

Exercises:

Write a program to calculate the area of a rectangle.



---

4. Control Structures

Conditionals: if, else if, else, switch.

Loops: for, while, do-while, foreach.


Example:

for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Iteration: {i}");
}

Exercises:

Write a program to print even numbers between 1 and 50.



---

5. Arrays and Collections

Arrays: Single-dimensional and multi-dimensional.

Collections: List, Dictionary.


Example:

int[] numbers = { 1, 2, 3, 4, 5 };
foreach (int num in numbers)
{
    Console.WriteLine(num);
}

Exercises:

Create a program to find the largest number in an array.



---

6. Functions and Methods

Syntax: Define, call, and pass parameters.

Return Types: void, other types.

Overloading: Method overloading.


Example:

int Add(int x, int y) => x + y;

Console.WriteLine($"Sum: {Add(5, 10)}");

Exercises:

Write a method to calculate the factorial of a number.



---

7. Object-Oriented Programming (OOP)

Classes and Objects.

Encapsulation: Access modifiers (public, private).

Inheritance.

Polymorphism: Method overriding and virtual methods.


Example:

class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal sound");
}

class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Bark");
}

Dog dog = new Dog();
dog.Speak();

Exercises:

Create a class Car with properties like Model and Speed. Include methods like Drive().



---

8. Error Handling

Try-Catch-Finally: Handle exceptions.

Throw: Create custom exceptions.


Example:

try
{
    int number = int.Parse("abc");
}
catch (FormatException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Exercises:

Write a program to catch a division by zero error.



---

9. File Handling

Read and Write Files: Use System.IO namespace.

StreamReader/StreamWriter.


Example:

using System.IO;

File.WriteAllText("example.txt", "Hello, File!");
Console.WriteLine(File.ReadAllText("example.txt"));

Exercises:

Write a program to create a text file and save user input.



---

10. Advanced Topics

Delegates and Events.

LINQ: Query collections.

Asynchronous Programming: async and await.


Example:

using System.Threading.Tasks;

async Task GreetAsync()
{
    await Task.Delay(1000);
    Console.WriteLine("Hello, Async World!");
}

GreetAsync().Wait();

Exercises:

Write a program using LINQ to filter even numbers from a list.



---

Conclusion

By following this structure, you’ll progress from understanding basic concepts to writing intermediate-level programs in C#. Ensure regular practice and explore additional topics as needed. Let me know if you'd like help on any specific topic!

```
[07/12, 18:51] Avinash R. Kauran: ```Here’s an expanded tutorial to cover more advanced concepts and intermediate programming techniques in C#.


---

11. Generics

Purpose: Write reusable, type-safe code.

Generic Classes and Methods.

Generic Constraints.


Example:

class GenericBox<T>
{
    private T _value;
    public void SetValue(T value) => _value = value;
    public T GetValue() => _value;
}

GenericBox<int> intBox = new GenericBox<int>();
intBox.SetValue(10);
Console.WriteLine($"Boxed Value: {intBox.GetValue()}");

Exercises:

Create a generic class Pair<T1, T2> that holds two values of different types.



---

12. Extension Methods

Purpose: Add methods to existing types without modifying them.

Usage: Use static methods with this keyword.


Example:

public static class StringExtensions
{
    public static int WordCount(this string str)
    {
        return str.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

string sentence = "C# is awesome!";
Console.WriteLine($"Word Count: {sentence.WordCount()}");

Exercises:

Write an extension method to reverse a string.



---

13. Interfaces

Purpose: Define contracts for classes.

Implementing Multiple Interfaces.

Default Interface Methods (C# 8.0+).


Example:

interface IAnimal
{
    void Speak();
}

class Cat : IAnimal
{
    public void Speak() => Console.WriteLine("Meow");
}

IAnimal myCat = new Cat();
myCat.Speak();

Exercises:

Create an interface ICalculator with methods Add and Subtract. Implement it in a SimpleCalculator class.



---

14. Delegates and Lambda Expressions

Delegates: Type-safe function pointers.

Anonymous Methods and Lambda Expressions.


Example:

delegate int MathOperation(int x, int y);

MathOperation add = (a, b) => a + b;
Console.WriteLine($"Sum: {add(10, 20)}");

Exercises:

Create a delegate that checks if a number is even or odd.



---

15. Events

Purpose: Notify objects when something happens.

Declaring and Raising Events.

Subscribing to Events.


Example:

class Publisher
{
    public event Action OnPublish;

    public void Publish()
    {
        Console.WriteLine("Publishing...");
        OnPublish?.Invoke();
    }
}

class Subscriber
{
    public void HandleEvent() => Console.WriteLine("Event Handled!");
}

Publisher publisher = new Publisher();
Subscriber subscriber = new Subscriber();

publisher.OnPublish += subscriber.HandleEvent;
publisher.Publish();

Exercises:

Create an event OnAlarmTriggered in a Clock class and handle it in another class.



---

16. LINQ (Language Integrated Query)

Purpose: Query collections using SQL-like syntax.

Operations: Select, Where, GroupBy, OrderBy.


Example:

int[] numbers = { 1, 2, 3, 4, 5 };

var evenNumbers = numbers.Where(n => n % 2 == 0);
Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

Exercises:

Use LINQ to group words by their first letter from a list of strings.



---

17. Reflection

Purpose: Inspect and manipulate types at runtime.

Key Classes: Type, MethodInfo, PropertyInfo.


Example:

Type type = typeof(string);
Console.WriteLine($"Type: {type.Name}");
foreach (var method in type.GetMethods())
{
    Console.WriteLine(method.Name);
}

Exercises:

Write a program that lists all properties of a custom class using reflection.



---

18. File I/O and Serialization

File I/O: Read/write files using StreamReader/StreamWriter.

Serialization: Use JsonSerializer or XmlSerializer.


Example (JSON Serialization):

using System.Text.Json;

var person = new { Name = "Alice", Age = 25 };
string json = JsonSerializer.Serialize(person);
Console.WriteLine($"Serialized JSON: {json}");

Exercises:

Serialize and deserialize a custom class using JSON.



---

19. Multithreading and Parallel Programming

Thread Class: Create and manage threads.

Task Parallel Library (TPL).

Async/Await: Handle asynchronous operations.


Example:

using System.Threading.Tasks;

Task.Run(() => Console.WriteLine("Running in a separate thread")).Wait();

Exercises:

Write a program to calculate the sum of an array in parallel using multiple threads.



---

20. Dependency Injection

Purpose: Decouple components and improve testability.

Built-in Support: Dependency injection in .NET Core/ASP.NET Core.


Example:

public interface IMessageService
{
    void SendMessage(string message);
}

public class EmailService : IMessageService
{
    public void SendMessage(string message) => Console.WriteLine($"Email: {message}");
}

class Program
{
    private readonly IMessageService _service;

    public Program(IMessageService service) => _service = service;

    public void Notify(string message) => _service.SendMessage(message);

    static void Main()
    {
        IMessageService service = new EmailService();
        Program program = new Program(service);
        program.Notify("Hello, Dependency Injection!");
    }
}

Exercises:

Implement a dependency injection pattern for a logging service.



---

21. Working with Databases

ADO.NET: Access and manage SQL databases.

Entity Framework Core: ORM for working with databases.


Example (Entity Framework Core):

using Microsoft.EntityFrameworkCore;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }
}

Exercises:

Create a console application that performs CRUD operations using Entity Framework Core.



---

22. Networking

HTTP Clients: Work with REST APIs.

Sockets: Build TCP/UDP servers and clients.


Example:

using System.Net.Http;

HttpClient client = new HttpClient();
string response = await client.GetStringAsync("https://api.github.com");
Console.WriteLine(response);

Exercises:

Write a program to fetch and display data from a public REST API.



---

23. Design Patterns

Creational: Singleton, Factory.

Structural: Adapter, Decorator.

Behavioral: Observer, Strategy.


Example (Singleton):

class Singleton
{
    private static Singleton _instance;
    private Singleton() { }
    public static Singleton Instance => _instance ??= new Singleton();
}

Singleton instance = Singleton.Instance;

Exercises:

Implement a factory pattern to create different types of shapes.



---

Would you like to dive deeper into any specific area?

```
