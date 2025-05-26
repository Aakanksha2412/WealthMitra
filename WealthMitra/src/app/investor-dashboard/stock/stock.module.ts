import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssetDisplayComponent } from './asset-display/asset-display.component';
import { RegisterAssetsComponent } from './register-assets/register-assets.component';



@NgModule({
  declarations: [
    AssetDisplayComponent,
    RegisterAssetsComponent
  ],

  exports:[
    AssetDisplayComponent,
    RegisterAssetsComponent
    
  ],
  imports: [
    CommonModule
  ]
})
export class StockModule { }
