import React from 'react';
import { Techno } from '../types';

interface TechnologyCardProps {
  technology: Techno;
}

const TechnologyCard: React.FC<TechnologyCardProps> = ({ technology }) => {
  return (
    <div className="bg-white rounded-lg shadow-md p-4 flex items-center gap-4">
      <img src={technology.img} alt={technology.name} className="w-12 h-12 object-contain" />
      <div>
        <h3 className="font-semibold">{technology.name}</h3>
        <p className="text-sm text-gray-500">
          {new Date(technology.date).toLocaleDateString()}
        </p>
      </div>
    </div>
  );
}

export default TechnologyCard;