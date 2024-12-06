---

## **Module 5: Machine Learning**

### **1. Supervised Learning**
#### **1.1 Linear Regression**
- Basics of regression analysis
- Gradient Descent and loss functions
- Implementation in Python using `sklearn`

#### **1.2 Logistic Regression**
- Difference from Linear Regression
- Sigmoid function and decision boundaries
- Example use case: Binary classification

#### **1.3 Decision Tree**
- Concept of tree splitting and Gini Index
- Visualization and depth control
- Code examples using `sklearn`

#### **1.4 Support Vector Machine (SVM)**
- Kernel trick for non-linear boundaries
- Hyperparameters like C and gamma
- Implementation using `sklearn`

#### **1.5 Naive Bayes**
- Bayes’ theorem explained
- Text classification use case
- Implementation in Python

#### **1.6 K-Nearest Neighbors (KNN)**
- Lazy learning method
- Distance metrics: Euclidean, Manhattan
- Implementation in Python

#### **1.7 Random Forest**
- Ensemble learning concept
- How it reduces overfitting
- Implementation using `sklearn`

### **2. Unsupervised Learning**
#### **2.1 K-Means Clustering**
- Objective and clustering mechanism
- Elbow method for optimal clusters
- Code examples using Python

#### **2.2 DBSCAN**
- Density-based clustering
- Detecting noise points
- Implementation using `sklearn`

### **3. Gradient Boosting Algorithms**
#### **3.1 PCA (Principal Component Analysis)**
- Dimensionality reduction explained
- Visualizing reduced dimensions
- Implementation using `sklearn`

#### **3.2 Hierarchical Clustering**
- Dendrograms and linkage criteria
- Agglomerative vs divisive clustering
- Code examples in Python

#### **3.3 GBM, XGBoost, LightGBM, CatBoost**
- Gradient Boosting concepts
- Comparison of algorithms
- Implementation with Python libraries

---

## **Module 6: Deep Learning**

### **1. Basics of Neural Networks**
- Structure of a perceptron
- Activation functions: Sigmoid, ReLU, Tanh
- Forward and backpropagation

### **2. TensorFlow Basics**
- Introduction to TensorFlow and its ecosystem
- Building and training simple models
- TensorFlow vs PyTorch

### **3. Reinforcement Learning**
#### **3.1 Q-Learning**
- Concept of Q-values
- Exploration vs exploitation
- Implementation in Python

#### **3.2 A3C Algorithm**
- Asynchronous Advantage Actor-Critic
- Multi-threading in RL
- Example applications

#### **3.3 Deep Q-Networks**
- Combining RL with deep learning
- Implementation of DQN in TensorFlow

#### **3.4 Deep Deterministic Policy Gradient**
- Policy-based methods
- Using it for continuous action spaces
- Code walkthrough

### **4. Advanced Topics**
- Handling overfitting in deep learning
- Transfer learning with pre-trained models
- Fine-tuning deep networks

---

Would you like me to create detailed code samples or dive deeper into specific topics?


--------------------------------------------------------------------------------------------------------------------------
| **Vision**                               | **Text**                            | **Audio**                             |
|------------------------------------------|-------------------------------------|---------------------------------------|
| Support Vector Machines (SVMs)           | Logistic Regression                 | Gaussian Mixture Models (GMMs)        |
| Decision Trees                           | Naive Bayes                         | k-Nearest Neighbors (k-NN)            |
| Random Forest                            | Support Vector Machines (SVMs)      | Decision Trees                        |
| k-Nearest Neighbors (k-NN)               | Random Forest                       | Random Forest                         |
| Logistic Regression                      | k-Nearest Neighbors (k-NN)          | Hidden Markov Models (HMMs)           |
| Linear Regression (for regression tasks) | Linear Regression                   | Linear Regression                     |
| Multi-Layer Perceptrons (MLPs)           | Multi-Layer Perceptrons (MLPs)      | Multi-Layer Perceptrons (MLPs)        |
--------------------------------------------------------------------------------------------------------------------------

----

### Tutorials for Supervised Learning Algorithms

Shown here **Supervised Learning Algorithms**:

1. **Linear Regression**  
2. **Logistic Regression**  
3. **Decision Tree**  
4. **Support Vector Machine (SVM)**  
5. **Naive Bayes**  
6. **K-Nearest Neighbors (KNN)**  
7. **Random Forest**

---

To make the implementation more professional, we'll refine the structure further by following best practices for real-world machine learning projects. We'll add comments for clarity, modularize the code into functions for reusability, integrate hyperparameter tuning, improve data preprocessing, and ensure readability and maintainability. Below is a more professional approach to solving these problems:

---

### 1. **Linear Regression: Predicting Housing Prices**
**Problem:** Predicting housing prices based on features like area, location, and age.

**Code:**
```python
import pandas as pd
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split
from sklearn.metrics import mean_squared_error
from sklearn.preprocessing import OneHotEncoder
from sklearn.compose import ColumnTransformer
from sklearn.pipeline import Pipeline
from sklearn.impute import SimpleImputer

def load_data(filepath):
    """Load housing data from CSV."""
    return pd.read_csv(filepath)

def preprocess_data(X):
    """Preprocess data by encoding categorical features and imputing missing values."""
    # Categorical feature encoding
    preprocessor = ColumnTransformer(
        transformers=[
            ('location', OneHotEncoder(), ['location'])  # Encoding categorical 'location'
        ],
        remainder='passthrough'  # Keep other columns as they are
    )
    return preprocessor.fit_transform(X)

def build_pipeline():
    """Build a pipeline with preprocessing and model."""
    preprocessor = ColumnTransformer(
        transformers=[
            ('location', OneHotEncoder(), ['location']),
            ('imputer', SimpleImputer(strategy='mean'), ['size', 'age'])
        ],
        remainder='passthrough'
    )

    model = Pipeline(steps=[
        ('preprocessor', preprocessor),
        ('regressor', LinearRegression())
    ])
    return model

def train_and_evaluate(X_train, y_train, X_test, y_test, model):
    """Train the model and evaluate performance."""
    model.fit(X_train, y_train)
    y_pred = model.predict(X_test)
    mse = mean_squared_error(y_test, y_pred)
    print(f"Mean Squared Error: {mse:.2f}")
    return model, mse

# Main execution
if __name__ == "__main__":
    df = load_data('housing_data.csv')
    X = df[['size', 'location', 'age']]
    y = df['price']
    
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)
    
    model = build_pipeline()
    trained_model, mse = train_and_evaluate(X_train, y_train, X_test, y_test, model)
```

---

### 2. **Logistic Regression: Customer Churn Prediction**
**Problem:** Predict if a customer will churn (leave the service).

**Code:**
```python
import pandas as pd
from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score, confusion_matrix
from sklearn.preprocessing import StandardScaler

def load_and_preprocess_data(filepath):
    """Load and preprocess customer churn data."""
    df = pd.read_csv(filepath)
    X = df[['age', 'tenure', 'monthly_spend']]
    y = df['is_churned']
    
    # Standardize numerical features
    scaler = StandardScaler()
    X_scaled = scaler.fit_transform(X)
    
    return X_scaled, y

def train_logistic_regression(X_train, y_train):
    """Train a logistic regression model."""
    model = LogisticRegression(max_iter=200)
    model.fit(X_train, y_train)
    return model

def evaluate_model(y_test, y_pred):
    """Evaluate the model using accuracy and confusion matrix."""
    accuracy = accuracy_score(y_test, y_pred)
    conf_matrix = confusion_matrix(y_test, y_pred)
    print(f"Accuracy: {accuracy:.2f}")
    print(f"Confusion Matrix:\n{conf_matrix}")

# Main execution
if __name__ == "__main__":
    X, y = load_and_preprocess_data('customer_churn.csv')
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)
    
    model = train_logistic_regression(X_train, y_train)
    y_pred = model.predict(X_test)
    evaluate_model(y_test, y_pred)
```

---

### 3. **Decision Tree: Fraud Detection**
**Problem:** Detect fraudulent transactions based on sensor data.

**Code:**
```python
import pandas as pd
from sklearn.tree import DecisionTreeClassifier
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
from sklearn.preprocessing import LabelEncoder

def load_data(filepath):
    """Load transaction data."""
    return pd.read_csv(filepath)

def preprocess_data(df):
    """Encode categorical features."""
    le = LabelEncoder()
    df['location'] = le.fit_transform(df['location'])
    return df[['amount', 'location', 'time']], df['is_fraud']

def train_decision_tree(X_train, y_train):
    """Train a decision tree classifier."""
    model = DecisionTreeClassifier(max_depth=5, random_state=42)
    model.fit(X_train, y_train)
    return model

def evaluate_model(model, X_test, y_test):
    """Evaluate model accuracy."""
    y_pred = model.predict(X_test)
    accuracy = accuracy_score(y_test, y_pred)
    print(f"Accuracy: {accuracy:.2f}")

# Main execution
if __name__ == "__main__":
    df = load_data('transactions.csv')
    X, y = preprocess_data(df)
    
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)
    
    model = train_decision_tree(X_train, y_train)
    evaluate_model(model, X_test, y_test)
```

---

### 4. **Support Vector Machine (SVM): Image Classification**
**Problem:** Classifying clothing images using the Fashion-MNIST dataset.

**Code:**
```python
import numpy as np
from sklearn.svm import SVC
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
from sklearn.decomposition import PCA
from sklearn.datasets import fetch_openml

def load_and_preprocess_data():
    """Load and preprocess Fashion-MNIST data."""
    data = fetch_openml('fashion-mnist', version=1)
    X = np.array(data.data)
    y = np.array(data.target, dtype=int)
    
    # Apply PCA for dimensionality reduction
    pca = PCA(n_components=50)
    X_reduced = pca.fit_transform(X)
    
    return X_reduced, y

def train_svm(X_train, y_train):
    """Train a support vector machine classifier."""
    model = SVC(kernel='linear', C=1)
    model.fit(X_train, y_train)
    return model

def evaluate_model(model, X_test, y_test):
    """Evaluate model accuracy."""
    y_pred = model.predict(X_test)
    accuracy = accuracy_score(y_test, y_pred)
    print(f"Accuracy: {accuracy:.2f}")

# Main execution
if __name__ == "__main__":
    X, y = load_and_preprocess_data()
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)
    
    model = train_svm(X_train, y_train)
    evaluate_model(model, X_test, y_test)
```

---

### 5. **Naive Bayes: Sentiment Analysis**
**Problem:** Classify customer reviews as positive or negative.

**Code:**
```python
import pandas as pd
from sklearn.naive_bayes import MultinomialNB
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score, classification_report

def load_and_preprocess_data(filepath):
    """Load and preprocess text data."""
    df = pd.read_csv(filepath)
    X = df['review']
    y = df['sentiment']
    
    # Convert text to numerical vectors
    vectorizer = CountVectorizer(stop_words='english')
    X_vectorized = vectorizer.fit_transform(X)
    
    return X_vectorized, y

def train_naive_bayes(X_train, y_train):
    """Train a Naive Bayes classifier."""
    model = MultinomialNB()
    model.fit(X_train, y_train)
    return model

def evaluate_model(model, X_test, y_test):
    """Evaluate model accuracy and print classification report."""
    y_pred = model.predict(X_test)
    accuracy = accuracy_score(y_test, y_pred)
    print(f"Accuracy: {accuracy:.2f}")
    print(classification_report(y_test, y_pred))

# Main execution
if __name__ == "__main__":
    X, y = load_and_preprocess_data('customer_reviews.csv')
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)
    
    model = train_naive_bayes(X_train, y_train)
    evaluate_model(model, X_test, y_test)
```

---

### Key Improvements:

- **Modularization:** Code is divided into clear, reusable functions like `load_data()`, `preprocess_data()`, `train_model()`, and `evaluate_model()`, making the code more maintainable and testable.
- **Data Preprocessing:** The preprocessing pipeline is integrated into the function and modularized for flexibility.
- **Pipeline for Training:** More professional and scalable approach with pipelines to handle preprocessing and model training together.
- **Evaluation Metrics:** The code evaluates the model's performance with appropriate metrics (e.g


-----

To enhance the existing code with a **Random Forest** model, let's modify one of the examples (e.g., **Fraud Detection** or **Customer Churn Prediction**) to use a Random Forest instead of a decision tree or logistic regression. Random Forest is an ensemble method that aggregates the predictions from multiple decision trees, providing a more robust and generalized model.

### **Random Forest: Fraud Detection**
**Problem:** Detect fraudulent transactions based on sensor data.

**Updated Code with Random Forest:**
```python
import pandas as pd
from sklearn.ensemble import RandomForestClassifier
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score
from sklearn.preprocessing import LabelEncoder
from sklearn.impute import SimpleImputer

def load_data(filepath):
    """Load transaction data."""
    return pd.read_csv(filepath)

def preprocess_data(df):
    """Encode categorical features and handle missing values."""
    le = LabelEncoder()
    df['location'] = le.fit_transform(df['location'])
    
    # Handle missing values
    imputer = SimpleImputer(strategy='mean')
    df[['amount', 'location', 'time']] = imputer.fit_transform(df[['amount', 'location', 'time']])
    
    return df[['amount', 'location', 'time']], df['is_fraud']

def train_random_forest(X_train, y_train):
    """Train a Random Forest classifier."""
    model = RandomForestClassifier(n_estimators=100, random_state=42)
    model.fit(X_train, y_train)
    return model

def evaluate_model(model, X_test, y_test):
    """Evaluate model accuracy."""
    y_pred = model.predict(X_test)
    accuracy = accuracy_score(y_test, y_pred)
    print(f"Accuracy: {accuracy:.2f}")

# Main execution
if __name__ == "__main__":
    df = load_data('transactions.csv')
    X, y = preprocess_data(df)
    
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)
    
    model = train_random_forest(X_train, y_train)
    evaluate_model(model, X_test, y_test)
```

### **Random Forest: Customer Churn Prediction**
**Problem:** Predict if a customer will churn (leave the service).

**Updated Code with Random Forest:**
```python
import pandas as pd
from sklearn.ensemble import RandomForestClassifier
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score, confusion_matrix
from sklearn.preprocessing import StandardScaler

def load_and_preprocess_data(filepath):
    """Load and preprocess customer churn data."""
    df = pd.read_csv(filepath)
    X = df[['age', 'tenure', 'monthly_spend']]
    y = df['is_churned']
    
    # Standardize numerical features
    scaler = StandardScaler()
    X_scaled = scaler.fit_transform(X)
    
    return X_scaled, y

def train_random_forest(X_train, y_train):
    """Train a Random Forest classifier."""
    model = RandomForestClassifier(n_estimators=100, random_state=42)
    model.fit(X_train, y_train)
    return model

def evaluate_model(y_test, y_pred):
    """Evaluate the model using accuracy and confusion matrix."""
    accuracy = accuracy_score(y_test, y_pred)
    conf_matrix = confusion_matrix(y_test, y_pred)
    print(f"Accuracy: {accuracy:.2f}")
    print(f"Confusion Matrix:\n{conf_matrix}")

# Main execution
if __name__ == "__main__":
    X, y = load_and_preprocess_data('customer_churn.csv')
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)
    
    model = train_random_forest(X_train, y_train)
    y_pred = model.predict(X_test)
    evaluate_model(y_test, y_pred)
```

### Key Improvements with Random Forest:
1. **Ensemble Learning**: Random Forest is an ensemble method that combines multiple decision trees, reducing the risk of overfitting and improving model performance.
2. **Hyperparameter Tuning**: By using `n_estimators=100` in the `RandomForestClassifier`, we set the number of trees in the forest. This can be further fine-tuned using cross-validation.
3. **Random State for Reproducibility**: Set `random_state=42` to ensure the results are reproducible.
4. **Model Evaluation**: We use the **accuracy score** and **confusion matrix** to evaluate model performance.

### Hyperparameter Tuning (Optional):
You can further enhance the model performance using **GridSearchCV** for hyperparameter tuning. For example, tuning the number of trees (`n_estimators`), depth of trees (`max_depth`), and other parameters.

```python
from sklearn.model_selection import GridSearchCV

# Hyperparameter grid
param_grid = {
    'n_estimators': [50, 100, 200],
    'max_depth': [None, 10, 20],
    'min_samples_split': [2, 5, 10]
}

# Create the model
model = RandomForestClassifier(random_state=42)

# Setup GridSearchCV
grid_search = GridSearchCV(estimator=model, param_grid=param_grid, cv=5, verbose=1, n_jobs=-1)
grid_search.fit(X_train, y_train)

# Best model
best_model = grid_search.best_estimator_
y_pred = best_model.predict(X_test)
evaluate_model(y_test, y_pred)
```

---

### Why Random Forest?

- **Reduced Overfitting**: Random Forest mitigates the risk of overfitting (a common issue with single decision trees) by averaging multiple trees.
- **Feature Importance**: It can be used to determine feature importance, which helps in understanding the key drivers of predictions.
- **Robustness**: Random Forest is more robust to noisy data and works well even with missing values or slight data imbalances.

This version is now more professional by making use of Random Forest, modularization, and incorporating best practices such as handling missing values, scaling, and reproducibility.


----

To carry out **hyperparameter tuning** for a **Random Forest** model more professionally, we can integrate best practices, including cross-validation, proper parameter grid search, and using more advanced techniques like **RandomizedSearchCV** for more efficient search, especially for large parameter spaces.

Let's enhance the Random Forest hyperparameter tuning by following these professional steps:

### Key Improvements:
1. **Cross-Validation**: We'll use **cross-validation** to estimate the model's performance more reliably across different subsets of the data.
2. **RandomizedSearchCV**: For large hyperparameter search spaces, **RandomizedSearchCV** is more efficient than **GridSearchCV**, as it samples from the parameter space rather than exhaustively trying all combinations.
3. **Model Evaluation**: Use additional evaluation metrics like **precision**, **recall**, **f1-score**, and **AUC-ROC** for better model assessment.

### Professional Hyperparameter Tuning with Random Forest

```python
import pandas as pd
from sklearn.ensemble import RandomForestClassifier
from sklearn.model_selection import train_test_split, RandomizedSearchCV
from sklearn.metrics import classification_report, roc_auc_score, confusion_matrix
from sklearn.preprocessing import StandardScaler
from scipy.stats import randint

def load_and_preprocess_data(filepath):
    """Load and preprocess the data."""
    df = pd.read_csv(filepath)
    X = df[['age', 'tenure', 'monthly_spend']]
    y = df['is_churned']
    
    # Standardize numerical features
    scaler = StandardScaler()
    X_scaled = scaler.fit_transform(X)
    
    return X_scaled, y

def tune_random_forest(X_train, y_train):
    """Tune Random Forest hyperparameters using RandomizedSearchCV."""
    # Parameter grid
    param_dist = {
        'n_estimators': randint(50, 300),      # Number of trees in the forest
        'max_depth': [None, 10, 20, 30],        # Maximum depth of the trees
        'min_samples_split': randint(2, 20),    # Minimum number of samples required to split a node
        'min_samples_leaf': randint(1, 20),     # Minimum number of samples required at a leaf node
        'max_features': ['auto', 'sqrt', 'log2'],  # Number of features to consider at each split
        'bootstrap': [True, False]              # Whether bootstrap samples are used when building trees
    }
    
    # Initialize the Random Forest model
    rf = RandomForestClassifier(random_state=42)
    
    # RandomizedSearchCV to search over hyperparameters
    random_search = RandomizedSearchCV(estimator=rf, param_distributions=param_dist,
                                       n_iter=100, cv=5, verbose=2, n_jobs=-1, random_state=42)
    
    random_search.fit(X_train, y_train)
    
    # Return the best model found
    return random_search.best_estimator_

def evaluate_model(model, X_test, y_test):
    """Evaluate model with various metrics."""
    y_pred = model.predict(X_test)
    y_prob = model.predict_proba(X_test)[:, 1]
    
    accuracy = model.score(X_test, y_test)
    print(f"Accuracy: {accuracy:.2f}")
    
    print("\nClassification Report:")
    print(classification_report(y_test, y_pred))
    
    # AUC-ROC
    auc_roc = roc_auc_score(y_test, y_prob)
    print(f"AUC-ROC Score: {auc_roc:.2f}")
    
    # Confusion Matrix
    print("\nConfusion Matrix:")
    print(confusion_matrix(y_test, y_pred))

# Main execution
if __name__ == "__main__":
    # Load and preprocess the data
    X, y = load_and_preprocess_data('customer_churn.csv')
    
    # Train-test split
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=42)
    
    # Tune the Random Forest model
    best_model = tune_random_forest(X_train, y_train)
    
    # Evaluate the tuned model
    evaluate_model(best_model, X_test, y_test)
```

### Breakdown of Key Elements:

1. **RandomizedSearchCV**:
   - `param_dist`: A distribution for each hyperparameter, allowing us to sample values within a specified range.
     - `randint(50, 300)` for `n_estimators`: Randomly samples between 50 and 300 trees.
     - `max_depth`, `min_samples_split`, and `min_samples_leaf` are set to reasonable values based on domain knowledge or typical settings.
     - `max_features`: The number of features to consider at each split (try different strategies like auto, sqrt, or log2).
   - `n_iter=100`: The number of different hyperparameter combinations to try (adjustable based on the problem and computational power).
   - `cv=5`: **5-fold cross-validation** ensures that the model is evaluated on different subsets of data.

2. **Model Evaluation**:
   - **Accuracy**: Overall classification accuracy.
   - **Classification Report**: Provides precision, recall, f1-score for each class.
   - **AUC-ROC Score**: Measures the model's ability to distinguish between the classes.
   - **Confusion Matrix**: Gives the true positives, true negatives, false positives, and false negatives.

3. **Efficiency**:
   - `n_jobs=-1` ensures that the computation is parallelized using all available cores.
   - `random_state=42` ensures that the random search and splits are reproducible.

4. **Scalable Parameter Search**:
   - Instead of using an exhaustive grid search, **RandomizedSearchCV** samples the hyperparameter space efficiently, which speeds up the process when the search space is large.
   - This approach balances between the thoroughness of Grid Search and the efficiency of Random Search.

### Optional Hyperparameter Tuning with GridSearchCV (For Small Search Space)

If you are working with a smaller, more constrained parameter space and want exhaustive search, you can replace `RandomizedSearchCV` with `GridSearchCV`.

```python
from sklearn.model_selection import GridSearchCV

# Parameter grid for GridSearchCV (smaller search space for demo)
param_grid = {
    'n_estimators': [50, 100, 150],
    'max_depth': [None, 10, 20],
    'min_samples_split': [2, 5],
    'min_samples_leaf': [1, 2],
    'max_features': ['auto', 'sqrt'],
    'bootstrap': [True, False]
}

# GridSearchCV to perform exhaustive search
grid_search = GridSearchCV(estimator=rf, param_grid=param_grid, cv=5, verbose=2, n_jobs=-1)
grid_search.fit(X_train, y_train)

# Best model from GridSearch
best_model = grid_search.best_estimator_
```

### Final Thoughts:
- **RandomizedSearchCV** is efficient for large parameter spaces, but **GridSearchCV** can be used for smaller, more defined search spaces.
- **Cross-validation** ensures a more robust model evaluation by training on different splits of the data.
- The use of **AUC-ROC** and other metrics provides a deeper understanding of the model’s performance beyond just accuracy.

This refined approach leverages more advanced techniques and ensures that the Random Forest model is optimized and professionally evaluated.
