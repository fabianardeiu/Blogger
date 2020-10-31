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

  getAllPosts(): Observable<Post[]> {
    return this.httpClient.get<Post[]>(`${this.apiHost}/${this.baseUrl}`);
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

  deletePost(postId: string) {
    return this.httpClient.delete(`${this.apiHost}/${this.baseUrl}/${postId}`);
  }

  addPost(post: Post) {
    return this.httpClient.post<string>(`${this.apiHost}/${this.baseUrl}`, post);
  }

  getPostById(postId: string) {
    return this.httpClient.get<Post>(`${this.apiHost}/${this.baseUrl}/${postId}`);
  }

  updatePost(post: Post) {
    return this.httpClient.post<Post>(`${this.apiHost}/${this.baseUrl}/update`, post);
  }
}
