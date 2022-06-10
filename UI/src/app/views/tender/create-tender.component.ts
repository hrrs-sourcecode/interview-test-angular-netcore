import { Component, OnInit, Renderer2 } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { getDate } from 'ngx-bootstrap/chronos/utils/date-getters';
import { BsDatepickerConfig, DatepickerDateCustomClasses } from 'ngx-bootstrap/datepicker';
import { Tender } from 'src/app/models/tender.model';
import { TenderService } from 'src/app/services/tender/tender.service';



@Component({
  selector: 'app-create-tender',
  templateUrl: './create-tender-reactive-form.component.html',
  styles: [
  ]
})


export class CreateTenderComponent implements OnInit {

  messageResponse: string = 'Success';
  errorMessage: string = 'Cannot connect to the server, please try again later';
  releaseDate!: Date;

  datePickerConfigReleaseDate! : Partial<BsDatepickerConfig>;
  datePickerConfigClosingDate! : Partial<BsDatepickerConfig>;

  constructor(private _fb: FormBuilder, private _tenderService : TenderService, private _router: Router) { 
  }

  tenderForm!: FormGroup;

  ngOnInit(): void {

    this.setFormGroup();

    this.setDefaultValues();

    this.monitoringCalendar();

  }

  setFormGroup(): void {
    this.tenderForm = this._fb.group(
      {
        //tenderID:['', Validators.required],
        contractNo:['', Validators.required],
        tenderName:['', Validators.required],
        tenderValue:['', Validators.required],
        description:['', Validators.required],
        releaseDate:['', Validators.required],
        closingDate:['', Validators.required],
      }
    )
  }

  setDefaultValues(): void {
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

  monitoringForm(): void {
    this.tenderForm.valueChanges.subscribe(x => {
      this.assignFormControl(this.tenderForm);
    })
  }

  monitoringCalendar():void{
    this.tenderForm.get('releaseDate')?.valueChanges.subscribe(x => {
      this.datePickerConfigClosingDate = Object.assign({}, {
        containerClass: 'theme-dark-blue',
        minDate: new Date (x.setDate(x.getDate() + 1)),
        dateInputFormat: 'DD/MM/YYYY',
        showWeekNumbers:false
      });
      if (this.tenderForm.get('closingDate')?.value <= x && this.tenderForm.get('closingDate')?.dirty) 
      {
        this.tenderForm.get('closingDate')?.setValue(new Date (x.setDate(x.getDate())));
      } 
    })
  }

  assignFormControl(fg:FormGroup):void{
    Object.keys(fg.controls).forEach((key:string) =>
    {
      let controlObj = fg.get(key);
      if(controlObj instanceof FormGroup){
        this.assignFormControl(controlObj);
      }
      else{
        //console.log(key + " : " + controlObj?.value);
      }      
    })
  }

  onSubmit()
  {
    this.assignFormControl(this.tenderForm);
    let tender:Tender = {
      id : 0,
      tenderID:'',
      contractNo:this.tenderForm.get('contractNo')?.value,
      tenderName:this.tenderForm.get('tenderName')?.value,
      tenderValue:this.tenderForm.get('tenderValue')?.value,
      description:this.tenderForm.get('description')?.value,
      releaseDate:this.tenderForm.get('releaseDate')?.value,
      closingDate:this.tenderForm.get('closingDate')?.value,    
      createdBy:'Admin',
      createdDate: new Date(),
    }

    this._tenderService.createTender(tender).subscribe(
      x => { alert(this.messageResponse); this._router.navigate(['/tenderList']) }, 
      error => { alert(this.errorMessage); console.log(error) },
      () => { alert('Redirect to the list ... ')} );
  
    //console.log(this.tenderForm.value );
    //console.log(this.tenderForm.get('tenderName')?.value);
    //console.log(this.tenderForm.get('tenderName')?.touched);
    //console.log(this.tenderForm.get('tenderName')?.errors?.['required']);
    
  }
}
