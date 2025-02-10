"use client";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormDescription,
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

// Define a type for the project
interface Project {
  id: number;
  projectCode: string;
  name?: string | null;
}

const formSchema = z.object({
  firstName: z.string().min(1, "First name is required."),
  lastName: z.string().min(1, "Last name is required."),
  email: z.string().email("Invalid email address."),
  phone: z.string().regex(/^\d{10}$/, "Phone number must be 10 digits."),
  clientID: z.string(),
  projectID: z.string(),
  pmid: z.string(),
  rmid: z.string(),
  supplierID: z.string(),
});

const EditResource = () => {
  const params = useParams<{ id: string }>();
  const [user, setUser] = useState<any>();
  const [projects, setProjects] = useState<Project[]>([]);
  const router = useRouter();

  const form = useForm({
    resolver: zodResolver(formSchema),
    defaultValues: {
      firstName: "",
      lastName: "",
      email: "",
      phone: "",
      clientID: "0",
      projectID: "0",
      pmid: "0",
      rmid: "0",
      supplierID: "0",
    },
  });

  const { reset } = form;

  // Fetch current resource details
  useEffect(() => {
    const fetchCurrentUser = async () => {
      try {
        const response = await api.get(`/resource/${params.id}`);
        const userData = response.data;
        console.log(userData);
        setUser(userData);
        reset({
          firstName: userData.firstName,
          lastName: userData.lastName,
          email: userData.emailID,
          phone: userData.mobileNumber,
          clientID: userData.clientID,
          projectID: userData.project,
          pmid: userData.projectManager,
          rmid: userData.relationshipManager,
          supplierID: userData.supplierID,
        });
      } catch (error) {
        console.error("Error fetching current user:", error);
      }
    };
    if (params?.id) fetchCurrentUser();
  }, [params?.id, reset]);

  // Fetch projects from the API and populate the dropdown
  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const response = await api.get("/Project");
        setProjects(response.data);
      } catch (error) {
        console.error("Error fetching projects:", error);
      }
    };
    fetchProjects();
  }, []);

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    const updatedUser = {
      ...(user || {}),
      ...values,
      isActive: true,
    };
    console.log(updatedUser);
    try {
      const res = await api.put(`/Resource/${params.id}`, updatedUser);
      console.log(res.data);
      router.push("/admin/manage-resource");
    } catch (error) {
      console.error("Error submitting form", error);
    }
  };

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Edit Resource</h1>
      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6 w-3/5">
          {/* First Name Field */}
          <FormField
            control={form.control}
            name="firstName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>First Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter first name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Last Name Field */}
          <FormField
            control={form.control}
            name="lastName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Last Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter last name" {...field} />
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

          {/* Phone Field */}
          <FormField
            control={form.control}
            name="phone"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Phone</FormLabel>
                <FormControl>
                  <Input placeholder="Enter phone number" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Account Name (Client) */}
          <FormField
            control={form.control}
            name="clientID"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Account Name (Client)</FormLabel>
                <Select onValueChange={field.onChange} defaultValue={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select an account name" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="1">Client A</SelectItem>
                    <SelectItem value="2">Client B</SelectItem>
                    <SelectItem value="3">Client C</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Project Dropdown (Populated from API) */}
          <FormField
            control={form.control}
            name="projectID"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Project</FormLabel>
                <Select onValueChange={field.onChange} defaultValue={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a project" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    {projects.length > 0 ? (
                      projects.map((project) => (
                        <SelectItem
                          key={project.id}
                          value={project.id.toString()}
                        >
                          {project.name || project.projectCode}
                        </SelectItem>
                      ))
                    ) : (
                      <SelectItem value="0">No Projects Available</SelectItem>
                    )}
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Project Manager */}
          <FormField
            control={form.control}
            name="pmid"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Project Manager</FormLabel>
                <Select onValueChange={field.onChange} defaultValue={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a project manager" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="1">Manager A</SelectItem>
                    <SelectItem value="2">Manager B</SelectItem>
                    <SelectItem value="3">Manager C</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Relationship Manager */}
          <FormField
            control={form.control}
            name="rmid"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Relationship Manager</FormLabel>
                <Select onValueChange={field.onChange} defaultValue={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a relationship manager" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="1">RM A</SelectItem>
                    <SelectItem value="2">RM B</SelectItem>
                    <SelectItem value="3">RM C</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Supplier */}
          <FormField
            control={form.control}
            name="supplierID"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Supplier</FormLabel>
                <Select onValueChange={field.onChange} defaultValue={field.value}>
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a supplier" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="1">Supplier A</SelectItem>
                    <SelectItem value="2">Supplier B</SelectItem>
                    <SelectItem value="3">Supplier C</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />
          <Button type="submit">Save</Button>
        </form>
      </Form>
    </div>
  );
};

export default EditResource;
