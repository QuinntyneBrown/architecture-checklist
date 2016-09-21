import { Component, OnInit } from "@angular/core";
import { AppStore } from "../store";
import { CheckListActions } from "../actions";

@Component({
    template: require("./landing-page.component.html"),
    styles: [require("./landing-page.component.scss")],
    selector: "landing-page"
})
export class LandingPageComponent implements OnInit { 
    constructor(private _checkListActions: CheckListActions, private _store: AppStore) {

    }

    ngOnInit() {
        this._checkListActions.get();
    }
    
}
