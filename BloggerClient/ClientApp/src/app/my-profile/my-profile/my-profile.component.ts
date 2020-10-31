import { Component, OnInit } from '@angular/core';
import { PostsService } from '../../services/posts.service';
import { Post } from '../../models/post';
import { MatDialog } from '@angular/material/dialog';
import { SimpleSnackBarService } from '../../services/simple-snack-bar.service';
import { UpdateProfileDialogComponent } from '../../shared/update-profile-dialog/update-profile-dialog.component';
import { PersonsService } from '../../services/persons.service';
import { Person } from '../../models/person';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent implements OnInit {

  person: Person;
  posts: Post[] = [];
  currentPersonId: string;

  constructor(
    private postsService: PostsService,
    private personsService: PersonsService,
    private dialog: MatDialog,
    private snackBar: SimpleSnackBarService
  ) {
  }

  ngOnInit() {
    this.currentPersonId = localStorage.getItem('personId');
    this.getPersonPosts();
    this.personsService.getPersonProfile(localStorage.getItem('personId')).subscribe(res => {
      this.person = res;
      this.person.image = "data:image/jpeg;base64," + this.person.image;
    });
  }

  getPersonPosts() {
    this.postsService.getPersonPosts(this.currentPersonId).subscribe(res => {
      res.forEach(p => {
        if (p.image != '') {
          p.image = "data:image/jpeg;base64," + p.image;
        }
        if (p.personImage != null) {
          p.personImage = "data:image/jpeg;base64," + p.personImage;
        }
        p.likesCount = p.likes.length;
        p.commentsCount = p.comments.length;
        p.currentUser = p.personId == this.currentPersonId;
      });
      this.posts = res;
    });
  }

  updateProfile() {
    let dialogRef = this.dialog.open(UpdateProfileDialogComponent, {
      width: '400px',
      data: this.currentPersonId
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.personsService.updateProfile(result).subscribe(res => {
          this.snackBar.openSuccess('Profile successfully updated.')
          this.person.firstName = result.firstName;
          this.person.lastName = result.lastName;
          this.person.image = "data:image/jpeg;base64," + result.image;
          this.getPersonPosts();
        });
      }
    });
  }
}
