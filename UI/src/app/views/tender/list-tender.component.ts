import { Component, OnInit } from '@angular/core';
import { Tender } from 'src/app/models/tender.model';
import { TenderService } from 'src/app/services/tender/tender.service';


@Component({
  selector: 'app-list-tender',
  templateUrl: './list-tender.component.html'
})
export class ListTenderComponent implements OnInit {

  errorMessage: string = "Loading data, please wait...";
  tenderList!: Tender[];

  constructor(private _tenderService : TenderService) { }

  ngOnInit(): void {
    this.getTenderList();
  }

  errorHandler(error: Error) {
    this.errorMessage = error.message;
    console.log(this.errorMessage);
  }

  getTenderList():void{
    this._tenderService.getTenderList().subscribe(
      x => { this.tenderList = <Tender[]> x.data }, 
      error => { this.errorMessage = 'Cannot connect to the server, please try again later'; console.log(error) });
  }

  deleteTender(tender:Tender):void{
    if (confirm("Are you sure ?"))
    {
      this._tenderService.deleteTender(tender).subscribe( x => {this.getTenderList()} , error => { this.errorMessage = error.message; console.log(error)});
    }
  }
}
