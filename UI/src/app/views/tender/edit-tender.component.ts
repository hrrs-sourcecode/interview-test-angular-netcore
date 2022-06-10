import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Tender } from 'src/app/models/tender.model';
import { TenderIdPipe } from 'src/app/pipe/tender-id.pipe';
import { TenderService } from 'src/app/services/tender/tender.service';

@Component({
  selector: 'app-edit-tender',
  templateUrl: './edit-tender.component.html',
  styles: [
  ]
})
export class EditTenderComponent implements OnInit {


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
  createdBy!:string;
  createdDate!:Date;

  getFormData(): void{
    this._tenderService.getTenderById(this._activatedRoute.snapshot.params['id']).subscribe(
      x => { this.tender = <Tender> x.data; this.setFormGroup(); this.monitoringCalendar();}, 
      error => { alert(this.errorMessage); console.log(error) },
      () => {  } );
  }

  setFormGroup(): void {
    let tender:Tender;
    let idPipe = new TenderIdPipe();
      this.tenderForm = this._fb.group(
        {
          id:[this.tender.id],
          tenderID:[{value: idPipe.transform(this.tender.id,7), disabled: true }],
          contractNo:[ this.tender.contractNo, Validators.required],
          tenderName:[ this.tender.tenderName, Validators.required],
          tenderValue:[ this.tender.tenderValue, Validators.required],
          description:[ this.tender.description, Validators.required],
          releaseDate:[ new Date(this.tender.releaseDate), Validators.required],
          closingDate:[ new Date(this.tender.closingDate), Validators.required],
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

  monitoringCalendar():void{
    console.log('monitoringCalendar');
    this.tenderForm.get('releaseDate')?.valueChanges.subscribe(x => {
      console.log(x);
      this.datePickerConfigClosingDate = Object.assign({}, {
        containerClass: 'theme-dark-blue',
        minDate: new Date (x.setDate(x.getDate() + 1)),
        dateInputFormat: 'DD/MM/YYYY',
        showWeekNumbers:false
      });
      if (this.tenderForm.get('closingDate')?.value <= x) 
      {
        this.tenderForm.get('closingDate')?.setValue(new Date (x.setDate(x.getDate())));
      } 
    });
    console.log('monitoringCalendar');
  }

  onSubmit()
  {
    //this.assignFormControl(this.tenderForm);
    let tender:Tender = {
      id :this.tenderForm.get('id')?.value,
      tenderID:this.tenderForm.get('tenderID')?.value,
      contractNo:this.tenderForm.get('contractNo')?.value,
      tenderName:this.tenderForm.get('tenderName')?.value,
      tenderValue:this.tenderForm.get('tenderValue')?.value,
      description:this.tenderForm.get('description')?.value,
      releaseDate:this.tenderForm.get('releaseDate')?.value,
      closingDate:this.tenderForm.get('closingDate')?.value,    
      modifiedBy:'Admin',
      modifiedDate: new Date(),
    }

    this._tenderService.updateTender(tender).subscribe(
      x => { alert(this.messageResponse); this._router.navigate(['/tenderList']) }, 
      error => { alert(this.errorMessage); console.log(error) },
      () => { alert('Redirect to the list ... ')} );
    
  }
}
