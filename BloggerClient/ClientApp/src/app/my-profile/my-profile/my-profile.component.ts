import { Component, OnInit } from '@angular/core';
import { PostsService } from '../../services/posts.service';
import { Post } from '../../models/post';
import { Like } from '../../models/like';
import { MatDialog } from '@angular/material/dialog';
import { AddCommentsDialogComponent } from '../../shared/add-comments-dialog/add-comments-dialog.component';
import { SimpleSnackBarService } from '../../services/simple-snack-bar.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  posts: Post[] = [];
  currentPersonId: string;

  constructor(
    private postsService: PostsService,
  ) {
  }

  ngOnInit() {
    this.currentPersonId = localStorage.getItem('personId');
    this.getPersonPosts();
  }

  getPersonPosts() {
    this.postsService.getPersonPosts(this.currentPersonId).subscribe(res => {
      res.forEach(p => {
        if (p.image != '') {
          p.image = "data:image/jpeg;base64," + p.image;
        }
        p.likesCount = p.likes.length;
        p.commentsCount = p.comments.length;
        p.currentUser = p.personId == this.currentPersonId;
      });
      this.posts = res;
    });
  }

}
