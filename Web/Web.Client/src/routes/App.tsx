import React, { Suspense } from 'react'
import { Route, Routes } from 'react-router-dom'
import PrivateOutlet from './PrivateOutlet'
import Layout from 'containers/Layout'

import { Callback } from 'components/auth/Callback'
import { Logout } from 'components/auth/Logout'
import { LogoutCallback } from 'components/auth/LogoutCallback'
import { SilentRenew } from 'components/auth/SilentRenew'

const Home = React.lazy(() => import('pages/Home'))
const Landing = React.lazy(() => import('pages/Landing'))
const Login = React.lazy(() => import('pages/Login'))
const Order = React.lazy(() => import('pages/Order'))

const App = () => {
  return (
    <Suspense fallback={null}>
      <Routes>
        <Route path="/" element={<Layout/>}>
          <Route path="/signin-oidc" element={<Callback/>}/>
          <Route path="/logout" element={<Logout/>}/>
          <Route path="/logout/callback" element={<LogoutCallback/>}/>
          <Route path="/silentrenew" element={<SilentRenew/>}/>
          <Route index element={<Home/>}/>
          <Route path="/landing/:id" element={<Landing/>}/>
          <Route element={<PrivateOutlet/>}>
            <Route path="/login" element={<Login/>}/>
            <Route path="/order" element={<Order/>}/>
          </Route>
        </Route>
      </Routes>
    </Suspense>
  )
}

export default App