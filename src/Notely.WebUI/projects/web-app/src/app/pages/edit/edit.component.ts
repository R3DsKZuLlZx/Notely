import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ThemeToggleComponent } from '../../shared/theme-toggle/theme-toggle.component';
import { EditNoteCommand, Note, NotelyClient } from '../../../../generated/api';
import { lastValueFrom } from 'rxjs';

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
        <input class="form-control form-control__minimal" type="text" formControlName="title" style="font-size: calc(1.375rem + 1.5vw); line-height: 1.2; font-weight: 500">
        <hr>
        <textarea class="form-control form-control__minimal" formControlName="content" style="height: 20rem"></textarea>
      </form>

    </div>
  `,
  styleUrl: './edit.component.scss'
})
export class EditComponent implements OnInit {
  constructor(private readonly route: ActivatedRoute, private readonly router: Router, private readonly notelyClient: NotelyClient) {
    this.noteId = this.route.snapshot.params['id'];
  }

  async ngOnInit() {
    this.note = await lastValueFrom(this.notelyClient.getNote(this.noteId))
    this.editForm.setValue(
      {
        title : this.note.title,
        content: this.note.content
      })

    this.initialValues = this.editForm.value;
  }

  noteId: string;
  note: Note | null = null;
  initialValues: {} = {};

  editForm = new FormGroup({
    title: new FormControl(this.note?.title, [Validators.required]),
    content: new FormControl(this.note?.content, [Validators.required]),
  });

  async onSubmit() {
    if (this.initialValues != this.editForm.value && !!this.editForm.valid) {
      let editNoteCommand: EditNoteCommand = {
        id: this.noteId,
        title: this.editForm.value.title ?? '',
        content: this.editForm.value.content ?? '',
      }
      await lastValueFrom(this.notelyClient.editNote(editNoteCommand));
    }

    this.router.navigate(['/details', this.noteId])
  }
}
