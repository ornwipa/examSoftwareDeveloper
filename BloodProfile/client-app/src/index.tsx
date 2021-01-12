import './index.css';
/*
import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import reportWebVitals from './reportWebVitals';

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

reportWebVitals();
*/

import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { FetchRecord } from './components/FetchRecord';

export const routes = <Layout>
    <Route path='/fetchrecord' component={FetchRecord} />
</Layout>;
