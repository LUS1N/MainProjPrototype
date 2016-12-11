import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Server } from './models/server';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map';
import { extractData, getHeaders, getPostHeaders } from './helpers';
@Injectable()
export class ServersService {

  apiUrl: string;
  constructor(config: ConfigService,
    private http: Http) {
    this.apiUrl = config.apiUrl;
  }

  getServers(): Observable<Server[]> {
    return this.http.get(this.apiUrl + '/servers', { headers: getHeaders() }).map(extractData);
  }


}
