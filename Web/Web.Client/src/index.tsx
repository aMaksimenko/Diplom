import 'reflect-metadata'
import React from 'react'
import ReactDOM from 'react-dom'
import App from 'containers/App'
import { container, Provider as IoCProvider } from 'ioc'
import darkTheme from 'themes/Dark'
import { CssBaseline, ThemeProvider } from '@mui/material'
import { unstable_HistoryRouter as HistoryRouter } from 'react-router-dom';
import history from 'routes/history'

ReactDOM.render(
  <React.StrictMode>
    <IoCProvider container={container}>
      <HistoryRouter history={history}>
        <ThemeProvider theme={darkTheme}>
          <CssBaseline />
          <App />
        </ThemeProvider>
      </HistoryRouter>
    </IoCProvider>
  </React.StrictMode>,
  document.getElementById('root')
)
