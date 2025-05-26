import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisplayMutualFundComponent } from './display-mutual-fund/display-mutual-fund.component';
import { AddMutualFundComponent } from './add-mutual-fund/add-mutual-fund.component';



@NgModule({
  declarations: [
    DisplayMutualFundComponent,
    AddMutualFundComponent
  ],
  exports:[
    DisplayMutualFundComponent,
    AddMutualFundComponent
  ],
  imports: [
    CommonModule
  ]
})
export class MutualFundModule { }
