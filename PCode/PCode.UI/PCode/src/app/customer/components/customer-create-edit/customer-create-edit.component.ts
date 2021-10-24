import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer';
import { CustomerService } from 'src/app/service/customer.service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-customer-create-edit',
  templateUrl: './customer-create-edit.component.html',
  styleUrls: ['./customer-create-edit.component.scss']
})
export class CustomerCreateEditComponent implements OnInit {

  myForm: FormGroup;
  constructor(private _customerService: CustomerService,private fb: FormBuilder) { }
  customerModel = new Customer();
  ngOnInit(): void {
    this.myForm =  this.fb.group({
      firstName: '',
      lastName: '',
      address: '',
      age:''
    })
    this.myForm.valueChanges.subscribe(console.log)

  }
  onClickSubmit() {
    this._customerService.addWeather(this.customerModel).subscribe((data)=>{
    });
    window.location.reload();
 }

}
