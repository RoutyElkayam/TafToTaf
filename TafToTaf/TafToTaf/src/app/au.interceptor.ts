import {Injectable} from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS} from '@angular/common/http';
import {observable, Observable} from 'rxjs';
import {AccountService} from '../app/shared/services/account.service';

@Injectable()
export class AuInterceptor implements HttpInterceptor{
    
    constructor(private authService: AccountService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {//header של הבקשה את הטוקן בשביל שהסרבר יוכל לדעת מיהו המשתש   כשמקבלים משתמש הוא דוחף ל
        const token = this.authService.token(); 
        
        if (token) {
            //immutable 
            request = request.clone({
                headers: request.headers.set('Authorization', ` ${token}`),
            });
        }
    
        return next.handle(request);
    }
}

