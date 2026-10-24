import CreatureCard from './CreatureCard';

export default function GameWindow() {
    return (
        <div className="flex h-screen w-full">
            {/* Left column - 40% of screen */}
            <div className="w-2/5 bg-gray-800 p-4 overflow-y-auto">
                <h2 className="text-white text-xl font-bold mb-4">Left Panel</h2>
                <p className="text-gray-300">This column takes up 40% of the screen width.</p>
            </div>

            {/* Right section - 60% of screen */}
            <div className="w-3/5 bg-gray-900 p-4 overflow-y-auto">
                
                <div className="mt-6 space-y-4">
                    <CreatureCard
                        name="Fire Dragon"
                        description="A mighty dragon that breathes flames and guards ancient treasure."
                    />
                    <CreatureCard
                        name="Shadow Wolf"
                        description="A stealthy predator that lurks in the darkness of the forest."
                    />
                    <CreatureCard
                        name="Ice Golem"
                        description="A massive construct made of ice and stone, slow but incredibly powerful."
                    />
                </div>
            </div>
            
            
            
            
        </div>
    )
}
