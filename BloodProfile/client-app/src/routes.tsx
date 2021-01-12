import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { FetchRecord } from './components/FetchRecord';
import { AddRecord } from './components/AddRecord';

export const routes = <Layout>
    <Route path='api/bloodwork' component={FetchRecord} />
    <Route path='api/bloodwork/AddRecord' component={AddRecord} />
</Layout>;
