import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Note } from '../../../generated/api';

@Component({
  selector: 'app-note',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="note">
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
