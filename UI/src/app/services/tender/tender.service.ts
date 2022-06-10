import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { RequestBase } from 'src/app/models/request-base.model';
import { ResponseBase } from 'src/app/models/response-base.model';
import { Tender } from 'src/app/models/tender.model';
import { Observable } from 'rxjs';

@Injectable()
export class TenderService {

  url: string = 'https://localhost:44381/api/tender/';

  constructor(private httpclient : HttpClient) {}

  request: RequestBase = new RequestBase();
  response: ResponseBase = new ResponseBase();

  // Get all
  getTenderList(): Observable<ResponseBase> {
    console.log('try get tender');
    let localURL = this.url + 'getalltenderlistasync';
    return this.httpclient.post<ResponseBase>(localURL,  null);
  }
  
  // Get by id 
  getTenderById(id:number): Observable<ResponseBase> {
    let localURL = this.url + 'gettenderbyidasync';
    const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
    console.log(localURL);
    return this.httpclient.post<ResponseBase>(localURL, id, { headers });
  }

  // Create 
  createTender(tender: Tender): Observable<ResponseBase> {
    let localURL = this.url + 'createtenderasync';
    this.request.data = tender;
    console.log(localURL);
    return this.httpclient.post<ResponseBase>(localURL, this.request);
  }

  // Update
  updateTender(tender: Tender): Observable<ResponseBase> {
    let localURL = this.url + 'updatetenderasync';
    this.request.data = tender;
    return this.httpclient.post<ResponseBase>(localURL, this.request);
  }

  // Delete
  deleteTender(tender: Tender): Observable<ResponseBase> {
    let localURL = this.url + 'deletetenderasync';
    this.request.data = tender;
    return this.httpclient.post<ResponseBase>(localURL, this.request);
  }
}
