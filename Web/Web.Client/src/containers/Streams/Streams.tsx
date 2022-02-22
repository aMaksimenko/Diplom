import React, { useEffect } from 'react'
import { types, useInjection } from 'ioc'
import ProductsStore from './Streams.store'
import { observer } from 'mobx-react-lite'
import Card from './components/Card'
import { Box, Container, Grid, Pagination } from '@mui/material'
import StreamsStore from './Streams.store'

const Products = observer(() => {
  const store = useInjection<StreamsStore>(types.StreamsStore)

  useEffect(() => {
    store.getStreamsByPage()
  }, [store, store.pageIndex])

  return (
    <Container sx={{ mb: 4 }}>
      <Grid container spacing={4} justifyContent="center" mb={4}>
        {store.products.map((item) => (
          <Grid key={item.id} item lg={4} md={6} xs={12}>
            <Card data={item}/>
          </Grid>
        ))}
      </Grid>
      <Box
        sx={{
          display: 'flex',
          justifyContent: 'center'
        }}
      >
        {store.pageCount > 1 && (
          <Pagination count={store.pageCount} page={store.pageIndex + 1} onChange={store.setPage}/>
        )}
      </Box>
    </Container>
  )
})

export default Products
