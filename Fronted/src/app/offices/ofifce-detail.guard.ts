import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { CanActivate, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from "@angular/router";

@Injectable({
    providedIn: 'root'
})

export class OfifceDetailGuard implements CanActivate {
    
    constructor(private router: Router){
        
    }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
            let id = +next.url[1].path;
            if(isNaN(id) || id < 1){
                alert("Invalid office Id");
                this.router.navigate(['/offices']);
                return false;
            }
            return true;
        }

}