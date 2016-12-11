import { Response, Headers } from '@angular/http'

export function extractData(res: Response) {
    let body = res.json();
    return body || {};
}

export function getHeaders(): Headers {
    let headers = new Headers();
    headers.append('Accept', 'application/json');
    return headers;
}

export function getPostHeaders(): Headers {
    return new Headers({ 'Content-Type': 'application/json' });
}