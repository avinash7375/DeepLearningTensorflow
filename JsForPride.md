
## *Number Object*

In JavaScript, numbers are primitive values, but they can also be wrapped in a Number object.

*Creating a Number Object*

You can create a Number object using the `Number()` constructor:

```
let num = new Number(10);
console.log(num); // Output: [Number: 10]
```

*Number Properties and Methods*

Here are some commonly used properties and methods of the Number object:

- `MAX_VALUE`: The largest possible number in JavaScript.
- `MIN_VALUE`: The smallest possible number in JavaScript.
- `NaN`: Not a Number.
- `POSITIVE_INFINITY`: Positive infinity.
- `NEGATIVE_INFINITY`: Negative infinity.
- `isInteger()`: Returns true if the number is an integer.
- `isSafeInteger()`: Returns true if the number is a safe integer.
- `toExponential()`: Returns the number in exponential notation.
- `toFixed()`: Returns the number as a fixed-point number.
- `toPrecision()`: Returns the number as a string, with a specified number of digits.

*Examples*

```
console.log(Number.MAX_VALUE); // Output: 1.7976931348623157e+308
console.log(Number.MIN_VALUE); // Output: 5e-324

let num = 10.5;
console.log(num.toExponential()); // Output: "1.05e+1"
console.log(num.toFixed(2)); // Output: "10.50"
console.log(num.toPrecision(3)); // Output: "10.5"
```

## *Boolean Object*

In JavaScript, booleans are primitive values, but they can also be wrapped in a Boolean object.

*Creating a Boolean Object*

You can create a Boolean object using the `Boolean()` constructor:

```
let bool = new Boolean(true);
console.log(bool); // Output: [Boolean: true]
```

*Boolean Properties and Methods*

Here are some commonly used properties and methods of the Boolean object:

- `valueOf()`: Returns the primitive value of the boolean.
- `toString()`: Returns the string representation of the boolean.

*Examples*

```
let bool = new Boolean(true);
console.log(bool.valueOf()); // Output: true
console.log(bool.toString()); // Output: "true"
```
## String
*Creating a String Object*

You can create a String object using the `String()` constructor:

```
let str = new String("Hello, World!");
console.log(str); // Output: [String: 'Hello, World!']
```

*String Properties and Methods*

Here are some commonly used properties and methods of the String object:

*Properties:*

- `length`: Returns the length of the string.

*Methods:*

- `charAt()`: Returns the character at the specified index.
- `charCodeAt()`: Returns the Unicode value of the character at the specified index.
- `concat()`: Concatenates two or more strings.
- `indexOf()`: Returns the index of the first occurrence of the specified value.
- `lastIndexOf()`: Returns the index of the last occurrence of the specified value.
- `localeCompare()`: Compares two strings in a specific locale.
- `match()`: Searches for a match between a string and a regular expression.
- `replace()`: Replaces some or all matches of a pattern in a string.
- `search()`: Searches for a match between a string and a regular expression.
- `slice()`: Extracts a section of a string.
- `split()`: Splits a string into an array of substrings.
- `substr()`: Returns the characters in a string beginning at the specified location.
- `substring()`: Returns the characters in a string between two indexes.
- `toLowerCase()`: Converts a string to lowercase.
- `toUpperCase()`: Converts a string to uppercase.
- `trim()`: Removes whitespace from both ends of a string.

*Examples:*

```
let str = "Hello, World!";

console.log(str.length); // Output: 13
console.log(str.charAt(0)); // Output: "H"
console.log(str.indexOf("World")); // Output: 7
console.log(str.replace("World", "Universe")); // Output: "Hello, Universe!"
console.log(str.toUpperCase()); // Output: "HELLO, WORLD!"
console.log(str.trim()); // Output: "Hello, World!" (removes whitespace)
```
[28/11, 18:02] Meta AI: Here's a concise tutorial on Array objects in JavaScript:

*Creating an Array Object*

You can create an Array object using the `Array()` constructor or the array literal syntax:

```
let arr1 = new Array(1, 2, 3);
let arr2 = [1, 2, 3];
```

*Array Properties and Methods*

Here are some commonly used properties and methods of the Array object:

*Properties:*

- `length`: Returns the number of elements in the array.

*Methods:*

- `concat()`: Concatenates two or more arrays.
- `copyWithin()`: Copies a sequence of array elements within the array.
- `every()`: Returns true if all elements in the array pass the test implemented by the provided function.
- `fill()`: Fills all the elements of an array from a start index to an end index with a static value.
- `filter()`: Creates a new array with all elements that pass the test implemented by the provided function.
- `find()`: Returns the first element in the array that satisfies the provided testing function.
- `findIndex()`: Returns the index of the first element in the array that satisfies the provided testing function.
- `forEach()`: Calls a function once for each element in the array.
- `includes()`: Determines whether an array includes a certain element.
- `indexOf()`: Returns the index of the first occurrence of a value in an array.
- `join()`: Joins all elements of an array into a string.
- `lastIndexOf()`: Returns the index of the last occurrence of a value in an array.
- `map()`: Creates a new array with the results of calling a provided function on every element in the calling array.
- `pop()`: Removes the last element from an array and returns that element.
- `push()`: Adds one or more elements to the end of an array and returns the new length of the array.
- `reduce()`: Applies a function against an accumulator and each element in the array (from left to right) to reduce it to a single output value.
- `reduceRight()`: Applies a function against an accumulator and each element in the array (from right to left) to reduce it to a single output value.
- `reverse()`: Reverses the order of the elements in an array.
- `shift()`: Removes the first element from an array and returns that element.
- `slice()`: Returns a shallow copy of a portion of an array.
- `some()`: Returns true if at least one element in the array passes the test implemented by the provided function.
- `sort()`: Sorts the elements of an array in place and returns the array.
- `splice()`: Adds or removes elements from an array.
- `toLocaleString()`: Returns a string representing the elements of the array.
- `toString()`: Returns a string representing the elements of the array.
- `unshift()`: Adds one or more elements to the beginning of an array and returns the new length of the array.

*Examples:*

```
let arr = [1, 2, 3, 4, 5];

console.log(arr.length); // Output: 5
console.log(arr.indexOf(3)); // Output: 2
console.log(arr.join(", ")); // Output: "1, 2, 3, 4, 5"
console.log(arr.slice(1, 3)); // Output: [2, 3]
console.log(arr.sort()); // Output: [1, 2, 3, 4, 5]
console.log(arr.reverse()); // Output: [5, 4, 3, 2, 1]
```
[28/11, 18:02] Meta AI: Here are some more examples and explanations of Array methods:

*Array Methods*

1. *`concat()`*

Concatenates two or more arrays.

```
let arr1 = [1, 2, 3];
let arr2 = [4, 5, 6];
let arr3 = arr1.concat(arr2);
console.log(arr3); // Output: [1, 2, 3, 4, 5, 6]
```

2. *`every()`*

Returns `true` if all elements in the array pass the test implemented by the provided function.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.every(x => x > 0);
console.log(result); // Output: true
```

3. *`filter()`*

Creates a new array with all elements that pass the test implemented by the provided function.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.filter(x => x % 2 === 0);
console.log(result); // Output: [2, 4]
```

4. *`find()`*

Returns the first element in the array that satisfies the provided testing function.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.find(x => x > 3);
console.log(result); // Output: 4
```

5. *`forEach()`*

Calls a function once for each element in the array.

```
let arr = [1, 2, 3, 4, 5];
arr.forEach(x => console.log(x));
// Output: 1, 2, 3, 4, 5
```

6. *`includes()`*

Determines whether an array includes a certain element.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.includes(3);
console.log(result); // Output: true
```

7. *`indexOf()`*

Returns the index of the first occurrence of a value in an array.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.indexOf(3);
console.log(result); // Output: 2
```

8. *`join()`*

Joins all elements of an array into a string.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.join(", ");
console.log(result); // Output: "1, 2, 3, 4, 5"
```

9. *`map()`*

Creates a new array with the results of calling a provided function on every element in the calling array.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.map(x => x * 2);
console.log(result); // Output: [2, 4, 6, 8, 10]
```

10. *`pop()`*

Removes the last element from an array and returns that element.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.pop();
console.log(result); // Output: 5
console.log(arr); // Output: [1, 2, 3, 4]
```

11. *`push()`*

Adds one or more elements to the end of an array and returns the new length of the array.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.push(6, 7);
console.log(result); // Output: 7
console.log(arr); // Output: [1, 2, 3, 4, 5, 6, 7]
```

12. *`reduce()`*

Applies a function against an accumulator and each element in the array (from left to right) to reduce it to a single output value.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.reduce((acc, current) => acc + current, 0);
console.log(result); // Output: 15
```

13. *`reverse()`*

Reverses the order of the elements in an array.

```
let arr = [1, 2, 3, 4, 5];
arr.reverse();
console.log(arr); // Output: [5, 4, 3, 2, 1]
```

14. *`shift()`*

Removes the first element from an array and returns that element.

```
let arr = [1, 2, 3, 4, 5];
let result = arr.shift
```
