### C Programming Tutorial for Beginners

---

#### **Lesson 1: Introduction to C**
- **What is C?**  
  C is a general-purpose, procedural programming language developed in the early 1970s by Dennis Ritchie at Bell Labs. It's widely used for system programming, embedded systems, and applications that require high performance.

- **Why Learn C?**
  - Foundation for learning other languages like C++, Java, and Python.
  - Close to hardware, making it efficient.
  - Helps understand core programming concepts like memory management.

---

#### **Lesson 2: Setting Up Your Environment**

1. **Install a Compiler:**
   - **Linux**: GCC (Pre-installed in most distributions)
     ```bash
     sudo pacman -S gcc   # Arch Linux
     ```
   - **Windows**: Use **MinGW** or **TDM-GCC**.
   - **Mac**: Install Xcode Command Line Tools:
     ```bash
     xcode-select --install
     ```

2. **Code Editor Options:**
   - **VS Code** (Recommended): Lightweight and extensible.
   - **Code::Blocks**: IDE with a built-in compiler.
   - **Terminal + Vim/Nano**: For minimalists.

---

#### **Lesson 3: Your First C Program**

1. **Hello, World! Program**
   ```c
   #include <stdio.h>

   int main() {
       printf("Hello, World!\n");
       return 0;
   }
   ```

2. **Compiling & Running the Program**
   - **Linux/Mac:**
     ```bash
     gcc hello.c -o hello
     ./hello
     ```
   - **Windows:**
     ```bash
     gcc hello.c -o hello.exe
     hello.exe
     ```

---

#### **Lesson 4: Basic Syntax**

1. **Structure of a C Program**
   - **Preprocessor Directives**: `#include <stdio.h>`
   - **Main Function**: `int main() { ... }`
   - **Statements & Semicolons**: Each line ends with `;`.

2. **Comments:**
   ```c
   // Single-line comment
   /* Multi-line
      comment */
   ```

---

#### **Lesson 5: Variables & Data Types**

1. **Common Data Types:**
   ```c
   int a = 5;           // Integer
   float b = 3.14;      // Floating point
   char c = 'A';        // Character
   double d = 3.14159;  // Double precision
   ```

2. **Input & Output:**
   ```c
   int age;
   printf("Enter your age: ");
   scanf("%d", &age);
   printf("You are %d years old.\n", age);
   ```

---

#### **Lesson 6: Control Structures**

1. **If-Else Statement:**
   ```c
   if (age >= 18) {
       printf("You are an adult.\n");
   } else {
       printf("You are a minor.\n");
   }
   ```

2. **Loops:**
   - **For Loop:**
     ```c
     for (int i = 0; i < 5; i++) {
         printf("%d\n", i);
     }
     ```
   - **While Loop:**
     ```c
     int i = 0;
     while (i < 5) {
         printf("%d\n", i);
         i++;
     }
     ```

---

#### **Lesson 7: Functions**

1. **Defining and Calling Functions:**
   ```c
   int add(int a, int b) {
       return a + b;
   }

   int main() {
       int result = add(5, 3);
       printf("Result: %d\n", result);
       return 0;
   }
   ```

---

#### **Lesson 8: Pointers**

1. **Introduction to Pointers:**
   ```c
   int a = 10;
   int *p = &a;
   printf("Value: %d, Address: %p\n", *p, p);
   ```

---

#### **Lesson 9: Arrays & Strings**

1. **Arrays:**
   ```c
   int arr[5] = {1, 2, 3, 4, 5};
   for (int i = 0; i < 5; i++) {
       printf("%d ", arr[i]);
   }
   ```

2. **Strings:**
   ```c
   char str[20] = "Hello, C!";
   printf("%s\n", str);
   ```

---

#### **Lesson 10: File Handling**

1. **Reading & Writing Files:**
   ```c
   FILE *fp = fopen("file.txt", "w");
   fprintf(fp, "Hello, File!\n");
   fclose(fp);
   ```

---

### **C Programming Tutorial (Extended Topics)**

---

#### **Lesson 11: Structures**

Structures allow you to group different data types under one name, useful for handling complex data.

1. **Defining a Structure:**
   ```c
   struct Student {
       int id;
       char name[50];
       float marks;
   };
   ```

2. **Using a Structure:**
   ```c
   int main() {
       struct Student s1;
       
       s1.id = 101;
       strcpy(s1.name, "John Doe");
       s1.marks = 89.5;

       printf("ID: %d\n", s1.id);
       printf("Name: %s\n", s1.name);
       printf("Marks: %.2f\n", s1.marks);
       return 0;
   }
   ```

3. **Array of Structures:**
   ```c
   struct Student students[3];
   for (int i = 0; i < 3; i++) {
       printf("Enter ID, Name, and Marks for Student %d: ", i + 1);
       scanf("%d %s %f", &students[i].id, students[i].name, &students[i].marks);
   }
   ```

---

#### **Lesson 12: Enumerations (Enums)**

Enums provide a way to define a set of named integral constants, improving code readability.

1. **Defining an Enum:**
   ```c
   enum Day { SUNDAY, MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY };
   ```

2. **Using an Enum:**
   ```c
   int main() {
       enum Day today;
       today = WEDNESDAY;

       if (today == WEDNESDAY) {
           printf("It's Wednesday!\n");
       }
       return 0;
   }
   ```

3. **Assigning Custom Values:**
   ```c
   enum Level { LOW = 1, MEDIUM = 5, HIGH = 10 };
   enum Level currentLevel = MEDIUM;
   printf("Current Level: %d\n", currentLevel);
   ```

---

#### **Lesson 13: Dynamic Memory Allocation**

C provides functions to allocate and free memory during runtime using pointers.

1. **Malloc & Free:**
   ```c
   int *ptr = (int*) malloc(5 * sizeof(int));
   if (ptr == NULL) {
       printf("Memory allocation failed.\n");
       return 1;
   }
   for (int i = 0; i < 5; i++) {
       ptr[i] = i + 1;
   }
   free(ptr);
   ```

2. **Calloc & Realloc:**
   ```c
   int *arr = (int*) calloc(5, sizeof(int));
   arr = (int*) realloc(arr, 10 * sizeof(int));
   free(arr);
   ```

---

#### **Lesson 14: Bitwise Operators**

Bitwise operators are used to manipulate data at the bit level, useful in embedded systems or performance-critical applications.

1. **Common Bitwise Operators:**
   ```c
   int a = 5, b = 3;
   printf("a & b = %d\n", a & b);  // AND
   printf("a | b = %d\n", a | b);  // OR
   printf("a ^ b = %d\n", a ^ b);  // XOR
   printf("~a = %d\n", ~a);        // NOT
   printf("a << 1 = %d\n", a << 1);// Left Shift
   printf("a >> 1 = %d\n", a >> 1);// Right Shift
   ```

---

#### **Lesson 15: Typedef & Unions**

1. **Typedef:**
   ```c
   typedef unsigned int uint;
   uint age = 25;
   printf("Age: %u\n", age);
   ```

2. **Unions:**
   ```c
   union Data {
       int i;
       float f;
       char str[20];
   };

   int main() {
       union Data data;
       data.i = 10;
       printf("Data.i: %d\n", data.i);
       data.f = 3.14;
       printf("Data.f: %.2f\n", data.f);
       return 0;
   }
   ```

---

#### **Lesson 16: Preprocessor Directives**

Preprocessor directives are commands that are executed before the compilation process.

1. **Macros:**
   ```c
   #define PI 3.14
   #define AREA(r) (PI * (r) * (r))

   int main() {
       printf("Area: %.2f\n", AREA(5));
       return 0;
   }
   ```

2. **Conditional Compilation:**
   ```c
   #ifdef DEBUG
       printf("Debug mode enabled.\n");
   #else
       printf("Debug mode disabled.\n");
   #endif
   ```

---

#### **Lesson 17: Command Line Arguments**

1. **Handling Arguments:**
   ```c
   int main(int argc, char *argv[]) {
       printf("Program Name: %s\n", argv[0]);
       if (argc > 1) {
           printf("Argument 1: %s\n", argv[1]);
       }
       return 0;
   }
   ```

---

These extended topics help you build more complex programs in C. Let me know if you need more lessons or examples!
