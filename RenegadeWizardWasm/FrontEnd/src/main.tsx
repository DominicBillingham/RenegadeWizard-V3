import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import GameWindow from "./GameWindow.tsx";

async function init() {
  // @ts-ignore
  if (window.Blazor) {
    // @ts-ignore
    await window.Blazor.start();
  }

  createRoot(document.getElementById('root')!).render(
    <StrictMode>
      <GameWindow />
    </StrictMode>,
  )
}

init();
