import React from 'react';
import { createRoot } from 'react-dom/client';

import { Provider } from 'react-redux';
import { Store } from 'redux';

import { configureStore } from './configure-store';
import { StoreType } from './store/store-type';
import { TodoLayout } from './components/todo-layout';

const store: Store<StoreType> = configureStore();

const container = document.getElementById('root');
if (container) {
    const root = createRoot(container);
    root.render(
        <Provider store={ store }>
            <TodoLayout />
        </Provider>
    );
}
