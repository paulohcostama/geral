import { useState } from 'react'
import {
  Alert,
  Box,
  Button,
  Card,
  CardContent,
  Divider,
  Stack,
  TextField,
  Typography,
} from '@mui/material'
import LockIcon from '@mui/icons-material/Lock'
import LockOpenIcon from '@mui/icons-material/LockOpen'
import { useCriptografiaController } from '../../controllers/useCriptografiaController'

/**
 * @summary Tela de demonstração da criptografia RAD (migração do componente Delphi).
 * Permite criptografar um texto claro para hexadecimal e descriptografar de volta.
 */
export function CriptografiaView() {
  const controller = useCriptografiaController()
  const [edtTextoClaro, setEdtTextoClaro] = useState('RADINFO 2026')
  const [edtHex, setEdtHex] = useState('')
  const [edtDecifrado, setEdtDecifrado] = useState('')

  const fnCriptografar = async () => {
    const hex = await controller.fnCriptografar(edtTextoClaro)
    setEdtHex(hex)
    setEdtDecifrado('')
  }

  const fnDescriptografar = async () => {
    const texto = await controller.fnDescriptografar(edtHex)
    setEdtDecifrado(texto)
  }

  return (
    <Box
      sx={{
        minHeight: '100vh',
        width: '100%',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'flex-start',
        p: 4,
      }}
    >
      <Card sx={{ width: '100%', maxWidth: 640, boxShadow: 4 }}>
        <Box sx={{ bgcolor: 'primary.main', color: 'primary.contrastText', px: 3, py: 2 }}>
          <Typography variant="h5" sx={{ fontWeight: 600 }}>
            RAD Convênio — Criptografia
          </Typography>
          <Typography variant="body2" sx={{ opacity: 0.85 }}>
            Migração do componente Delphi para C# + React
          </Typography>
        </Box>

        <CardContent>
          <Stack spacing={2}>
            <TextField
              label="Texto claro"
              value={edtTextoClaro}
              onChange={(e) => setEdtTextoClaro(e.target.value)}
              fullWidth
            />
            <Button
              variant="contained"
              startIcon={<LockIcon />}
              onClick={fnCriptografar}
              disabled={controller.lkpCarregando || !edtTextoClaro}
            >
              Criptografar
            </Button>

            <TextField
              label="Hexadecimal criptografado"
              value={edtHex}
              onChange={(e) => setEdtHex(e.target.value.toUpperCase())}
              fullWidth
              slotProps={{ input: { sx: { fontFamily: 'monospace' } } }}
            />
            <Button
              variant="outlined"
              color="secondary"
              startIcon={<LockOpenIcon />}
              onClick={fnDescriptografar}
              disabled={controller.lkpCarregando || !edtHex}
            >
              Descriptografar
            </Button>

            {edtDecifrado && (
              <>
                <Divider />
                <Alert severity="success">
                  Texto recuperado: <strong>{edtDecifrado}</strong>
                </Alert>
              </>
            )}

            {controller.edtErro && <Alert severity="error">{controller.edtErro}</Alert>}
          </Stack>
        </CardContent>
      </Card>
    </Box>
  )
}
