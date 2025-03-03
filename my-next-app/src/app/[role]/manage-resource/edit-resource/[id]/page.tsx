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
import { ResourceApi, resourceFormSchema } from "@/services/api/resource";
import { ClientRow, ClientApi } from "@/services/api/client";
import { ProjectType, ProjectApi, projectFormSchema } from "@/services/api/projects";
import { useMutation, useQuery } from "@tanstack/react-query";

// Define a type for the project
interface Project {
  id: number;
  projectCode: string;
  name?: string | null;
}


const EditResource = () => {
  const params = useParams<{ id: string }>();
  const router = useRouter();

  const form = useForm({
    resolver: zodResolver(resourceFormSchema),
    defaultValues: {
      firstName: "",
      lastName: "",
      emailID: "",
      mobileNumber: "",
      clientID: "1",
      projectID: "1",
      pmid: "1",
      rmid: "1",
      supplierID: "1",
    },
  });

  const { reset } = form;

  // Fetch current resource details
  const { data: resource, isLoading: isProjectLoading } = useQuery({
    queryKey: ["resource", params.id],
    queryFn: async () => {
      const response = await api.get(`/Resource/${params.id}`);
      const userData = response.data
      console.log(response.data)
      reset({
        firstName: userData.firstName,
        lastName: userData.lastName,
        emailID: userData.emailID,
        mobileNumber: userData.mobileNumber,
        clientID: userData.clientID.toString(),
        projectID: userData.projectID.toString(),
        pmid: userData.projectManager,
        rmid: userData.relationshipManager,
        supplierID: userData.supplierID,
      });
      return response.data;
    },
    enabled: !!params.id, // only run if params.id is defined
  });

  // Fetch projects from the API and populate the dropdown
  const { data: clients = [] } = useQuery<ClientRow[]>({
    queryKey: ["clients"],
    queryFn: ClientApi.fetchClients,
  });

  const { data: projects = [] } = useQuery<ProjectType[]>({
      queryKey: ["projects"],
      queryFn: ProjectApi.fetchProjects,
    });


    const updateResource = useMutation({
      mutationFn: (values: z.infer<typeof resourceFormSchema>) =>
            ResourceApi.updateResource(values, params.id),
      onSuccess: () => {
        form.reset();
        router.push("/admin/manage-resource");
      },
    });

  const onSubmit = async (values: z.infer<typeof resourceFormSchema>) => {
    const updatedResource = {
      ...(resource || {}),
      ...values,
      isActive: true,
    };
    console.log(updatedResource);
    updateResource.mutate(updatedResource)
  };

  
  if (isProjectLoading) {
    return <div>Loading resource data...</div>;
  }
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
            name="emailID"
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
            name="mobileNumber"
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
                <FormLabel>Account Name (Logo)</FormLabel>
                <Select
                  onValueChange={field.onChange}
                  defaultValue={field.value}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select an account name" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                  {clients.map((client) => (
                        <SelectItem key={client.id} value={client.id.toString()}>
                          {client.name}
                        </SelectItem>
                      ))}
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
