import React, { useEffect } from 'react'
import { types, useInjection } from 'ioc'
import ProductsStore from './Products.store'
import { observer } from 'mobx-react-lite'
import ProductCard from './components/Card'
import { Box, Container, FormControl, Grid, InputLabel, MenuItem, Pagination, Select } from '@mui/material'

const Products = observer(() => {
  const store = useInjection<ProductsStore>(types.ProductsStore)

  useEffect(() => {
    store.getGenres()
  }, [store])

  useEffect(() => {
    store.getProductsAsync()
  }, [store, store.pageIndex])

  useEffect(() => {
    store.setPage(1)
    store.getProductsAsync()
  }, [store, store.selectedGenre])

  return (
    <Container sx={{ mb: 4 }}>
      {!!store.genres.length && (
        <Grid container sx={{ mb: 2 }} spacing={4}>
          <Grid item xs={12} md={6} lg={4}>
            <FormControl fullWidth>
              <InputLabel>Select Genre</InputLabel>
              <Select
                value={store.selectedGenre}
                label="Select Genr"
                onChange={(ev) => store.setSelectedGenre(ev.target.value)}
              >
                {store.genres.map(option => (
                  <MenuItem key={option.id} value={option.id}>{option.genre}</MenuItem>
                ))}
              </Select>
            </FormControl>

          </Grid>
        </Grid>
      )}
      <Grid container spacing={4} justifyContent="center" mb={4}>
        {store.products.map((item) => (
          <Grid key={item.id} item lg={3} md={4} xs={6}>
            <ProductCard data={item}/>
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
          <Pagination count={store.pageCount} page={store.pageIndex + 1} onChange={(event, val) => store.setPage(val)}/>
        )}
      </Box>
    </Container>
  )
})

export default Products
