import { CssBaseline, ThemeProvider } from '@mui/material'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { radTheme } from './themes/radTheme'
import { CriptografiaView } from './views/Criptografia/CriptografiaView'

const queryClient = new QueryClient()

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <ThemeProvider theme={radTheme}>
        <CssBaseline />
        <CriptografiaView />
      </ThemeProvider>
    </QueryClientProvider>
  )
}

export default App
