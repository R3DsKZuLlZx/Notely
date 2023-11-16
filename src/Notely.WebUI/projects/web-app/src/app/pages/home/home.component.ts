import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoteComponent } from '../../shared/note/note.component';
import { ThemeToggleComponent } from '../../shared/theme-toggle/theme-toggle.component';
import { Note, NotelyClient } from '../../../../generated/api';
import { HttpClientModule } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, NoteComponent, ThemeToggleComponent, HttpClientModule, RouterModule],
  template: `
    <div class="container">

      <div class="header">
        <div class="row">
          <div class="col">
            <h1>Notes</h1>
          </div>
          <div class="col">
            <button class="btn icon-plus" [routerLink]="['/add']"></button>
            <button class="btn icon-search"></button>
            <app-theme-toggle />
          </div>
        </div>
      </div>

      @for (note of notes; track note.id) {
        <app-note [note]="note" />
      } @empty {
      Empty
      }

    </div>
  `,
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  constructor(private readonly notelyClient: NotelyClient) {
  }

  async ngOnInit(): Promise<void> {
    this.notes = await lastValueFrom(this.notelyClient.getNotes()) ?? [];
  }

  notes: Note[] = []
}
