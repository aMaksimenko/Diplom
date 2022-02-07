import { injectable, inject } from 'inversify'
import { makeAutoObservable } from 'mobx'
import { types } from 'ioc'
import { IProductService } from 'services/ProductService'
import React from 'react'

@injectable()
export default class ProductsStore {
  @inject(types.IProductService)
  private readonly _productService!: IProductService
  private readonly pageSize: number = 6
  public products: any[] = []
  public pageIndex: number = 0
  public pageCount: number  = 0

  constructor() {
    makeAutoObservable(this)
  }

  getProductsAsync = async () => {
    try {
      const res = await this._productService.getItemsByPage({
        pageIndex: this.pageIndex,
        pageSize: this.pageSize
      })

      this.setProducts(res.data)
      this.setPageCount(Math.ceil(res.count / this.pageSize))
    } catch (e) {
      console.error(e)
    }
  }

  setProducts = (data: []) => {
    this.products = data
  }

  setPage = (event: React.ChangeEvent<unknown>, val: number) => {
    this.pageIndex = val - 1
  }

  setPageCount = (val: number) => {
    this.pageCount = val
  }
}
