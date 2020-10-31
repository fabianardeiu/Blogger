import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonsService } from '../../services/persons.service';
import { Person } from '../../models/person';

@Component({
  selector: 'app-update-profile-dialog',
  templateUrl: './update-profile-dialog.component.html',
  styleUrls: ['./update-profile-dialog.component.css']
})
export class UpdateProfileDialogComponent implements OnInit {

  updateProfileForm: FormGroup;
  person: Person;
  imageSnippet: any;

  constructor(
    public dialogRef: MatDialogRef<UpdateProfileDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string,
    private fb: FormBuilder,
    private personService: PersonsService
  ) { }

  ngOnInit() {
    this.personService.getPersonProfile(localStorage.getItem('personId')).subscribe(res => {
      this.person = res;
      this.person.image = res.image;

      if (res.image != '') {
        this.imageSnippet = "data:image/jpeg;base64," + res.image;
      }

      this.updateProfileForm.get('firstName').setValue(this.person.firstName);
      this.updateProfileForm.get('lastName').setValue(this.person.lastName);

    });

    this.updateProfileForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]]
    });
  }

  onFileChanged(event) {
    let reader = new FileReader();
    let file = event.target.files[0];
    reader.onload = () => {
      this.person.image = reader.result.slice(23);
      this.imageSnippet = "data:image/jpeg;base64," + this.person.image;
    };
    reader.readAsDataURL(file);
  }

  onConfirm() {
    if (this.updateProfileForm.valid) {
      this.person.firstName = this.updateProfileForm.get('firstName').value;
      this.person.lastName = this.updateProfileForm.get('lastName').value;

      this.dialogRef.close(this.person);
    }
  }

  onDecline() {
    this.dialogRef.close(false);
  }
}
