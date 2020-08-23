import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TimeSeriesChart-Web';
  websiteList: any = ['ItSolutionStuff.com', 'HDTuto.com', 'Nicesnippets.com']
  
  form = new FormGroup({
    website: new FormControl('', Validators.required)
  });
  
  get f(){
    return this.form.controls;
  }
  
  submit(){
    console.log(this.form.value);
  }
  changeWebsite(e) {
    console.log(e.target.value);
  }
}
