import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ConfirmationDialogData } from './confirmation-dialog.dialogdata';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})
export class ConfirmationDialogComponent implements OnInit {

  messageText: string;
  okBtnText: string;
  cancelBtnText: string;
  title: string;

  constructor(
    public thisDialogRef: MatDialogRef<ConfirmationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ConfirmationDialogData) {
  }

  ngOnInit() {
    if (!this.data) {
      this.data = <ConfirmationDialogData>{
        messageText: null,
        okBtnText: null,
        cancelBtnText: null,
        title: null,
      };
    }
    this.title = this.data.title || 'Confirmation';
    this.messageText = this.data.messageText || 'Are you sure you want to discard your changes?';
    this.okBtnText = this.data.okBtnText || 'Yes';
    this.cancelBtnText = this.data.cancelBtnText || 'No';
  }

  onConfirm() {
    this.thisDialogRef.close(true);
  }

  onDecline() {
    this.thisDialogRef.close(false);
  }
}
