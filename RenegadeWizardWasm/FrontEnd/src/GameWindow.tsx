import { useState, useEffect, useRef } from 'react';

export default function GameWindow() {
    
    const [userInput, setUserInput] = useState("");
    const [terminalLines, setTerminalLines] = useState<string[]>([]);
    const scrollRef = useRef<HTMLDivElement>(null);
    const typingSoundRef = useRef<HTMLAudioElement | null>(null);
    const enterSoundRef = useRef<HTMLAudioElement | null>(null);

    useEffect(() => {
        typingSoundRef.current = new Audio("/sound/typing.mp3");
        enterSoundRef.current = new Audio("/sound/enter.wav");
    }, []);

    useEffect(() => {
        if (scrollRef.current) {
            scrollRef.current.scrollTop = scrollRef.current.scrollHeight;
        }
    }, [terminalLines]);

    const playTypingSound = () => {
        if (typingSoundRef.current) {
            const sound = typingSoundRef.current.cloneNode() as HTMLAudioElement;
            // Shift pitch between 0.8 and 1.2
            sound.playbackRate = 0.8 + Math.random() * 0.4;
            sound.play().catch(e => console.error("Error playing typing sound:", e));
        }
    };

    const playEnterSound = () => {
        if (enterSoundRef.current) {
            const sound = enterSoundRef.current.cloneNode() as HTMLAudioElement;
            sound.play().catch(e => console.error("Error playing enter sound:", e));
        }
    };

    const handleSubmit = async () => {
        if (!userInput.trim()) return;

        playEnterSound();
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
        <div className="flex h-screen w-full bg-gray-100 justify-center">
            {/* Main column - anchored 30% from bottom */}
            <div className="w-2/5 flex flex-col relative h-full">
                
                {/* Upper Text Box - should occupy top 70% and float upwards */}
                <div 
                    ref={scrollRef}
                    className="flex-1 flex flex-col justify-end overflow-y-auto p-4 pt-10" 
                    style={{ height: '70vh' }}
                >
                    <div className="text-black font-mono space-y-2 text-xl">
                        {terminalLines.map((line, i) => (
                            <div key={i} dangerouslySetInnerHTML={{ __html: line }} />
                        ))}
                    </div>
                </div>

                {/* Thick Line Separator */}
                <div className="border-t-4 border-black w-full"></div>

                {/* Text Bar - Anchored at ~30% from bottom */}
                <div className="p-4">
                    <input
                        type="text"
                        value={userInput}
                        onChange={(e) => {
                            setUserInput(e.target.value);
                            playTypingSound();
                        }}
                        onKeyDown={(e) => {
                            if (e.key === 'Enter') {
                                handleSubmit();
                            }
                        }}
                        className="w-full bg-transparent text-black px-3 py-2 focus:outline-none text-xl"
                        placeholder="> Enter your command..."
                        autoFocus
                    />
                </div>
                
                {/* Spacer to push everything up to 30% from bottom */}
                <div style={{ height: '20vh' }}></div>
            </div>
        </div>
    )
}
