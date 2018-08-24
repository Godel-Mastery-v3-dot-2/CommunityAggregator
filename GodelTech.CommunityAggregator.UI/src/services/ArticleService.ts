import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Article } from "../models/article";
import { Observable } from "rxjs";
import { environment } from "../environments/environment";

@Injectable()
export class ArticleService{

    serverURL : string = environment.articleURL;

    constructor (private http : HttpClient){}

    getArticles() : Observable<Article[]>
    {
        return this.http.get<Article[]>(this.serverURL);
    }

    getArticle(id : number) : Observable<Article>
    {
        return this.http.get(this.serverURL + '/' + id);
    }

    postArticle(value : Article) : Observable<Article>
    {
        return this.http.post(this.serverURL, value);
    }

    putArticle(value : Article) : Observable<Article>
    {
        return this.http.put(this.serverURL + '/' + value.id, value);
    }

    deleteArticle(id : number) : Observable<Article>
    {
        return this.http.delete(this.serverURL + '/' + id);
    }
}