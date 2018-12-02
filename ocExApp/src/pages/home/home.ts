import {Component} from '@angular/core';
import {NavController} from 'ionic-angular';
import {Api} from "../../providers/api";

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  public selected: string = "srt2";
  public result: string = "";

  private model: any = {
    "token": null,
    "algo": null,
    "x": 14,
    "y": 3
  };

  public setAlgo(algoName: string) {
    console.log(algoName);
    this.selected = algoName;
    this.model.algo = algoName;
  }

  constructor(public navCtrl: NavController, private api: Api) {
    this.setAlgo("srt2");
  }

  public doCalc() {
    this.result = "loading ...";
    this.api.getResult(this.model).subscribe(result => {
      console.log(result);
      this.result = result.message;
    });
  }

}
