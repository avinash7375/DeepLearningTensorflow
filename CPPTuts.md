### **C++ Programming Tutorial for Beginners**

---

### **Lesson 1: Introduction to C++**

- **What is C++?**  
  C++ is a general-purpose, object-oriented programming (OOP) language developed by Bjarne Stroustrup as an extension of C. It supports both procedural and object-oriented paradigms.

- **Why Learn C++?**
  - Combines high performance with OOP concepts.
  - Widely used in game development, system software, and competitive programming.
  - Backward-compatible with C.

---

### **Lesson 2: Setting Up Your Environment**

1. **Install a Compiler:**
   - **Linux**: Use **g++** (part of GCC).
     ```bash
     sudo pacman -S gcc
     ```
   - **Windows**: Use **MinGW** or **TDM-GCC**.
   - **Mac**: Install Xcode Command Line Tools:
     ```bash
     xcode-select --install
     ```

2. **Code Editor Options:**
   - **VS Code** with C++ extensions.
   - **CLion** (from JetBrains) for a fully-featured IDE.
   - **Terminal + Vim/Nano** for minimal setups.

---

### **Lesson 3: Your First C++ Program**

1. **Hello, World! Program:**
   ```cpp
   #include <iostream>
   
   int main() {
       std::cout << "Hello, World!" << std::endl;
       return 0;
   }
   ```

2. **Compiling & Running:**
   - **Linux/Mac:**
     ```bash
     g++ hello.cpp -o hello
     ./hello
     ```
   - **Windows:**
     ```bash
     g++ hello.cpp -o hello.exe
     hello.exe
     ```

---

### **Lesson 4: Basic Syntax**

1. **Namespace & I/O:**
   ```cpp
   using namespace std; // Avoids prefixing std::
   ```

2. **Variables & Data Types:**
   ```cpp
   int a = 10;
   float b = 3.14;
   char c = 'A';
   string name = "Alice";
   bool isAdult = true;
   ```

---

### **Lesson 5: Control Structures**

1. **If-Else Statement:**
   ```cpp
   int age = 18;
   if (age >= 18) {
       cout << "You are an adult." << endl;
   } else {
       cout << "You are a minor." << endl;
   }
   ```

2. **Loops:**
   - **For Loop:**
     ```cpp
     for (int i = 0; i < 5; i++) {
         cout << i << endl;
     }
     ```
   - **While Loop:**
     ```cpp
     int i = 0;
     while (i < 5) {
         cout << i << endl;
         i++;
     }
     ```

---

### **Lesson 6: Functions**

1. **Defining and Calling Functions:**
   ```cpp
   int add(int a, int b) {
       return a + b;
   }

   int main() {
       int result = add(5, 3);
       cout << "Result: " << result << endl;
       return 0;
   }
   ```

2. **Function Overloading:**
   ```cpp
   int add(int a, int b) { return a + b; }
   float add(float a, float b) { return a + b; }
   ```

---

### **Lesson 7: Object-Oriented Programming (OOP)**

1. **Classes and Objects:**
   ```cpp
   class Car {
   public:
       string brand;
       int year;
       void display() {
           cout << "Brand: " << brand << ", Year: " << year << endl;
       }
   };

   int main() {
       Car car1;
       car1.brand = "Toyota";
       car1.year = 2020;
       car1.display();
       return 0;
   }
   ```

2. **Constructors:**
   ```cpp
   class Car {
   public:
       string brand;
       Car(string b) {
           brand = b;
       }
   };

   int main() {
       Car car1("Ford");
       cout << "Brand: " << car1.brand << endl;
       return 0;
   }
   ```

---

### **Lesson 8: Pointers & References**

1. **Pointers:**
   ```cpp
   int a = 5;
   int *p = &a;
   cout << "Value: " << *p << ", Address: " << p << endl;
   ```

2. **References:**
   ```cpp
   int a = 5;
   int &ref = a;
   ref = 10;
   cout << "a: " << a << endl; // a = 10
   ```

---

### **Lesson 9: Inheritance**

1. **Basic Inheritance:**
   ```cpp
   class Animal {
   public:
       void eat() {
           cout << "This animal eats food." << endl;
       }
   };

   class Dog : public Animal {
   public:
       void bark() {
           cout << "Dog barks." << endl;
       }
   };

   int main() {
       Dog d;
       d.eat();
       d.bark();
       return 0;
   }
   ```

---

### **Lesson 10: Polymorphism**

1. **Function Overriding:**
   ```cpp
   class Animal {
   public:
       virtual void sound() {
           cout << "Animal sound." << endl;
       }
   };

   class Dog : public Animal {
   public:
       void sound() override {
           cout << "Dog barks." << endl;
       }
   };

   int main() {
       Animal *a = new Dog();
       a->sound();
       delete a;
       return 0;
   }
   ```

---

### **Lesson 11: Templates**

1. **Function Templates:**
   ```cpp
   template <typename T>
   T add(T a, T b) {
       return a + b;
   }

   int main() {
       cout << add(5, 3) << endl;
       cout << add(3.5, 2.5) << endl;
       return 0;
   }
   ```

---

### **Lesson 12: Exception Handling**

1. **Try-Catch Block:**
   ```cpp
   try {
       int x = 0;
       if (x == 0) throw "Division by zero!";
   } catch (const char* msg) {
       cout << "Error: " << msg << endl;
   }
   ```

---

### **Extended C++ Programming Tutorial for Beginners**

---

### **Lesson 13: File Handling in C++**

C++ provides file handling through the `fstream` library, which includes three classes:
- **ifstream**: For reading files.
- **ofstream**: For writing files.
- **fstream**: For both reading and writing.

---

#### **1. Writing to a File:**
```cpp
#include <fstream>
#include <iostream>
using namespace std;

int main() {
    ofstream file("example.txt");
    if (file.is_open()) {
        file << "Hello, C++ File Handling!\n";
        file << "Writing to a file is simple.\n";
        file.close();
        cout << "Data written to file successfully.\n";
    } else {
        cout << "Unable to open file.\n";
    }
    return 0;
}
```

---

#### **2. Reading from a File:**
```cpp
#include <fstream>
#include <iostream>
using namespace std;

int main() {
    ifstream file("example.txt");
    string line;
    if (file.is_open()) {
        while (getline(file, line)) {
            cout << line << endl;
        }
        file.close();
    } else {
        cout << "Unable to open file.\n";
    }
    return 0;
}
```

---

### **Lesson 14: Standard Template Library (STL)**

The STL is a powerful feature in C++ that provides generic classes and functions.

---

#### **1. Vectors:**
```cpp
#include <vector>
#include <iostream>
using namespace std;

int main() {
    vector<int> numbers = {1, 2, 3, 4, 5};
    numbers.push_back(6); // Add element
    numbers.pop_back();   // Remove last element

    for (int num : numbers) {
        cout << num << " ";
    }
    cout << endl;
    return 0;
}
```

---

#### **2. Sets:**
```cpp
#include <set>
#include <iostream>
using namespace std;

int main() {
    set<int> s = {3, 1, 4, 1, 5, 9};
    s.insert(2);  // Add an element

    for (int num : s) {
        cout << num << " ";
    }
    return 0;
}
```

---

#### **3. Maps:**
```cpp
#include <map>
#include <iostream>
using namespace std;

int main() {
    map<string, int> marks;
    marks["Alice"] = 95;
    marks["Bob"] = 85;

    for (auto &pair : marks) {
        cout << pair.first << ": " << pair.second << endl;
    }
    return 0;
}
```

---

### **Lesson 15: Smart Pointers (Memory Management)**

Smart pointers handle memory automatically, helping avoid memory leaks.

---

#### **1. Unique Pointer:**
```cpp
#include <memory>
#include <iostream>
using namespace std;

int main() {
    unique_ptr<int> p = make_unique<int>(10);
    cout << "Unique Pointer Value: " << *p << endl;
    return 0;
}
```

---

#### **2. Shared Pointer:**
```cpp
#include <memory>
#include <iostream>
using namespace std;

int main() {
    shared_ptr<int> sp1 = make_shared<int>(20);
    shared_ptr<int> sp2 = sp1;  // Shared ownership
    cout << "Shared Pointer Value: " << *sp1 << ", Use Count: " << sp1.use_count() << endl;
    return 0;
}
```

---

### **Lesson 16: Lambda Expressions**

Lambdas are anonymous functions used for short tasks.

```cpp
#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

int main() {
    vector<int> numbers = {1, 2, 3, 4, 5};
    
    // Lambda to print each element
    for_each(numbers.begin(), numbers.end(), [](int n) { cout << n << " "; });
    
    cout << endl;
    return 0;
}
```

---

### **Lesson 17: Multithreading**

C++ provides multithreading through the `<thread>` library.

---

#### **1. Basic Thread Example:**
```cpp
#include <thread>
#include <iostream>
using namespace std;

void printMessage() {
    cout << "Thread is running!\n";
}

int main() {
    thread t(printMessage);
    t.join(); // Wait for thread to finish
    cout << "Main thread ends.\n";
    return 0;
}
```

---

#### **2. Passing Arguments to Threads:**
```cpp
#include <thread>
#include <iostream>
using namespace std;

void printNumbers(int n) {
    for (int i = 1; i <= n; i++) {
        cout << i << " ";
    }
}

int main() {
    thread t(printNumbers, 5);
    t.join();
    return 0;
}
```

---

### **Lesson 18: Operator Overloading**

C++ allows overloading of operators to work with user-defined types.

---

#### **1. Overloading the `+` Operator:**
```cpp
#include <iostream>
using namespace std;

class Complex {
public:
    int real, imag;
    Complex(int r, int i) : real(r), imag(i) {}

    Complex operator+(const Complex &c) {
        return Complex(real + c.real, imag + c.imag);
    }

    void display() {
        cout << real << " + " << imag << "i" << endl;
    }
};

int main() {
    Complex c1(2, 3), c2(4, 5);
    Complex c3 = c1 + c2;
    c3.display();
    return 0;
}
```

---

These lessons cover intermediate and advanced C++ topics. Let me know if you'd like more specialized tutorials on specific areas!

### **Advanced C++ Programming Topics**

---

### **Lesson 19: Move Semantics and Rvalue References**

Move semantics improve performance by transferring resources rather than copying them.

---

#### **1. Rvalue References (`&&`):**
```cpp
#include <iostream>
#include <vector>
using namespace std;

void display(vector<int> &&v) {
    for (int i : v) {
        cout << i << " ";
    }
    cout << endl;
}

int main() {
    display({1, 2, 3, 4});  // Passing a temporary vector
    return 0;
}
```

---

#### **2. Move Constructor and Move Assignment Operator:**
```cpp
#include <iostream>
#include <vector>
using namespace std;

class MyClass {
private:
    vector<int> data;
public:
    MyClass(vector<int> d) : data(move(d)) {}  // Move Constructor
    MyClass &operator=(vector<int> d) {        // Move Assignment Operator
        data = move(d);
        return *this;
    }
    void display() {
        for (int i : data) {
            cout << i << " ";
        }
        cout << endl;
    }
};

int main() {
    MyClass obj({1, 2, 3, 4});
    obj.display();
    return 0;
}
```

---

### **Lesson 20: Templates (Advanced)**

---

#### **1. Class Templates:**
```cpp
#include <iostream>
using namespace std;

template <typename T>
class Calculator {
public:
    T add(T a, T b) {
        return a + b;
    }
};

int main() {
    Calculator<int> intCalc;
    Calculator<double> doubleCalc;
    cout << "Int Addition: " << intCalc.add(3, 5) << endl;
    cout << "Double Addition: " << doubleCalc.add(3.5, 5.5) << endl;
    return 0;
}
```

---

#### **2. Template Specialization:**
```cpp
#include <iostream>
using namespace std;

template <typename T>
class Printer {
public:
    void print(T value) {
        cout << "Generic: " << value << endl;
    }
};

// Specialization for char*
template <>
class Printer<char*> {
public:
    void print(char* value) {
        cout << "Specialized for strings: " << value << endl;
    }
};

int main() {
    Printer<int> intPrinter;
    Printer<char*> strPrinter;
    intPrinter.print(100);
    strPrinter.print("Hello, C++ Templates!");
    return 0;
}
```

---

### **Lesson 21: Multiple Inheritance and Virtual Inheritance**

---

#### **1. Multiple Inheritance:**
```cpp
#include <iostream>
using namespace std;

class Base1 {
public:
    void show() {
        cout << "Base1 show() called." << endl;
    }
};

class Base2 {
public:
    void show() {
        cout << "Base2 show() called." << endl;
    }
};

class Derived : public Base1, public Base2 {
public:
    void display() {
        Base1::show();  // Avoid ambiguity
        Base2::show();
    }
};

int main() {
    Derived d;
    d.display();
    return 0;
}
```

---

#### **2. Virtual Inheritance:**
```cpp
#include <iostream>
using namespace std;

class Base {
public:
    void display() {
        cout << "Base class display." << endl;
    }
};

class Derived1 : virtual public Base {};
class Derived2 : virtual public Base {};

class Final : public Derived1, public Derived2 {};

int main() {
    Final obj;
    obj.display();  // No ambiguity due to virtual inheritance
    return 0;
}
```

---

### **Lesson 22: Type Casting in C++**

C++ provides several types of casting:

---

#### **1. `static_cast`:**
```cpp
#include <iostream>
using namespace std;

int main() {
    float a = 3.14;
    int b = static_cast<int>(a);
    cout << "Float: " << a << ", Int: " << b << endl;
    return 0;
}
```

---

#### **2. `dynamic_cast`:**
```cpp
#include <iostream>
using namespace std;

class Base {
public:
    virtual void show() {}
};

class Derived : public Base {};

int main() {
    Base *b = new Derived();
    Derived *d = dynamic_cast<Derived*>(b);
    if (d) {
        cout << "Successful cast to Derived." << endl;
    } else {
        cout << "Failed cast." << endl;
    }
    delete b;
    return 0;
}
```

---

### **Lesson 23: C++17/20 Features (Modern C++)**

---

#### **1. Structured Bindings (C++17):**
```cpp
#include <iostream>
#include <tuple>
using namespace std;

int main() {
    tuple<int, string, float> t = make_tuple(1, "Alice", 95.5);
    auto [id, name, score] = t;
    cout << "ID: " << id << ", Name: " << name << ", Score: " << score << endl;
    return 0;
}
```

---

#### **2. Concepts (C++20):**
```cpp
#include <iostream>
using namespace std;

template <typename T>
concept Number = is_arithmetic_v<T>;

template <Number T>
T add(T a, T b) {
    return a + b;
}

int main() {
    cout << add(5, 10) << endl;      // Works
    cout << add(5.5, 2.5) << endl;   // Works
    // cout << add("A", "B");        // Compilation error
    return 0;
}
```

---

These advanced lessons should help solidify your C++ expertise. Let me know if you'd like further details or specialized concepts!

This C++ series should provide a comprehensive foundation for beginners. Let me know if you need more advanced concepts!
