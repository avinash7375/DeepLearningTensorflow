Here is detailed information for **Module 5: Machine Learning**, covering **Supervised**, **Unsupervised**, and **Gradient Boosting Algorithms**:

---

### **Supervised Learning Algorithms**

#### **1. Linear Regression**
- **Formula**:  
  \[
  y = \beta_0 + \beta_1 x_1 + \beta_2 x_2 + \dots + \beta_n x_n + \epsilon
  \]  
- **Use**: Predict continuous values (e.g., predicting house prices).  
- **Working**: Finds the line of best fit by minimizing the Mean Squared Error (MSE).  

---

#### **2. Logistic Regression**
- **Formula**:  
  Sigmoid Function:
  \[
  P(y=1|x) = \frac{1}{1 + e^{-(\beta_0 + \beta_1 x_1 + \dots + \beta_n x_n)}}
  \]
- **Use**: Binary classification (e.g., spam email detection).  
- **Working**: Models probabilities and classifies data points using a logistic (sigmoid) function.

---

#### **3. Decision Tree**
- **Formula**:  
  Gini Index:
  \[
  Gini = 1 - \sum_{i=1}^{C} p_i^2
  \]
- **Use**: Both classification (e.g., loan approval) and regression tasks.  
- **Working**: Splits data into branches using conditions that maximize information gain.

---

#### **4. Support Vector Machine (SVM)**
- **Formula**:  
  Decision Boundary:
  \[
  w^T x + b = 0
  \]
- **Use**: Classification tasks (e.g., image recognition).  
- **Working**: Identifies the hyperplane that separates classes with the maximum margin.

---

#### **5. Naive Bayes**
- **Formula**:  
  Bayes’ Theorem:
  \[
  P(A|B) = \frac{P(B|A) \cdot P(A)}{P(B)}
  \]
- **Use**: Text classification and sentiment analysis.  
- **Working**: Calculates the posterior probability of each class based on feature likelihoods.

---

#### **6. K-Nearest Neighbors (KNN)**
- **Formula**:  
  Euclidean Distance:
  \[
  d(x, y) = \sqrt{\sum_{i=1}^{n} (x_i - y_i)^2}
  \]
- **Use**: Recommendation systems, classification tasks.  
- **Working**: Assigns a class label to a data point based on the majority vote of its \(k\)-nearest neighbors.

---

#### **7. Random Forest**
- **Formula**:  
  Aggregated Predictions:
  \[
  \hat{y} = \text{mode/average of predictions from all trees}
  \]
- **Use**: Fraud detection, risk analysis.  
- **Working**: Combines predictions from multiple decision trees to improve accuracy and reduce overfitting.

---

### **Unsupervised Learning Algorithms**

#### **1. Principal Component Analysis (PCA)**
- **Formula**:  
  Eigenvalue Decomposition:
  \[
  Cov(X) = Q \Lambda Q^{-1}
  \]
- **Use**: Dimensionality reduction (e.g., data visualization).  
- **Working**: Projects data onto a lower-dimensional space by retaining features with the highest variance.

---

#### **2. Hierarchical Clustering**
- **Formula**:  
  Linkage Criteria:
  \[
  d(A, B) = \min_{i \in A, j \in B} d(i, j)
  \]
- **Use**: Document clustering, customer segmentation.  
- **Working**: Builds a hierarchy of clusters by iteratively merging the closest ones.

---

### **Gradient Boosting Algorithms**

#### **1. Gradient Boosting Machine (GBM)**
- **Formula**:  
  Update Rule:
  \[
  F_{m+1}(x) = F_m(x) + \gamma h_m(x)
  \]
- **Use**: Predictive analytics (e.g., risk modeling).  
- **Working**: Sequentially builds models, where each corrects errors of the previous one.

---

#### **2. XGBoost**
- **Formula**:  
  Objective Function:
  \[
  Obj = \sum_{i} l(y_i, \hat{y}_i) + \sum_{k} \Omega(h_k)
  \]
- **Use**: Classification and regression tasks.  
- **Working**: Optimized for speed and performance with parallel processing and regularization.

---

#### **3. LightGBM**
- **Formula**:  
  Leaf-wise Splitting:
  \[
  Gain = \frac{(sumGrad)^2}{countGrad + \lambda}
  \]
- **Use**: Large datasets, quick training.  
- **Working**: Splits trees leaf-wise for better accuracy and efficiency.

---

#### **4. CatBoost**
- **Formula**:  
  Target Encoding:
  \[
  TE(x) = \frac{\sum y}{\text{Count of } x}
  \]
- **Use**: Handles categorical data without preprocessing.  
- **Working**: Uses gradient boosting and efficiently processes categorical variables.

---

This module provides the foundation for solving real-world problems like classification, regression, clustering, and dimensionality reduction. Let me know if you'd like further elaboration or examples for any specific algorithm!
