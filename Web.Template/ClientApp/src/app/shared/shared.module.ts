import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AlertmodalComponent } from './alertmodal/alertmodal.component';
//import { ModalModule } from 'ngx-bootstrap/modal';



@NgModule({
  declarations: [AlertmodalComponent],
  imports: [
    CommonModule,
    //ModalModule
  ],
  exports: [AlertmodalComponent],//informando que o component está disponivel para outros usarem
  entryComponents: [AlertmodalComponent]
})
export class SharedModule { }
