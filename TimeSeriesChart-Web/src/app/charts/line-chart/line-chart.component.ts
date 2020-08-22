
import { Component } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent {

  // Array of different segments in chart
  lineChartData: ChartDataSets[] = [
    { data: [65, 59, 80, 81, 56, 55, 40, 56, 55, 40 ], label: 'Product A' },
    { data: [65, 59, 80, 81, 56, 55, 40, 56, 55, 40 ], label: 'Product B' },
    { data: [65, 59, 80, 81, 56, 55, 40 , 56, 55, 40 ], label: 'Product C' },
    { data: [65, 59, 80, 81, 56, 55, 40 , 56, 55, 40 ], label: 'Product D' },
    { data: [65, 59, 80, 81, 56, 55, 40 , 56, 55, 40 ], label: 'Product E' },
    { data: [65, 59, 80, 81, 56, 55, 40 ,  56, 55, 40 ], label: 'Product F' }
  ];

  //Labels shown on the x-axis
  lineChartLabels: Label[] = ['00:00', '00:01', '00:02', '00:03', '00:04', '00:5', '00:06'];

  // Define chart options
  lineChartOptions: ChartOptions = {
    responsive: true
  };

  // Define colors of chart segments
  lineChartColors: Color[] = [
    { // red
      backgroundColor: 'rgba(255,0,0,0.3)',
      borderColor: 'red',
    }
  ];

  // Set true to show legends
  lineChartLegend = true;

  // Define type of chart
  lineChartType = 'line';

  lineChartPlugins = [];

  // events
  chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

}