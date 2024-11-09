### SQL Tutorial: Basic Commands, Creating Databases, Tables, and Inserting Data

In this tutorial, we will cover some of the basic SQL commands and concepts including how to:

- Create a database
- Create tables
- Insert data into tables
- Understand Primary and Foreign keys and their uses

Let’s get started!

---

### 1. **Creating a Database**

The first step when working with SQL is to create a database. You can think of a database as a container that holds your data, in the form of tables.

#### Command: `CREATE DATABASE`

```sql
CREATE DATABASE SchoolDB;
```

This command creates a database called `SchoolDB`. After creating the database, you would typically want to use it.

#### Command: `USE`

```sql
USE SchoolDB;
```

This command selects the `SchoolDB` database as the active database, so that all subsequent commands will be executed within it.

---

### 2. **Creating Tables**

After creating a database, the next step is to create tables. Tables are used to store data in a structured way. Each table consists of columns and rows.

#### Command: `CREATE TABLE`

Here's an example of how to create a table for storing student information:

```sql
CREATE TABLE Students (
    student_id INT PRIMARY KEY,   -- Unique identifier for each student
    first_name VARCHAR(50),       -- First name of the student
    last_name VARCHAR(50),        -- Last name of the student
    date_of_birth DATE,           -- Date of birth of the student
    email VARCHAR(100)            -- Email address of the student
);
```

Explanation of the columns:
- `student_id`: An integer column, marked as the **Primary Key**. It uniquely identifies each student.
- `first_name` and `last_name`: Strings that store the student's first and last names.
- `date_of_birth`: A date column for the student's date of birth.
- `email`: A string column for the student's email address.

### 3. **Inserting Data into a Table**

Once a table is created, you can add data to it using the `INSERT INTO` statement.

#### Command: `INSERT INTO`

```sql
INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email)
VALUES (1, 'John', 'Doe', '2000-05-15', 'john.doe@example.com');

INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email)
VALUES (2, 'Jane', 'Smith', '2001-08-22', 'jane.smith@example.com');
```

This command inserts two rows into the `Students` table with the details for two students.

### 4. **Querying Data**

To see the data in your table, you can use the `SELECT` statement.

#### Command: `SELECT`

```sql
SELECT * FROM Students;
```

This will return all rows and columns from the `Students` table. You can also specify which columns to return:

```sql
SELECT first_name, last_name FROM Students;
```

This will return only the `first_name` and `last_name` columns.

---

### 5. **Primary Key and Foreign Key**

#### What is a Primary Key?

- A **Primary Key** is a column (or a combination of columns) that uniquely identifies each row in a table.
- It cannot contain `NULL` values.
- Each table can only have one **Primary Key**.

In the `Students` table above, `student_id` is the **Primary Key**, because each student has a unique ID. This helps to uniquely identify each student and avoid duplicate records.

#### Example of Primary Key:

```sql
CREATE TABLE Courses (
    course_id INT PRIMARY KEY,       -- Unique identifier for each course
    course_name VARCHAR(100),        -- Name of the course
    credits INT                     -- Number of credits for the course
);
```

Here, `course_id` is the **Primary Key** of the `Courses` table, ensuring each course has a unique identifier.

#### What is a Foreign Key?

- A **Foreign Key** is a column (or a set of columns) that establishes a relationship between two tables. 
- It refers to the **Primary Key** of another table.
- The purpose of a **Foreign Key** is to maintain referential integrity between the two tables.

For example, if we want to link students to the courses they enroll in, we would need a **Foreign Key** in one table (e.g., `Enrollments`) that references the `student_id` in the `Students` table.

#### Example of Foreign Key:

Let's create an `Enrollments` table that tracks which student is enrolled in which course.

```sql
CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY,       -- Unique identifier for each enrollment
    student_id INT,                      -- The ID of the student
    course_id INT,                       -- The ID of the course
    enrollment_date DATE,                -- The date the student enrolled
    FOREIGN KEY (student_id) REFERENCES Students(student_id),  -- Foreign Key
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)     -- Foreign Key
);
```

Here:
- `student_id` is a **Foreign Key** that refers to the `student_id` in the `Students` table.
- `course_id` is a **Foreign Key** that refers to the `course_id` in the `Courses` table.

By using foreign keys, we ensure that every enrollment record corresponds to a valid student and a valid course.

---

### 6. **Why Use Primary and Foreign Keys?**

#### Primary Key:
- **Uniqueness**: The primary key guarantees that each record in a table is unique.
- **Data Integrity**: It helps maintain consistency and accuracy in the database by ensuring no duplicate rows.

#### Foreign Key:
- **Referential Integrity**: A foreign key ensures that a record in one table corresponds to a valid record in another table, maintaining the logical relationships between tables.
- **Prevent Orphan Records**: By enforcing the foreign key relationship, you prevent "orphan" records (e.g., an enrollment in a non-existent student or course).

---

### 7. **Updating and Deleting Data**

You can also update or delete data in a table.

#### Update Data:

```sql
UPDATE Students
SET email = 'john.newemail@example.com'
WHERE student_id = 1;
```

This command updates the email address of the student with `student_id` 1.

#### Delete Data:

```sql
DELETE FROM Students
WHERE student_id = 2;
```

This command deletes the student with `student_id` 2 from the `Students` table.

### 8. **Alter Table**

The `ALTER TABLE` command allows you to modify the structure of an existing table, such as adding, removing, or changing columns.

#### Add a Column

```sql
ALTER TABLE Students
ADD phone_number VARCHAR(20);
```

This command adds a new column `phone_number` to the `Students` table.

#### Modify a Column

You can change the definition of an existing column, for example, changing the data type of `phone_number` from `VARCHAR(20)` to `VARCHAR(30)`.

```sql
ALTER TABLE Students
MODIFY phone_number VARCHAR(30);
```

#### Drop a Column

To remove a column from a table:

```sql
ALTER TABLE Students
DROP COLUMN phone_number;
```

#### Rename a Column

```sql
ALTER TABLE Students
RENAME COLUMN email TO student_email;
```

---

### 9. **Dropping a Table**

If you no longer need a table, you can remove it using the `DROP TABLE` command.

#### Command: `DROP TABLE`

```sql
DROP TABLE Enrollments;
```

This command deletes the `Enrollments` table and all of its data permanently. **Be cautious** when using `DROP` as it cannot be undone.

---

### 10. **Indexing**

An index in SQL is used to speed up query execution. It is particularly useful for columns that are frequently searched or used in join conditions. While creating an index may improve read performance, it can degrade write performance (due to the additional work involved in updating the index).

#### Creating an Index

```sql
CREATE INDEX idx_lastname ON Students(last_name);
```

This creates an index on the `last_name` column of the `Students` table. Now, searches based on `last_name` will be faster.

#### Dropping an Index

To remove an index, you can use the `DROP INDEX` command.

```sql
DROP INDEX idx_lastname;
```

Note that the syntax for dropping an index may vary slightly depending on the database system (e.g., MySQL, PostgreSQL, SQL Server).

---

### 11. **Constraints**

Constraints are rules that help ensure the integrity of data in your database. We already touched on **Primary Keys** and **Foreign Keys**, but here are some more common constraints.

#### NOT NULL

A `NOT NULL` constraint ensures that a column cannot have a `NULL` value.

```sql
CREATE TABLE Employees (
    employee_id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,   -- Name cannot be NULL
    department VARCHAR(50)        -- Department can be NULL
);
```

#### UNIQUE

The `UNIQUE` constraint ensures that all values in a column are distinct.

```sql
CREATE TABLE Employees (
    employee_id INT PRIMARY KEY,
    email VARCHAR(100) UNIQUE   -- Email must be unique
);
```

#### CHECK

The `CHECK` constraint ensures that the values in a column meet a specific condition.

```sql
CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    price DECIMAL(10, 2),
    CHECK (price > 0)   -- Price must be greater than 0
);
```

#### DEFAULT

The `DEFAULT` constraint is used to provide a default value for a column if no value is specified during an `INSERT`.

```sql
CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    order_date DATE DEFAULT CURRENT_DATE   -- Default to the current date
);
```

---

### 12. **Joins**

In SQL, joins are used to combine rows from two or more tables based on a related column. Here are the most common types of joins:

#### INNER JOIN

The `INNER JOIN` returns only the rows where there is a match in both tables.

```sql
SELECT Students.first_name, Students.last_name, Courses.course_name
FROM Students
INNER JOIN Enrollments ON Students.student_id = Enrollments.student_id
INNER JOIN Courses ON Enrollments.course_id = Courses.course_id;
```

This query returns a list of students along with the courses they are enrolled in.

#### LEFT JOIN (or LEFT OUTER JOIN)

The `LEFT JOIN` returns all rows from the left table (in this case, `Students`) and the matching rows from the right table (`Courses`). If there’s no match, the result will contain `NULL` for the right table’s columns.

```sql
SELECT Students.first_name, Students.last_name, Courses.course_name
FROM Students
LEFT JOIN Enrollments ON Students.student_id = Enrollments.student_id
LEFT JOIN Courses ON Enrollments.course_id = Courses.course_id;
```

This will return all students, including those who are not enrolled in any courses (in which case `course_name` will be `NULL`).

#### RIGHT JOIN (or RIGHT OUTER JOIN)

The `RIGHT JOIN` is the opposite of the `LEFT JOIN` — it returns all rows from the right table (e.g., `Courses`) and the matching rows from the left table (e.g., `Students`). If no match exists, `NULL` values will appear for the left table's columns.

```sql
SELECT Students.first_name, Students.last_name, Courses.course_name
FROM Students
RIGHT JOIN Enrollments ON Students.student_id = Enrollments.student_id
RIGHT JOIN Courses ON Enrollments.course_id = Courses.course_id;
```

#### FULL OUTER JOIN

A `FULL OUTER JOIN` returns all rows when there is a match in either the left or right table. Rows with no match will have `NULL` values for the non-matching side.

```sql
SELECT Students.first_name, Students.last_name, Courses.course_name
FROM Students
FULL OUTER JOIN Enrollments ON Students.student_id = Enrollments.student_id
FULL OUTER JOIN Courses ON Enrollments.course_id = Courses.course_id;
```

---

### 13. **Group By and Aggregate Functions**

SQL provides aggregate functions like `COUNT()`, `SUM()`, `AVG()`, `MAX()`, and `MIN()` to perform calculations on data. You often use these functions in combination with the `GROUP BY` clause.

#### COUNT

```sql
SELECT COUNT(*) AS total_students FROM Students;
```

This returns the total number of students in the `Students` table.

#### SUM

```sql
SELECT course_id, SUM(credits) AS total_credits
FROM Courses
GROUP BY course_id;
```

This query calculates the total number of credits for each course.

#### AVG

```sql
SELECT AVG(price) AS average_price
FROM Products;
```

This returns the average price of all products in the `Products` table.

#### GROUP BY

The `GROUP BY` statement groups rows that have the same values into summary rows, like "total" or "average" calculations.

```sql
SELECT student_id, COUNT(course_id) AS total_courses
FROM Enrollments
GROUP BY student_id;
```

This query gives the number of courses each student is enrolled in.

---

### 14. **HAVING Clause**

The `HAVING` clause is used to filter records after the `GROUP BY` has been applied. It is similar to the `WHERE` clause but works with grouped data.

```sql
SELECT student_id, COUNT(course_id) AS total_courses
FROM Enrollments
GROUP BY student_id
HAVING COUNT(course_id) > 2;
```

This query returns the students who are enrolled in more than 2 courses.

---

### 15. **Subqueries**

A subquery is a query inside another query. Subqueries can be used in the `WHERE`, `FROM`, or `SELECT` clauses.

#### Subquery in WHERE Clause

```sql
SELECT first_name, last_name
FROM Students
WHERE student_id IN (SELECT student_id FROM Enrollments WHERE course_id = 101);
```

This query returns the names of students who are enrolled in the course with `course_id` 101.

#### Subquery in FROM Clause

```sql
SELECT subquery.student_id, subquery.total_courses
FROM (SELECT student_id, COUNT(course_id) AS total_courses
      FROM Enrollments
      GROUP BY student_id) AS subquery
WHERE subquery.total_courses > 2;
```

This query returns students who are enrolled in more than 2 courses, using a subquery in the `FROM` clause.

---

### Conclusion

In this extended SQL tutorial, we covered several advanced SQL commands and concepts, including:

- **`ALTER TABLE`** to modify a table
- **Indexes** to improve query performance
- Additional **constraints** like `NOT NULL`, `UNIQUE`, `CHECK`, and `DEFAULT`
- **Joins** to combine data from multiple tables
- **Aggregate functions** (like `COUNT()`, `SUM()`, etc.) and the `GROUP BY` clause
- **Subqueries** to embed queries within queries

These commands help you perform more advanced operations and optimize your database for both data integrity and performance.
