export interface Techno {
  id: string;
  img: string;
  name: string;
  date: string;
}

export interface Project {
  id: string;
  name: string;
  url: string;
  img: string;
  description: string;
  github: string;
  technos: Techno[];
  docs: doc[];
}

export interface doc {
  id: string;
  name: string;
  url: string;
  projectrId: string;
}

export interface SocialLink {
  name: string;
  url: string;
  icon: string;
}