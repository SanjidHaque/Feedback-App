import {Observable} from 'rxjs';
import {Resolve} from '@angular/router';
import { Injectable } from '@angular/core';

import {Post} from '../models/post.model';
import {PostDataStorageService} from '../services/post-data-storage.service';

@Injectable({
  providedIn: 'root'
})
export class PostsResolverService implements Resolve<Post[]> {
  constructor(private productDataStorageService: PostDataStorageService) {}

  resolve(): Observable<Post[]> | Promise<Post[]> | Post[] {
    return this.productDataStorageService.getPosts();
  }
}

