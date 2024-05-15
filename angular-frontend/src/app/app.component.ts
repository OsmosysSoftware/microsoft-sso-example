import { Component, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private msalService: MsalService, private http: HttpClient) {}
  loginResponse: any;
  login() {
    this.msalService.loginRedirect();
  }

  ngOnInit() {
    this.msalService.handleRedirectObservable().subscribe({
      next: (result) => {
        if (result !== null && result.idToken) {
          const idToken = result.idToken;
          this.http.post('http://localhost:5068/api/auth/microsoft', { token: idToken }).subscribe((response: any) => {
            localStorage.setItem('jwt', response.token);
            console.table(response)
            console.log('JWT received and stored:', response.token);
            this.loginResponse = response;
          });
        }
      },
      error: (error) => console.error(error)
    });
  }
}
