import { render, screen } from '@testing-library/react';
import App from './App.js';

test('renders index page', () => {
  render(<App />);
  const registerElement = screen.getByText(/Sign Up/i);
  const loginElement = screen.getByText(/Login/i);
  const coronaElement = screen.getByText(/Coronavirus/i);
  const placeholderTitleElement = screen.getByText(/Placeholder/i);
  const articlePhraseElement = screen.getByText(/Lorem/i);

  expect(registerElement).toBeInTheDocument();
  expect(loginElement).toBeInTheDocument();
  expect(coronaElement).toBeInTheDocument();
  expect(placeholderTitleElement).toBeInTheDocument();
  expect(articlePhraseElement).toBeInTheDocument();
});