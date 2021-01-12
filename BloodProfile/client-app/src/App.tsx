import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { AppContainer } from 'react-hot-loader';
import './App.css';
import 'bootstrap';
import * as RoutesModule from './routes';
let routes = RoutesModule.routes;

function App() {
  const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;
  ReactDOM.render(
      <AppContainer>
          <BrowserRouter children={ routes } basename={ baseUrl } />
      </AppContainer>,
      document.getElementById('client-app')
  )
  return;
}

export default App;
