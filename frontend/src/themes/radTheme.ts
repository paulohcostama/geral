import { createTheme } from '@mui/material/styles'

export const radTheme = createTheme({
  palette: {
    primary: { main: '#1a4a8a', contrastText: '#ffffff' },
    secondary: { main: '#8D522B' },
    background: { default: '#f4f6f9' },
  },
  typography: {
    fontFamily: 'Roboto, Segoe UI, Inter, sans-serif',
  },
})
