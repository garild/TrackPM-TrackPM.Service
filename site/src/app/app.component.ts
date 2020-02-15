import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from './services';
import { User } from './models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
    currentUser: User;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        console.log("run here")
        this.authenticationService.currentUser.subscribe(x =>
            this.currentUser = x
          );
    }

    logout() {
       
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
}
