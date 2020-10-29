import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCommentsDialogComponent } from './add-comments-dialog/add-comments-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { PostsComponent } from './posts/posts.component';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { AddPostDialogComponent } from './add-post-dialog/add-post-dialog.component';

@NgModule({
  declarations: [
    AddCommentsDialogComponent,
    PostsComponent,
    ConfirmationDialogComponent,
    AddPostDialogComponent
  ],
  entryComponents: [
    AddCommentsDialogComponent,
    ConfirmationDialogComponent,
    AddPostDialogComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatDividerModule,
    MatListModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule
  ],
  exports: [
    AddCommentsDialogComponent,
    PostsComponent,
    ConfirmationDialogComponent,
    AddPostDialogComponent
  ]
})
export class SharedModule { }
