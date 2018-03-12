import { Product } from "./product.model";
import { Http, RequestMethod, Request } from "@angular/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { Filter } from "./cofigClasses.repository";

const productsUrl = "/api/products";

@Injectable()
export class Repository {
    product: Product;
    products: Product[];

    private filterObject = new Filter();

    constructor(private http: Http) {
        this.getProduct(1);

        this.filter.category = "Вино";
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
