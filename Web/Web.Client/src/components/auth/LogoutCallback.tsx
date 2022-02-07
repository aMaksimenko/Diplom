import React, { useEffect } from 'react'
import { IAuthService } from 'services/AuthService'
import { types, useInjection } from 'ioc'

export const LogoutCallback = () => {
  const authService = useInjection<IAuthService>(types.IAuthService)

  useEffect(() => {
    authService.signoutRedirectCallback()
  }, [authService])

  return <>Loading...</>
}