import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Note, NotelyClient } from '../../../../generated/api';
import { ThemeToggleComponent } from '../../shared/theme-toggle/theme-toggle.component';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule, ThemeToggleComponent, RouterModule],
  template: `
    <div class="container">

      <div class="header">
        <div class="row">
          <div class="col">
            <button class="btn icon-back" [routerLink]="['/']"></button>
          </div>
          <div class="col">
            <button class="btn icon-edit" [routerLink]="['/edit', note?.id]"></button>
            <app-theme-toggle />
          </div>
        </div>
      </div>

      <h1>
        {{note?.title}}
      </h1>
      <hr>
      <p>
        {{note?.content}}
      </p>
    </div>
  `,
  styles: []
})
export class DetailsComponent implements OnInit {
  constructor(private readonly route: ActivatedRoute, private readonly notelyClient: NotelyClient) {
    this.noteId = this.route.snapshot.params['id'];
  }

  async ngOnInit() {
    this.note = await lastValueFrom(this.notelyClient.getNote(this.noteId))
  }

  noteId: string;
  note: Note | null = null;
}
