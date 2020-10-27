import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/post';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  private baseUrl = 'api/posts';

  private readonly apiHost = 'https://localhost:5001';
  
  constructor(private httpClient: HttpClient) {
  }

  getPersonPosts(personId: string): Observable<Post[]> {
    return this.httpClient.get<Post[]>(`${this.apiHost}/${this.baseUrl}/person/` + personId);
  }

}
