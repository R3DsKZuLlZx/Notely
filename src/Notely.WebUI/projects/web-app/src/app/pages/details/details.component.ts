import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Note } from '../../../../generated/api';
import { ThemeToggleComponent } from '../../shared/theme-toggle/theme-toggle.component';
import { RouterModule } from '@angular/router';

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
            <button class="btn icon-edit" [routerLink]="['/edit']"></button>
            <app-theme-toggle />
          </div>
        </div>
      </div>

      <h1>
        {{note.fileName}}
      </h1>
      <hr>
      <p>
        {{note.content}}
      </p>
    </div>
  `,
  styleUrl: './details.component.scss'
})
export class DetailsComponent {
  note: Note = {
    fileName: 'Book Review: The Design of Everyday Things by Don Norman',
    content: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas mollis ante et dolor fermentum aliquet. Proin rutrum pharetra sapien quis semper. Nullam fringilla risus vel molestie hendrerit. Morbi nec risus semper, lacinia lorem ut, semper elit. Ut faucibus massa non dolor mattis, vitae efficitur sem mollis. Nunc rutrum sem sed interdum porta. Integer pulvinar, urna eget placerat ultricies, nulla purus fringilla turpis, non imperdiet lorem massa ut diam. Donec posuere facilisis ante, vitae mollis enim. Quisque placerat justo magna, ut imperdiet augue tristique eget. Interdum et malesuada fames ac ante ipsum primis in faucibus.\n' +
      '\n' +
      'Praesent ultrices, ipsum eu tincidunt efficitur, tellus sapien blandit arcu, a finibus augue urna ac diam. Suspendisse tincidunt mauris nibh, gravida blandit velit sagittis et. Aenean tristique dignissim nibh, vel suscipit augue scelerisque vitae. Mauris ullamcorper ut lorem ut tristique. Pellentesque dui quam, facilisis id facilisis sed, egestas ut odio. Sed auctor, turpis ac tempus malesuada, arcu tortor hendrerit elit, at condimentum massa dolor posuere mauris. Cras iaculis bibendum turpis vel efficitur. Aenean vel luctus urna. Morbi ut fermentum sapien, id viverra velit. Ut suscipit ac lorem a dictum. Duis tincidunt semper luctus. Phasellus ultricies dignissim augue, ut tempus enim vestibulum in. Nunc tempus magna vel purus fringilla interdum. Curabitur porta facilisis arcu, dignissim interdum magna hendrerit eu.\n' +
      '\n' +
      'Aliquam blandit dui sit amet lacinia lobortis. Quisque risus diam, condimentum id porttitor eget, vestibulum sed massa. Nullam aliquet laoreet nisl tincidunt gravida. Mauris vel vulputate felis. Quisque vel nisl ut ex commodo luctus in in quam. In orci turpis, fermentum vitae ante a, posuere malesuada lectus. Suspendisse dapibus mattis nulla, eget ornare massa malesuada at. Curabitur suscipit velit nisl, quis mattis est fringilla id. Etiam convallis ex a nibh fringilla, et sollicitudin nisl tincidunt. Ut nec fermentum sapien.',
    colour: 'Test'
  }
}
