import React, { useState } from 'react';
import axios from 'axios';
import './AddMatchPage.css';

const AddMatchPage = () => {
  const [player1Id, setPlayer1Id] = useState('');
  const [player2Id, setPlayer2Id] = useState('');
  const [matchDate, setMatchDate] = useState('');
  const [matchLevel, setMatchLevel] = useState('');
  const [error, setError] = useState(null);

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      await axios.post('/api/matches', {
        player1_id: player1Id,
        player2_id: player2Id,
        match_date: matchDate,
        match_level: matchLevel,
      });
      alert('Match added successfully!');
    } catch (err) {
      setError('Failed to add match');
    }
  };

  return (
    <div className="add-match-page">
      <h1>Add New Match</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Player 1 ID:
          <input type="number" value={player1Id} onChange={(e) => setPlayer1Id(e.target.value)} required />
        </label>
        <label>
          Player 2 ID:
          <input type="number" value={player2Id} onChange={(e) => setPlayer2Id(e.target.value)} required />
        </label>
        <label>
          Match Date:
          <input type="date" value={matchDate} onChange={(e) => setMatchDate(e.target.value)} required />
        </label>
        <label>
          Match Level:
          <select value={matchLevel} onChange={(e) => setMatchLevel(e.target.value)} required>
            <option value="">Select level</option>
            <option value="International">International</option>
            <option value="National">National</option>
          </select>
        </label>
        <button type="submit">Add Match</button>
        {error && <p className="error">{error}</p>}
      </form>
    </div>
  );
};

export default AddMatchPage;
