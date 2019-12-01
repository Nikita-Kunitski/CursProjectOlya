import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponentAuditoriumType } from './app.component.auditoriumtype';
@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [AppComponentAuditoriumType],
    bootstrap: [AppComponentAuditoriumType]
})
export class AuditoriumTypeModule { }