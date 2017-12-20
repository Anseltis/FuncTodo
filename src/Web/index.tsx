import * as React from 'react';
import * as ReactDOM from 'react-dom';

import { Provider } from 'react-redux';
import { Store } from 'redux';

import { configureStore } from './configure-store';
import { StoreType } from './store/store-type';
import { TodoLayout } from './components/todo-layout';

const store: Store<StoreType> = configureStore();

ReactDOM.render(
    <Provider store={ store }>
        <TodoLayout/>
    </Provider>,
    document.getElementById('root'));