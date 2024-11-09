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

---

### Conclusion

In this tutorial, we covered the following concepts and SQL commands:

- **Creating a database** with `CREATE DATABASE`
- **Creating tables** with `CREATE TABLE` and defining columns, including primary keys
- **Inserting data** into tables with `INSERT INTO`
- **Querying data** using `SELECT`
- The importance of **Primary Keys** (unique identifiers for each record) and **Foreign Keys** (which enforce relationships between tables)

These are the foundational concepts of SQL, and mastering them will help you manage and manipulate relational databases effectively.
