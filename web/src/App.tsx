import { useEffect, useState } from 'react';
import Header from './components/Header';
import { Hero } from './components/Hero';
import TechnoCard from './components/TechnologyCard';
import ProjectCard from './components/ProjectCard';
import { Techno, Project } from './types';

function App() {
  const [technologies, setTechnologies] = useState<Techno[]>([]);
  const [projects, setProjects] = useState<Project[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const [techResponse, projectsResponse] = await Promise.all([
          fetch('http://100.74.153.114:5142/api/techno'),
          fetch('http://100.74.153.114:5142/api/project')
        ]);

        const techData = await techResponse.json();
        const projectsData = await projectsResponse.json();

        setTechnologies(techData);
        setProjects(projectsData);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="min-h-screen bg-gray-50">
      <Header />

      <main>
        <Hero />

        <section id="technologies" className="py-20 bg-white">
          <div className="container mx-auto px-6">
            <h2 className="text-3xl font-bold mb-12 text-center">Skills</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
              {technologies.map(tech => (
                <TechnoCard key={tech.id} techno={tech} />
              ))}
            </div>
          </div>
        </section>

        <section id="projets" className="py-20">
          <div className="container mx-auto px-6">
            <h2 className="text-3xl font-bold mb-12 text-center">Mes Projets</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
              {projects.map(project => (
                <ProjectCard key={project.id} project={project} />
              ))}
            </div>
          </div>
        </section>
      </main>

      <footer className="bg-gray-900 text-white py-8">
        <div className="container mx-auto px-6 text-center">
          <p>© {new Date().getFullYear()} Portfolio Milan JUINO.</p>
        </div>
      </footer>
    </div>
  );
}

export default App;