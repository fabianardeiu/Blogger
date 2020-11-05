import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { PersonsService } from '../services/persons.service';
import { Person } from '../models/person';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  person: string;

  myControl = new FormControl();
  options: Person[] = [];
  filteredOptions: Observable<Person[]>;

  constructor(
    private personsService: PersonsService,
    public router: Router
  ) {

  }

  ngOnInit(): void {
    this.personsService.getAllPersons().subscribe(res => {
      res.forEach(p => {
        p.name = p.firstName + ' ' + p.lastName;
      });
      this.options = res;
    });

    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => typeof value === 'string' ? value : value.name),
        map(name => name ? this._filter(name) : this.options.slice())
      );
  }

  displayFn(user: any): string {
    return user && user.name ? user.name : '';
  }

  private _filter(name: string): any[] {
    const filterValue = name.toLowerCase();

    return this.options.filter(option => option.name.toLowerCase().indexOf(filterValue) === 0);
  }

  optionSelected(personId) {
    this.router.navigate(['person-profile'], { queryParams: { personId: encodeURIComponent(personId) } });
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.person = null;
    localStorage.clear();
  }
}
