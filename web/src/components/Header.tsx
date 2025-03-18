import React from 'react';

const Header: React.FC = () => {
  return (
    <header className="fixed top-0 left-0 right-0 bg-white/80 backdrop-blur-sm z-50 border-b">
      <nav className="container mx-auto px-6 py-4">
        <div className="flex items-center justify-between">
          <h1 className="text-xl font-bold">Milan JUINO</h1>
          <div className="flex items-center gap-6">
            <a href="#accueil" className="hover:text-blue-600 transition-colors">Accueil</a>
            <a href="#technologies" className="hover:text-blue-600 transition-colors">Technologies</a>
            <a href="#projets" className="hover:text-blue-600 transition-colors">Projets</a>
          </div>
        </div>
      </nav>
    </header>
  );
}

export default Header;