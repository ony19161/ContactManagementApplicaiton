import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact';
import { PaginatedResult } from '../models/Pagination';
import { map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization' : 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  baseURL = environment.apiUrl + 'contact';


constructor(private http: HttpClient) { }

getContacts(pageIndex?, pageSize?): Observable<PaginatedResult<Contact[]>> {

  const paginatedResult: PaginatedResult<Contact[]> = new PaginatedResult<Contact[]>();

  return this.http.get<any>(this.baseURL + '?pageIndex=' + pageIndex + '&pageSize=' + pageSize,
   httpOptions).pipe(
     map(response => {
       paginatedResult.result = response.contacts;
       paginatedResult.pagination = response.pagination;
       return paginatedResult;
     })
   );
}

getCategory(id): Observable<Contact> {
  return this.http.get<Contact>(this.baseURL + '/get?id=' + id, httpOptions);
}

getAll(): Observable<Contact[]> {
  return this.http.get<Contact[]>(this.baseURL + '/getAll', httpOptions)
  .pipe(
    map(response => {
      console.log(response);
      return response;
    })
  );
}

addContact(model: Contact) {
  return this.http.post(this.baseURL + '/add', model, httpOptions);
}

updateContact(model: Contact) {
  return this.http.post(this.baseURL + '/update', model, httpOptions);
}

}
