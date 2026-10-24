import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'
import tailwindcss from "@tailwindcss/vite";

export default defineConfig({
  plugins: [react(), tailwindcss()],
  server: {
    proxy: {
      // Proxy Blazor framework and data requests to the .NET server
      '/_framework': {
        target: 'http://localhost:5168', // Update this to your Blazor dev URL
        secure: false,
      },
    }
  }
})