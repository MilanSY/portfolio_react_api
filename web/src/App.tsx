import React, { useEffect, useState } from 'react';
import Header from './components/Header';
import Hero from './components/Hero';
import TechnologyCard from './components/TechnologyCard';
import ProjectCard from './components/ProjectCard';
import { Techno, Project } from './types';

function App() {
  const [technologies, setTechnologies] = useState<Techno[]>([]);
  const [projects, setProjects] = useState<Project[]>([]);

  useEffect(() => {
    // Replace these URLs with your actual API endpoints
    const fetchData = async () => {
      try {
        const [techResponse, projectsResponse] = await Promise.all([
          fetch('your-tech-api-endpoint'),
          fetch('your-projects-api-endpoint')
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

        <section id="skills" className="py-20 bg-white">
          <div className="container mx-auto px-6">
            <h2 className="text-3xl font-bold mb-12 text-center">Technologies & Skills</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
              {technologies.map(tech => (
                <TechnologyCard key={tech.id} technology={tech} />
              ))}
            </div>
          </div>
        </section>

        <section id="projects" className="py-20">
          <div className="container mx-auto px-6">
            <h2 className="text-3xl font-bold mb-12 text-center">My Projects</h2>
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
          <p>© {new Date().getFullYear()} Milan JUINO. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
}

export default App;