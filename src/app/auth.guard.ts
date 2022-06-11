import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Authenticate } from './Models/authenticate.model';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private jwtHelper: JwtHelperService, private http: HttpClient) { }
  async canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot) {
    const token= localStorage.getItem("token");

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    const isRefreshSuccess = await this.RefreshingTokens(token!);
    if (!isRefreshSuccess) {
      this.router.navigate(['/signIn']);
    }
    return isRefreshSuccess;
  }
  private async RefreshingTokens(token: string): Promise<boolean> {

    const refreshToken= localStorage.getItem("refreshToken");
    if (!token || !refreshToken) { 
      return false;
    }
    const tokenDetails = JSON.stringify({ accessToken: token, refreshToken: refreshToken });
    let isRefresh: boolean;

    const refresh = await new Promise<Authenticate>((resolve, reject) => {
      this.http.post<Authenticate>("https://localhost:7204/api/token/refresh", tokenDetails, {
        headers: new HttpHeaders({
          "Content-Type": "application/json"
        })
      }).subscribe({
        next: (res: Authenticate) => resolve(res),
        error: (_) => { reject; isRefresh = false;}
      });
    });
    localStorage.setItem("token", refresh.token);
    localStorage.setItem("refreshToken", refresh.refreshToken);
    isRefresh = true;

    return isRefresh;
  }
}


