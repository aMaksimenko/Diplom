import React from 'react'
import { Chip } from '@mui/material'

const GenreList = ({ items }: { items: {id: number, genre: string}[] }) => {
  return (
    <>
      {items.map((item ) => (
        <Chip variant="outlined" key={item.id} label={item.genre} size="small" sx={{ mr: 1 }} />
      ))}
    </>
  )
}

export default GenreList
