import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { catchError, finalize } from 'rxjs/operators';
import { ReadingsModel } from 'src/app/_models/ReadingsModel';
@Injectable({
  providedIn: 'root'
})
export class ChartService {
  url = environment.url;
  constructor(private http: HttpClient) { }

  GetAllBuildings() {
    return this.http.get(this.url + 'buildings')
      .pipe(catchError(e => {
        throw new Error(e);
      }));
  }
  GetAllDataField() {
    return this.http.get(this.url + 'DataField')
      .pipe(catchError(e => {
        throw new Error(e);
      }));
  }
  GetAllObjectItem() {
    return this.http.get(this.url + 'ObjectItem')
      .pipe(catchError(e => {
        throw new Error(e);
      }));
  }
  GetAllReadings( objectid : any, buildid: any, datafieldid: any,  dtfrom:any, dtto:any) {
    return this.http.get<ReadingsModel>(this.url + `Readings?objectid=${objectid}&buildid=${buildid}&datafieldid=${datafieldid}&dtfrom=${dtfrom}&dtto=${dtto}`)
      .pipe(catchError(e => {
        throw new Error(e);
      }));
  }
}

