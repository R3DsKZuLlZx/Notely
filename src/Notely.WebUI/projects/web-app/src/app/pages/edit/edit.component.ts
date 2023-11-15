import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import {Router, RouterModule } from '@angular/router';
import { ThemeToggleComponent } from '../../shared/theme-toggle/theme-toggle.component';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterModule, ThemeToggleComponent],
  template: `
    <div class="container">

      <div class="header">
        <div class="row">
          <div class="col">
            <button class="btn icon-back" form="editForm"></button>
          </div>
          <div class="col">
            <app-theme-toggle />
          </div>
        </div>
      </div>

      <form id="editForm" [formGroup]="editForm" (ngSubmit)="onSubmit()">
        <input class="form-control" type="text" formControlName="title" placeholder="Title" style="font-size: 2.5rem; line-height: 1.2">
        <hr>
        <textarea class="form-control" formControlName="content" placeholder="Content" style="height: 20rem"></textarea>
      </form>

    </div>
  `,
  styleUrl: './edit.component.scss'
})
export class EditComponent {
  constructor(private readonly router: Router) {
  }

  editForm = new FormGroup({
    title: new FormControl(''),
    content: new FormControl(''),
  });

  onSubmit() {
    console.log(this.editForm.value);
    this.router.navigate(['/details'])
  }
}
