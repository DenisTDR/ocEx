import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import 'rxjs/add/operator/map';

/*
 Generated class for the Api provider.

 See https://angular.io/docs/ts/latest/guide/dependency-injection.html
 for more info on providers and Angular DI.
 */
@Injectable()
export class Api {

  constructor(public http: Http) {
  }

  private url: string = "http://api.oc.tdrs.me/api/Algos";

  public getResult(model: any): any {
    return this.http.post(this.url, model).map(response => response.json());
  }

}
