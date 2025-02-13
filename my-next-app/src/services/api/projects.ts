import api from "@/lib/axiosInstance";
import { z } from "zod";


export interface ProjectType {
  id: number;
  projectCode: string;
  startDate: string;
  endDate: string;
  isActive: boolean;
  name?: string | null;
  pmName?: string | null;
  rmName?: string | null;
}

export const projectFormSchema = z.object({
    isActive: z.boolean(),
    name: z.string().min(6, "Project name must be at least 6 characters"),
    projectCode: z.string().min(1, "Project code is required"),
    startDate: z.date({ required_error: "Start date is required" }),
    endDate: z.date({ required_error: "End date is required" }),
    clientID: z.number(),
    pmid: z.number(),
    rmid: z.number(),
    deleiveryMotionID: z.number(),
    segmentID: z.number(),
    supportTypeID: z.number(),
  });

export const ProjectApi = {
     fetchProjects: async () => {
        const response = await api.get("/Project");
        return response.data;
      },

      deactivateProjects: async (id: number) => {
        await api.patch("/Project", { id, isActive: false });
      },

      createProject:async (values: z.infer<typeof projectFormSchema>) => {
        console.log(values)
        return await api.post("/Project", values);
      },

      updateProject:async (values: z.infer<typeof projectFormSchema>, id:string) => {
        return await api.put(`/Project/${id}`, values);
      },

      fetchProject: async (id: string) => {
        const response = await api.get(`/Project/${id}`);
        return response.data;
      },
      
}