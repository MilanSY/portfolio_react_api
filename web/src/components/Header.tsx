import React from 'react';

const Header: React.FC = () => {
  return (
    <header className="fixed top-0 left-0 right-0 bg-white/80 backdrop-blur-sm z-50 border-b">
      <nav className="container mx-auto px-6 py-4">
        <div className="flex items-center justify-between">
          <h1 className="text-xl font-bold">Milan JUINO</h1>
          <div className="flex items-center gap-6">
            <a href="#home" className="hover:text-blue-600 transition-colors">Home</a>
            <a href="#skills" className="hover:text-blue-600 transition-colors">Skills</a>
            <a href="#projects" className="hover:text-blue-600 transition-colors">Projets</a>
          </div>
        </div>
      </nav>
    </header>
  );
}

export default Header;