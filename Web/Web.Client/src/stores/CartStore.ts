import { makeAutoObservable } from 'mobx'
import { inject, injectable } from 'inversify'
import { types } from 'ioc'
import AuthStore from 'stores/AuthStore'
import { Product } from 'models/Product'
import { Stream } from 'models/Stream'
import { IAuthService } from 'services/AuthService'
import { ICartService } from 'services/CartService'

@injectable()
export default class CartStore {
  @inject(types.IAuthService)
  private readonly _authService!: IAuthService
  @inject(types.ICartService)
  private readonly _cartService!: ICartService
  public products: Product[] = []
  public streams: Stream[] = []

  constructor () {
    makeAutoObservable(this)
  }

  public fetchData = async () => {
    const response = await this._cartService.fetchData()
    const { products, streams } = JSON.parse(response.data)

    this.setProducts(products)
    this.setStreams(streams)
  }

  public readonly addProduct = async (data: Product) => {
    if (!this._authService.isAuthenticated()) {
      this._authService.signinRedirect()
    }

    const nextItems = [...this.products, data]

    try {
      await this._cartService.sendData(JSON.stringify({
        products: nextItems,
        streams: this.streams
      }))
      this.setProducts(nextItems)
    } catch (e) {
      console.error(e)
    }
  }

  public readonly removeProduct = async (productId: number) => {
    const indexToRemove = this.products.findIndex(i => i.id === productId)
    const nextItems = [...this.products]

    if (indexToRemove < 0) {
      return null
    }

    nextItems.splice(indexToRemove, 1)

    try {
      await this._cartService.sendData(JSON.stringify({
        products: nextItems,
        streams: this.streams
      }))
      this.setProducts(nextItems)
    } catch (e) {
      console.error(e)
    }
  }

  public readonly containsProduct = (productId: number) => {
    return Boolean(this.products.find(i => i.id === productId))
  }

  private setProducts = (items: Product[]) => {
    this.products = items || []
  }

  public readonly addStream = async (data: Stream) => {
    if (!this._authService.isAuthenticated()) {
      this._authService.signinRedirect()
    }

    const nextItems = [...this.streams, data]

    try {
      await this._cartService.sendData(JSON.stringify({
        streams: nextItems,
        strproductseams: this.products
      }))
      this.setStreams(nextItems)
    } catch (e) {
      console.error(e)
    }
  }

  public readonly removeStream = async (streamId: number) => {
    const indexToRemove = this.streams.findIndex(i => i.id === streamId)
    const nextItems = [...this.streams]

    if (indexToRemove < 0) {
      return null
    }

    nextItems.splice(indexToRemove, 1)

    try {
      await this._cartService.sendData(JSON.stringify({
        streams: nextItems,
        strproductseams: this.products
      }))
      this.setStreams(nextItems)
    } catch (e) {
      console.error(e)
    }
  }

  public readonly containsStream = (streamId: number) => {
    return Boolean(this.streams.find(i => i.id === streamId))
  }

  private setStreams = (items: Stream[]) => {
    this.streams = items || []
  }
}
