import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Comment } from '../../models/comment';
import { PostsService } from '../../services/posts.service';

@Component({
  selector: 'app-add-comments-dialog',
  templateUrl: './add-comments-dialog.component.html',
  styleUrls: ['./add-comments-dialog.component.css']
})
export class AddCommentsDialogComponent implements OnInit {

  commentForm: FormGroup;
  comments: Comment[];

  constructor(
    public dialogRef: MatDialogRef<AddCommentsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string,
    private fb: FormBuilder,
    private postsService: PostsService
  ) {
  }

  ngOnInit() {
    this.postsService.getPostComments(this.data).subscribe(res => {
      this.comments = res;
    })
    this.commentForm = this.fb.group({
      text: ['', [Validators.required]],
    });
  }

  onConfirm() {
    if (this.commentForm.valid) {
      var comment = new Comment();
      comment.text = this.commentForm.get('text').value;
      comment.personId = localStorage.getItem('personId');
      comment.postId = this.data;
      this.dialogRef.close(comment);
    }
  }

  onDecline() {
    this.dialogRef.close(false);
  }

}
