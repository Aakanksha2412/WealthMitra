import { Component, OnInit } from '@angular/core';
import { InvestorStocksServiceService } from '../../investor-stock-service.service';

@Component({
  selector: 'app-asset-display',
  templateUrl: './asset-display.component.html',
  styleUrls: ['./asset-display.component.css']
})
export class AssetDisplayComponent implements OnInit {


    stocks:any=[]
  
    constructor(private svc:InvestorStocksServiceService) { }
  
  
  
    ngOnInit(): void {
  
      this.stocks=this.svc.GetAll();
  
    }
  
  
  
  
}
