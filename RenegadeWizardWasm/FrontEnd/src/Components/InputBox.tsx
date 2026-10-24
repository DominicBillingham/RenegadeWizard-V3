import React from 'react';
import {Send} from 'lucide-react';

interface InputBoxProps {
    placeholder?: string;
    value: string;
    onChange: (value: string) => void;
    onSubmit: () => void;
}

export default function InputBox({placeholder = "Enter your command...", value, onChange, onSubmit}: InputBoxProps) {
    const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
        if (e.key === 'Enter') {
            onSubmit();
        }
    };

    return (
        <div className="bg-gray-800 border-t border-gray-700 p-4">
            <div className="flex gap-2 w-full">
                <input
                    type="text"
                    value={value}
                    onChange={(e) => onChange(e.target.value)}
                    onKeyDown={handleKeyDown}
                    placeholder={placeholder}
                    className="flex-1 bg-gray-900 text-white px-4 py-2 rounded border border-gray-700 focus:outline-none focus:border-blue-500"
                />
                <button
                    onClick={onSubmit}
                    className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded flex items-center gap-2 transition-colors"
                >
                    <Send size={18}/>
                    Send
                </button>
            </div>
        </div>
    );
}