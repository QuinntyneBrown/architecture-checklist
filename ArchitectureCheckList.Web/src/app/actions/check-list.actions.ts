import { Injectable } from "@angular/core";
import { Store } from "@ngrx/store";
import { CheckListService } from "../services";
import { AppState, AppStore } from "../store";
import {
    CHECK_LIST_ADD_SUCCESS,
    CHECK_LIST_GET_SUCCESS,
    CHECK_LIST_REMOVE_SUCCESS,
    CHECK_LIST_GET_BY_NAME_SUCCESS
} from "../constants";

import { CheckList } from "../models";
import { Observable } from "rxjs";
import { guid } from "../utilities";

@Injectable()
export class CheckListActions {
    constructor(private _checkListService: CheckListService, private _store: AppStore) { }

    public add(checkList: CheckList) {
        const newGuid = guid();
        this._checkListService.add(checkList)
            .subscribe(checkList => {
                this._store.dispatch({
                    type: CHECK_LIST_ADD_SUCCESS,
                    payload: checkList
                },newGuid);                
            });
        return newGuid;
    }

    public get() {                          
        return this._checkListService.get()
            .subscribe(checkLists => {
                this._store.dispatch({
                    type: CHECK_LIST_GET_SUCCESS,
                    payload: checkLists
                });
                return true;
            });
    }

    public remove(options: {id: number}) {
        return this._checkListService.remove({ id: options.id })
            .subscribe(checkList => {
                this._store.dispatch({
                    type: CHECK_LIST_REMOVE_SUCCESS,
                    payload: options.id
                });
                return true;
            });
    }

    public getById(options: { id: number }) {
        return this._checkListService.getById({ id: options.id })
            .subscribe(checkList => {
                this._store.dispatch({
                    type: CHECK_LIST_GET_SUCCESS,
                    payload: [checkList]
                });
                return true;
            });
    }

    public getByName(options: { name: string }) {
        return this._checkListService.getByName({ name: options.name })
            .subscribe(checkList => {
                this._store.dispatch({
                    type: CHECK_LIST_GET_BY_NAME_SUCCESS,
                    payload: checkList
                });
                return true;
            });
    }


}
