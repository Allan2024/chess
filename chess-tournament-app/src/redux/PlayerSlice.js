import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

// Fetch players from the API
export const fetchPlayers = createAsyncThunk('players/fetchPlayers', async () => {
  const API_URL = process.env.REACT_APP_API_URL || 'http://localhost:5257'; // Use correct port for .NET API
  const response = await axios.get(`${API_URL}/api/players`);
  return response.data;
});

const playerSlice = createSlice({
  name: 'players',
  initialState: {
    players: [],
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchPlayers.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(fetchPlayers.fulfilled, (state, action) => {
        state.status = 'succeeded';
        state.players = action.payload;
      })
      .addCase(fetchPlayers.rejected, (state, action) => {
        state.status = 'failed';
        state.error = action.error.message;
      });
  },
});

export default playerSlice.reducer;
