import React, { useState } from 'react';
import { useAuth } from '../contexts/AuthContexts';
import { useNavigate } from 'react-router-dom';
import './LoginPage.css'; // Create and import this CSS file

const LoginPage = () => {
  const [token, setToken] = useState('');
  const { login } = useAuth();
  const navigate = useNavigate();

  const handleLogin = () => {
    if (token) {
      login(token);
      navigate('/post');
    } else {
      alert('Please enter a token');
    }
  };

  return (
    <div className="login-page">
      <h1>Login</h1>
      <input
        type="text"
        placeholder="Enter token"
        value={token}
        onChange={(e) => setToken(e.target.value)}
        className="login-input"
      />
      <button onClick={handleLogin} className="login-button">Login</button>
    </div>
  );
};

export default LoginPage;
