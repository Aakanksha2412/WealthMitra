import { Component, OnInit } from '@angular/core';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { ChartType ,ChartOptions } from 'chart.js'


@Component({
  selector: 'app-main-screen',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.css']
})
export class MainScreenComponent implements OnInit {

  public pieAssetChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieAssetChartLabels: Label[] = ['Equity', 'Debt','Liquid' ];
  public pieAssetChartData: SingleDataSet = [300, 500, 100];
  public pieAssetChartType: ChartType = 'pie';
  public pieAssetChartLegend = true;
  public pieAssetChartPlugins = [];

  // public pieProductChartOptions: ChartOptions = {
  //   responsive: true,
  // };
  // public pieProductChartLabels: Label[] = ['EquityMF', 'Stock','DebtMF' ];
  // public pieProductChartData: SingleDataSet = [30000, 50000, 10000];
  // public pieProductChartType: ChartType = 'pie';
  // public pieProductChartLegend = true;
  // public pieProductChartPlugins = [];

  // public pieCategoryChartOptions: ChartOptions = {
  //   responsive: true,
  // };
  // public pieCategoryChartLabels: Label[] = ['MidCap', 'SmallCap','LargeCap' ];
  // public pieCategoryChartData: SingleDataSet = [3000, 5000, 1000];
  // public pieCategoryChartType: ChartType = 'pie';
  // public pieCategoryChartLegend = true;
  // public pieCategoryChartPlugins = [];

  constructor() {
    
  }


  ngOnInit(): void {
  }

}
