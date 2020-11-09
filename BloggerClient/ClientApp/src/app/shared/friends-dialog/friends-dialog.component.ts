import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { PersonsService } from '../../services/persons.service';
import { Person } from '../../models/person';

@Component({
  selector: 'app-friends-dialog',
  templateUrl: './friends-dialog.component.html',
  styleUrls: ['./friends-dialog.component.css']
})
export class FriendsDialogComponent implements OnInit {

  friends: Person[] = [];
  dataLoaded: boolean;

  constructor(
    public dialogRef: MatDialogRef<FriendsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string,
    private personsService: PersonsService

  ) { }

  ngOnInit() {
    this.dataLoaded = false;

    this.personsService.getPersonFriends(this.data).subscribe(res => {
      res.forEach(f => {
        f.name = f.firstName + ' ' + f.lastName;
        if (f.image != '') {
          f.image = "data:image/jpeg;base64," + f.image;
        }
      }
      );
      this.friends = res;

      this.dataLoaded = true;
    });
  }



}
