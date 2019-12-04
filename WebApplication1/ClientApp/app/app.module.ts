import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import {AppComponentTimeTable} from './time-table/app.component.time-table';


@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [AppComponent, AppComponentTimeTable],
    bootstrap: [AppComponent]
})
export class AppModule { }