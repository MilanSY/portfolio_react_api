import React from 'react';
import { Github, FileText, Mail } from 'lucide-react';

export const Hero: React.FC = () => {
  return (
    <section id="accueil" className="min-h-screen pt-20 flex items-center">
      <div className="container mx-auto px-6">
        <div className="grid md:grid-cols-2 gap-12 items-center">
          <div className="space-y-6">
            <h1 className="text-4xl md:text-6xl font-bold">
              Milan JUINO
            </h1>
            <p className="text-lg text-gray-600">
              Développeur web passionné, je prépare actuellement mon BTS SIO au Lycée Saint Vincent de Senlis. Je suis spécialisé dans la création d'applications web ou api en utilisant des technologies variées.</p>
            <div className="flex gap-4">
                <a
                href="https://github.com/MilanSY"
                target="_blank"
                rel="noopener noreferrer"
                className="flex items-center gap-2 px-4 py-2 bg-gray-900 text-white rounded-lg hover:bg-gray-800 transition-colors"
                >
                <Github size={20} />
                </a>
                <a
                href="https://www.linkedin.com/in/milan-juino-376636286/"
                target="_blank"
                rel="noopener noreferrer"
                className="flex items-center gap-2 px-4 py-2 bg-blue-700 text-white rounded-lg hover:bg-blue-800 transition-colors"
                >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 24 24"
                  fill="currentColor"
                  className="w-5 h-5"
                >
                  <path d="M19 0h-14c-2.761 0-5 2.239-5 5v14c0 2.761 2.239 5 5 5h14c2.761 0 5-2.239 5-5v-14c0-2.761-2.239-5-5-5zm-11 19h-3v-10h3v10zm-1.5-11.268c-.966 0-1.75-.784-1.75-1.75s.784-1.75 1.75-1.75 1.75.784 1.75 1.75-.784 1.75-1.75 1.75zm13.5 11.268h-3v-5.5c0-1.378-1.122-2.5-2.5-2.5s-2.5 1.122-2.5 2.5v5.5h-3v-10h3v1.5c.878-1.314 2.5-1.5 3.5-1.5 2.485 0 4.5 2.015 4.5 4.5v5.5z" />
                </svg>
                </a>
                <a
                href="./assets/docs/CVMilanJUINO.pdf"
                download
                className="flex items-center gap-2 px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
                >
                <FileText size={20} />
                Mon CV
                </a>
                <a
                href="mailto:milan.juino@lyceestvincent.fr"
                className="flex items-center gap-2 px-4 py-2 bg-green-600 text-white rounded-lg hover:bg-green-700 transition-colors"
                >
                <Mail size={20} />
                Mail
                </a>
            </div>
          </div>
          <div className="relative">
            <img
              src="./assets/img/milanjuino.png"
              alt="Milan JUINO"
              className="rounded-full w-72 h-72 object-cover mx-auto shadow-2xl"
            />
            <div className="absolute inset-0 rounded-full bg-blue-500/10"></div>
          </div>
        </div>
      </div>
    </section>
  );
}
