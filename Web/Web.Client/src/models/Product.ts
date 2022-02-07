export type Product = {
  description: string
  genres: {
    id: number
    genre: string
  }[]
  id: number
  imdb: number
  pictureUrl: string
  price: number
  title: string
  year: number
}
