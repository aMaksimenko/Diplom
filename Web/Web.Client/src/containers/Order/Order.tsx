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
  Paper,
  Typography
} from '@mui/material'
import { types, useInjection } from 'ioc'
import DeleteIcon from '@mui/icons-material/Delete'
import { observer } from 'mobx-react-lite'
import { useNavigate } from 'react-router-dom'
import OrderStore from './Order.store'
import CartStore from 'stores/CartStore'

const Order = observer(() => {
  const cartStore = useInjection<CartStore>(types.CartStore)
  const navigate = useNavigate()

  return (
    <Container>
      <Grid container justifyContent="center">
        <Grid item xs={12} sm={8} md={6} lg={4}>
          {!!cartStore.products?.length && (
            <>
              <Typography component={'h2'} sx={{ mb: 2 }}>
                Movies
              </Typography>
              <Paper sx={{ mb: 6 }}>
                <List>
                  {cartStore.products?.map((item) => (
                      <ListItem
                        key={item.id}
                        secondaryAction={
                          <IconButton edge="end" onClick={() => cartStore.removeProduct(item.id)}>
                            <DeleteIcon/>
                          </IconButton>
                        }
                      >
                        <ListItemButton onClick={() => navigate(`/product/${item.id}`)}>
                          <ListItemAvatar>
                            <Avatar src={item.pictureUrl}/>
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
            </>
          )}
          {!!cartStore.streams?.length && (
            <>
              <Typography component={'h2'} sx={{ mb: 2 }}>
                Stream Services
              </Typography>
              <Paper sx={{ mb: 6 }}>
                <List>
                  {cartStore.streams?.map((item) => (
                      <ListItem
                        key={item.id}
                        secondaryAction={
                          <IconButton edge="end" onClick={() => cartStore.removeStream(item.id)}>
                            <DeleteIcon/>
                          </IconButton>
                        }
                      >
                        <ListItemButton onClick={() => navigate(`/stream/${item.id}`)}>
                          <ListItemAvatar>
                            <Avatar src={item.pictureUrl}/>
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

            </>
          )}

        </Grid>
      </Grid>
    </Container>
  )
})

export default Order
