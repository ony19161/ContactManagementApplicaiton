import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';
import { PaginatedResult } from '../models/Pagination';
import { AngularCsv  } from 'angular7-csv/dist/Angular-csv';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  categories: Category[];
  totalCount: number;
  pageSize: number;
  pageIndex: number;
  isShowCategoryList: boolean;
  model: Category = new Category();
  action: string;
  csvOptions = {
    fieldSeparator: ',',
    quoteStrings: '"',
    decimalseparator: '.',
    showLabels: true,
    showTitle: true,
    title: 'Your Category List :',
    useBom: true,
    noDownload: false,
    headers: ['Title', 'Description']
  };

  constructor(private categoryService: CategoryService) { }

  ngOnInit() {
    this.isShowCategoryList = true;
    this.loadCategories(1, 10);
  }

  loadCategories(pageIndex, pageSize) {
    this.isShowCategoryList = true;
    this.categoryService.getCategories(pageIndex, pageSize).subscribe((paginatedResult: PaginatedResult<Category[]>) => {
      this.categories = paginatedResult.result;
      this.totalCount = paginatedResult.pagination.totalCount;
      this.pageSize = paginatedResult.pagination.pageSize;
      this.pageIndex = paginatedResult.pagination.pageIndex;
    });
  }

  pageChanged($event: any): void {
    this.pageIndex = $event.page;
    this.loadCategories(this.pageIndex, this.pageSize);
  }

  hideCategoryList(entity: any) {
    if (entity != null) {
      this.action = 'edit';
      this.model = entity;
    } else {
      this.action = 'add';
    }
    this.isShowCategoryList = false;
  }

  saveCategory() {

    this.model.requestfrom = 'browser';

    if (this.action === 'add') {
      this.addCategory();
    } else {
      this.updateCategory();
    }

  }

  addCategory() {
    this.categoryService.addCategory(this.model).subscribe(() => {
      this.loadCategories(this.pageIndex, this.pageSize);
    }, error => {
      console.log('error');
    });
  }

  updateCategory() {
    this.categoryService.updateCategory(this.model).subscribe(() => {
      this.loadCategories(this.pageIndex, this.pageSize);
    }, error => {
      console.log('error');
    });
  }

  exportToCsv() {
    this.categoryService.getAll().subscribe((data) => {
      return new  AngularCsv(data, 'CategoryList', this.csvOptions);
    }, error => {
      console.log('error');
    });
  }


  showCategoryList() {
    this.isShowCategoryList = true;
  }

}
