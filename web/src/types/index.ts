export interface Techno {
  id: string;
  img: string;
  name: string;
  date: string;
  description: string;
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
  projectId: string;
}

export interface SocialLink {
  name: string;
  url: string;
  icon: string;
}

export interface AuthResponse {
  success: boolean;
  message: string;
  token?: string;
}