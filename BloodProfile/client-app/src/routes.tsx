
import React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { FetchRecord } from './components/FetchRecord';

export const routes = <Layout>
    <Route path='/fetchrecord' component={FetchRecord} />
</Layout>;
