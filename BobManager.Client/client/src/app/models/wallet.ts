import { WalletCategory } from './wallet-category';

export class Wallet {
    id: number;
    description: string;
    value:number;
    date:Date;
    userId:string;
    spendingCategory:WalletCategory;
}