import { api } from './api'

export interface CriptografiaResultado {
  original: string
  resultado: string
}

/**
 * @summary Serviço de acesso aos endpoints de criptografia do backend RAD.
 */
export const criptografiaService = {
  /**
   * @summary Criptografa um texto claro em uma string hexadecimal.
   * @param {string} aTexto - Texto claro a ser criptografado.
   * @returns {Promise<CriptografiaResultado>} Resultado com o hexadecimal.
   */
  async fnCriptografar(aTexto: string): Promise<CriptografiaResultado> {
    const { data } = await api.post<CriptografiaResultado>(
      '/api/criptografia/criptografar',
      { texto: aTexto },
    )
    return data
  },

  /**
   * @summary Descriptografa uma string hexadecimal para o texto claro original.
   * @param {string} aHex - Hexadecimal criptografado.
   * @returns {Promise<CriptografiaResultado>} Resultado com o texto claro.
   */
  async fnDescriptografar(aHex: string): Promise<CriptografiaResultado> {
    const { data } = await api.post<CriptografiaResultado>(
      '/api/criptografia/descriptografar',
      { texto: aHex },
    )
    return data
  },
}
