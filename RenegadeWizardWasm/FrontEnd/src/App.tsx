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
          <h1 className="font-bold text-3xl text-green-600 mb-4">WASM + React Bridge</h1>
          
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

      <div className="ticks"></div>

      <section id="next-steps">
        <div id="docs">
          <svg className="icon" role="presentation" aria-hidden="true">
            <use href="/icons.svg#documentation-icon"></use>
          </svg>
          <h2>Documentation</h2>
          <p>Your questions, answered</p>
        </div>
        <div id="social">
          <svg className="icon" role="presentation" aria-hidden="true">
            <use href="/icons.svg#social-icon"></use>
          </svg>
          <h2>Connect with us</h2>
          <p>Join the Vite community</p>
          <ul>
            <li>
              <a href="https://github.com/vitejs/vite" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#github-icon"></use>
                </svg>
                GitHub
              </a>
            </li>
            <li>
              <a href="https://chat.vite.dev/" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#discord-icon"></use>
                </svg>
                Discord
              </a>
            </li>
            <li>
              <a href="https://x.com/vite_js" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#x-icon"></use>
                </svg>
                X.com
              </a>
            </li>
            <li>
              <a href="https://bsky.app/profile/vite.dev" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#bluesky-icon"></use>
                </svg>
                Bluesky
              </a>
            </li>
          </ul>
        </div>
      </section>

      <div className="ticks"></div>
      <section id="spacer"></section>
    </>
  )
}

export default App
