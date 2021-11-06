import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { CoreService } from 'src/app/_services/core.service';

@Component({
  selector: 'app-containerForm',
  templateUrl: './containerForm.component.html',
  styleUrls: ['./containerForm.component.css']
})
export class ContainerFormComponent implements OnInit {

  currentForm: any;
  pathForm: string;
    
  constructor(private _coreService: CoreService, private router: Router) { }

  ngOnInit() {
    this.pathForm = this.router.url;
    console.log("url:", this.pathForm);
    this.loadSelectedFormData();
  }

  loadSelectedFormData() {
    this.currentForm = this._coreService.getFormInfoByName(this.pathForm);
  }

}
