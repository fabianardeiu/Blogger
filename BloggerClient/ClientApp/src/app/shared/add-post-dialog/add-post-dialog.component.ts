import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Post } from '../../models/post';

@Component({
  selector: 'app-add-post-dialog',
  templateUrl: './add-post-dialog.component.html',
  styleUrls: ['./add-post-dialog.component.css']
})
export class AddPostDialogComponent implements OnInit {
  post: Post;
  addPostForm: FormGroup;
  postSnippet: any;

  constructor(
    public dialogRef: MatDialogRef<AddPostDialogComponent>,
    private fb: FormBuilder
  ) {
  }

  ngOnInit() {
    this.post = new Post();
    this.addPostForm = this.fb.group({
      text: ['', [Validators.required]]
    });
  }

  onFileChanged(event) {
    let reader = new FileReader();
    let file = event.target.files[0];
    reader.onload = () => {
      this.post.image = reader.result.slice(23);
      this.postSnippet = "data:image/jpeg;base64," + this.post.image;

    };
    reader.readAsDataURL(file);
  }

  onConfirm() {
    if (this.addPostForm.valid) {
      this.post.text = this.addPostForm.get('text').value;
      this.post.personId = localStorage.getItem('personId');
      this.dialogRef.close(this.post);
    }
  }

  onDecline() {
    this.dialogRef.close(false);
  }

}
