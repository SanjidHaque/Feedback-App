import {AppUser} from './app-user.model';
import {Reaction} from './reaction.model';
import {Post} from './post.model';

export class Comment {
  constructor(
    public Id: number,
    public Title: string,
    public CreatedDate: string,
    public AppUser: AppUser,
    public AppUserId: number,
    public Post: Post,
    public PostId: number,
    public Reaction: Reaction,
    public ReactionId: number,
  ) {}
}
