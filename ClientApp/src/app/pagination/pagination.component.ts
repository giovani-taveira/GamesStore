import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {
  size: number = 10;
  page: any;
  @Input("page") public set value(page: any) {
    if (!page) return;
    this.page = page;
    this.setPagetion();
  }
  @Output() public paginationEvent: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit() { }

  changePage(page?: any) {
    setTimeout(() => {
      this.paginationEvent.emit({ page: page ? page : 0, size: this.size });
    });
  }

  setPagetion() {
    let pages = new Array<number>();
    let inc = (this.page.number - 2) <= 0 ? (4 - this.page.number) : 2;
    let dec = (this.page.number + 2) >= this.page.totalPages ? (5 - (this.page.totalPages - this.page.number)) : 2;
    let inicio = (this.page.number - dec) <= 0 ? 0 : (this.page.number - dec);
    let fim = (this.page.number + inc) < this.page.totalPages ? (this.page.number + inc) : (this.page.totalPages - 1);
    for (let i = inicio; i <= fim; i++) {
      pages.push(i);
    }
    this.page.pages = pages;
  }

}
