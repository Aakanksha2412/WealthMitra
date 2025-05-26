import { Component, OnInit } from '@angular/core';
import { InvestorMutualfundServiceService } from '../../investor-mutualfund-service.service';

@Component({
  selector: 'app-display-mutual-fund',
  templateUrl: './display-mutual-fund.component.html',
  styleUrls: ['./display-mutual-fund.component.css']
})
export class DisplayMutualFundComponent implements OnInit {

  mutuals:any=[]
  
  constructor(private svc:InvestorMutualfundServiceService) { }



  ngOnInit(): void {

    this.mutuals=this.svc.GetAll();

  }

}
