import { NgModule } from '@angular/core';
import { CheckListActions } from "./check-list.actions";
import { CheckListItemActions } from "./check-list-item.actions";

const providers = [CheckListActions,CheckListItemActions];

@NgModule({
	providers: providers
})
export class ActionsModule { }
