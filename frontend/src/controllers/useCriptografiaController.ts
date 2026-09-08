import { useState } from 'react'
import { criptografiaService } from '../services/criptografiaService'

/**
 * @summary Controller da tela de Criptografia. Orquestra as chamadas ao serviço
 * e mantém o estado dos resultados de criptografar/descriptografar.
 */
export function useCriptografiaController() {
  const [lkpCarregando, setLkpCarregando] = useState(false)
  const [edtErro, setEdtErro] = useState<string | null>(null)

  const fnCriptografar = async (aTexto: string): Promise<string> => {
    setLkpCarregando(true)
    setEdtErro(null)
    try {
      const res = await criptografiaService.fnCriptografar(aTexto)
      return res.resultado
    } catch {
      setEdtErro('Falha ao criptografar o texto.')
      return ''
    } finally {
      setLkpCarregando(false)
    }
  }

  const fnDescriptografar = async (aHex: string): Promise<string> => {
    setLkpCarregando(true)
    setEdtErro(null)
    try {
      const res = await criptografiaService.fnDescriptografar(aHex)
      return res.resultado
    } catch {
      setEdtErro('Falha ao descriptografar. Verifique se o valor é um hexadecimal válido.')
      return ''
    } finally {
      setLkpCarregando(false)
    }
  }

  return { fnCriptografar, fnDescriptografar, lkpCarregando, edtErro }
}
