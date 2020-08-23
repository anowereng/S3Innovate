import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LineChartComponent } from './charts/line-chart/line-chart.component';


const routes: Routes = [
  { path: 'linechart', pathMatch: 'full', component: LineChartComponent },
  { path: '', pathMatch: 'full', component: LineChartComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
