import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

showConfirm(message: string, okCallback: () => any) {
  alertify.confirm(message, function(e){
    if (e) {
      okCallback();
    }
  });
}

showSuccess(message: string){
  alertify.success(message);
}

showError(message: string){
  alertify.error(message);
}

showWarning(message: string){
  alertify.warning(message);
}

showMessage(message: string){
  alertify.message(message);
}

}
