import { makeAutoObservable } from 'mobx'
import { inject, injectable } from 'inversify'
import { types } from 'ioc'
import AuthStore from 'stores/AuthStore'
import { Product } from 'models/Product'
import { IAuthService } from 'services/AuthService'
import { ICartService } from 'services/CartService'

@injectable()
export default class CartStore {
  @inject(types.IAuthService)
  private readonly _authService!: IAuthService
  @inject(types.ICartService)
  private readonly _cartService!: ICartService
  public items: Product[] = []

  constructor () {
    makeAutoObservable(this)
  }

  public fetchData = async () => {
    const response = await this._cartService.fetchData()

    this.setItems(JSON.parse(response.data) as Product[])
  }

  public readonly add = async (data: Product) => {
    if (!this._authService.isAuthenticated()) {
      this._authService.signinRedirect()
    }

    const nextItems = [...this.items, data]

    try {
      await this._cartService.sendData(JSON.stringify(nextItems))
      this.setItems(nextItems)
    } catch (e) {
      console.error(e)
    }
  }

  public readonly remove = async (productId: number) => {
    const indexToRemove = this.items.findIndex(i => i.id === productId)
    const nextItems = [...this.items]

    if (indexToRemove < 0) {
      return null
    }

    nextItems.splice(indexToRemove, 1)

    try {
      await this._cartService.sendData(JSON.stringify(nextItems))
      this.setItems(nextItems)
    } catch (e) {
      console.error(e)
    }
  }

  public readonly contains = (productId: number) => {
    return Boolean(this.items.find(i => i.id === productId))
  }

  private setItems = (items: Product[]) => {
    this.items = items
  }
}
