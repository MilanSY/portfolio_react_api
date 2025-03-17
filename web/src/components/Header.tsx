import React, { useState } from 'react';
import LoginModal from './LoginModal';
import { useAuth } from '../contexts/AuthContext';
import { Link, useLocation } from 'react-router-dom';

const Header: React.FC = () => {
  const [isLoginOpen, setIsLoginOpen] = useState(false);
  const { isAuthenticated, logout } = useAuth();
  const location = useLocation();
  const isAdmin = location.pathname.startsWith('/admin');

  return (
    <>
      <header className="fixed top-0 left-0 right-0 bg-white/80 backdrop-blur-sm z-50 border-b">
        <nav className="container mx-auto px-6 py-4">
          <div className="flex items-center justify-between">
            <h1 className="text-xl font-bold">Milan JUINO</h1>
            <div className="flex items-center gap-6">
              {isAdmin ? (
                <>
                  <Link to="/admin/technology" className="hover:text-blue-600 transition-colors">Add Technology</Link>
                  <Link to="/admin/project" className="hover:text-blue-600 transition-colors">Add Project</Link>
                  <Link to="/admin/doc" className="hover:text-blue-600 transition-colors">Add Doc</Link>
                  <button
                    onClick={logout}
                    className="px-4 py-2 bg-red-600 text-white rounded-lg hover:bg-red-700 transition-colors"
                  >
                    Logout
                  </button>
                </>
              ) : (
                <>
                  <a href="#home" className="hover:text-blue-600 transition-colors">Home</a>
                  <a href="#skills" className="hover:text-blue-600 transition-colors">Skills</a>
                  <a href="#projects" className="hover:text-blue-600 transition-colors">Projects</a>
                  {!isAuthenticated ? (
                    <button
                      onClick={() => setIsLoginOpen(true)}
                      className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
                    >
                      Login
                    </button>
                  ) : (
                    <Link
                      to="/admin/technology"
                      className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
                    >
                      Admin
                    </Link>
                  )}
                </>
              )}
            </div>
          </div>
        </nav>
      </header>
      <LoginModal isOpen={isLoginOpen} onClose={() => setIsLoginOpen(false)} />
    </>
  );
}

export default Header;