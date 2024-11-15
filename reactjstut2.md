Here's a tutorial for creating a frontend for an eCommerce website using **React.js** without using Bootstrap. Instead, we'll rely on plain **CSS** for styling. 

---

### **Step 1: Setting Up the Project**

1. **Install Node.js and npm**  
   Ensure Node.js and npm are installed. [Download Node.js](https://nodejs.org/).

2. **Create a React App**  
   Run the following commands:  
   ```bash
   npx create-react-app ecommerce-frontend
   cd ecommerce-frontend
   npm start
   ```

3. **Install Required Libraries**  
   Install libraries for routing and state management:  
   ```bash
   npm install react-router-dom axios @reduxjs/toolkit react-redux
   ```

---

### **Step 2: Project Folder Structure**

Organize your project into this structure:
```
src/
├── components/
│   ├── Header.js
│   ├── Footer.js
│   ├── ProductCard.js
│   ├── ProductList.js
│   └── Cart.js
├── pages/
│   ├── HomePage.js
│   ├── ProductPage.js
│   ├── CartPage.js
│   └── NotFoundPage.js
├── store/
│   ├── cartSlice.js
│   └── store.js
├── styles/
│   ├── main.css
│   └── variables.css
├── App.js
└── index.js
```

---

### **Step 3: Add Styling**

1. **CSS Variables for Colors**
   ```css
   /* src/styles/variables.css */
   :root {
       --primary-color: #3498db;
       --secondary-color: #2ecc71;
       --text-color: #333;
       --background-color: #f4f4f9;
   }
   ```

2. **Main Styles**
   ```css
   /* src/styles/main.css */
   body {
       font-family: 'Arial', sans-serif;
       margin: 0;
       padding: 0;
       background-color: var(--background-color);
       color: var(--text-color);
   }

   header, footer {
       background-color: var(--primary-color);
       color: white;
       padding: 10px 20px;
   }

   main {
       padding: 20px;
   }

   .container {
       max-width: 1200px;
       margin: auto;
       padding: 10px;
   }

   .grid {
       display: grid;
       grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
       gap: 20px;
   }

   .card {
       border: 1px solid #ddd;
       border-radius: 5px;
       background: white;
       overflow: hidden;
       box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
   }

   .card img {
       width: 100%;
       height: auto;
   }

   .card-body {
       padding: 10px;
   }

   .btn {
       display: inline-block;
       padding: 10px 15px;
       margin-top: 10px;
       background: var(--primary-color);
       color: white;
       text-decoration: none;
       text-align: center;
       border-radius: 3px;
       transition: background 0.3s;
   }

   .btn:hover {
       background: var(--secondary-color);
   }
   ```

---

### **Step 4: Building Components**

1. **Header**
   ```jsx
   // src/components/Header.js
   import React from 'react';
   import { Link } from 'react-router-dom';

   const Header = () => (
       <header>
           <div className="container">
               <h1><Link to="/" style={{ color: 'white', textDecoration: 'none' }}>ShopMate</Link></h1>
               <nav>
                   <Link className="btn" to="/cart">Cart</Link>
               </nav>
           </div>
       </header>
   );

   export default Header;
   ```

2. **Footer**
   ```jsx
   // src/components/Footer.js
   import React from 'react';

   const Footer = () => (
       <footer>
           <div className="container">
               <p>&copy; 2024 ShopMate. All rights reserved.</p>
           </div>
       </footer>
   );

   export default Footer;
   ```

3. **Product Card**
   ```jsx
   // src/components/ProductCard.js
   import React from 'react';

   const ProductCard = ({ product, onAddToCart }) => (
       <div className="card">
           <img src={product.image} alt={product.name} />
           <div className="card-body">
               <h3>{product.name}</h3>
               <p>${product.price}</p>
               <button className="btn" onClick={() => onAddToCart(product)}>Add to Cart</button>
           </div>
       </div>
   );

   export default ProductCard;
   ```

4. **Product List**
   ```jsx
   // src/components/ProductList.js
   import React from 'react';
   import ProductCard from './ProductCard';

   const ProductList = ({ products, onAddToCart }) => (
       <div className="grid">
           {products.map(product => (
               <ProductCard key={product.id} product={product} onAddToCart={onAddToCart} />
           ))}
       </div>
   );

   export default ProductList;
   ```

---

### **Step 5: Pages**

1. **Home Page**
   ```jsx
   // src/pages/HomePage.js
   import React, { useState, useEffect } from 'react';
   import ProductList from '../components/ProductList';

   const HomePage = () => {
       const [products, setProducts] = useState([]);

       useEffect(() => {
           // Mock data
           setProducts([
               { id: 1, name: 'Laptop', price: 1200, image: '/images/laptop.jpg' },
               { id: 2, name: 'Phone', price: 800, image: '/images/phone.jpg' },
               { id: 3, name: 'Headphones', price: 200, image: '/images/headphones.jpg' },
           ]);
       }, []);

       const handleAddToCart = (product) => {
           console.log('Add to cart:', product);
       };

       return (
           <div className="container">
               <h1>Products</h1>
               <ProductList products={products} onAddToCart={handleAddToCart} />
           </div>
       );
   };

   export default HomePage;
   ```

2. **Cart Page**
   ```jsx
   // src/pages/CartPage.js
   import React from 'react';

   const CartPage = () => (
       <div className="container">
           <h1>Cart</h1>
           <p>Cart functionality will be added here.</p>
       </div>
   );

   export default CartPage;
   ```

---

### **Step 6: Routing**

1. **App.js**
   ```jsx
   import React from 'react';
   import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
   import Header from './components/Header';
   import Footer from './components/Footer';
   import HomePage from './pages/HomePage';
   import CartPage from './pages/CartPage';

   const App = () => (
       <Router>
           <Header />
           <main>
               <Switch>
                   <Route exact path="/" component={HomePage} />
                   <Route path="/cart" component={CartPage} />
               </Switch>
           </main>
           <Footer />
       </Router>
   );

   export default App;
   ```

---

### **Step 7: Running the App**

1. Start the development server:
   ```bash
   npm start
   ```

2. Open your browser and visit:  
   [http://localhost:3000](http://localhost:3000)

---

This approach uses pure CSS to style the components and ensures the design is lightweight and easily customizable. Add more features like filtering, search, or integration with a backend API to enhance functionality.
## ----------------------------------------------------------------------------------------------

**Building an E-commerce Frontend with React: A Comprehensive Tutorial**

**Introduction**

In this tutorial, we'll build a basic e-commerce frontend using React. We'll cover essential components like product cards, a shopping cart, and a checkout page. We'll use React's state management and routing features to create a dynamic and interactive user experience.

**Project Setup**

1. **Create a New React App:**
   ```bash
   npx create-react-app ecommerce-app
   ```
2. **Navigate to the Project Directory:**
   ```bash
   cd ecommerce-app
   ```

**Component Structure**

Let's break down the components we'll need:

1. **ProductCard:** Displays information about a product, including its image, name, price, and a "Add to Cart" button.
2. **ProductList:** Renders a list of ProductCard components.
3. **ShoppingCart:** Displays the items added to the cart and provides options to remove items and proceed to checkout.
4. **CheckoutPage:** Displays the final order details and a "Place Order" button.
5. **Navbar:** Provides navigation links to different parts of the application.

**Code Implementation**

**ProductCard.js:**

```javascript
import React from 'react';

const ProductCard = ({ product }) => {
  return (
    <div className="product-card">
      <img src={product.image} alt={product.name} />
      <h3>{product.name}</h3>
      <p>${product.price}</p>
      <button onClick={() => addToCart(product)}>Add to Cart</button>
    </div>
  );
};

export default ProductCard;
```

**ProductList.js:**

```javascript
import React from 'react';
import ProductCard from './ProductCard';

const ProductList = ({ products }) => {
  return (
    <div className="product-list">
      {products.map((product) => (
        <ProductCard key={product.id} product={product} />
      ))}
    </div>
  );
};

export default ProductList;
```

**ShoppingCart.js:**

```javascript
import React, { useState, useContext } from 'react';
import { CartContext } from './CartContext';

const ShoppingCart = () => {
  const { cart, removeFromCart, checkout } = useContext(CartContext);

  return (
    <div className="shopping-cart">
      <h2>Shopping Cart</h2>
      {cart.length === 0 ? (
        <p>Your cart is empty.</p>
      ) : (
        <ul>
          {cart.map((item) => (
            <li key={item.id}>
              {item.name} - ${item.price}
              <button onClick={() => removeFromCart(item.id)}>Remove</button>
            </li>
          ))}
        </ul>
      )}
      <button onClick={checkout}>Checkout</button>
    </div>
  );
};

export default ShoppingCart;
```

**CheckoutPage.js:**

```javascript
import React, { useContext } from 'react';
import { CartContext } from './CartContext';

const CheckoutPage = () => {
  const { cart, checkout } = useContext(CartContext);

  return (
    <div className="checkout-page">
      <h2>Checkout</h2>
      {/* Display order summary here */}
      <button onClick={checkout}>Place Order</button>
    </div>
  );
};

export default CheckoutPage;
```

**Navbar.js:**

```javascript
import React from 'react';
import { Link } from 'react-router-dom';

const Navbar = () => {
  return (
    <nav>
      <Link to="/">Home</Link>
      <Link to="/cart">Cart</Link>
      <Link to="/checkout">Checkout</Link>
    </nav>
  );
};

export default Navbar;
```

**App.js:**

```javascript
import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './Navbar';
import ProductList from './ProductList';
import ShoppingCart from './ShoppingCart';
import CheckoutPage from './CheckoutPage';

const CartContext = React.createContext();

function App() {
  const [cart, setCart] = useState([]);

  const addToCart = (product) => {
    setCart([...cart, product]);
  };

  const removeFromCart = (productId) => {
```


## --------------------------------------------------------------
## File Structure for the E-commerce Frontend

Here's a suggested file structure for your React e-commerce application:

```
ecommerce-app/
  public/
    index.html
  src/
    App.js
    components/
      Navbar.js
      ProductCard.js
      ProductList.js
      ShoppingCart.js
      CheckoutPage.js
    CartContext.js
    index.css
    index.js
```

**Explanation of the Structure:**

- **public/index.html:** This file serves as the entry point for your web application. It includes basic HTML structure and a script tag to load your React app.
- **src/App.js:** This is the main component of your application. It sets up the routing and provides the context provider for the shopping cart.
- **src/components/:** This folder contains all the functional components used in your app, including:
  - **Navbar.js:** Handles navigation between different pages.
  - **ProductCard.js:** Displays information about a single product.
  - **ProductList.js:** Renders a list of ProductCard components.
  - **ShoppingCart.js:** Displays the items in the cart and provides options to remove items and proceed to checkout.
  - **CheckoutPage.js:** Displays the final order details and a "Place Order" button.
- **src/CartContext.js:** This file defines the context provider for managing the shopping cart state.
- **src/index.css:** This file contains global CSS styles for your application.
- **src/index.js:** This file renders the App component and connects it to the DOM.

Remember to install the necessary dependencies using npm or yarn:

```bash
npm install react react-dom react-router-dom
```

With this structure, you can easily organize your code and maintain a clean and scalable e-commerce frontend. 
