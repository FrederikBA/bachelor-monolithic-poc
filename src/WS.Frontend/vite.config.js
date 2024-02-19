import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import svgr from "@svgr/rollup";

// https://vitejs.dev/config/
export default defineConfig({
  build: {
    outDir: '../ws.web/wwwroot'
  },
  plugins: [react(), svgr()],
  server: {
    port: 3000,
  }
})
