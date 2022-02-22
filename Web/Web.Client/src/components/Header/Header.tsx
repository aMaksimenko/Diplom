import React, { useContext } from 'react'
import AppBar from '@mui/material/AppBar'
import Toolbar from '@mui/material/Toolbar'
import Container from '@mui/material/Container'
import { Badge, Box, Button, IconButton, Typography } from '@mui/material'
import { useNavigate } from 'react-router-dom'
import { types, useInjection } from 'ioc'
import AuthStore from 'stores/AuthStore'
import { observer } from 'mobx-react-lite'
import LogoutIcon from '@mui/icons-material/Logout'
import LoginIcon from '@mui/icons-material/Login'
import CartStore from 'stores/CartStore'
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart'
import { useEffect } from 'react'

const Header = observer(() => {
  const navigate = useNavigate()
  const authStore = useInjection<AuthStore>(types.AuthStore)
  const cartStore = useInjection<CartStore>(types.CartStore)
  const sumTotal = cartStore.products.length + cartStore.streams.length
  
  return (
    <AppBar position="static">
      <Container>
        <Toolbar disableGutters sx={{ justifyContent: 'space-between' }}>
          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ mr: 2, cursor: 'pointer' }}
            onClick={() => navigate('/')}
          >
            MDB
          </Typography>

          {!!authStore.user ? (
            <Box>
              <IconButton size="large" onClick={() => navigate('/order')}>
                <Badge badgeContent={sumTotal} color="primary">
                  <ShoppingCartIcon/>
                </Badge>
              </IconButton>
              <Button
                color="primary"
                sx={{ textTransform: 'capitalize', ml: 2 }}
                size="small"
                variant="outlined"
                endIcon={<LogoutIcon/>}
                onClick={() => navigate('/logout')}
              >
                {authStore?.user?.profile?.name}
              </Button>
            </Box>
          ) : (
            <Button
              color="primary"
              size="small"
              variant="outlined"
              endIcon={<LoginIcon/>}
              onClick={() => navigate('/login')}
            >
              Login
            </Button>
          )}
        </Toolbar>
      </Container>
    </AppBar>
  )
})

export default Header

