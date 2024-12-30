export class Category {
    categoryId: number;
    categoryName: String;
    isSelected: boolean = false;

    constructor(categoryId: number, categoryName: string) {
        this.categoryId = categoryId;
        this.categoryName = categoryName;
    }
}
