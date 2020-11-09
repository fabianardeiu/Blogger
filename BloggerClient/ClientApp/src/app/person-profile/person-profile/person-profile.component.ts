import { Component, OnInit } from '@angular/core';
import { Person } from '../../models/person';
import { Post } from '../../models/post';
import { PostsService } from '../../services/posts.service';
import { ActivatedRoute } from '@angular/router';
import { PersonsService } from '../../services/persons.service';
import { AddFriend } from '../../models/add-friend';
import { SimpleSnackBarService } from '../../services/simple-snack-bar.service';

@Component({
  selector: 'app-person-profile',
  templateUrl: './person-profile.component.html',
  styleUrls: ['./person-profile.component.css']
})
export class PersonProfileComponent implements OnInit {
  person: Person;
  posts: Post[] = [];
  personId: string;
  dataLoaded: boolean;

  constructor(
    private postsService: PostsService,
    private personsService: PersonsService,
    private snackBar: SimpleSnackBarService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.dataLoaded = false;

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
        p.currentUser = false;
      });
      this.posts = res;
      this.dataLoaded = true;
    });
  }

  addFriend() {
    var addFriendModel = new AddFriend();
    addFriendModel.personId = localStorage.getItem('personId');
    addFriendModel.friendId = this.personId;

    this.personsService.addFriend(addFriendModel)
      .subscribe(res => {
        if (res) {
          this.snackBar.openSuccess('Friend successfully added.');
        }
        else {
          this.snackBar.openSuccess('You are already friends.');
        }
      });
  }

}
