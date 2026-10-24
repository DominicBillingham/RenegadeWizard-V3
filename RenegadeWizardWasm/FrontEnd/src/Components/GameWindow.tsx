import CreatureCard from './CreatureCard';
import ItemCard from './ItemCard';
import { Sword, Shield, Zap, Flame, Snowflake, Ghost } from 'lucide-react';

export default function GameWindow() {
    return (
        <div className="flex h-screen w-full">
            {/* Left column - 40% of screen */}
            <div className="w-2/5 bg-gray-800 p-4 overflow-y-auto border-r border-gray-700">
                <h2 className="text-white text-xl font-bold mb-4">Game Info</h2>
            </div>

            {/* Right section - 60% of screen */}
            <div className="w-3/5 bg-gray-900 p-4 overflow-y-auto">
                
                <div className="space-y-4">
                    <CreatureCard
                        name="Fire Dragon"
                        description="A mighty dragon that breathes flames and guards ancient treasure."
                        health={120}
                        tags={["Creature", "Elite", "Fire"]}
                        intention="Inferno"
                        Icon={Flame}
                    />
                    <CreatureCard
                        name="Shadow Wolf"
                        description="A stealthy predator that lurks in the darkness of the forest."
                        health={45}
                        tags={["Creature", "Stealth"]}
                        intention="Ambush"
                        Icon={Ghost}
                    />
                    <CreatureCard
                        name="Ice Golem"
                        description="A massive construct made of ice and stone, slow but incredibly powerful."
                        health={80}
                        tags={["Creature", "Construct"]}
                        intention="Freeze"
                        Icon={Snowflake}
                    />
                </div>

                <div className="mt-8">
                    <div className="grid grid-cols-3 gap-4">
                        <ItemCard
                            name="Health Potion"
                            description="Restores 20 health points when consumed."
                            tags={["Item", "Consumable"]}
                        />
                        <ItemCard
                            name="Iron Shield"
                            description="Increases defense by 5 points."
                            tags={["Item", "Equipment"]}
                        />
                        <ItemCard
                            name="Magic Wand"
                            description="Used to cast powerful spells."
                            tags={["Item", "Weapon"]}
                        />
                    </div>
                </div>
            </div>
        </div>
    )
}
