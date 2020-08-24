import { Component } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ChartService } from 'src/services/chart.service';
import { ReadingsModel } from 'src/app/_models/ReadingsModel';
import { SelectModel } from 'src/app/_models/SelectModel';
@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent {

  public buildings: SelectModel;
  public datafield: SelectModel;
  public objectitem: SelectModel;

  public readingModel: ReadingsModel;
  public chartLegend: boolean = true;
  public chartType: string = 'line';



  public chartOptions: any = {
    responsive: true,
    legend: {
      position: 'bottom'
    },
    fill: false,
  };

  constructor(private chartservice: ChartService) {
    this.GetDropdownItem(); this.GetReadingsData();
  }

  form = new FormGroup({
    building: new FormControl('', Validators.required),
    object: new FormControl('', Validators.required),
    datafield: new FormControl('', Validators.required),
    dtfrom: new FormControl('', Validators.required),
    dtto: new FormControl('', Validators.required)
  });

  GetDropdownItem() {
    this.chartservice.GetAllBuildings().subscribe(result => {
      this.buildings = result as SelectModel;
    });
    this.chartservice.GetAllDataField().subscribe(result => {
      this.datafield = result as SelectModel;
    });
    this.chartservice.GetAllObjectItem().subscribe(result => {
      this.objectitem = result as SelectModel;
    });
  }
  GetReadingsData() {
    this.chartservice.GetAllReadings().subscribe(result => {
      this.readingModel = result as ReadingsModel;
    });
  }

  search() {
    this.GetReadingsData();
  }
  changeValue(e) {
    console.log(e.target.value);
  }

}