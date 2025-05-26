import { Injectable } from '@angular/core';



@Injectable({

  providedIn: 'root'

})

export class InvestorStocksServiceService {



  stocks:any=[]

  constructor() {



  this.stocks=[

      {"id":1,"name":"TCS","buySell Price":"180","currentPrice":468,"TotalValue":1234,"ROI":"123","PL":"444","quantity":1000},

      {"id":2,"name":"Tanla","buySellPrice":"260","currentPrice":1260,"TotalValue":1234,"ROI":"123","PL":"444","quantity":100},

      {"id":3,"name":"Idea","buySellPrice":"8","currentPrice":12,"TotalValue":1234,"ROI":"123","PL":"444","quantity":10000},

      {"id":4,"name":"Gail","buySellPrice":"90","currentPrice":152,"TotalValue":1234,"ROI":"123","PL":"444","quantity":100}



    ];

  }

  GetAll():any{

    return this.stocks;

  }

}