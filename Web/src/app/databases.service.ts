import { Database } from './models/database';

import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map';
import { extractData, getHeaders, getPostHeaders } from './helpers';

@Injectable()
export class DatabasesService {

  apiUrl: string;
  constructor(config: ConfigService,
    private http: Http) {
    this.apiUrl = config.apiUrl;
  }


  getDatabase(id: number): Observable<Database> {
    return this.http.get(`${this.apiUrl}/databases/${id}`, { headers: getHeaders() }).map(extractData);
  }

  getDatabases(): Observable<Database[]> {
    return this.http.get(this.apiUrl + '/databases', { headers: getHeaders() }).map(extractData);
  }

}
