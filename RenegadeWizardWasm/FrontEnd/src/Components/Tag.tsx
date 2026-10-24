import React from 'react';

interface TagProps {
    label: string;
}

export default function Tag({ label }: TagProps) {
    return (
        <span className="inline-block bg-blue-600 text-white text-[10px] px-1.5 py-0.5 rounded-full whitespace-nowrap">
            {label}
        </span>
    );
}
