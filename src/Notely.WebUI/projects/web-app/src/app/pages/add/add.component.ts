import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeToggleComponent } from '../../shared/theme-toggle/theme-toggle.component';
import { Router, RouterModule } from '@angular/router';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AddNoteCommand, NotelyClient } from '../../../../generated/api';
import { lastValueFrom } from 'rxjs';

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
        <input class="form-control form-control__minimal" type="text" formControlName="title" placeholder="Title">
        <hr>
        <textarea class="form-control form-control__minimal" formControlName="content" placeholder="Content"></textarea>
      </form>

    </div>
  `,
  styles: []
})
export class AddComponent {
  constructor(private readonly router: Router, private readonly notelyClient: NotelyClient) {
  }

  addForm = new FormGroup({
    title: new FormControl('', [Validators.required]),
    content: new FormControl('', [Validators.required]),
  });

  async onSubmit() {
    if(!!this.addForm.valid) {
      let addNoteCommand: AddNoteCommand = {
        title: this.addForm.value.title ?? '',
        content: this.addForm.value.content ?? '',
      }
      await lastValueFrom(this.notelyClient.addNote(addNoteCommand));
    }

    this.router.navigate(['/'])
  }
}
