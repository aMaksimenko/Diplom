import React, { useEffect } from 'react'
import { Navigate, Outlet, useNavigate } from 'react-router-dom'
import AuthStore from 'stores/AuthStore'
import { observer } from 'mobx-react-lite'
import { IAuthService } from 'services/AuthService'
import { types, useInjection } from 'ioc'

const LoginPage = () => {
  const authService = useInjection<IAuthService>(types.IAuthService)
  const navigate = useNavigate()

  useEffect(() => {
    if (authService.isAuthenticated()) {
      navigate('/')
    }
  }, [authService])

  return <>Loading...</>
}
export default LoginPage
