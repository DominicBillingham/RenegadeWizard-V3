import React from 'react';
import {Send} from 'lucide-react';

interface InputBoxProps {
    placeholder?: string;
    value: string;
    ghostValue?: string;
    onChange: (value: string) => void;
    onSubmit: () => void;
    onKeyDown?: (e: React.KeyboardEvent<HTMLInputElement>) => void;
}

export default function InputBox({placeholder = "Enter your command...", value, ghostValue = "", onChange, onSubmit, onKeyDown}: InputBoxProps) {
    const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
        if (e.key === 'Enter') {
            onSubmit();
        }
        if (onKeyDown) {
            onKeyDown(e);
        }
    };

    return (
        <div className="bg-gray-800 border-t border-gray-700 p-4">
            <div className="flex gap-2 w-full relative">
                <div className="flex-1 relative">
                    {ghostValue && (
                        <div className="absolute inset-0 px-4 py-2 text-gray-500 pointer-events-none whitespace-pre">
                            {ghostValue}
                        </div>
                    )}
                    <input
                        type="text"
                        value={value}
                        onChange={(e) => onChange(e.target.value)}
                        onKeyDown={handleKeyDown}
                        placeholder={placeholder}
                        className="w-full bg-gray-900 text-white px-4 py-2 rounded border border-gray-700 focus:outline-none focus:border-blue-500 relative z-10 bg-transparent"
                    />
                </div>
                <button
                    onClick={onSubmit}
                    className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded flex items-center gap-2 transition-colors shrink-0"
                >
                    <Send size={18}/>
                    Send
                </button>
            </div>
        </div>
    );
}