export class Product {
    productId: number;
    productName: string;
    productCatrgoryId: number;
    productCompanyId: number;
    productDescription: string;
    productPrice: number;
    productImage: string;
    productLastUpdate: Date;
    productAge: number;
    categoryName: string;
    companyName: string;  

    constructor(product: any) {
        this.productCatrgoryId = product.productCatrgoryId;
        this.productCompanyId = product.productCompanyId;
        this.productDescription = product.productDescription;
        this.productId = product.productId;
        this.productImage = product.productImage;
        this.productLastUpdate = product.productLastUpdate;
        this.productName = product.productName;
        this.productPrice = product.productPrice;
        this.productAge = product.productAge;
        this.categoryName = product.categoryName; 
        this.companyName = product.companyName
    }
}
