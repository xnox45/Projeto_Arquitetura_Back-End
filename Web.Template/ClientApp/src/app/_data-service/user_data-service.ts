import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()//definindo que é uma classe injetavel em outras(eu acho)
export class UserDataService {

  module: string = 'api/UserControllers';

  constructor(private _http: HttpClient) {

  }

  get() {
    return this._http.get(this.module);
  }

}
