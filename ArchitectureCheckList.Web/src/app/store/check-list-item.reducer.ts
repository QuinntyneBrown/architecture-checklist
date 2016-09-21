import { Action } from "@ngrx/store";
import { CHECK_LIST_ITEM_ADD_SUCCESS, CHECK_LIST_ITEM_GET_SUCCESS, CHECK_LIST_ITEM_REMOVE_SUCCESS } from "../constants";
import { initialState } from "./initial-state";
import { AppState } from "./app-state";
import { CheckListItem } from "../models";
import { addOrUpdate, pluckOut } from "../utilities";

export const checkListItemsReducer = (state: AppState = initialState, action: Action) => {
    switch (action.type) {
        case CHECK_LIST_ITEM_ADD_SUCCESS:
            var entities: Array<CheckListItem> = state.checkListItems;
            var entity: CheckListItem = action.payload;
            addOrUpdate({ items: entities, item: entity});            
            return Object.assign({}, state, { checkListItems: entities });

        case CHECK_LIST_ITEM_GET_SUCCESS:
            var entities: Array<CheckListItem> = state.checkListItems;
            var newOrExistingCheckListItems: Array<CheckListItem> = action.payload;
            for (let i = 0; i < newOrExistingCheckListItems.length; i++) {
                addOrUpdate({ items: entities, item: newOrExistingCheckListItems[i] });
            }                                    
            return Object.assign({}, state, { checkListItems: entities });

        case CHECK_LIST_ITEM_REMOVE_SUCCESS:
            var entities: Array<CheckListItem> = state.checkListItems;
            var id = action.payload;
            pluckOut({ value: id, items: entities });
            return Object.assign({}, state, { checkListItems: entities });

        default:
            return state;
    }
}

