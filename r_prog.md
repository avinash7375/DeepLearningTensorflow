## R Programming: A Basic to Intermediate Guide

This guide will introduce you to R, a powerful language for data analysis, statistics, and visualization. We'll start with the fundamentals and progress to more complex techniques.

### 1. Getting Started

* **Download and Install R:** Head to the official R Project website ([https://www.r-project.org/](https://www.r-project.org/)) to download and install R for your operating system.
* **RStudio:** Consider using RStudio, a free Integrated Development Environment (IDE) for R that provides a user-friendly interface for writing code, viewing results, and managing projects. Download it from RStudio's website ([https://posit.co/download/rstudio-desktop/](https://posit.co/download/rstudio-desktop/)).

### 2. Basic Syntax

* **R as a Calculator:** Perform simple arithmetic operations like addition (+), subtraction (-), multiplication (*), division (/), exponentiation (^), and modulo (%%).
* **Variables:** Assign values to variables using `<-` (e.g., `x <- 5`). Use `x` to access the stored value.
* **Comments:** Add comments using `#` to explain your code (these lines are not executed).

```R
# Addition
2 + 3

# Assigning value to a variable
x <- 10
x
```

### 3. Data Types

* **Numeric:** Represent numbers (e.g., `12.34`).
* **Integer:** Whole numbers (use `L` to specify, e.g., `5L`).
* **Logical:** True (TRUE) or False (FALSE).
* **Character Strings:** Text data (e.g., `"Hello, R!"`).

```R
# Numeric
num <- 3.14
is.numeric(num)  # Check data type

# Integer
age <- 25L
is.integer(age)
```

### 4. Data Structures

* **Vectors:** Ordered sequences of elements of the same type.
* **Matrices:** Two-dimensional arrays of data.
* **Data Frames:** Similar to tables with columns of potentially different data types.
* **Lists:** Can hold elements of various types.

```R
# Vector of numbers
numbers <- c(1, 2, 3, 4)
numbers[2]  # Access second element

# Matrix (2 rows, 3 columns)
data_matrix <- matrix(c(1, 2, 3, 4, 5, 6), nrow = 2, ncol = 3)
data_matrix[1, 2]  # Access element in first row, second column

# Data frame with name, age, and gender
data_df <- data.frame(Name = c("John", "Jane"), Age = c(30, 28), Gender = c("M", "F"))
data_df$Name  # Access Name column
```

### 5. Control Flow

* **If-Else Statements:** Execute code based on conditions.
* **For Loops:** Repeat a block of code a certain number of times.
* **While Loops:** Repeat a block of code as long as a condition is true.

```R
# If statement
age <- 18
if (age >= 18) {
  print("You are an adult.")
} else {
  print("You are not an adult.")
}

# For loop
for (i in 1:5) {
  print(i * 2)  # Print even numbers
}
```

### 6. Functions

* Create reusable blocks of code with defined inputs and outputs.

```R
# Function to add two numbers
add_numbers <- function(a, b) {
  return(a + b)
}

result <- add_numbers(7, 8)
print(result)
```

### 7. Working with Data

* **Reading Data:** Import data from CSV, Excel, and other formats using functions like `read.csv` and `read.xlsx`.
* **Writing Data:** Export data to CSV, Excel, and other formats using functions like `write.csv` and `write.xlsx`.

```R
# Read data from a CSV file
data <- read.csv("data.csv")
head(data)  # View the first few rows

# Write data to a CSV file
write.csv(data, "output.csv")
```

### 8. Visualization

* **Base R Plots:** Create basic plots like scatter plots, histograms, and bar charts.
* **ggplot2 Package:** Offers a more powerful and customizable plotting system (install with `install.packages("ggplot2")`).

```R
# Basic scatter plot (
