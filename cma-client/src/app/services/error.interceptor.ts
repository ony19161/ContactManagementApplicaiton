import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, throwIfEmpty } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    modelStateErrors = '';
    serverError: any;

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(error => {
                if (error.status === 401) {
                    return throwError(error.statusText);
                }
                if (error instanceof HttpErrorResponse) {
                    const applicationError = error.headers.get('Application-Error');
                    if (applicationError) {
                        console.log(applicationError);
                        return throwError(applicationError);
                    }
                }

                this.serverError = error.error.errors; // because server api in running on .net core 2.2

                if (this.serverError && typeof this.serverError === 'object') {
                    for (const key in this.serverError) {
                        if (this.serverError[key]) {
                            this.modelStateErrors += this.serverError[key] + '\n';
                        }
                    }
                }

                return throwError(this.modelStateErrors || this.serverError || 'Server Error');
            })
        );
    }

}

export const ErrorInterceptorProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
};
