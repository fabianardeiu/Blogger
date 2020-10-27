import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddCommentsDialogComponent } from './add-comments-dialog/add-comments-dialog.component';



@NgModule({
  declarations: [AddCommentsDialogComponent],
  entryComponents: [AddCommentsDialogComponent],
  imports: [CommonModule],
  exports: [ AddCommentsDialogComponent]
})
export class SharedModule { }
