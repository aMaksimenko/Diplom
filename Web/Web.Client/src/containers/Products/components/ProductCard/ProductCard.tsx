import * as React from 'react'
import { FC } from 'react'
import Card from '@mui/material/Card'
import CardMedia from '@mui/material/CardMedia'
import { Button, CardActionArea, CardActions } from '@mui/material'
import { Product as ProductType } from 'models/Product'
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart'
import { useNavigate } from 'react-router-dom'
import { types, useInjection } from 'ioc'
import CartStore from 'stores/CartStore'
import { observer } from 'mobx-react-lite'
import DoneOutlineIcon from '@mui/icons-material/DoneOutline'

const ProductCard: FC<ProductCardProps> = observer(({ data }) => {
  const { title, pictureUrl, id } = data
  const navigate = useNavigate()
  const cartStore = useInjection<CartStore>(types.CartStore)
  const isAdded = cartStore.contains(id)

  return (
    <Card>
      <CardActionArea onClick={() => navigate(`/landing/${id}`)}>
        <CardMedia
          component="img"
          height="300"
          image={pictureUrl}
          alt={title}
        />
      </CardActionArea>
      <CardActions disableSpacing>
        <Button
          fullWidth
          size="small"
          variant="outlined"
          startIcon={isAdded ? <DoneOutlineIcon/> : <AddShoppingCartIcon/>}
          onClick={() => cartStore.add(data)}
          disabled={isAdded}
        >
          {isAdded ? 'In cart ' : 'Buy'}
        </Button>
      </CardActions>
    </Card>
  )
})

type ProductCardProps = {
  data: ProductType & { onClick: () => void }
}

export default ProductCard
