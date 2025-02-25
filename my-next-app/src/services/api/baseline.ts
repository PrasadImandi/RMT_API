import api from "@/lib/axiosInstance";
import { z } from "zod";


export const baselineFormSchema = z.object({
    logo: z.string().min(1, "Logo is required."),
    project: z.string().min(1, "Project is required."),
    type: z.string().min(1, "Type is required."),
    domain: z.string().min(1, "Domain is required."),
    role: z.string().min(1, "Role is required."),
    level: z.string().min(1, "Level is required."),
    baseline: z.number().min(0, "Baseline must be a non-negative number."),
    domainNameAsPerCustomer: z.string().min(1, "Domain name as per customer is required."),
    notes: z.string().optional(),
  });

  export interface BaselineRow{
    id: number;
    logo: string;
    project: string;
    type: string;
    domain: string;
    role: string;
    level: string;
    baseline: number;
    domainNameAsPerCustomer: string;
    notes?: string;
    isActive: boolean;
  }
export const BaselineApi = {
     fetchBaselines: async () => {
        const response = await api.get("/ProjectBaseline");
        return response.data;
      },

      deactivateBaseline: async (id: number) => {
        await api.patch("/ProjectBaseline", { id, isActive: false });
      },

      createBaseline:async (values: z.infer<typeof baselineFormSchema>) => {
        console.log(values)
        return await api.post("/ProjectBaseline", values);
      },

      updateBaseline:async (values: z.infer<typeof baselineFormSchema>, id:string) => {
        return await api.put(`/ProjectBaseline/${id}`, values);
      },

      fetchBaseline: async (id: number) => {
        const response = await api.get(`/ProjectBaseline/${id}`);
        return response.data;
      },
      
}