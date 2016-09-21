import { Injectable } from "@angular/core";
import { Store, Action } from "@ngrx/store";
import { AppState } from "./app-state";
import { guid, pluck } from "../utilities";
import { select, SelectSignature } from '@ngrx/core/operator/select';
import { Observable, BehaviorSubject } from "rxjs";
import { CheckListItem, CheckList } from "../models";


@Injectable()
export class AppStore {
    constructor(private _store: Store<AppState>) { }

    public dispatch(action: Action, newGuid?: string): string {
        newGuid = this._registerLastAction(action.type, newGuid);
        this._store.dispatch(action);
        return newGuid;
    }

    private _registerLastAction(actionType: string, newGuid?: string): string {
        newGuid = newGuid || guid();
        this.lastTriggeredAction = actionType;
        this.lastTriggeredActionId = newGuid;
        this.lastTriggeredAction$.next(this.lastTriggeredAction);        
        this.lastTriggeredActionId$.next(this.lastTriggeredActionId);
        return newGuid;
    }

    select: SelectSignature<AppState> = select.bind(this._store);

    public lastTriggeredAction$: BehaviorSubject<string> = new BehaviorSubject<string>(this.lastTriggeredAction);

    public lastTriggeredActionId$: BehaviorSubject<string> = new BehaviorSubject<string>(this.lastTriggeredActionId);

    public lastTriggeredAction: string = null;

    public lastTriggeredActionId: string = null;    

    public getState(): AppState {
        let state: AppState;
        this._store.take(1).subscribe(s => state = s);
        return state;
    }

    public checkListByName$(name: string): Observable<CheckListItem> {
        return this._store.select("checkLists")
            .map((data: { checkLists: Array<CheckList> }) => {
                return pluck({ value: name, items: data.checkLists, key: "name" }) as CheckList;
            });
    }

    public checkListItemById$(id: string): Observable<CheckListItem> {
        return this._store.select("checkListItems")
            .map((data: { checkListItems: Array<CheckListItem> }) => {
                return pluck({ value: id, items: data.checkListItems }) as CheckListItem;
            })
    }

    public checkListItems$(): Observable<Array<CheckListItem>> {
        return this._store.select("checkListItems")
            .map((data: { checkListItems: Array<CheckListItem> }) => {
                return data.checkListItems;
            });
    }
}

