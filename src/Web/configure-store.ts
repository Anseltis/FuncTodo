import { reducer as formReducer } from 'redux-form';
import { Reducer, Store, createStore } from 'redux';
import { combineReducers } from 'redux';

import { StoreType } from './store/store-type';

const rootReducer: Reducer<StoreType> = combineReducers<StoreType>({
    form: formReducer
   });

export function configureStore(): Store<StoreType> {
   const store: Store<StoreType> = createStore<StoreType>(
       rootReducer);
   return store;
 }