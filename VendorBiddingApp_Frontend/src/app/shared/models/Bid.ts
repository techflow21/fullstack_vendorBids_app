import { Project } from "./Project";

export interface Bid {
    id: string;
    amount: number;
    projectId: string;
    project: Project
    submittedAt: Date;
  }