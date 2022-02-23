import { inject, injectable } from 'inversify'
import 'reflect-metadata'
import { types } from 'ioc'
import { IHttpService } from 'services/HttpService'

type getItemsByPageProps = {
  pageIndex: number
  pageSize: number,
  filters: {
    genre?: string
  }
}

type getStreamsByPageProps = {
  pageIndex: number
  pageSize: number
}

export interface IProductService {
  getItemsByPage: ({ pageIndex, pageSize, filters: { genre } }: getItemsByPageProps) => Promise<any>
  getItemById: (id: number) => Promise<any>
  getItemsByGenre: (id: number) => Promise<any>
  getStreamsByPage: ({ pageIndex, pageSize }: getStreamsByPageProps) => Promise<any>
  getStreamById: (id: number) => Promise<any>
  getGenres: () => Promise<any>
}

@injectable()
export default class ProductService implements IProductService {
  @inject(types.IHttpService)
  private readonly _httpService!: IHttpService
  private readonly _urlPath = process.env.REACT_APP_ROUTE_CATALOG

  public readonly getItemsByPage = (
    {
      pageIndex,
      pageSize,
      filters
    }: getItemsByPageProps) => this._httpService.sendAsync(`${this._urlPath}/items`, {
    pageIndex,
    pageSize,
    filters
  })

  public readonly getItemById = (id: number) => this._httpService.sendAsync(`${this._urlPath}/getById`, { id })

  public readonly getItemsByGenre = (id: number) => this._httpService.sendAsync(`${this._urlPath}/getByGenre`, {
    genreId: id
  })

  public readonly getStreamsByPage = (
    {
      pageIndex,
      pageSize
    }: getStreamsByPageProps) => this._httpService.sendAsync(`${this._urlPath}/streams`, {
    pageIndex,
    pageSize
  })

  public readonly getStreamById = (id: number) => this._httpService.sendAsync(`${this._urlPath}/getStreamById`, { id })

  public readonly getGenres = () => this._httpService.sendAsync(`${this._urlPath}/getGenres`)
}