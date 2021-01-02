import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {PostsComponent} from './components/posts/posts.component';
import {PostsResolverService} from './route-resolvers/posts-resolver.service';
import {PageNotFoundComponent} from './components/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: 'posts',
    component: PostsComponent,
    resolve: { posts: PostsResolverService }
  },
  {
    path : '',
    redirectTo: '/posts',
    pathMatch : 'full'
  },
  {
    path: 'not-found',
    component: PageNotFoundComponent,
  },
  { path: '**',
    redirectTo: '/not-found'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
