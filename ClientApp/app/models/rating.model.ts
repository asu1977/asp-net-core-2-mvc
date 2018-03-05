import { Product } from "./product.model";

export class Rating {

    constructor(
        public raitngId?: number,
        public stars?: number,
        public product?: Product) { }
}
