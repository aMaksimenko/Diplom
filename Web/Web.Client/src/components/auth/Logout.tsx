import React, { useEffect } from 'react'
import { IAuthService } from 'services/AuthService'
import { types, useInjection } from 'ioc'

export const Logout = () => {
  const authService = useInjection<IAuthService>(types.IAuthService)

  useEffect(() => {
    authService.logout()
  }, [authService])

  return <>Loading...</>
} 