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
## R Programming: A Basic to Intermediate Guide (Continued)

This guide provides a foundation for R programming. We'll delve deeper into some key areas:

### 8\. Visualization (Continued)

**Base R Plots:**

```r
# Example: Scatter plot
plot(x = iris$Sepal.Length, y = iris$Sepal.Width, main = "Sepal Length vs Width")
```

**ggplot2 Package:**

  - Create complex and visually appealing plots with a focus on grammar of graphics.
  - Explore resources like the ggplot2 documentation ([https://ggplot2.tidyverse.org/](https://www.google.com/url?sa=E&source=gmail&q=https://ggplot2.tidyverse.org/)) and online tutorials for in-depth usage.

### 9\. Data Wrangling

  * **Data Cleaning:** Handle missing values, outliers, and inconsistencies.
  * **Data Transformation:** Reshape data for analysis (e.g., merging datasets, creating new variables).
  * **Packages:** Utilize packages like `dplyr` for efficient data manipulation.

<!-- end list -->

```r
# Example: Removing missing values
library(dplyr)  # Load dplyr package

# Create a data frame with missing values
data <- data.frame(x = c(1, NA, 3), y = c(4, 5, NA))

# Remove rows with missing values (complete.cases)
clean_data <- data[!is.na(data$x), ]

# Alternatively, fill missing values (replace with mean)
data$x <- replace(data$x, is.na(data$x), mean(data$x, na.rm = TRUE))
```

### 10\. Statistical Analysis

  * **Descriptive Statistics:** Calculate measures like mean, median, standard deviation.
  * **Hypothesis Testing:** Test hypotheses about data relationships.
  * **Linear Regression:** Model relationships between variables.
  * **Packages:** Leverage packages like `stats` and `lm` for statistical computations.

<!-- end list -->

```r
# Example: Descriptive statistics
library(stats)

# Calculate mean, median, and standard deviation
summary(iris$Sepal.Length)
```

## Further Exploration in R Programming

### Advanced Data Wrangling with dplyr

* **Piping Operator (`%>%`)**: Chain operations together for cleaner code:

```R
iris %>%
  filter(Sepal.Length > 7) %>%
  select(Sepal.Length, Sepal.Width) %>%
  mutate(Ratio = Sepal.Length / Sepal.Width)
```

* **Grouped Operations**: Aggregate data by groups:

```R
iris %>%
  group_by(Species) %>%
  summarize(Mean.Sepal.Length = mean(Sepal.Length))
```

* **Joins**: Combine datasets based on common columns:

```R
# Assuming two data frames: df1 and df2
merged_data <- left_join(df1, df2, by = "common_column")
```

### Statistical Modeling and Machine Learning

* **Linear Regression**: Model linear relationships:

```R
model <- lm(Sepal.Width ~ Sepal.Length, data = iris)
summary(model)
```

* **Generalized Linear Models (GLMs)**: For non-normal response variables (e.g., logistic regression for binary outcomes):

```R
model <- glm(Species ~ Sepal.Length + Sepal.Width, data = iris, family = binomial(link = "logit"))
summary(model)
```

* **Decision Trees and Random Forests**: For classification and regression tasks:

```R
library(rpart)
library(randomForest)

# Decision tree
tree_model <- rpart(Species ~ Sepal.Length + Sepal.Width, data = iris)
plot(tree_model)
text(tree_model)

# Random forest
rf_model <- randomForest(Species ~ Sepal.Length + Sepal.Width, data = iris)
print(rf_model)
```

### Time Series Analysis

* **Time Series Objects**: Create and manipulate time series data:

```R
library(ts)

# Create a time series
time_series <- ts(data, start = c(2010, 1), frequency = 12)
```

* **Smoothing and Forecasting**: Apply techniques like moving averages, exponential smoothing, ARIMA models:

```R
# Moving average
smoothed_data <- ma(time_series, order = 12)

# ARIMA model
model <- arima(time_series, order = c(1, 0, 0))
forecast <- forecast(model, h = 12)
plot(forecast)
```

### Visualization with ggplot2

* **Faceting**: Create multiple plots based on a variable:

```R
ggplot(iris, aes(x = Sepal.Length, y = Sepal.Width)) +
  geom_point() +
  facet_wrap(~ Species)
```

* **Themes**: Customize plot appearance:

```R
ggplot(iris, aes(x = Sepal.Length, y = Sepal.Width)) +
  geom_point() +
  theme_minimal()
```

* **Annotations**: Add text, lines, and shapes:

```R
ggplot(iris, aes(x = Sepal.Length, y = Sepal.Width)) +
  geom_point() +
  geom_text(aes(label = Species), vjust = -0.5)
```

### Interactive Visualization with Shiny

* **Create interactive web applications**:

```R
library(shiny)

ui <- fluidPage(
  textInput("text", "Enter text"),
  textOutput("output")
)

server <- function(input, output) {
  output$output <- renderText({
    paste("You entered:", input$text)
  })
}

shinyApp(ui, server)
```

Remember to explore additional packages and resources to expand your R programming skills.


