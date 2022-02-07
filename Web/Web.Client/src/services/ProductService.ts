import { inject, injectable } from 'inversify'
import 'reflect-metadata'
import { types } from 'ioc'
import { IHttpService } from 'services/HttpService'

type getItemsByPageProps = {
  pageIndex: number
  pageSize: number
}

export interface IProductService {
  getItemsByPage: ({ pageIndex, pageSize }: getItemsByPageProps) => Promise<any>
  getItemById: (id: number) => Promise<any>
  getItemsByIds: (id: number[]) => Promise<any>
  getItemsByGenre: (id: number) => Promise<any>
}

@injectable()
export default class ProductService implements IProductService {
  @inject(types.IHttpService)
  private readonly _httpService!: IHttpService
  private readonly _urlPath = process.env.REACT_APP_ROUTE_CATALOG

  public readonly getItemsByPage = (
    {
      pageIndex,
      pageSize
    }: getItemsByPageProps) => this._httpService.sendAsync(`${this._urlPath}/items`, {
    pageIndex,
    pageSize
  })

  public readonly getItemById = (id: number) => this._httpService.sendAsync(`${this._urlPath}/getById?id=${id}`)

  public readonly getItemsByGenre = (id: number) => this._httpService.sendAsync(`${this._urlPath}/getByGenre`, {
    genreId: id
  })

  getItemsByIds (id: number[]): Promise<any> {
    return Promise.resolve(undefined);
  }
}