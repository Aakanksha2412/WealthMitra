import { Component, OnInit } from '@angular/core';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { ChartType ,ChartOptions } from 'chart.js'

@Component({
  selector: 'app-product-pie',
  templateUrl: './product-pie.component.html',
  styleUrls: ['./product-pie.component.css']
})
export class ProductPieComponent implements OnInit {
  
  public pieProductChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieProductChartLabels: Label[] = ['EquityMF', 'Stock','DebtMF' ];
  public pieProductChartData: SingleDataSet = [30000, 50000, 10000];
  public pieProductChartType: ChartType = 'pie';
  public pieProductChartLegend = true;
  public pieProductChartPlugins = [];

  constructor() { }

  ngOnInit(): void {
  }

}
