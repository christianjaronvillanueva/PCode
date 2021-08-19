import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComponentsCreateEditComponent } from './components/components-create-edit/components-create-edit.component';
import { ComponentListComponent } from './components/component-list/component-list.component';
import { CustomerCreateEditComponent } from './components/customer-create-edit/customer-create-edit.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ComponentsCreateEditComponent,
    ComponentListComponent,
    CustomerCreateEditComponent,
    CustomerListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
