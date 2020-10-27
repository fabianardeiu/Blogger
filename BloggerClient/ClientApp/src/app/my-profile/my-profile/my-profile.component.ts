import { Component, OnInit } from '@angular/core';
import { PostsService } from '../../services/posts.service';
import { Post } from '../../models/post';
import { Like } from '../../models/like';
import { MatDialog } from '@angular/material/dialog';
import { AddCommentsDialogComponent } from '../../shared/add-comments-dialog/add-comments-dialog.component';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  posts: Post[] = [];
  currentPersonId: string;
  currentPersonName: string;

  constructor(
    private postsService: PostsService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.currentPersonId = localStorage.getItem('personId');
    this.currentPersonName = localStorage.getItem('person');

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
      });
      this.posts = res;
    });
  }

  like(postId: string) {
    var post = this.posts.find(p => p.id == postId);
    if (post.likes.some(l => l.personId == this.currentPersonId))
      return;

    var newLike = new Like();
    newLike.postId = postId;
    newLike.personId = this.currentPersonId;
    newLike.personName = this.currentPersonName;

    post.likes.push(newLike);
    post.likesCount += 1;
  }

  comment(postId: string) {
    var post = this.posts.find(p => p.id == postId);
    this.dialog.open(AddCommentsDialogComponent, {
      width: '400px'
    });
  }

}
