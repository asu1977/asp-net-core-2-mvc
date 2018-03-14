import { Product } from "./product.model";
import { Http, RequestMethod, Request } from "@angular/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { Filter } from "./cofigClasses.repository";
import { Supplier } from "./supplier.model";

const productsUrl = "/api/products";
const suppliersUrl = "/api/suppliers";

@Injectable()
export class Repository {
    product: Product;
    products: Product[];
    suppliers: Supplier[] = [];

    private filterObject = new Filter();

    constructor(private http: Http) {
        this.getProduct(1);

        //this.filter.category = "Вино";
        this.filter.related = true;

        this.getProducts();
    }

    getProduct(id: number) {
        this.sendRequest(RequestMethod.Get, productsUrl + "/" + id)
            .subscribe(response => {
                this.product = response;
            });
    }

    getProducts() {
        let url = productsUrl + "?related=" + this.filter.related;

        if (this.filter.category) {
            url += "&category=" + this.filter.category;
        }

        if (this.filter.search) {
            url += "&search=" + this.filter.search; 
        }

        this.sendRequest(RequestMethod.Get, url)
            .subscribe(response => this.products = response);
    }

    getSuppliers() {
        this.sendRequest(RequestMethod.Get, suppliersUrl)
            .subscribe(response => this.suppliers = response);
    }

    createProduct(prod: Product) {
        let data = {
            name: prod.name, category: prod.category,
            description: prod.description, price: prod.price,
            supplier: prod.supplier ? prod.supplier.supplierId : 0
        };

        this.sendRequest(RequestMethod.Post, productsUrl, data)
            .subscribe(response => {
                prod.productId = response;
                this.products.push(prod);
            });
    }

    createProductAndSupplier(prod: Product, supp: Supplier) {
        let data = {
            name: supp.name, city: supp.city, address: supp.address
        };

        this.sendRequest(RequestMethod.Post, suppliersUrl, data)
            .subscribe(response => {
                supp.supplierId = response;
                prod.supplier = supp;
                this.suppliers.push(supp);
                if (prod != null) {
                    this.createProduct(prod);
                }
            });
    }


    private sendRequest(verb: RequestMethod, url: string, data?: any)
        {

        return this.http.request(new Request({
            method: verb, url: url, body: data
        })).map(response => response.json());
    }

    get filter() {
        return this.filterObject;
    }
}
