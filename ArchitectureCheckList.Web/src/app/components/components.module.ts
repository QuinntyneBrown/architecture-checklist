import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';

import { EditorComponent } from "./editor.component";
import { PageHeaderComponent } from "./page-header.component";

const declarables = [EditorComponent, PageHeaderComponent];

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, RouterModule],
    exports: [declarables],
    declarations: [declarables]
})
export class ComponentsModule { }
