import { render, screen } from '@testing-library/react';
import App from './App.js';

test('renders index page', () => {
  render(<App />);
  
  const coronaElement = screen.getByText(/Coronavirus/i);
  const placeholderTitleElement = screen.getByText(/Placeholder/i);
  const articlePhraseElement = screen.getByText(/Lorem/i);

  expect(coronaElement).toBeInTheDocument();
  expect(placeholderTitleElement).toBeInTheDocument();
  expect(articlePhraseElement).toBeInTheDocument();
});