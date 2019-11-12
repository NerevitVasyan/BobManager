import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  BASE_API = environment.baseAPI;
  constructor(private http: HttpClient) {}

  getToDos(): Observable<any> {
    return this.http.get(this.BASE_API + 'todo');
  }
}
