"use client";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Input } from "@/components/ui/input";
import api from "@/lib/axiosInstance";
import { useParams, useRouter } from "next/navigation";
import { useEffect, useState } from "react";

const formSchema = z.object({
  fullName: z
    .string()
    .min(2, { message: "Full Name must be at least 2 characters." }),
  email: z.string().email({ message: "Please enter a valid email address." }),
  role: z.enum(["admin", "pm", "user", "supplier"], {
    required_error: "Please select a role.",
  }),
  status: z.enum(["active", "inactive"], {
    required_error: "Please select a status.",
  }),
});

const roleMap: Record<string, number> = {
  admin: 1,
  pm: 2,
  user: 3,
  supplier: 4,
};

const EditUser = () => {
  const router = useRouter();
  const params = useParams<{ id: string }>();
  const [user, setUser] = useState<any>();

  const form = useForm({
    resolver: zodResolver(formSchema),
    defaultValues: {
      fullName: "",
      email: "",
      role: "user",
      status: "active",
    },
  });
  const { reset } = form;

  useEffect(() => {
    const fetchCurrentUser = async () => {
      try {
        const response = await api.get(`/User/${params.id}`);
        const userData = response.data;
        setUser(userData);
        console.log(userData.status);
        // Update the form values once the user data is fetched
        reset({
          fullName: userData?.fullName || "",
          email: userData?.email || "",
          role: userData?.roleID || "",
          status: userData?.isActive ? "Active" : "Inactive", // Dynamically set status
        });
      } catch (error) {
        console.error("Error fetching current user:", error);
      }
    };

    if (params?.id) fetchCurrentUser();
  }, [params?.id, reset]);

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    console.log("Form Submitted", values);
    const updatedUser = {
      ...(user || {}), // Fallback to an empty object if user is undefined
      fullName: values.fullName,
      email: values.email,
      role: values.role,
      roleID: roleMap[values.role], // Map role to roleID
      isActive: values.status === "active", // Map status to isActive
    };

    try {
      const res = await api.put(`/User/${params.id}`, updatedUser);
      console.log(res.data);
      form.reset();
      router.push("/admin/manage-user");
    } catch (error) {
      console.error("Error submitting form", error);
    }
  };

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Create User</h1>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="space-y-6 w-3/5"
        >
          {/* Full Name Field */}
          <FormField
            control={form.control}
            name="fullName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Full Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter full name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          {/* Email Field */}
          <FormField
            control={form.control}
            name="email"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Email</FormLabel>
                <FormControl>
                  <Input placeholder="Enter email" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          {/* Role Field */}
          <FormField
            control={form.control}
            name="role"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Role</FormLabel>
                <Select
                  onValueChange={field.onChange}
                  value={field.value} // Use the field value dynamically updated by `reset`
                  defaultValue={user?.status || ""}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a role" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="admin">Admin</SelectItem>
                    <SelectItem value="pm">Project Manager</SelectItem>
                    <SelectItem value="user">User</SelectItem>
                    <SelectItem value="supplier">Supplier</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />
          {/* Status Field */}
          <FormField
            control={form.control}
            name="status"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Status</FormLabel>
                <Select
                  onValueChange={field.onChange}
                  value={field.value} // Use the field value dynamically updated by `reset`
                  defaultValue={user?.status || ""}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a status" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="active">Active</SelectItem>
                    <SelectItem value="inactive">Inactive</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />
          {/* Submit Button */}
          <Button type="submit">Create User</Button>
        </form>
      </Form>
    </div>
  );
};

export default EditUser;
