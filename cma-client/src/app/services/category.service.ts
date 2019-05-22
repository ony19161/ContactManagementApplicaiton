import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { IdAndValue } from '../models/IdAndValue';
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
export class CategoryService {
  baseURL = environment.apiUrl + 'category';

  constructor(private http: HttpClient) { }

  getCategories(searchText: string, pageIndex?, pageSize?): Observable<PaginatedResult<Category[]>> {

    const paginatedResult: PaginatedResult<Category[]> = new PaginatedResult<Category[]>();

    return this.http.get<any>(this.baseURL + '?searchText=' + searchText + '&pageIndex=' + pageIndex + '&pageSize=' + pageSize,
     httpOptions).pipe(
       map(response => {
         paginatedResult.result = response.categories;
         paginatedResult.pagination = response.pagination;
         return paginatedResult;
       })
     );
  }

  getDropdownCategories(searchText: string, pageIndex?, pageSize?): Observable<IdAndValue[]> {

    return this.http.get<any>(this.baseURL + '?searchText=' + searchText + '&pageIndex=' +
    pageIndex + '&pageSize=' + pageSize + '&IsIdValue=true',
     httpOptions).pipe(
       map(response => {
         return response;
       })
     );
  }

  getCategory(id): Observable<Category> {
    return this.http.get<Category>(this.baseURL + '/get?id=' + id, httpOptions);
  }

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseURL + '/getAll', httpOptions)
    .pipe(
      map(response => {
        // console.log(response);
        return response;
      })
    );
  }

  addCategory(model: Category) {
    return this.http.post(this.baseURL + '/add', model, httpOptions);
  }

  updateCategory(model: Category) {
    return this.http.post(this.baseURL + '/update', model, httpOptions);
  }


}
