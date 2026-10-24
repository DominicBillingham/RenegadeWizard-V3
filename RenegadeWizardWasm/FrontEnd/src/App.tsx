import { useState } from 'react'
import GameWindow from "./Components/GameWindow.tsx";

function App() {
  const [response, setResponse] = useState<any>(null)
  const [loading, setLoading] = useState(false)

  const handlePunchDoor = async () => {
    setLoading(true)
    try {
      // @ts-ignore
      const result = await window.DotNet.invokeMethodAsync(
        'RenegadeWizardWasm',
        'EnterInputStatic',
        'I punch the door'
      )
      setResponse(result)
    } catch (err) {
      console.error('Failed to call WASM:', err)
      setResponse({ error: 'Failed to connect to WASM engine' })
    } finally {
      setLoading(false)
    }
  }

  return (
    <>
      <GameWindow />
    </>
  )
}

export default App
