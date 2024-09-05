import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchPlayers } from '../redux/PlayerSlice';
import { Link } from 'react-router-dom';
import './HomePage.css';

const HomePage = () => {
  const dispatch = useDispatch();
  const players = useSelector((state) => state.players.players);
  const status = useSelector((state) => state.players.status);
  const error = useSelector((state) => state.players.error);

  useEffect(() => {
    if (status === 'idle') {
      dispatch(fetchPlayers());
    }
  }, [dispatch, status]);

  return (
    <div className="home-page">
      <header className="header">
        <h1>Chess Tournament Players</h1>
        <nav className="nav">
          <Link to="/post" className="nav-button">Post Match</Link>
          <Link to="/login" className="nav-button">Login</Link>
        </nav>
      </header>
      <main className="content">
        {status === 'loading' && <p>Loading...</p>}
        {status === 'failed' && <p className="error">Error: {error}</p>}
        {status === 'succeeded' && (
          <ul className="player-list">
            {players.map((player) => (
              <li key={player.player_id} className="player-item">
                {player.first_name} {player.last_name} ({player.country}) - Ranking: {player.current_world_ranking}
              </li>
            ))}
          </ul>
        )}
      </main>
    </div>
  );
};

export default HomePage;
