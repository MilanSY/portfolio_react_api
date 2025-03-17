import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Header from './components/Header';
import TechnologyForm from './components/forms/TechnoForm';
import ProjectForm from './components/forms/ProjectForm';
import DocForm from './components/forms/DocForm';
import { AuthProvider } from './contexts/AuthContext';
import ProtectedRoute from './components/ProtectedRoute';
import Portfolio from './components/Portfolio';

function App() {
  return (
    <Router>
      <AuthProvider>
        <div className="min-h-screen bg-gray-50">
          <Header />

          <Routes>
            <Route path="/" element={<Portfolio />} />
            <Route
              path="/admin/technology"
              element={
                <ProtectedRoute>
                  <TechnologyForm />
                </ProtectedRoute>
              }
            />
            <Route
              path="/admin/project"
              element={
                <ProtectedRoute>
                  <ProjectForm />
                </ProtectedRoute>
              }
            />
            <Route
              path="/admin/doc"
              element={
                <ProtectedRoute>
                  <DocForm />
                </ProtectedRoute>
              }
            />
          </Routes>
        </div>
      </AuthProvider>
    </Router>
  );
}

export default App;