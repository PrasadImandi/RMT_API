import api from "@/lib/axiosInstance";
import { z } from "zod";


export const supplierContactSchema = z.object({
    id: z.number().default(0),
    isActive: z.boolean().default(true),
    contactTypeID: z
      .number({ required_error: "Contact type is required" })
      .min(1, "Select a valid contact type"),
    name: z.string().min(1, "Name is required"),
    contactNumber: z
      .string()
      .regex(/^\d{10}$/, "Invalid contact number"),
    contactEmail: z.string().email("Invalid email address"),
  });

export const supplierFormSchema = z.object({
  isActive: z.boolean().default(true),
  name: z.string().min(1, "Supplier name is required"),
  sidDate: z.date({ required_error: "SID date is required" }),
  address: z.string().min(1, "Address is required"),
  stateID: z.number().min(1, "State is required"),
  gst: z.string().min(1, "GST ID is required"),
  pan: z.string().min(1, "PAN ID is required"),
  tan: z.string().min(1, "TAN ID is required"),
  stateName: z.string().min(1, "State Name is required"),
  contactInformation: z
    .array(supplierContactSchema)
    .min(1, "At least one contact is required"),
});

export const SupplierApi = {
     fetchSuppliers: async () => {
        const response = await api.get("/Supplier");
        return response.data;
      },

      deactivateSuppliers: async (id: number) => {
        await api.patch("/Supplier", { id, isActive: false });
      },

      createSupplier:async (values: z.infer<typeof supplierFormSchema>) => {
        console.log(values)
        return await api.post("/Supplier", values);
      },

      updateSupplier:async (values: z.infer<typeof supplierFormSchema>, id:string) => {
        return await api.put(`/Supplier/${id}`, values);
      },

      fetchSupplier: async (id: string) => {
        const response = await api.get(`/Supplier/${id}`);
        return response.data;
      },
      
}