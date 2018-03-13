import { Component } from '@angular/core';
import { Repository } from './models/repository';
import { Product } from './models/product.model';
import { Supplier } from './models/supplier.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(private repo: Repository) { }

    get product() {
        //console.log(this.repo.product);
        return this.repo.product;
    }

    get products() {
        console.log(this.repo.products);
        return this.repo.products;
    }

    createProduct() {
        this.repo.createProduct(new Product(0, "Пиво тест", "Пиво", "тестирование",
            22.34, this.repo.products[0].supplier));
    }

    createProductAndSupplier() {
        let s = new Supplier(0, "Производство", "Город", "Адрес");
        let p = new Product(0, "Пиво тест #2", "Пиво #2", "тестирование #2", 50, s);
        this.repo.createProductAndSupplier(p, s);
    }
}
