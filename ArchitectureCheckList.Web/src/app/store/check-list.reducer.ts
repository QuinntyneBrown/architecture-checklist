import { Action } from "@ngrx/store";
import { CHECK_LIST_ADD_SUCCESS, CHECK_LIST_GET_SUCCESS, CHECK_LIST_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { CheckList } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const checkListsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case CHECK_LIST_ADD_SUCCESS:
            var entities: Array<CheckList> = state.checkLists;
            var entity: CheckList = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { checkLists: entities });

        case CHECK_LIST_GET_SUCCESS:
            var entities: Array<CheckList> = state.checkLists;
            var newOrExistingCheckLists: Array<CheckList> = action.payload;
            for (let i = 0; i < newOrExistingCheckLists.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingCheckLists[i] });
            }                                    
            return Object.assign({}, state, { checkLists: entities });

        case CHECK_LIST_REMOVE_SUCCESS:
            var entities: Array<CheckList> = state.checkLists;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { checkLists: entities });

        default:
            return state;
    }
}

