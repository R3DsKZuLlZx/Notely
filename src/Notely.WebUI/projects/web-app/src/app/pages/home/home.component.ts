import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoteComponent } from '../../shared/note/note.component';
import { ThemeToggleComponent } from '../../shared/theme-toggle/theme-toggle.component';
import { Note, NotelyClient } from '../../../../generated/api';
import { HttpClientModule } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { RouterModule } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, NoteComponent, ThemeToggleComponent, HttpClientModule, RouterModule, ReactiveFormsModule],
  template: `
    <div class="container">

      <div class="header">
        <div class="row">
          <div class="col">
            <h1>Notes</h1>
          </div>
          <div class="col">
            <button class="btn icon-plus" [routerLink]="['/add']"></button>
            <button class="btn icon-search" (click)="toggleSearch()"></button>
            <app-theme-toggle />
          </div>
        </div>
        <div *ngIf="searchEnabled" class="row" style="margin-top: 1rem">
          <form id="searchForm" [formGroup]="searchForm">
            <input class="form-control" type="text" formControlName="search" placeholder="Search">
          </form>
        </div>
      </div>

      @for (note of filteredNotes; track note.id) {
        <app-note [note]="note" />
      } @empty {
      Empty
      }

    </div>
  `,
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit, OnDestroy {
  constructor(private readonly notelyClient: NotelyClient) {
  }

  ngOnDestroy(): void {
    this.$changes?.unsubscribe()
  }

  async ngOnInit(): Promise<void> {
    this.notes = await lastValueFrom(this.notelyClient.getNotes()) ?? [];
    this.filteredNotes = this.notes;
  }

  notes: Note[] = []
  filteredNotes: Note[] = []
  searchEnabled: boolean = false;

  searchForm = new FormGroup({
    search: new FormControl(''),
  });

  $changes = this.searchForm.get('search')?.valueChanges.subscribe((searchTerm) => {
    if (searchTerm == null || !searchTerm) {
      this.filteredNotes = this.notes;
    }

    this.filteredNotes = this.notes.filter((note) =>
      note?.title.toLowerCase().includes(searchTerm!.toLowerCase()),
    );
  })

  toggleSearch() {
    this.searchEnabled = !this.searchEnabled;
  }
}
