import { Component, OnInit } from '@angular/core';
import { Article } from '../../models/article';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {

  article1 = new Article("article1", "Some content", "https://wdb.space/media/2015-10-27/ptuVhopbos_scale_300x500.jpg", new Date);
  article2 = new Article("article2", "Some content", "https://cache3.youla.io/files/images/780_780/59/24/5924ca7df094f349042968d3.jpg", new Date);
  articles: Article[] = [this.article1, this.article2];

  constructor() {
  }

  ngOnInit() {
  }

}
