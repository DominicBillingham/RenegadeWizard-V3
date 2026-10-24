import React from 'react';
import Tag from './Tag';
import type { LucideIcon } from 'lucide-react';

interface CreatureCardProps {
    name: string;
    description: string;
    health: number;
    tags: string[];
    intention: string;
    Icon: LucideIcon;
}

export default function CreatureCard({ name, description, health, tags, intention, Icon }: CreatureCardProps) {
    return (
        <div className="w-full bg-gray-800 rounded-lg p-4 shadow-lg border border-gray-700">
            <div className="flex justify-between items-start mb-2">
                <div className="flex flex-wrap items-center gap-2">
                    <h3 className="text-white text-lg font-bold">{name}</h3>
                    {tags.map(tag => (
                        <Tag key={tag} label={tag} />
                    ))}
                </div>
                <span className="bg-red-900 text-red-100 px-2 py-0.5 rounded text-sm font-mono whitespace-nowrap">
                    HP: {health}
                </span>
            </div>
            
            <p className="text-gray-300 text-sm mb-4">{description}</p>
            
            <div className="flex items-center text-yellow-400 bg-gray-900/50 p-2 rounded border border-yellow-900/30">
                <Icon size={18} className="mr-2" />
                <span className="text-xs font-semibold uppercase tracking-wider">{intention}</span>
            </div>
        </div>
    );
}
