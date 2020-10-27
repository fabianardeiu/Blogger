import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-comments-dialog',
  templateUrl: './add-comments-dialog.component.html',
  styleUrls: ['./add-comments-dialog.component.css']
})
export class AddCommentsDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<AddCommentsDialogComponent>,
  ) { }

  ngOnInit() {
  }

}
