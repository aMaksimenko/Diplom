import React, { useEffect } from 'react'
import { IAuthService } from 'services/AuthService'
import { types, useInjection } from 'ioc'

export const Callback = () => {
  const authService = useInjection<IAuthService>(types.IAuthService)

  useEffect(() => {
    authService.signinRedirectCallback()
  }, [authService])

  return <>Loading...</>
}