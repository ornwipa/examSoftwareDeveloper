import './index.css';
import reportWebVitals from './reportWebVitals';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';

export const routes = <Layout>
    <Route path='bloodwork' />
</Layout>;

reportWebVitals();
