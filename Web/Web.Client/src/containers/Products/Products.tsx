import React, { useEffect } from 'react'
import { types, useInjection } from 'ioc'
import ProductsStore from './Products.store'
import { observer } from 'mobx-react-lite'
import ProductCard from './components/ProductCard'
import { Box, Container, Grid, Pagination } from '@mui/material'

const Products = observer(() => {
  const store = useInjection<ProductsStore>(types.ProductsStore)

  useEffect(() => {
    store.getProductsAsync()
  }, [store, store.pageIndex])

  return (
    <Container>
      <Grid container spacing={4} justifyContent="center" mb={4}>
        {store.products.map((item) => (
          <Grid key={item.id} item lg={2} md={4} xs={6}>
            <ProductCard data={item} />
          </Grid>
        ))}
      </Grid>
      <Box
        sx={{
          display: 'flex',
          justifyContent: 'center'
        }}
      >
        <Pagination count={store.pageCount} page={store.pageIndex + 1} onChange={store.setPage}/>
      </Box>
    </Container>
  )
})

export default Products
