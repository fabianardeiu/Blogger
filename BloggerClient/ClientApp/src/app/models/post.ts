import { Like } from "./like";
import { Comment } from "./comment";

export class Post {
  id: string;
  createdAt: Date;
  image: any;
  text: string;
  personName: string;
  personId: string;
  likes: Like[];
  comments: Comment[];
  likesCount: number;
  commentsCount: number;
  currentUser: boolean;
}
