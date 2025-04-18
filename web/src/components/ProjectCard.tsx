import React, { useState } from 'react';
import { Project } from '../types';
import { ExternalLink, X } from 'lucide-react';

interface ProjectCardProps {
  project: Project;
}

const ProjectCard: React.FC<ProjectCardProps> = ({ project }) => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  console.log(project);
  return (
    <>
      <div className="bg-white rounded-lg shadow-md overflow-hidden">
        <img
          src={`/img/project/${project.img}`} // Updated image path
          alt={project.name}
          className="w-full h-48 object-cover"
        />
        <div className="p-4">
          <h3 className="text-xl font-semibold mb-2">{project.name}</h3>
          <button
            onClick={() => setIsModalOpen(true)}
            className="px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors w-full"
          >
            voir plus
          </button>
        </div>
      </div>

      {isModalOpen && (
        <div
          className="fixed inset-0 bg-black/50 flex items-center justify-center z-50"
          onClick={() => setIsModalOpen(false)} // Close modal on backdrop click
        >
          <div
            className="bg-white rounded-lg p-6 max-w-2xl w-full mx-4 max-h-[90vh] overflow-y-auto"
            onClick={(e) => e.stopPropagation()}
          >
            <div className="flex justify-between items-center mb-4">
              <h2 className="text-2xl font-bold">{project.name}</h2>
              <button
                onClick={() => setIsModalOpen(false)}
                className="p-2 hover:bg-gray-100 rounded-full"
              >
                <X size={24} />
              </button>
            </div>

            <img
              src={`/img/project/${project.img}`} // Updated image path
              alt={project.name}
              className="w-full h-64 object-cover rounded-lg mb-4"
            />
            {project.description.split('\n').map((line) => (
              <p
                className="mb-4"
                dangerouslySetInnerHTML={{ __html: line }}
              />
            ))}

            <div className="space-y-4">
              <div>
                <h3 className="font-semibold mb-2">Technologies Utilisées:</h3>
                <div className="flex flex-wrap gap-2">
                  {project.technos && project.technos.length > 0 ? (
                    project.technos.map((tech) => (
                      <span
                        key={tech.id}
                        className="px-3 py-1 bg-gray-100 rounded-full text-sm"
                      >
                        {tech.name}
                      </span>
                    ))
                  ) : (
                    <p>Aucune technologie utilisée.</p>
                  )}
                </div>
              </div>
              <div>
                {project.github ? (
                  <a
                    href={project.github}
                    target="_blank"
                    className="inline-flex items-center gap-2 px-4 py-2 bg-gray-100 rounded-lg hover:bg-gray-200 transition-colors"
                  >
                    <ExternalLink size={20} />
                    GitHub
                  </a>
                ) : (
                  <p>Pas de GitHub disponible.</p>
                )}
              </div>
              <div>
                <h3 className="font-semibold mb-2">Documentation:</h3>
                <div className="space-y-2">
                  {project.docs && project.docs.length > 0 ? (
                    project.docs.map((doc, index) => (
                      (doc.url.startsWith('http') || doc.url.startsWith('www')) ? (
                        <a
                          key={index}
                          href={doc.url}
                          target="_blank"
                          rel="noopener noreferrer"
                          className="block px-4 py-2 bg-gray-100 rounded-lg hover:bg-gray-200 transition-colors"
                        >
                          {doc.name}
                        </a>
                      ) : (
                        <a
                          key={index}
                          href={`/docs/${doc.url}`}
                          download={`/docs/${doc.url}`}
                          className="block px-4 py-2 bg-gray-100 rounded-lg hover:bg-gray-200 transition-colors"
                        >
                          {doc.name}
                        </a>
                      )
                    ))
                  ) : (
                    <p>Pas de documentation disponnible.</p>
                  )}
                </div>
              </div>

              {project.url && (
                <a
                  href={`/project/${project.url}/index.html`}
                  target="_blank"
                  rel="noopener noreferrer"
                  className="inline-flex items-center gap-2 px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
                >
                  <ExternalLink size={20} />
                  Voir le projet live
                </a>
              )}
            </div>
          </div>
        </div>
      )}
    </>
  );
}

export default ProjectCard;