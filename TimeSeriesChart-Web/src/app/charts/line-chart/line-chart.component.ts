import { Component } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ChartService } from 'src/services/chart.service';
@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent {

  websiteList: any = ['ItSolutionStuff.com', 'HDTuto.com', 'Nicesnippets.com'];
  public buildings: any = [];
  public datafield: any = [];
  public objectitem: any = [];

  constructor(private chartservice: ChartService) { this.GetDropdownItem(); }

  form = new FormGroup({
    building: new FormControl('', Validators.required),
    object: new FormControl('', Validators.required),
    datafield: new FormControl('', Validators.required),
    dtfrom: new FormControl('', Validators.required),
    dtto: new FormControl('', Validators.required)
  });

  GetDropdownItem() {
    this.chartservice.GetAllBuildings().subscribe(result => {
      this.buildings = result;
      console.log(result);
    });
    this.chartservice.GetAllDataField().subscribe(result => {
      this.datafield = result;
      console.log(result);
    });
    this.chartservice.GetAllObjectItem().subscribe(result => {
      this.objectitem = result;
      console.log(result);
    });
  }


  submit() {
    console.log(this.form.value);
  }
  changeValue(e) {
    console.log(e.target.value);
  }


  // Array of different segments in chart
  // tslint:disable-next-line: member-ordering
  lineChartData: ChartDataSets[] = [
    { data: [65, 59, 80, 81, 56, 55, 40, 56, 55, 40], label: 'Product A' },
    { data: [65, 59, 80, 81, 56, 55, 40, 56, 55, 40], label: 'Product B' }
  ];

  // Labels shown on the x-axis
  // tslint:disable-next-line: member-ordering
  lineChartLabels: Label[] = ['00:00', '00:01', '00:02', '00:03', '00:04', '00:5', '00:06'];

  // Define chart options
  lineChartOptions: ChartOptions = {
    responsive: true
  };

  // Define colors of chart segments
  // tslint:disable-next-line: member-ordering
  lineChartColors: Color[] = [
    { // red
      backgroundColor: 'rgba(255,0,0,0.3)',
      borderColor: 'red',
    }
  ];

  // Set true to show legends
  // tslint:disable-next-line: member-ordering
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