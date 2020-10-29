import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCommentsDialogComponent } from './add-comments-dialog/add-comments-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';

@NgModule({
  declarations: [AddCommentsDialogComponent],
  entryComponents: [AddCommentsDialogComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatDividerModule,
    MatListModule
  ],
  exports: [ AddCommentsDialogComponent]
})
export class SharedModule { }
