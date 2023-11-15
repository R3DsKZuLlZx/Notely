import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeToggleComponent } from '../../shared/theme-toggle/theme-toggle.component';
import {Router, RouterModule } from '@angular/router';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterModule, ThemeToggleComponent],
  template: `
    <div class="container">

      <div class="header">
        <div class="row">
          <div class="col">
            <button class="btn icon-back" form="addForm"></button>
          </div>
          <div class="col">
            <app-theme-toggle />
          </div>
        </div>
      </div>

      <form id="addForm" [formGroup]="addForm" (ngSubmit)="onSubmit()">
        <input class="form-control" type="text" formControlName="title" placeholder="Title" style="font-size: 2.5rem; line-height: 1.2">
        <hr>
        <textarea class="form-control" formControlName="content" placeholder="Content" style="height: 20rem"></textarea>
      </form>

    </div>
  `,
  styleUrl: './add.component.scss'
})
export class AddComponent {
  constructor(private readonly router: Router) {
  }

  addForm = new FormGroup({
    title: new FormControl(''),
    content: new FormControl(''),
  });

  onSubmit() {
    console.log(this.addForm.value);
    this.router.navigate(['/'])
  }
}
