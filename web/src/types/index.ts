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
  techno: Techno[];
  docs: string[];
}

export interface docs {
  id: string;
  name: string;
  url: string;
}

export interface SocialLink {
  name: string;
  url: string;
  icon: string;
}