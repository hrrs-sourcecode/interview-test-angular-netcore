import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListTenderComponent } from './views/tender/list-tender.component';
import { CreateTenderComponent } from './views/tender/create-tender.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule, BsDatepickerConfig  } from 'ngx-bootstrap/datepicker';
import { TenderService } from './services/tender/tender.service';
import { TenderScalePipe } from './pipe/tender-scale.pipe';
import { EditTenderComponent } from './views/tender/edit-tender.component';
import { DetailsTenderComponent } from './views/tender/details-tender.component';
import { TenderIdPipe } from './pipe/tender-id.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ListTenderComponent,
    CreateTenderComponent,
    TenderScalePipe,
    TenderIdPipe,
    EditTenderComponent,
    DetailsTenderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BsDatepickerModule.forRoot(),
    ReactiveFormsModule
  ],
  providers: [BsDatepickerConfig, TenderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
