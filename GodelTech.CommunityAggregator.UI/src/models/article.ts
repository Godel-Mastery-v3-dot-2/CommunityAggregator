export class Article {
    constructor(
        public id? : string,
        public title? : string,
        public body? : string,
        public imageUrl? : string,
        public publishDate? : Date
    ) { }
}