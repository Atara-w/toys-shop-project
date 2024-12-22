export class PurchaseDetails {
    purchaseDetailsId: number;
    purchaseDetailsPurchaseId: number;
    purchaseDetailsProductId: number;
    purchaseDetailsAmount: number;

    constructor(purchaseDetailsId: number, purchaseDetailsPurchaseId: number, purchaseDetailsProductId: number, purchaseDetailsAmount: number) {
        this.purchaseDetailsAmount = purchaseDetailsAmount;
        this.purchaseDetailsId = purchaseDetailsId;
        this.purchaseDetailsProductId = purchaseDetailsProductId;
        this.purchaseDetailsPurchaseId = purchaseDetailsPurchaseId;
    }
}
