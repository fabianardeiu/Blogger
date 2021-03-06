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
  dataLoaded: boolean;

  constructor(
    private postsService: PostsService,
  ) { }

  ngOnInit() {
    this.dataLoaded = false;
    this.getAllPosts();

    this.currentPersonId = localStorage.getItem('personId');
  }

  getAllPosts() {
    this.postsService.getAllPosts().subscribe(res => {
      res.forEach(p => {
        if (p.image != '') {
          p.image = "data:image/jpeg;base64," + p.image;
        }
        if (p.personImage != null) {
          p.personImage = "data:image/jpeg;base64," + p.personImage;
        }
        p.currentUser = p.personId == this.currentPersonId;
      });
      this.posts = res;
      this.dataLoaded = true;
    });
  }
}
