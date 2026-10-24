interface CreatureCardProps {
    name: string;
    description: string;
}

export default function CreatureCard({name, description}: CreatureCardProps) {
    return (
        <div className="w-full bg-gray-800 rounded-lg p-4 shadow-lg">
            <h3 className="text-white text-lg font-bold mb-2">{name}</h3>
            <p className="text-gray-300 text-sm">{description}</p>
        </div>
    );
}
