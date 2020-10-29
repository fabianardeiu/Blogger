import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/post';
import { Observable } from 'rxjs';
import { Comment } from '../models/comment';
import { Like } from '../models/like';

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

  commentPost(comment: Comment) {
    return this.httpClient.post<Comment>(`${this.apiHost}/${this.baseUrl}/comment`, comment)
  }

  likePost(like: Like) {
    return this.httpClient.post<Comment>(`${this.apiHost}/${this.baseUrl}/like`, like)
  }

  getPostComments(postId: string): Observable<Comment[]> {
    return this.httpClient.get<Comment[]>(`${this.apiHost}/${this.baseUrl}/${postId}/comment`);
  }
}
