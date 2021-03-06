import { configureStore, combineReducers, Reducer, AnyAction } from '@reduxjs/toolkit';

import { diagraphApi } from 'services';
import { graphReducer } from 'modules/graph';
import { sharedReducer } from 'modules/common';
import { profileReducer } from 'modules/profile';
import { googleIntegrationReducer } from 'modules/google-integration';
import { authReducer, logoutActionType, authMiddleware } from 'modules/auth';

const reducer = {
    [diagraphApi.reducerPath]: diagraphApi.reducer,
    graph: graphReducer,
    auth: authReducer,
    profile: profileReducer,
    shared: sharedReducer,
    googleIntegration: googleIntegrationReducer
};

export type RootState = ReturnType<typeof combinedReducer>;

const combinedReducer = combineReducers(reducer);
const rootReducer: Reducer = (state: RootState, action: AnyAction) => {
    if (action.type === logoutActionType) {
        state = {} as RootState;
    }

    return combinedReducer(state, action);
};

export const store = configureStore({
    reducer: rootReducer,
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware()
            .concat(diagraphApi.middleware)
            .concat(authMiddleware)
});

export type AppDispatch = typeof store.dispatch;