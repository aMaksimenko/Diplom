import { Container } from 'inversify'
import types from './types'
import HttpService, { IHttpService } from 'services/HttpService'
import ProductService, { IProductService } from 'services/ProductService'
import AuthService, { IAuthService } from 'services/AuthService'
import ProductsStore from 'containers/Products/Products.store'
import ProductStore from 'containers/Product/Product.store'
import AuthStore from 'stores/AuthStore'
import CartStore from 'stores/CartStore'
import OrderStore from 'containers/Order/Order.store'
import CartService, { ICartService } from 'services/CartService'
import StreamsStore from 'containers/Streams/Streams.store'
import StreamStore from 'containers/Stream/Stream.store'

const container = new Container()

container.bind<IHttpService>(types.IHttpService).to(HttpService).inSingletonScope()
container.bind<IProductService>(types.IProductService).to(ProductService).inSingletonScope()
container.bind<IAuthService>(types.IAuthService).to(AuthService).inSingletonScope()
container.bind<ICartService>(types.ICartService).to(CartService).inSingletonScope()
container.bind<AuthStore>(types.AuthStore).to(AuthStore).inSingletonScope()
container.bind<CartStore>(types.CartStore).to(CartStore).inSingletonScope()
container.bind<ProductsStore>(types.ProductsStore).to(ProductsStore).inTransientScope()
container.bind<StreamsStore>(types.StreamsStore).to(StreamsStore).inTransientScope()
container.bind<ProductStore>(types.ProductStore).to(ProductStore).inTransientScope()
container.bind<StreamStore>(types.StreamStore).to(StreamStore).inTransientScope()
container.bind<OrderStore>(types.OrderStore).to(OrderStore).inTransientScope()

export default container
