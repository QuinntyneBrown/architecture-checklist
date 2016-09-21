import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { CheckListItemService } from "../services";
import { AppState, AppStore } from "../store";
import { CHECK_LIST_ITEM_ADD_SUCCESS, CHECK_LIST_ITEM_GET_SUCCESS, CHECK_LIST_ITEM_REMOVE_SUCCESS } from "../constants";
import { CheckListItem } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class CheckListItemActions {
    constructor(private _checkListItemService: CheckListItemService, private _store: AppStore) { }

    public add(checkListItem: CheckListItem) {
        const newGuid = guid();
        this._checkListItemService.add(checkListItem)
            .subscribe(checkListItem => {
                this._store.dispatch({
                    type: CHECK_LIST_ITEM_ADD_SUCCESS,
                    payload: checkListItem
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._checkListItemService.get()
            .subscribe(checkListItems => {
                this._store.dispatch({
                    type: CHECK_LIST_ITEM_GET_SUCCESS,
                    payload: checkListItems
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._checkListItemService.remove({ id: options.id })
            .subscribe(checkListItem => {
                this._store.dispatch({
                    type: CHECK_LIST_ITEM_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._checkListItemService.getById({ id: options.id })
            .subscribe(checkListItem => {
                this._store.dispatch({
                    type: CHECK_LIST_ITEM_GET_SUCCESS,
                    payload: [checkListItem]
                });
                return true;
            });
    }
}
