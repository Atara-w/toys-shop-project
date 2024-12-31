export class Category {
    categoryId: number;
    categoryName: String;
    isSelect: boolean = false;

    constructor(categoryId: number, categoryName: string) {
        this.categoryId = categoryId;
        this.categoryName = categoryName;
    }
}
