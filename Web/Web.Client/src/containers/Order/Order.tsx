import React, { useEffect } from 'react'
import {
  Avatar,
  Container,
  Grid,
  IconButton,
  List,
  ListItem,
  ListItemAvatar,
  ListItemButton,
  ListItemText,
  Paper
} from '@mui/material'
import { types, useInjection } from 'ioc'
import DeleteIcon from '@mui/icons-material/Delete'
import { observer } from 'mobx-react-lite'
import { useNavigate } from 'react-router-dom'
import OrderStore from './Order.store'
import CartStore from 'stores/CartStore'

const Order = observer(() => {
  // const orderStore = useInjection<OrderStore>(types.OrderStore)
  const cartStore = useInjection<CartStore>(types.CartStore)
  const navigate = useNavigate()

  // useEffect(() => {
  //   orderStore.fetchOrder()
  // }, [orderStore])

  if (!cartStore.items.length) {
    return null
  }

  return (
    <Container>
      <Grid container justifyContent="center">
        <Grid item xs={12} sm={8} md={6} lg={4}>
          <Paper>
            <List>
              {cartStore.items?.map((item) => (
                  <ListItem
                    key={item.id}
                    secondaryAction={
                      <IconButton edge="end" onClick={() => cartStore.remove(item.id)}>
                        <DeleteIcon />
                      </IconButton>
                    }
                  >
                    <ListItemButton onClick={() => navigate(`/landing/${item.id}`)}>
                      <ListItemAvatar>
                        <Avatar src={item.pictureUrl} />
                      </ListItemAvatar>
                      <ListItemText
                        primary={item.title}
                      />
                    </ListItemButton>
                  </ListItem>
                )
              )}
            </List>
          </Paper>
        </Grid>
      </Grid>
    </Container>
  )
})

export default Order
