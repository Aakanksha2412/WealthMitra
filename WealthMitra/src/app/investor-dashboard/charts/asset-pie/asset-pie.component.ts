import { Component, OnInit } from '@angular/core';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { ChartType ,ChartOptions } from 'chart.js'

@Component({
  selector: 'app-asset-pie',
  templateUrl: './asset-pie.component.html',
  styleUrls: ['./asset-pie.component.css']
})
export class AssetPieComponent implements OnInit {
  public pieAssetChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieAssetChartLabels: Label[] = ['Equity', 'Debt','Liquid' ];
  public pieAssetChartData: SingleDataSet = [300, 500, 100];
  public pieAssetChartType: ChartType = 'pie';
  public pieAssetChartLegend = true;
  public pieAssetChartPlugins = [];

  constructor() { }

  ngOnInit(): void {
  }

}
