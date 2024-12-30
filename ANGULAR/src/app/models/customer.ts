export class Customer {
    customerId: number;
    customerName: string;
    customerPhoneNumber: string;
    customerEmail: string;
    customerDateOfBirth: Date;

    constructor(customerId: number, customerName: string, customerPhoneNumber: string, customerEmail: string, customerDateOfBirth: Date) {
        this.customerDateOfBirth = customerDateOfBirth;
        this.customerEmail = customerEmail;
        this.customerId = customerId;
        this.customerName = customerName;
        this.customerPhoneNumber = customerPhoneNumber;
    }
}
