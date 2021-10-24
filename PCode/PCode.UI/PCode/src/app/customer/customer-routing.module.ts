import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerCreateEditComponent } from './components/customer-create-edit/customer-create-edit.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';

const routes: Routes = [
    {path: 'list', component: CustomerListComponent },
    {path: "create", component: CustomerCreateEditComponent},
    {path: "**", redirectTo: 'list'}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
