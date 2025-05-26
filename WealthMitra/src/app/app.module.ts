import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { appRoutingModule} from './app-routing.module';
import { ProductsComponent } from './products/products.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InvestorDashboardModule } from './investor-dashboard/investor-dashboard.module';
import { HttpClientModule } from '@angular/common/http';
import { StockModule } from './investor-dashboard/stock/stock.module';
import { MutualFundModule } from './investor-dashboard/mutual-fund/mutual-fund.module';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ProductsComponent,
    ContactUsComponent,
    LoginComponent,
    SignupComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    InvestorDashboardModule,
    appRoutingModule,
    HttpClientModule,
    StockModule,
    MutualFundModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
