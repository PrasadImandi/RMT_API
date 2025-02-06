export interface Resource {
  id: string;
  name: string;
  role: string;
  skills: string[];
  imageUrl: string;
  availability: boolean;
  currentProject?: string;
}

export interface Project {
  id: string;
  name: string;
  description: string;
  startDate: string;
  endDate: string;
  resources: Resource[];
}

export interface Shift {
  id: string;
  resourceId: string;
  projectId: string;
  startTime: string;
  endTime: string;
  type: 'morning' | 'afternoon' | 'night';
  date: string;
}

export interface Holiday {
  phid: string;
  name: string;
  phDate: string;
  phDescription: string;
  isPublic: boolean;
}