```
```

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




Conclusion

By following this structure, you’ll progress from understanding basic concepts to writing intermediate-level programs in C#. Ensure regular practice and explore additional topics as needed. Let me know if you'd like help on any specific topic!




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

