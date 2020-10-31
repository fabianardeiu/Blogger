import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Post } from '../../models/post';
import { PostsService } from '../../services/posts.service';
import { MatDialog } from '@angular/material/dialog';
import { SimpleSnackBarService } from '../../services/simple-snack-bar.service';
import { Like } from '../../models/like';
import { AddCommentsDialogComponent } from '../add-comments-dialog/add-comments-dialog.component';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { AddPostDialogComponent } from '../add-post-dialog/add-post-dialog.component';
import { EditPostDialogComponent } from '../edit-post-dialog/edit-post-dialog.component';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  @Input() posts: Post[];
  currentPersonId: string;
  currentPersonName: string;

  constructor(
    private postsService: PostsService,
    private dialog: MatDialog,
    private snackBar: SimpleSnackBarService

  ) { }

  ngOnInit() {
    this.currentPersonId = localStorage.getItem('personId');
    this.currentPersonName = localStorage.getItem('person');
  }

  like(postId: string) {
    var post = this.posts.find(p => p.id == postId);

    var newLike = new Like();
    newLike.postId = postId;
    newLike.personId = this.currentPersonId;
    newLike.personName = this.currentPersonName;

    this.postsService.likePost(newLike).subscribe(like => {
      if (!like) {
        post.likes = post.likes.filter(l => l.personId != this.currentPersonId);
        post.likesCount -= 1;
      }
      else {
        post.likes.push(newLike);
        post.likesCount += 1;
      }

    });
  }

  comment(postId: string) {
    var post = this.posts.find(p => p.id == postId);
    let dialogRef = this.dialog.open(AddCommentsDialogComponent, {
      width: '400px',
      data: post.id
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.postsService.commentPost(result).subscribe(res => {
          this.snackBar.openSuccess('Comment successfully created.');
          var post = this.posts.find(p => p.id == postId);
          post.commentsCount += 1;
        });
      }
    });
    dialogRef = null;
  }

  deletePost(postId: string) {
    let dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '500px',
      data:
      {
        title: ' ',
        messageText:
          '<div>You are deleting this post. This action is not reversible.</p></div>' +
          '<br>' +
          '<div>Do you want to continue?</div>'
      },
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.postsService.deletePost(postId).subscribe(res => {
          this.snackBar.openSuccess('Post successfully deleted.');
          this.posts = this.posts.filter(p => p.id != postId);
        });
      }
    });
    dialogRef = null;
  }

  editPost(postId: string) {
    let dialogRef = this.dialog.open(EditPostDialogComponent, {
      width: '400px',
      data: postId
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        var postToUpdate = new Post();
        postToUpdate.id = result.id;
        postToUpdate.text = result.text;
        postToUpdate.image = result.image;
        this.postsService.updatePost(postToUpdate).subscribe(res => {
          this.snackBar.openSuccess('Post successfully updated.');
          this.posts.find(p => p.id == postId).text = postToUpdate.text;
          if (postToUpdate.image != '') {
            this.posts.find(p => p.id == postId).image = "data:image/jpeg;base64," + postToUpdate.image;
          }
        });
      }
    });
    dialogRef = null;
  }

  addPost() {
    let dialogRef = this.dialog.open(AddPostDialogComponent, {
      width: '400px',
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.postsService.addPost(result).subscribe(res => {
          this.snackBar.openSuccess('Post successfully created.');
          this.postsService.getPostById(res).subscribe(res => {
            if (res.image != '') {
              res.image = "data:image/jpeg;base64," + res.image;
            }
            res.likesCount = res.likes.length;
            res.commentsCount = res.comments.length;
            this.posts.push(res);
            this.posts.sort((val1, val2) => {
              return new Date(val2.createdAt).getTime() - new
                Date(val1.createdAt).getTime()
            })
          })
        });
      }
    });
    dialogRef = null;
  }

}
