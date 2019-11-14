import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { baseAPI } from 'src/app/consts/const'

@Injectable({
  providedIn: 'root'
})

export class BaseService {
  constructor(private httpClient: HttpClient) { }

  public get(path: string) {
    return this.httpClient.get(baseAPI + path);
  }

  public post(path: string, data: any) {
    return this.httpClient.post(baseAPI + path, data);
  }
}