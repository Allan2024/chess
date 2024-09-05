import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { AuthProvider } from './contexts/AuthContexts'; 
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import PostPage from './pages/PostPage';
import ProtectedRoute from './contexts/ProtectedRoute.js';

const App = () => {
  return (
    <AuthProvider>
      <Router>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/post" element={<ProtectedRoute element={<PostPage />} />} />
        </Routes>
      </Router>
    </AuthProvider>
  );
};

export default App;
