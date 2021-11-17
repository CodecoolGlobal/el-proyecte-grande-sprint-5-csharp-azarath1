import { render, screen } from '@testing-library/react';
import Home from './Home.js';

test('renders cardstats', () => {
    render(<Home />);
    const welcomeText = screen.getByText(/SuperduperMedapp!/i);
    expect(welcomeText).toBeInTheDocument();
  });