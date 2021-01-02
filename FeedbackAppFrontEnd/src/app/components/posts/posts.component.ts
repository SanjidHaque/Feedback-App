import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Data} from '@angular/router';
import {MatDialog, MatSnackBar} from '@angular/material';

import {Post} from '../../models/post.model';
import {PostDataStorageService} from '../../services/post-data-storage.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  posts: Post[] = [];

  constructor(private snackBar: MatSnackBar,
              private route: ActivatedRoute,
              private matDialog: MatDialog,
              private postDataStorageService: PostDataStorageService) {
  }

  ngOnInit() {
    this.route.data.subscribe((data: Data) => {
      this.posts = data['posts'].paginatedPosts;
      this.formatPostCreatedTime();
      console.log(this.posts);
    });
  }


  formatPostCreatedTime() {
    this.posts.forEach(post => {
      const postDate = new Date(post.CreatedDate);
      post.CreatedDate = postDate.toLocaleDateString();
    });
  }

  formatCommentDate(createdDate) {
    return new Date(createdDate).toLocaleDateString();
  }
}

