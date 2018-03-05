import { Product } from "./product.model";
import { Http } from "@angular/http";
import { Injectable } from "@angular/core";

@Injectable()
export class Repository {
    product: Product;

    constructor(private http: Http) {
        //this.product = JSON.parse(document.getElementById("data").textContent);
        this.getProduct(1);
    }

    getProduct(id: number) {
        this.http.get("/api/products/" + id)
            .subscribe(response => this.product = response.json());
    }
}
