import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Tender } from 'src/app/models/tender.model';
import { TenderIdPipe } from 'src/app/pipe/tender-id.pipe';
import { TenderService } from 'src/app/services/tender/tender.service';

@Component({
  selector: 'app-details-tender',
  templateUrl: './details-tender.component.html',
  styles: [
  ]
})
export class DetailsTenderComponent implements OnInit {

  messageResponse: string = 'Success';
  errorMessage: string = 'Cannot connect to the server, please try again later';
  releaseDate!: Date;

  datePickerConfigReleaseDate! : Partial<BsDatepickerConfig>;
  datePickerConfigClosingDate! : Partial<BsDatepickerConfig>;

  constructor(private _fb: FormBuilder, private _tenderService : TenderService, private _router: Router, private _activatedRoute: ActivatedRoute) { 
  }

  tenderForm!: FormGroup;
  tender!:Tender;

  ngOnInit(): void {

    this.getFormData();
    this.setDefaultValues();
  }

  getFormData(): void{
    this._tenderService.getTenderById(this._activatedRoute.snapshot.params['id']).subscribe(
      x => { this.tender = <Tender> x.data; this.setFormGroup();}, 
      error => { alert(this.errorMessage); console.log(error) },
      () => {  } );
  }

  setFormGroup(): void {
    let tender:Tender;
    let idPipe = new TenderIdPipe();
      this.tenderForm = this._fb.group(
        {
          tenderID:[{ value: idPipe.transform(this.tender.id,7), disabled: true }],
          contractNo:[{value: this.tender.contractNo, disabled: true }],
          tenderName:[{value: this.tender.tenderName, disabled: true }],
          tenderValue:[{value: this.tender.tenderValue, disabled: true }],
          description:[{value: this.tender.description, disabled: true }],
          releaseDate:[{value: new Date(this.tender.releaseDate), disabled: true }],
          closingDate:[{value: new Date(this.tender.closingDate), disabled: true }],
          createdBy:[{value:this.tender.createdBy, disabled:true}],
          createdDate:[{value:this.tender.createdDate, disabled:true}],
          modifiedBy:[{value:this.tender.modifiedBy, disabled:true}],
          modifiedDate:[{value:this.tender.modifiedDate, disabled:true}],
        }
      ); 
  }

  setDefaultValues(): void {
    console.log('setDefaultValues');
    this.datePickerConfigReleaseDate = Object.assign({}, {
      containerClass: 'theme-dark-blue',
      minDate: new Date (new Date().setDate(new Date().getDate() + 1)),
      dateInputFormat: 'DD/MM/YYYY',
      showWeekNumbers:false
    });

    this.datePickerConfigClosingDate = Object.assign({}, {
      containerClass: 'theme-dark-blue',
      minDate: new Date (new Date().setDate(new Date().getDate() + 2)),
      dateInputFormat: 'DD/MM/YYYY',
      showWeekNumbers:false
    });
  }
}

