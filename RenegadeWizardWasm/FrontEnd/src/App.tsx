import { useState } from 'react'

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
      <section id="center">
        <div className="p-4">
          <h1 className="font-bold text-3xl text-pink-500 mb-4">WASM + React Bridge</h1>
          
          <button
            type="button"
            className="bg-blue-600 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mb-4"
            onClick={handlePunchDoor}
            disabled={loading}
          >
            {loading ? 'Processing...' : 'I punch the door'}
          </button>

          {response && (
            <div className="mt-4 p-4 border border-gray-300 rounded bg-gray-50 text-left">
              <h2 className="font-bold mb-2">Engine Response:</h2>
              <pre className="whitespace-pre-wrap">
                {JSON.stringify(response, null, 2)}
              </pre>
            </div>
          )}
        </div>
      </section>
    </>
  )
}

export default App
