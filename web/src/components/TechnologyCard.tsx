import React from 'react';
import { Techno } from '../types';

interface TechnologyCardProps {
  techno: Techno;
}

const TechnoCard: React.FC<TechnologyCardProps> = ({ techno }) => {
  return (
    <div className="bg-white rounded-lg shadow-md p-4 flex items-center gap-4">
    
      <img src={`assets/img/techno/${techno.img}`} alt={techno.name} className="w-12 h-12 object-contain" />
      <div>
        <h3 className="font-semibold">{techno.name}</h3>
        <p className="text-sm text-gray-500">
          {new Date(techno.date).toLocaleDateString()}
        </p>
      </div>
    </div>
  );
}

export default TechnoCard;