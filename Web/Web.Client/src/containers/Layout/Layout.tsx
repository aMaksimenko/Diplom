import React from 'react'
import Header from 'components/Header'
import { Outlet } from 'react-router-dom'
import { Box } from '@mui/material'

const Layout = () => {
  return (
    <>
      <Header />
      <Box sx={{ py: { xs: 2, md: 4 } }}>
        <Outlet />
      </Box>
    </>
  )
}

export default Layout
