import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NgbModule, HttpClientModule],
  template: `
    <router-outlet></router-outlet>
  `,
  styleUrls: []
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    const storedTheme = localStorage.getItem('theme');

    if(storedTheme !== null) {
      if(storedTheme === 'dark') {
        document.documentElement.setAttribute('data-bs-theme', 'dark')
      } else {
        document.documentElement.setAttribute('data-bs-theme', 'light')
      }
    }
  }

  title = 'web-app';
}
