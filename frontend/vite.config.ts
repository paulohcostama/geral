import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

const backendTarget = process.env.VITE_API_TARGET ?? 'http://localhost:5044'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    host: true,
    port: 5173,
    proxy: {
      '/api': { target: backendTarget, changeOrigin: true },
      '/health': { target: backendTarget, changeOrigin: true },
    },
  },
})
