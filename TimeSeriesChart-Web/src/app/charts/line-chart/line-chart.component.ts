import { Component } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ChartService } from 'src/services/chart.service';
import { ReadingsModel } from 'src/app/_models/ReadingsModel';
import { SelectModel } from 'src/app/_models/SelectModel';
import { DatePipe } from '@angular/common'
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

  constructor(private chartservice: ChartService, public datepipe: DatePipe) {
    this.GetDropdownItem();
  }

  form = new FormGroup({
    building: new FormControl('', Validators.required),
    object: new FormControl('', Validators.required),
    datafield: new FormControl('', Validators.required),
    dtfrom: new FormControl(new Date, Validators.required),
    dtto: new FormControl(new Date, Validators.required)
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
    let buildid =  this.form.value.building.Id;
    let datafield =  this.form.value.datafield.Id;
    let object =  this.form.value.object.Id;
    let dtfrom =  this.datepipe.transform(this.form.value.dtfrom, 'dd-MMM-yyyy');
    let dtto =  this.datepipe.transform(this.form.value.dtto, 'dd-MMM-yyyy');

    this.chartservice.GetAllReadings(object, buildid, datafield, dtfrom , dtto).subscribe(result => {
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