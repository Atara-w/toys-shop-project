export class Customer {
    customerId: number;
    customerName: string;
    customerPhoneNumber: string;
    customerEmail: string;
    customerPassword:string;
    customerDateOfBirth: Date;

    constructor(customerId: number, customerName: string, customerPhoneNumber: string, customerEmail: string, customerDateOfBirth: Date,customerPassword:string) {
        this.customerDateOfBirth = customerDateOfBirth;
        this.customerEmail = customerEmail;
        this.customerId = customerId;
        this.customerName = customerName;
        this.customerPhoneNumber = customerPhoneNumber;
        this.customerPassword=customerPassword;
    }
}
