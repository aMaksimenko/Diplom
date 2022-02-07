import React, { useEffect } from 'react'
import AppRoutes from 'routes/App'
import { types, useInjection } from 'ioc'
import AuthStore from 'stores/AuthStore'
import CartStore from 'stores/CartStore'
import { observer } from 'mobx-react-lite'

const App = observer(() => {
  const authStore = useInjection<AuthStore>(types.AuthStore)
  const cartStore = useInjection<CartStore>(types.CartStore)

  useEffect(() => {
    authStore.getUser()
  }, [authStore])

  useEffect(() => {
    if (authStore.user) {
      cartStore.fetchData()
    }
  }, [authStore.user, cartStore])

  return (
    <>
      <AppRoutes/>
    </>
  )
})

export default App
