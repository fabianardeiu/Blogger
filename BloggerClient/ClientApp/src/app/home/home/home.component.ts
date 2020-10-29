import { Component, OnInit } from '@angular/core';
import { PostsService } from '../../services/posts.service';
import { Post } from '../../models/post';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  posts: Post[] = [];
  currentPersonId: string;

  constructor(
    private postsService: PostsService,
  ) { }

  ngOnInit() {
    this.getAllPosts();
    this.currentPersonId = localStorage.getItem('personId');
  }

  getAllPosts() {
    this.postsService.getAllPosts().subscribe(res => {
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
