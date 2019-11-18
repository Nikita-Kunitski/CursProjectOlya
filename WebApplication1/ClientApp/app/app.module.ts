import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponentAuditoriumType } from './auditoriumType/app.component.auditoriumtype';
import { AppComponentAuditorium } from './auditorium/app.component.auditorium';
@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [AppComponentAuditoriumType, AppComponentAuditorium],
    bootstrap: [AppComponentAuditoriumType, AppComponentAuditorium]
})
export class AppModule { }