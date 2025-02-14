import api from "@/lib/axiosInstance";
import { z } from "zod";


export const resourceFormSchema = z.object({
    firstName: z.string().min(1, "First name is required."),
    lastName: z.string().min(1, "Last name is required."),
    emailID: z.string().email("Invalid email address."),
    mobileNumber: z.string().regex(/^\d{10}$/, "Phone number must be 10 digits."),
    clientID: z.string(),
    projectID: z.string(),
    pmid: z.string(),
    rmid: z.string(),
    supplierID: z.string(),
  });

export const ResourceApi = {
     fetchResources: async () => {
        const response = await api.get("/Resource");
        return response.data;
      },

      deactivateResources: async (id: string) => {
        await api.patch("/Resource", { id, isActive: false });
      },

      createResource:async (values: z.infer<typeof resourceFormSchema>) => {
        console.log(values)
        return await api.post("/Resource", values);
      },

      updateResource:async (values: z.infer<typeof resourceFormSchema>, id:string) => {
        return await api.put(`/Resource/${id}`, values);
      },

      fetchResource: async (id: number) => {
        const response = await api.get(`/Resource/${id}`);
        return response.data;
      },
      
}