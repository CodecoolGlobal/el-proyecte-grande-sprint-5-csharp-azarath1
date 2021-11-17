import { render, screen } from '@testing-library/react';
import App from './App.js';

test('renders navbar', () => {
  render(<App />);
  const linkElement = screen.getByText(/Login/i);
  expect(linkElement).toBeInTheDocument();
});

test('renders corona statistics tab', () => {
  render(<App />);
  const linkElement = screen.getByText(/Coronavirus/i);
  expect(linkElement).toBeInTheDocument();
});

test('renders Placeholder title', () => {
  render(<App />);
  const linkElement = screen.getByText(/Placeholder/i);
  expect(linkElement).toBeInTheDocument();
});

test('renders Placeholder body', () => {
  render(<App />);
  const linkElement = screen.getByText(/Lorem/i);
  expect(linkElement).toBeInTheDocument();
});