import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainNagivationBarComponent } from './main-nagivation-bar/main-nagivation-bar.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { MainScreenComponent } from './main-screen/main-screen.component';
import {IgxPieChartModule, IgxLegendModule, IgxItemLegendModule } from 'igniteui-angular-charts';
import { ChartsModule } from 'ng2-charts';
import { AssetPieComponent } from './charts/asset-pie/asset-pie.component';
import { ProductPieComponent } from './charts/product-pie/product-pie.component';
import { CategoryPieComponent } from './charts/category-pie/category-pie.component';
import { appRoutingModule } from '../app-routing.module';
import { ProfileComponent } from './profile/profile.component';
import { ChangepasswordComponent } from './changepassword/changepassword.component';
import { UpdateProfileComponent } from './update-profile/update-profile.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterAssetsComponent } from './register-assets/register-assets.component';


@NgModule({
  declarations: [
    MainNagivationBarComponent,
    NavigationBarComponent,
    MainScreenComponent,
    AssetPieComponent,
    ProductPieComponent,
    CategoryPieComponent,
    ProfileComponent,
    ChangepasswordComponent,
    UpdateProfileComponent,
    RegisterAssetsComponent
    
  ],
  exports:[
    MainNagivationBarComponent,
    NavigationBarComponent,
    MainScreenComponent,
    AssetPieComponent,
    ProductPieComponent,
    CategoryPieComponent,
    ProfileComponent,
    ChangepasswordComponent,
    UpdateProfileComponent,
    RegisterAssetsComponent
  ],
  imports: [
    CommonModule,
    IgxPieChartModule,
	  IgxLegendModule,
	  IgxItemLegendModule,
    ChartsModule,
    appRoutingModule,
    ReactiveFormsModule
  ]
})
export class InvestorDashboardModule { }
