import { Component, OnInit } from '@angular/core';
import { Person } from '../../models/person';
import { Post } from '../../models/post';
import { PostsService } from '../../services/posts.service';
import { ActivatedRoute } from '@angular/router';
import { PersonsService } from '../../services/persons.service';

@Component({
  selector: 'app-person-profile',
  templateUrl: './person-profile.component.html',
  styleUrls: ['./person-profile.component.css']
})
export class PersonProfileComponent implements OnInit {
  person: Person;
  posts: Post[] = [];
  personId: string;

  constructor(
    private postsService: PostsService,
    private personsService: PersonsService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.personId = params['personId'];
    });

    this.getPersonPosts();
    this.personsService.getPersonProfile(this.personId).subscribe(res => {
      this.person = res;
      if (res.image != '') {
        this.person.image = "data:image/jpeg;base64," + this.person.image;
      }
    });
  }

  getPersonPosts() {
    this.postsService.getPersonPosts(this.personId).subscribe(res => {
      res.forEach(p => {
        if (p.image != '') {
          p.image = "data:image/jpeg;base64," + p.image;
        }
        if (p.personImage != null) {
          p.personImage = "data:image/jpeg;base64," + p.personImage;
        }
        p.likesCount = p.likes.length;
        p.commentsCount = p.comments.length;
        p.currentUser = p.personId == this.personId;
      });
      this.posts = res;
    });
  }

  addFriend() {
    //TO DO Add friend action
    console.log(this.personId);
  }

}
