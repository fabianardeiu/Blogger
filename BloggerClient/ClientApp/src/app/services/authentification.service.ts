import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { Person } from '../models/person';
import { RegisterUser } from '../models/register-user';

@Injectable({
  providedIn: 'root'
})

export class AuthentificationService {

  private baseUrl = 'api/authentication';

  private readonly apiHost = 'https://localhost:5001';

  constructor(private httpClient: HttpClient) {
  }

  login(user: User): Observable<Person> {
    return this.httpClient.post<Person>(`${this.apiHost}/${this.baseUrl}/login`, user);
  }

  register(registerUser: RegisterUser): Observable<RegisterUser> {
    return this.httpClient.post<RegisterUser>(`${this.apiHost}/${this.baseUrl}/register`, registerUser);

  }
}
