import { inject, injectable } from 'inversify'
import { makeAutoObservable } from 'mobx'
import { User } from 'models/User'
import { IAuthService } from 'services/AuthService'
import { types } from 'ioc'

@injectable()
export default class AuthStore {
  @inject(types.IAuthService)
  private readonly _authService!: IAuthService
  public user: any | null = null

  constructor() {
    makeAutoObservable(this)
  }
  
  public getUser = async () => {
    const userRes = await this._authService.getUser()

    this.setUser(userRes)
  }
  
  public setUser = (user: any) => {
    this.user = user
  }
}
