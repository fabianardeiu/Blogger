import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../models/person';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  private baseUrl = 'api/person';
  private readonly apiHost = 'https://localhost:5001';

  constructor(private httpClient: HttpClient) {
  }

  updateProfile(person: Person) {
    return this.httpClient.post<Person>(`${this.apiHost}/${this.baseUrl}/update-profile`, person)
  }

  getPersonProfile(personId: string) {
    return this.httpClient.get<Person>(`${this.apiHost}/${this.baseUrl}/${personId}`);
  }

  getAllPersons(): Observable<Person[]> {
    return this.httpClient.get<Person[]>(`${this.apiHost}/${this.baseUrl}`);
  }
}
