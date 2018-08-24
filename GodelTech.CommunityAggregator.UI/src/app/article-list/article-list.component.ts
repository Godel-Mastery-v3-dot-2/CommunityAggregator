import { Component, OnInit } from '@angular/core';
import { Article } from '../../models/article';
import { ArticleService } from '../../services/ArticleService';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css'],
  providers: [ArticleService]
})
export class ArticleListComponent implements OnInit {

  articles: Article[] = [];
  
  constructor(private articleService : ArticleService) {
  }

  ngOnInit() {
    this.articleService.getArticles().subscribe(
      (data : Article[]) => this.articles = data,
      error => {console.log(error);}
    );
  }
}
