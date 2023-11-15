import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { DetailsComponent } from './pages/details/details.component';
import { EditComponent } from './pages/edit/edit.component';
import { AddComponent } from './pages/add/add.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: 'Home'
  },
  {
    path: 'add',
    component: AddComponent,
    title: 'Add'
  },
  {
    path: 'details',
    component: DetailsComponent,
    title: 'Details'
  },
  {
    path: 'edit',
    component: EditComponent,
    title: 'Edit'
  }
];
