import { useState, useEffect, useRef } from 'react';

export default function GameWindow() {
    
    const [userInput, setUserInput] = useState("");
    const [terminalLines, setTerminalLines] = useState<string[]>([]);
    const scrollRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        if (scrollRef.current) {
            scrollRef.current.scrollTop = scrollRef.current.scrollHeight;
        }
    }, [terminalLines]);

    const handleSubmit = async () => {
        if (!userInput.trim()) return;

        const input = userInput;
        setUserInput("");

        try {
            // @ts-ignore
            const result = await window.DotNet.invokeMethodAsync(
                'RenegadeWizardWasm',
                'EnterInputStatic',
                input
            );
            console.log("WASM Result:", result);
            
            if (result.text) {
                setTerminalLines(prev => [...prev, result.text]);
            }
            
        } catch (err) {
            console.error('Failed to call WASM:', err);
        }
    };
    
    return (
        <div className="flex h-screen w-full bg-gray-900 justify-center">
            {/* Main column - anchored 30% from bottom */}
            <div className="w-2/5 flex flex-col relative h-full">
                
                {/* Upper Text Box - should occupy top 70% and float upwards */}
                <div 
                    ref={scrollRef}
                    className="flex-1 flex flex-col justify-end overflow-y-auto p-4 pt-10" 
                    style={{ height: '70vh' }}
                >
                    <div className="text-gray-300 font-mono space-y-1">
                        {terminalLines.map((line, i) => (
                            <div key={i} dangerouslySetInnerHTML={{ __html: line }} />
                        ))}
                    </div>
                </div>

                {/* Thin Line Separator */}
                <div className="border-t border-gray-700 w-full"></div>

                {/* Text Bar - Anchored at ~30% from bottom */}
                <div className="p-4 bg-gray-800">
                    <input
                        type="text"
                        value={userInput}
                        onChange={(e) => setUserInput(e.target.value)}
                        onKeyDown={(e) => {
                            if (e.key === 'Enter') {
                                handleSubmit();
                            }
                        }}
                        className="w-full bg-transparent text-white px-3 py-2 focus:outline-none"
                        placeholder="Enter your command..."
                        autoFocus
                    />
                </div>
                
                {/* Spacer to push everything up to 30% from bottom */}
                <div style={{ height: '30vh' }}></div>
            </div>
        </div>
    )
}
