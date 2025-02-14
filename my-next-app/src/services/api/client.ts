import api from "@/lib/axiosInstance";
import { z } from "zod";

export interface ClientRow {
  id: number;
  clientCode: string;
  name: string;
  startDate: string;
  endDate: string;
  isActive: boolean;
  address: string;
  stateName: string;
  regionName: string;
  notes: string;
}

export const clientFormSchema = z.object({
  name: z.string().min(1, "Logo Name is required"),
  shortName: z.string().min(1, "Short Name is required"),
  startDate: z.date({ required_error: "Start Date is required" }),
  endDate: z.date({ required_error: "End Date is required" }),
  regionID: z.number({ required_error: "Region is required" }),
  stateID: z.number({ required_error: "State is required" }),
  locationID: z.string(),
  pincodeID: z.number({ required_error: "Pincode is required" }),
  address: z.string().optional(),
  spocName: z.string().optional(),
  spocContactNumber: z.string().optional(),
  spocEmail: z.string().optional(),
  notes: z.string().optional(),
  isActive: z.boolean(),
});

export const ClientApi = {
     fetchClients: async () => {
        const response = await api.get("/Client");
        return response.data;
      },

      deactivateClients: async (id: number) => {
        await api.patch("/Client", { id, isActive: false });
      },

      createClient:async (values: z.infer<typeof clientFormSchema>) => {
        console.log(values)
        return await api.post("/Client", values);
      },

      updateClient:async (values: z.infer<typeof clientFormSchema>, id:string) => {
        return await api.put(`/Client/${id}`, values);
      },


      //make sure to add fetchclient(singular)
}