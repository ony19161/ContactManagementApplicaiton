import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact';
import { ContactService } from '../services/contact.service';
import { AngularCsv  } from 'angular7-csv/dist/Angular-csv';
import { PaginatedResult } from '../models/Pagination';
import { Observable } from 'rxjs/internal/Observable';
import { FormControl } from '@angular/forms';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  contacts: Contact[];
  totalCount: number;
  pageSize: number;
  pageIndex: number;
  isShowContactList: boolean;
  isNoData: boolean;
  model: Contact = new Contact();
  action: string;
  csvOptions = {
    fieldSeparator: ',',
    quoteStrings: '"',
    decimalseparator: '.',
    showLabels: true,
    showTitle: true,
    title: 'Your Contact List :',
    useBom: true,
    noDownload: false,
    headers: ['Name', 'Email', 'Address', 'Mobile', 'Category']
  };
  
  keyword = 'name';
  data = [
     {
       id: 1,
       name: 'Usa'
     },
     {
       id: 2,
       name: 'England'
     }
  ];

  constructor(private contactService: ContactService) { }

  ngOnInit() {
    this.isShowContactList = true;
    this.loadContacts(1, 10);
  }

  selectEvent(item) {
    console.log(item);
  }

  onChangeSearch(val: string) {
    // fetch remote data from here
    // And reassign the 'data' which is binded to 'data' property.
  }

  onFocused(e){
    // do something when input is focused
  }

  loadContacts(pageIndex, pageSize) {
    this.isShowContactList = true;
    this.contactService.getContacts(pageIndex, pageSize).subscribe((paginatedResult: PaginatedResult<Contact[]>) => {
      this.contacts = paginatedResult.result;
      this.totalCount = paginatedResult.pagination.totalCount;
      this.pageSize = paginatedResult.pagination.pageSize;
      this.pageIndex = paginatedResult.pagination.pageIndex;
      this.isNoData = this.totalCount === 0;
    });
  }

  pageChanged($event: any): void {
    this.pageIndex = $event.page;
    this.loadContacts(this.pageIndex, this.pageSize);
  }

  hideContactList(entity: any) {
    if (entity != null) {
      this.action = 'edit';
      this.model = entity;
    } else {
      this.action = 'add';
    }
    this.isShowContactList = false;
  }

  saveCategory() {

    this.model.requestfrom = 'browser';

    if (this.action === 'add') {
      this.addContact();
    } else {
      this.updateContact();
    }

  }

  addContact() {
    this.contactService.addContact(this.model).subscribe(() => {
      this.loadContacts(this.pageIndex, this.pageSize);
    }, error => {
      console.log('error');
    });
  }

  updateContact() {
    this.contactService.updateContact(this.model).subscribe(() => {
      this.loadContacts(this.pageIndex, this.pageSize);
    }, error => {
      console.log('error');
    });
  }

  exportToCsv() {
    this.contactService.getAll().subscribe((data) => {
      return new  AngularCsv(data, 'ContactList', this.csvOptions);
    }, error => {
      console.log('error');
    });
  }


  showContactList() {
    this.isShowContactList = true;
  }

}
