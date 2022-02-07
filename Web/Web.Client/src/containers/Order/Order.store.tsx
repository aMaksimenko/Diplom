import { makeAutoObservable } from 'mobx'
import { inject, injectable } from 'inversify'
import { types } from 'ioc'
import { IProductService } from 'services/ProductService'
import CartStore from 'stores/CartStore'
import { Product } from 'models/Product'

@injectable()
export default class OrderStore {
  @inject(types.CartStore)
  private readonly _cartStore!: CartStore
  @inject(types.IProductService)
  private readonly _productService!: IProductService
  public products: Product[] = []

  constructor() {
    makeAutoObservable(this)
  }

  private readonly setProducts = (products: Product[]) => {
    this.products = products
  }

  public readonly fetchOrder = async () => {
   
  }

  public readonly removeItem = (orderId: number) => {
 
  }
}
