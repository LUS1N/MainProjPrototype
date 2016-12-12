import { Owner } from './models/owner';

import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map';
import { extractData, getHeaders, getPostHeaders } from './helpers';

@Injectable()
export class OwnersService {

  apiUrl: string;
  constructor(config: ConfigService,
    private http: Http) {
    this.apiUrl = config.apiUrl;
  }

  getOwner(id: number): Observable<Owner> {
    return this.http.get(`${this.apiUrl}/owners/${id}`, { headers: getHeaders() }).map(extractData);
  }

  getOwners(): Observable<Owner[]> {
    return this.http.get(this.apiUrl + '/owners', { headers: getHeaders() }).map(extractData);
  }

  updateEntitiesOwner<T>(href: string, ownerId: number): Observable<T> {
    var body = JSON.stringify({ ownerId: ownerId });
    return this.http.patch(`${this.apiUrl}${href}`, body, { headers: getPostHeaders() }).map(extractData);
  }
}
