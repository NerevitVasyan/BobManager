import { Component, OnInit } from '@angular/core';
import { Wallet } from 'src/app/models/wallet';
import { WalletService } from 'src/app/services/wallet.service';
import { PageChangedEvent } from 'ngx-bootstrap/pagination/pagination.component';
import { WalletPerPage } from 'src/app/models/wallet-per-page';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-wallet-list',
  templateUrl: './wallet-list.component.html',
  styleUrls: ['./wallet-list.component.css']
})
export class WalletListComponent implements OnInit {
  walletperpage: WalletPerPage;
  wallets: Wallet[];
  pagenum: any;
  totalItems = 64;
  currentPage:number;
  maxSize : number;
  status = "ON";
  totalwallet:number;
  totalpage:number;
  constructor(private walletService: WalletService,private route: ActivatedRoute,  private router: Router) {
    this.walletperpage = new WalletPerPage()
    this.route.params.subscribe( params =>{ this.pagenum=(params) }); 
    this.currentPage=Number.parseInt(this.pagenum.page);
   }

  ngOnInit() {
    this.walletService.getWalletForPage(this.pagenum.page).subscribe(res => {
      this.currentPage=Number.parseInt(this.pagenum.page);
      this.walletperpage.pageInfo = res.pageInfo;
      this.walletperpage.wallet = res.paginatedList;
      this.maxSize=this.walletperpage.pageInfo.itemsPerPage;
      this.totalwallet=this.walletperpage.pageInfo.totalItems;
      this.totalpage=this.walletperpage.pageInfo.totalPages;
    });

  }
  pageChanged(event: PageChangedEvent) {
    this.currentPage=event.page;
    this.router.navigate(['wallet/'+event.page]);
    this.walletService.getWalletForPage(this.currentPage).subscribe(res => {
      this.walletperpage.pageInfo = res.pageInfo;
      this.walletperpage.wallet = res.paginatedList;
      this.maxSize=this.walletperpage.pageInfo.itemsPerPage;
      this.totalwallet=this.walletperpage.pageInfo.totalItems;
      this.totalpage=this.walletperpage.pageInfo.totalPages; 
    });
  }
}