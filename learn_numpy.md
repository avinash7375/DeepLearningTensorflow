## **NumPy Tutorial for Data Analysts**

NumPy (Numerical Python) is a powerful library for numerical computing in Python. It's widely used in data analysis, machine learning, and scientific computing.

---

### **Lesson 1: Introduction to NumPy**

- **Why Use NumPy?**
  - Efficient multi-dimensional array operations.
  - Broad mathematical functions (linear algebra, statistics, etc.).
  - Foundation for libraries like Pandas, SciPy, and Scikit-Learn.

---

### **Lesson 2: Installing NumPy**

```bash
pip install numpy
```

---

### **Lesson 3: Importing NumPy**

```python
import numpy as np
```

---

### **Lesson 4: Creating Arrays**

#### **1. 1D Array**
```python
import numpy as np

arr = np.array([1, 2, 3, 4, 5])
print(arr)
print(type(arr))  # Output: <class 'numpy.ndarray'>
```

#### **2. 2D Array**
```python
matrix = np.array([[1, 2, 3], [4, 5, 6]])
print(matrix)
```

#### **3. Arrays with Specific Functions**
```python
zeros = np.zeros((3, 3))   # 3x3 array of zeros
ones = np.ones((2, 4))     # 2x4 array of ones
identity = np.eye(4)       # 4x4 Identity matrix
random = np.random.rand(3, 2)  # 3x2 array with random numbers

print(zeros)
print(ones)
print(identity)
print(random)
```

---

### **Lesson 5: Array Indexing & Slicing**

```python
arr = np.array([10, 20, 30, 40, 50])
print(arr[2])      # Accessing the third element
print(arr[1:4])    # Slicing elements from index 1 to 3
print(arr[-1])     # Accessing the last element
```

```python
matrix = np.array([[1, 2, 3], [4, 5, 6], [7, 8, 9]])
print(matrix[1, 2])      # Element at 2nd row, 3rd column
print(matrix[:, 1])      # All rows, 2nd column
print(matrix[0:2, 0:2])  # Submatrix of the first 2 rows and 2 columns
```

---

### **Lesson 6: Array Operations**

#### **1. Element-wise Operations**
```python
arr1 = np.array([1, 2, 3])
arr2 = np.array([4, 5, 6])

print(arr1 + arr2)   # [5 7 9]
print(arr1 * arr2)   # [4 10 18]
print(arr1 / 2)      # [0.5 1.  1.5]
```

#### **2. Matrix Multiplication**
```python
a = np.array([[1, 2], [3, 4]])
b = np.array([[5, 6], [7, 8]])

result = np.dot(a, b)
print(result)  # [[19 22], [43 50]]
```

---

### **Lesson 7: Aggregations & Statistics**

```python
data = np.array([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])

print("Sum:", np.sum(data))           # Sum of all elements
print("Mean:", np.mean(data))         # Mean
print("Median:", np.median(data))     # Median
print("Standard Deviation:", np.std(data))  # Standard Deviation
print("Maximum:", np.max(data))       # Max value
print("Minimum:", np.min(data))       # Min value
```

---

### **Lesson 8: Reshaping & Flattening Arrays**

#### **1. Reshaping**
```python
arr = np.array([1, 2, 3, 4, 5, 6])
reshaped = arr.reshape(2, 3)  # Reshape to 2x3 matrix
print(reshaped)
```

#### **2. Flattening**
```python
matrix = np.array([[1, 2], [3, 4], [5, 6]])
flattened = matrix.flatten()
print(flattened)  # [1 2 3 4 5 6]
```

---

### **Lesson 9: Filtering & Boolean Indexing**

```python
data = np.array([5, 10, 15, 20, 25])
filter = data > 10
print(data[filter])  # [15 20 25]
```

---

### **Lesson 10: Sorting & Searching**

#### **1. Sorting**
```python
unsorted = np.array([10, 3, 5, 8, 1])
sorted_arr = np.sort(unsorted)
print(sorted_arr)  # [1 3 5 8 10]
```

#### **2. Searching**
```python
arr = np.array([1, 2, 3, 4, 5])
index = np.where(arr == 3)
print(index)  # (array([2]),)
```

---

### **Lesson 11: Handling Missing Data (NaN)**

```python
data = np.array([1, 2, np.nan, 4, 5])
print(np.isnan(data))       # [False False  True False False]
print(np.nanmean(data))     # Mean ignoring NaN
```

---

### **Lesson 12: Broadcasting**

```python
arr = np.array([[1, 2, 3], [4, 5, 6]])
scalar = 10
print(arr + scalar)  # Add scalar to all elements
```

---

### **Lesson 13: Saving & Loading Arrays**

#### **1. Saving to a File**
```python
arr = np.array([1, 2, 3, 4, 5])
np.save('array.npy', arr)
```

#### **2. Loading from a File**
```python
loaded_arr = np.load('array.npy')
print(loaded_arr)
```

---

### **Lesson 14: NumPy in Data Analysis Workflow**

#### **1. Basic Data Transformation:**
```python
import pandas as pd

data = np.random.randn(1000, 3)  # Random 1000 rows, 3 columns
df = pd.DataFrame(data, columns=['A', 'B', 'C'])
print(df.describe())  # Quick statistical summary
```

---

These lessons provide a solid foundation for using NumPy in data analysis. Let me know if you'd like to explore more advanced topics!
