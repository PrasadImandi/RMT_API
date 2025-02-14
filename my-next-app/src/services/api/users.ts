import api from "@/lib/axiosInstance";
import { z } from "zod";


export const userFormSchema = z.object({
    firstName: z.string().min(2, { message: "First Name must be at least 2 characters." }),
    lastName: z.string().min(2, { message: "Last Name must be at least 2 characters." }),
    username: z.string().min(2, { message: "Username must be at least 2 characters." }),
    email: z.string().email({ message: "Please enter a valid email address." }),
    roleID: z.number(),
    isActive: z.boolean(),
  });

export const UsersApi = {
     fetchUsers: async () => {
        const response = await api.get("/User");
        return response.data;
      },

      deactivateUser: async (id: number) => {
        await api.patch("/User", { id, isActive: false });
      },

      createUser:async (values: z.infer<typeof userFormSchema>) => {
        console.log(values)
        return await api.post("/User", values);
      },

      updateUser:async (values: z.infer<typeof userFormSchema>, id:string) => {
        return await api.put(`/User`, values);
      },


      //make sure to add fetchuser(singular)
}