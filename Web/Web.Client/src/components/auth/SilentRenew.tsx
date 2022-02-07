import React, { useEffect } from 'react'
import { IAuthService } from 'services/AuthService'
import { types, useInjection } from 'ioc'

export const SilentRenew = () => {
  const authService = useInjection<IAuthService>(types.IAuthService)

  useEffect(() => {
    authService.signinSilentCallback()
  }, [authService])

  return <>Loading...</>
}