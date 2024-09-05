import { configureStore } from '@reduxjs/toolkit';
import playerReducer from './PlayerSlice'; // Make sure this path is correct

export const store = configureStore({
  reducer: {
    players: playerReducer,
  },
});
