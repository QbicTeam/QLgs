import { Component, OnDestroy, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { AuthService } from 'src/app/securitas/_services/auth.service';
import { Subject } from 'rxjs';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ShareDataService } from 'src/app/_services/ShareData.service';
import { QuickAction } from 'src/app/_model/QuickAction';
@Component({
  selector: 'app-edoCta',
  templateUrl: './edoCta.component.html',
  styleUrls: ['./edoCta.component.css']
})
export class EdoCtaComponent implements OnDestroy, OnInit {

  dtTrigger: Subject<any> = new Subject<any>();

  @Input() formData: any;

  @ViewChild('closeNewInvitationModalBtn') closeBtn: ElementRef;
  @ViewChild('closeCancelInvitation') closeBtnCancel: ElementRef;
  @ViewChild('closeApproveInvitation') closeBtnApprove: ElementRef;
  
  constructor(private _authService: AuthService, private _alertify: AlertifyService, private _shareData: ShareDataService) { }

  currentUser: any;
  currentExp: any;
  aPagar: any;

  ngOnInit() {
    this.currentUser = this._authService.getDecodedToken();
    console.log("currentUser ", this.currentUser);
    
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

  selectExp(exp,frac) {
    this.currentExp = {exp};
    console.log('Exp', this.currentExp, 'frac', frac);
    this._shareData.notifyActionSource(new QuickAction("selectedExp", { value: {frac,exp}}));
  }

  selectAPagar(tipo) {
    this.aPagar = {tipo};
    console.log('Forma de Pago', this.aPagar);
  }
}
