import { inject, injectable } from 'inversify'
import { makeAutoObservable } from 'mobx'
import { types } from 'ioc'
import { IProductService } from 'services/ProductService'
import { Product } from 'models/Product'

@injectable()
export default class ProductsStore {
  @inject(types.IProductService)
  private readonly _productService!: IProductService
  public product!: Product

  constructor() {
    makeAutoObservable(this)
  }

  getProductAsync = async (id: number) => {
    try {
      const res = await this._productService.getItemById(id)
      this.setProduct(res)
    } catch (e) {
      console.error(e)
    }
  }

  setProduct = (val: Product) => {
    this.product = val
  }
}
