import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Post } from '../../models/post';
import { PostsService } from '../../services/posts.service';

@Component({
  selector: 'app-edit-post-dialog',
  templateUrl: './edit-post-dialog.component.html',
  styleUrls: ['./edit-post-dialog.component.css']
})
export class EditPostDialogComponent implements OnInit {

  editPostForm: FormGroup;
  post: Post;
  postSnippet: any;

  constructor(
    public dialogRef: MatDialogRef<EditPostDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string,
    private fb: FormBuilder,
    private postsService: PostsService
  ) {
  }

  ngOnInit() {
    this.postsService.getPostById(this.data).subscribe(res => {
      this.post = res;
      this.editPostForm.get('text').setValue(this.post.text);
      this.postSnippet = "data:image/jpeg;base64," + this.post.image;
    });
    this.editPostForm = this.fb.group({
      text: ['', [Validators.required]],
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
    if (this.editPostForm.valid) {
      this.post.text = this.editPostForm.get('text').value;

      this.dialogRef.close(this.post);
    }
  }

  onDecline() {
    this.dialogRef.close(false);
  }
}
