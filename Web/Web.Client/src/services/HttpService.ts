import { inject, injectable } from 'inversify'
import AuthStore from 'stores/AuthStore'
import { types } from 'ioc'

export interface IHttpService {
  sendAsync: (path: string, payload?: any) => Promise<any>
}

@injectable()
export default class HttpService implements IHttpService {
  @inject(types.AuthStore)
  private readonly _authStore!: AuthStore
  private readonly _baseUrl = process.env.REACT_APP_BASE_API_URL!

  private readonly handleResponse = (response: Response) => {
    // if (!response.ok) {
    //   const message = await response.json()
    //   throw Error(message.error || 'Request error')
    // }
    return response.json()
  }

  public readonly sendAsync = async (path: string, payload?: any) => {
    const accessToken = this._authStore?.user?.access_token
    const requestOptions = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        Authorization: accessToken ? `Bearer ${accessToken}` : ''
      },
      body: payload ? JSON.stringify(payload) : undefined
    }
    return await fetch(`${this._baseUrl}${path}`, requestOptions).then(this.handleResponse)
  }
}



