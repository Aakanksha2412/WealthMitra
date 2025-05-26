import { Component, OnInit } from '@angular/core';
import { SingleDataSet, Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { ChartType ,ChartOptions } from 'chart.js'

@Component({
  selector: 'app-category-pie',
  templateUrl: './category-pie.component.html',
  styleUrls: ['./category-pie.component.css']
})
export class CategoryPieComponent implements OnInit {
  public pieCategoryChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieCategoryChartLabels: Label[] = ['MidCap', 'SmallCap','LargeCap' ];
  public pieCategoryChartData: SingleDataSet = [3000, 5000, 1000];
  public pieCategoryChartType: ChartType = 'pie';
  public pieCategoryChartLegend = true;
  public pieCategoryChartPlugins = [];
  constructor() { }

  ngOnInit(): void {
  }

}
