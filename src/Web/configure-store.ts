import { reducer as formReducer } from 'redux-form';
import { Reducer, Store, createStore } from 'redux';
import { combineReducers } from 'redux';

import { StoreType } from './store/store-type';
import { Effect } from 'redux-saga/effects';

const rootReducer: Reducer<StoreType> = combineReducers<StoreType>({
    form: formReducer
   });

export function configureStore(): Store<StoreType> {
   const store: Store<StoreType> = createStore<StoreType>(
       rootReducer,
       (<any>window).__REDUX_DEVTOOLS_EXTENSION__ && (<any>window).__REDUX_DEVTOOLS_EXTENSION__());
   return store;
 }