import {AppUser} from './app-user.model';

export class Post {
  constructor(
    public Id: number,
    public Title: string,
    public CreatedDate: string,
    public AppUser: AppUser,
    public AppUserId: number,
    public Comments: Comment[] = []
  ) {}
}
