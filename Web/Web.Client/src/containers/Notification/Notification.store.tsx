import { injectable } from 'inversify'
import { makeAutoObservable } from 'mobx'

@injectable()
export default class NotificationStore {
  public items: string[] = []

  constructor() {
    makeAutoObservable(this)
  }

  public add = (item: string) => {
    this.items.unshift(item)
  }

  public remove = (index: number) => {
    this.items.splice(index, 1)
  }
}
