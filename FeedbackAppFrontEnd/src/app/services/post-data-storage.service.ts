import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

import {Post} from '../models/post.model';

@Injectable({
  providedIn: 'root'
})
export class PostDataStorageService {
  backEndPort = '44385';
  rootUrl = 'http://localhost:' + this.backEndPort;

  constructor(private httpClient: HttpClient) { }

  getPosts() {
    return this.httpClient.get<Post[]>(this.rootUrl + '/api/GetPosts');
  }

}
