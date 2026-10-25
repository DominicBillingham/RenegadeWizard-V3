import React, { useState, useEffect, useCallback } from 'react';
import InputBox from "./InputBox.tsx";

interface GameResponse {
    playerInput: string;
    actionNames: string[];
    entityNames: string[];
    text: string[];
    // Add other fields if necessary
}

export default function GameWindow() {
    const [userInput, setUserInput] = useState("");
    const [ghostInput, setGhostInput] = useState("");
    const [commandHistory, setCommandHistory] = useState<string[]>([]);
    const [historyIndex, setHistoryIndex] = useState(-1);
    const [tempInput, setTempInput] = useState("");
    const [lastResponse, setLastResponse] = useState<GameResponse | null>(null);
    const [terminalLines, setTerminalLines] = useState<string[]>([]);

    useEffect(() => {
        const initializeGame = async () => {
            try {
                // @ts-ignore
                if (window.DotNet) {
                    // @ts-ignore
                    const result = await window.DotNet.invokeMethodAsync(
                        'RenegadeWizardWasm',
                        'StartGameStatic'
                    );
                    console.log("WASM Init Result:", result);
                    setLastResponse(result);
                    if (result && result.text) {
                        setTerminalLines(result.text);
                    }
                }
            } catch (err) {
                console.error('Failed to initialize game:', err);
            }
        };
        
        // Give WASM a little time to load if necessary, or just call it
        // Depending on how the project is set up, window.DotNet might not be immediately available
        const timer = setTimeout(initializeGame, 500);
        return () => clearTimeout(timer);
    }, []);

    const updateGhostInput = useCallback((input: string, response: GameResponse | null) => {
        if (!input || !response) {
            setGhostInput("");
            return;
        }

        const parts = input.toLowerCase().split(' ').filter(p => p);
        const hasTrailingSpace = input.endsWith(" ");

        if (parts.length === 0 || hasTrailingSpace) {
            setGhostInput("");
            return;
        }

        const lastPart = parts[parts.length - 1];
        let suggestion = "";

        for (const name of response.actionNames || []) {
            if (name.startsWith(lastPart) && name !== lastPart) {
                suggestion = name;
                break;
            }
        }

        if (!suggestion) {
            for (const name of response.entityNames || []) {
                if (name.startsWith(lastPart) && name !== lastPart) {
                    suggestion = name;
                    break;
                }
            }
        }

        if (suggestion) {
            parts[parts.length - 1] = suggestion;
            let fullGhost = parts.join(" ");
            if (fullGhost.toLowerCase().startsWith(input.toLowerCase())) {
                setGhostInput(input + fullGhost.substring(input.length));
            } else {
                setGhostInput("");
            }
        } else {
            setGhostInput("");
        }
    }, []);

    const handleInputChange = (value: string) => {
        setUserInput(value);
        updateGhostInput(value, lastResponse);
    };

    const handleSubmit = async () => {
        if (!userInput.trim()) return;

        const input = userInput;
        setUserInput("");
        setGhostInput("");
        setCommandHistory(prev => [...prev, input]);
        setHistoryIndex(-1);
        setTempInput("");

        try {
            // @ts-ignore
            const result = await window.DotNet.invokeMethodAsync(
                'RenegadeWizardWasm',
                'EnterInputStatic',
                input
            );
            console.log("WASM Result:", result);
            setLastResponse(result);
            if (result.text) {
                setTerminalLines(prev => [...prev, ...result.text]);
            }
            updateGhostInput("", result);
        } catch (err) {
            console.error('Failed to call WASM:', err);
        }
    };

    const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
        if (e.key === 'Tab') {
            e.preventDefault();
            if (ghostInput) {
                setUserInput(ghostInput);
                setGhostInput("");
            } else if (lastResponse && userInput) {
                // Legacy autocomplete logic (cycling)
                const parts = userInput.toLowerCase().split(' ').filter(p => p);
                if (parts.length > 0 && !userInput.endsWith(" ")) {
                    const lastPart = parts[parts.length - 1];
                    const allNames = [...(lastResponse.actionNames || []), ...(lastResponse.entityNames || [])];
                    const currentIndex = allNames.indexOf(lastPart);
                    
                    let nextIndex = -1;
                    if (currentIndex !== -1) {
                        nextIndex = (currentIndex + 1) % allNames.length;
                    } else {
                        nextIndex = allNames.findIndex(n => n.startsWith(lastPart));
                    }

                    if (nextIndex !== -1) {
                        parts[parts.length - 1] = allNames[nextIndex];
                        const newValue = parts.join(" ");
                        setUserInput(newValue);
                        updateGhostInput(newValue, lastResponse);
                    }
                }
            }
        } else if (e.key === 'ArrowUp') {
            if (commandHistory.length === 0) return;
            let newIndex = historyIndex;
            if (historyIndex === -1) {
                setTempInput(userInput);
            }

            if (historyIndex < commandHistory.length - 1) {
                newIndex++;
                setHistoryIndex(newIndex);
                const val = commandHistory[commandHistory.length - 1 - newIndex];
                setUserInput(val);
                updateGhostInput(val, lastResponse);
            }
        } else if (e.key === 'ArrowDown') {
            if (historyIndex > 0) {
                const newIndex = historyIndex - 1;
                setHistoryIndex(newIndex);
                const val = commandHistory[commandHistory.length - 1 - newIndex];
                setUserInput(val);
                updateGhostInput(val, lastResponse);
            } else if (historyIndex === 0) {
                setHistoryIndex(-1);
                setUserInput(tempInput);
                updateGhostInput(tempInput, lastResponse);
            }
        }
    };

    return (
        <div className="flex h-screen w-full">
            {/* Left column - 40% of screen */}

            <div className="w-2/5 m-auto bg-gray-800 p-4 overflow-y-auto border-r border-gray-700 flex flex-col">
                <h2 className="text-white text-xl font-bold mb-4">Game Info</h2>
                
                <div className="flex-1 overflow-y-auto mb-4 text-gray-300 font-mono space-y-1">
                    {terminalLines.map((line, i) => (
                        <div key={i} dangerouslySetInnerHTML={{ __html: line }} />
                    ))}
                </div>

                <div className="mt-auto">
                    <InputBox 
                        value={userInput} 
                        ghostValue={ghostInput}
                        onChange={handleInputChange} 
                        onSubmit={handleSubmit}
                        onKeyDown={handleKeyDown}
                    />
                </div>
                
            </div>
            
        </div>
    )
}
