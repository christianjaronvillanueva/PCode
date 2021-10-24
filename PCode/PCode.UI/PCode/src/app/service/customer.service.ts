import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  public getCustomer(){
    return this.http.get<Customer[]>(`${environment.baseUrl}/api/Customer`);
  }

  public addWeather(customer: Customer){
    return this.http.post<Customer[]>(`${environment.baseUrl}/api/Customer`,customer);
  }
}
