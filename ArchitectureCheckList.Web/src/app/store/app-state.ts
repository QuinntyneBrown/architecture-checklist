import { CheckListItem, CheckList } from "../models";

export interface AppState {
    checkListItems: Array<CheckListItem>;
    checkLists: Array<CheckList>;
	currentUser: any;
    isLoggedIn: boolean;
    token: string;
}
