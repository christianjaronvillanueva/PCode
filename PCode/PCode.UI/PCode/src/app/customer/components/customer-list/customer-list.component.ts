import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer';
import { CustomerService } from 'src/app/service/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {

  public customerUpdate!: Customer[];
  constructor(private _customerService: CustomerService) { }

  ngOnInit(): void {
    this._customerService.getCustomer().subscribe((data)=>{
      this.customerUpdate = data;
    });
  }
}
