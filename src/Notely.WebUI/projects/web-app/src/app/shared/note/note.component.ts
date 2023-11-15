import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Note } from '../../../../generated/api';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-note',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <div class="note" [routerLink]="['/details']" [style.background-color]="note.colour">
      <div class="note-title">
        {{note.fileName}}
      </div>
    </div>
  `,
  styleUrl: './note.component.scss'
})
export class NoteComponent {
  @Input() note!: Note;
}