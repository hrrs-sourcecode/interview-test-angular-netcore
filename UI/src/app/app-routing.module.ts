import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateTenderComponent } from './views/tender/create-tender.component';
import { DetailsTenderComponent } from './views/tender/details-tender.component';
import { EditTenderComponent } from './views/tender/edit-tender.component';
import { ListTenderComponent } from './views/tender/list-tender.component';

const routes: Routes =       
[ 
  { path: 'tenderList', component: ListTenderComponent },
  { path: 'tenderCreate', component: CreateTenderComponent },
  { path: 'tenderDetails/:id', component: DetailsTenderComponent },
  { path: 'tenderEdit/:id', component: EditTenderComponent },
  { path: '', redirectTo:'tenderList', pathMatch: 'full' },
  //{ path: '**', component: PageNotFoundComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
