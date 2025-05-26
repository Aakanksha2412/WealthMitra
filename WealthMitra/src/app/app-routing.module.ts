import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

import { AboutComponent } from './about/about.component';


import { ProductsComponent } from './products/products.component';

import { ContactUsComponent } from './contact-us/contact-us.component';

import { LoginComponent } from './login/login.component';

import { SignupComponent } from './signup/signup.component';

import { MainScreenComponent } from './investor-dashboard/main-screen/main-screen.component';

import { ProfileComponent } from './investor-dashboard/profile/profile.component';

import { ChangepasswordComponent } from './investor-dashboard/changepassword/changepassword.component';

import { UpdateProfileComponent } from './investor-dashboard/update-profile/update-profile.component';
import { RegisterAssetsComponent } from './investor-dashboard/register-assets/register-assets.component';
import { AssetDisplayComponent } from './investor-dashboard/stock/asset-display/asset-display.component';
import { AddMutualFundComponent } from './investor-dashboard/mutual-fund/add-mutual-fund/add-mutual-fund.component';
import { DisplayMutualFundComponent } from './investor-dashboard/mutual-fund/display-mutual-fund/display-mutual-fund.component';
//import { AssetDisplayComponent } from './investor-dashboard/stock/asset-display/asset-display.component';
//import { RegisterAssetsComponent } from './investor-dashboard/stock/register-assets/register-assets.component';
// import { AddMutualFundComponent } from './investor-dashboard/mutual-fund/add-mutual-fund/add-mutual-fund.component';
// import { DisplayMutualFundComponent } from './investor-dashboard/mutual-fund/display-mutual-fund/display-mutual-fund.component';
// import { TransactionHistoryComponent } from './investor-dashboard/transactionshistory/transaction-history/transaction-history.component';
// import { StokeHistoryComponent } from './investor-dashboard/transactionshistory/stoke-history/stoke-history.component';
// import { MutualFundHistoryComponent } from './investor-dashboard/transactionshistory/mutual-fund-history/mutual-fund-history.component';






const routes: Routes = [

    { path: 'home', component: HomeComponent },

    { path: 'about', component: AboutComponent },

    { path: 'contactus', component: ContactUsComponent },

    { path: 'products', component: ProductsComponent },

   

    { path: 'login', component: LoginComponent },

    {path: 'signup', component: SignupComponent},

    {path: 'dashboard',component:MainScreenComponent},

    {path: 'profile',component:ProfileComponent},

    {path: 'changepassword',component:ChangepasswordComponent},

    {path: 'updateinvestor',component:UpdateProfileComponent},

  ////  {path: 'registerassets',component:RegisterAssetsComponent},

 {path: 'displyassets',component:AssetDisplayComponent},

 
 {path: 'registerassets',component:RegisterAssetsComponent},

 {path: 'addmutualfund',component:AddMutualFundComponent}, 

  {path: 'displaymutualfund',component:DisplayMutualFundComponent}, 

//  {path: 'history',component:TransactionHistoryComponent}, 

//  {path: 'stockhistory',component:StokeHistoryComponent}, 

//  {path: 'mutualfundhistory',component:MutualFundHistoryComponent}, 


    
   

    { path: '', redirectTo: 'home' , pathMatch: 'full'}
    
    

];



export const appRoutingModule = RouterModule.forRoot(routes);








  export class FormsReactiveModule { }