import React, { useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { types, useInjection } from 'ioc'
import StreamStore from './Stream.store'
import { observer } from 'mobx-react-lite'
import { Box, Button, Container, Grid, Stack, Typography } from '@mui/material'
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart'
import CartStore from 'stores/CartStore'
import DoneOutlineIcon from '@mui/icons-material/DoneOutline'

const Stream = observer(() => {
  const params = useParams()
  const store = useInjection<StreamStore>(types.StreamStore)
  const cartStore = useInjection<CartStore>(types.CartStore)

  useEffect(() => {
    if (params.id) {
      store.getStreamAsync(Number(params.id))
    }
  }, [params, store])

  if (!store.product) {
    return null
  }

  const { title, pictureUrl, imdb, year, genres, id, description } = store.product
  const isAdded = cartStore.containsStream(id)

  return (
    <Container>
      <Box mb={4}>
        <img src={pictureUrl} alt={title} style={{ width: '100%' }}/>
      </Box>
      <Grid container spacing={4}>
        <Grid item xs={12} sm={8}>
          <Typography variant="h4" fontWeight={700} mb={4}>
            {title}
          </Typography>
          <Stack spacing={1} alignItems="flex-start" mb={4}>
            <Typography>
              {description}
            </Typography>
          </Stack>
          <Button
            variant="outlined"
            startIcon={isAdded ? <DoneOutlineIcon/> : <AddShoppingCartIcon/>}
            onClick={() => cartStore.addStream(store.product)}
            disabled={isAdded}
          >
            {isAdded ? 'In cart ' : 'Subscribe'}
          </Button>
        </Grid>
      </Grid>
    </Container>
  )
})

export default Stream
