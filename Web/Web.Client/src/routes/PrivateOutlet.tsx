import React from 'react'
import { Navigate, Outlet } from 'react-router-dom'
import AuthStore from 'stores/AuthStore'
import { observer } from 'mobx-react-lite'
import { IAuthService } from 'services/AuthService'
import { types, useInjection } from 'ioc'

const PrivateOutlet = observer(() => {
  const authService = useInjection<IAuthService>(types.IAuthService)

  if (!authService.isAuthenticated()) {
    authService.signinRedirect()
    return <>Loading...</>
  }

  return <Outlet/>
})

export default PrivateOutlet
