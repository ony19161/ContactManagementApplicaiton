import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization' : 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseURL = environment.apiUrl + 'category/';

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseURL + 'getAll?pageIndex=1&pageSize=10', httpOptions);
  }

  getCategory(id): Observable<Category> {
    return this.http.get<Category>(this.baseURL + '/get?id=' + id, httpOptions);
  }


}
