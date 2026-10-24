import React from 'react';
import Tag from './Tag';

interface ItemCardProps {
    name: string;
    description: string;
    tags: string[];
}

export default function ItemCard({ name, description, tags }: ItemCardProps) {
    return (
        <div className="bg-gray-700 rounded-lg p-3 shadow-md border border-gray-600 h-full flex flex-col">
            <div className="flex flex-wrap items-center gap-2 mb-2">
                <h4 className="text-white text-md font-bold">{name}</h4>
                {tags.map(tag => (
                    <Tag key={tag} label={tag} />
                ))}
            </div>
            <p className="text-gray-400 text-xs flex-grow">{description}</p>
        </div>
    );
}
