import { inject, injectable } from 'inversify'
import 'reflect-metadata'
import { types } from 'ioc'
import { IHttpService } from 'services/HttpService'
import { Product } from 'models/Product'

export interface ICartService {
  fetchData: () => Promise<any>
  sendData: (data: string) => void
}

@injectable()
export default class CartService implements ICartService {
  @inject(types.IHttpService)
  private readonly _httpService!: IHttpService
  private readonly _urlPath = process.env.REACT_APP_ROUTE_BASKET

  fetchData = async (): Promise<any> => {
    return await this._httpService.sendAsync(`${this._urlPath}/getItems`)
  }

  sendData = (data: string): void => {
    this._httpService.sendAsync(`${this._urlPath}/updateItems`, { data })
  }
}