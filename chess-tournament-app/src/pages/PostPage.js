import React, { useState } from 'react';
import axios from 'axios';
import { useAuth } from '../contexts/AuthContexts';
import './PostPage.css';

const PostPage = () => {
  const [player1Id, setPlayer1Id] = useState('');
  const [player2Id, setPlayer2Id] = useState('');
  const [matchDate, setMatchDate] = useState('');
  const [matchLevel, setMatchLevel] = useState('');
  const [response, setResponse] = useState('');
  const { isAuthenticated } = useAuth();

  const handlePost = async () => {
    if (isAuthenticated) {
      try {
        const result = await axios.post('http://localhost:5231/api/matches', {
          Player1Id: player1Id,
          Player2Id: player2Id,
          MatchDate: matchDate,
          MatchLevel: matchLevel
        });
        setResponse(result.data);
      } catch (error) {
        setResponse('Error posting data');
      }
    } else {
      setResponse('You must be logged in to post data');
    }
  };

  return (
    <div className="post-page">
      <header className="header">
        <h1>Post Match Details</h1>
      </header>
      <main className="content">
        <form onSubmit={(e) => { e.preventDefault(); handlePost(); }} className="form">
          <label>
            Player 1 ID:
            <input
              type="number"
              value={player1Id}
              onChange={(e) => setPlayer1Id(e.target.value)}
              required
            />
          </label>
          <label>
            Player 2 ID:
            <input
              type="number"
              value={player2Id}
              onChange={(e) => setPlayer2Id(e.target.value)}
              required
            />
          </label>
          <label>
            Match Date:
            <input
              type="datetime-local"
              value={matchDate}
              onChange={(e) => setMatchDate(e.target.value)}
              required
            />
          </label>
          <label>
            Match Level:
            <input
              type="text"
              value={matchLevel}
              onChange={(e) => setMatchLevel(e.target.value)}
              required
            />
          </label>
          <button type="submit" className="submit-button">Post Match</button>
        </form>
        <div className="response">{response}</div>
      </main>
    </div>
  );
};

export default PostPage;
