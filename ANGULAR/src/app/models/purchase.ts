export class Purchase {
    purchaseId: number;
    purchaseCustomerId: string;
    purchaseDate: Date;
    purchaseAmountToPay: number;
    purchaseMention: string;

    constructor(purchaseId: number, purchaseCustomerId: string, purchaseDate: Date, purchaseAmountToPay: number, purchaseMention: string) {
        this.purchaseAmountToPay = purchaseAmountToPay;
        this.purchaseCustomerId = purchaseCustomerId;
        this.purchaseDate = purchaseDate;
        this.purchaseId = purchaseId;
        this.purchaseMention = purchaseMention;
    }
}
