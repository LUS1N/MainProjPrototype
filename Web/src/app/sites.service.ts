import { Site } from './models/site';

import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map';
import { extractData, getHeaders, getPostHeaders } from './helpers';

@Injectable()
export class SitesService {

  apiUrl: string;
  constructor(config: ConfigService,
    private http: Http) {
    this.apiUrl = config.apiUrl;
  }

  getSite(id: number): Observable<Site> {
    return this.http.get(`${this.apiUrl}/sites/${id}`, { headers: getHeaders() }).map(extractData);
  }

  getSites(): Observable<Site[]> {
    return this.http.get(this.apiUrl + '/sites', { headers: getHeaders() }).map(extractData);
  }
}
