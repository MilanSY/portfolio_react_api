import React from 'react';
import { Github, FileText, Mail } from 'lucide-react';

const Hero: React.FC = () => {
  return (
    <section id="home" className="min-h-screen pt-20 flex items-center">
      <div className="container mx-auto px-6">
        <div className="grid md:grid-cols-2 gap-12 items-center">
          <div className="space-y-6">
            <h1 className="text-4xl md:text-6xl font-bold">
              Hi, I'm Milan JUINO
            </h1>
            <p className="text-lg text-gray-600">
              A passionate web developer currently pursuing my BTS SIO. I specialize in creating modern web applications using cutting-edge technologies.
            </p>
            <div className="flex gap-4">
              <a
                href="https://github.com/MilanSY"
                target="_blank"
                rel="noopener noreferrer"
                className="flex items-center gap-2 px-4 py-2 bg-gray-900 text-white rounded-lg hover:bg-gray-800 transition-colors"
              >
                <Github size={20} />
                GitHub
              </a>
              <a
                href="/resume.pdf"
                target="_blank"
                className="flex items-center gap-2 px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
              >
                <FileText size={20} />
                Mon CV
              </a>
              <a
                href="mailto:your.email@example.com"
                className="flex items-center gap-2 px-4 py-2 bg-green-600 text-white rounded-lg hover:bg-green-700 transition-colors"
              >
                <Mail size={20} />
                Contact
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

export default Hero;