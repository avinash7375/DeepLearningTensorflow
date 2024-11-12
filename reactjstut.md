Here's a step-by-step tutorial on how to build a frontend for an eCommerce website using React.js:

---

### **Step 1: Setting Up the Project**

1. **Install Node.js and npm**  
   Ensure Node.js and npm are installed on your system. [Download Node.js](https://nodejs.org/).

2. **Create a New React App**  
   Run the following commands to create a new React app:  
   ```bash
   npx create-react-app ecommerce-frontend
   cd ecommerce-frontend
   npm start
   ```

3. **Install Required Libraries**  
   Install additional dependencies for styling and routing:  
   ```bash
   npm install react-router-dom axios bootstrap
   npm install @reduxjs/toolkit react-redux
   ```

---

### **Step 2: Folder Structure**
Organize your project into folders:
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
├── App.js
└── index.js
```

---

### **Step 3: Building Components**

1. **Header Component**
   ```jsx
   // src/components/Header.js
   import React from 'react';
   import { Link } from 'react-router-dom';

   const Header = () => (
       <nav className="navbar navbar-expand-lg navbar-light bg-light">
           <div className="container">
               <Link className="navbar-brand" to="/">ShopMate</Link>
               <ul className="navbar-nav ml-auto">
                   <li className="nav-item">
                       <Link className="nav-link" to="/cart">Cart</Link>
                   </li>
               </ul>
           </div>
       </nav>
   );

   export default Header;
   ```

2. **Footer Component**
   ```jsx
   // src/components/Footer.js
   import React from 'react';

   const Footer = () => (
       <footer className="bg-dark text-white text-center py-3">
           <p>&copy; 2024 ShopMate. All Rights Reserved.</p>
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
           <img src={product.image} className="card-img-top" alt={product.name} />
           <div className="card-body">
               <h5 className="card-title">{product.name}</h5>
               <p className="card-text">${product.price}</p>
               <button className="btn btn-primary" onClick={() => onAddToCart(product)}>Add to Cart</button>
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
       <div className="row">
           {products.map(product => (
               <div className="col-md-4" key={product.id}>
                   <ProductCard product={product} onAddToCart={onAddToCart} />
               </div>
           ))}
       </div>
   );

   export default ProductList;
   ```

---

### **Step 4: Pages**

1. **Home Page**
   ```jsx
   // src/pages/HomePage.js
   import React, { useState, useEffect } from 'react';
   import ProductList from '../components/ProductList';
   import axios from 'axios';

   const HomePage = () => {
       const [products, setProducts] = useState([]);

       useEffect(() => {
           axios.get('/api/products')
               .then(response => setProducts(response.data))
               .catch(error => console.error(error));
       }, []);

       const handleAddToCart = (product) => {
           console.log('Add to cart:', product);
       };

       return (
           <div className="container mt-4">
               <h1>Our Products</h1>
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
       <div className="container mt-4">
           <h1>Your Cart</h1>
           <p>Cart functionality will be implemented here.</p>
       </div>
   );

   export default CartPage;
   ```

3. **404 Page**
   ```jsx
   // src/pages/NotFoundPage.js
   import React from 'react';

   const NotFoundPage = () => (
       <div className="container mt-4 text-center">
           <h1>404 - Page Not Found</h1>
       </div>
   );

   export default NotFoundPage;
   ```

---

### **Step 5: Routing**

1. **App.js**
   ```jsx
   import React from 'react';
   import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
   import Header from './components/Header';
   import Footer from './components/Footer';
   import HomePage from './pages/HomePage';
   import CartPage from './pages/CartPage';
   import NotFoundPage from './pages/NotFoundPage';

   const App = () => (
       <Router>
           <Header />
           <main>
               <Switch>
                   <Route exact path="/" component={HomePage} />
                   <Route path="/cart" component={CartPage} />
                   <Route component={NotFoundPage} />
               </Switch>
           </main>
           <Footer />
       </Router>
   );

   export default App;
   ```

---

### **Step 6: Add Redux (Optional)**

1. **Store Setup**
   ```javascript
   // src/store/store.js
   import { configureStore } from '@reduxjs/toolkit';
   import cartSlice from './cartSlice';

   export default configureStore({
       reducer: {
           cart: cartSlice,
       },
   });
   ```

2. **Cart Slice**
   ```javascript
   // src/store/cartSlice.js
   import { createSlice } from '@reduxjs/toolkit';

   const cartSlice = createSlice({
       name: 'cart',
       initialState: [],
       reducers: {
           addToCart: (state, action) => {
               state.push(action.payload);
           },
       },
   });

   export const { addToCart } = cartSlice.actions;
   export default cartSlice.reducer;
   ```

3. **Provide Store**
   ```jsx
   // src/index.js
   import React from 'react';
   import ReactDOM from 'react-dom';
   import { Provider } from 'react-redux';
   import store from './store/store';
   import App from './App';

   ReactDOM.render(
       <Provider store={store}>
           <App />
       </Provider>,
       document.getElementById('root')
   );
   ```

---

This gives you a functional eCommerce frontend with React.js. Customize further by adding features like product filtering, payment integration, and API connections!
