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
import { Input } from "@/components/ui/input";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { useRouter, useParams } from "next/navigation";
import api from "@/lib/axiosInstance";
import { dropdownApi } from "@/services/api/dropdown";
import { BaselineApi, baselineFormSchema } from "@/services/api/baseline";
import { ClientApi } from "@/services/api/client";
import { ProjectApi } from "@/services/api/projects";

const EditBaseline = () => {
  const router = useRouter();
  const queryClient = useQueryClient();
  const params = useParams<{ id: string }>();

  // Initialize the form with the baseline schema and default values.
  const form = useForm<z.infer<typeof baselineFormSchema>>({
    resolver: zodResolver(baselineFormSchema),
    defaultValues: {
      logoID: "",
      projectID: "",
      type: "",
      domainID: "",
      roleID: "",
      levelID: "",
      baseline: 0,
      domainNameAsPerCustomer: "",
      notes: "",
    },
  });

  // Fetch dropdown data for logos, projects, and domain values.
  const { data: logos = [] } = useQuery({
    queryKey: ["logos"],
    queryFn: ClientApi.fetchClients, // Expected to return an array like [{ id: "1", name: "Logo 1" }, ...]
  });

  const { data: projects = [] } = useQuery({
    queryKey: ["projects"],
    queryFn: ProjectApi.fetchProjects, // Expected to return an array like [{ id: "1", name: "Project 1" }, ...]
  });

  const { data: domain = [] } = useQuery({
    queryKey: ["domain"],
    queryFn: dropdownApi.fetchDomian, // Expected to return an array like [{ id: "1", name: "Option 1" }, ...]
  });

  const { data: domainroles = [] } = useQuery({
    queryKey: ["domainroles"],
    queryFn: dropdownApi.fetchDomianROles, // Expected to return an array like [{ id: "1", name: "Option 1" }, ...]
  });

  const { data: domainLevels = [] } = useQuery({
    queryKey: ["domainLevels"],
    queryFn: dropdownApi.fetchDomianelevels, // Expected to return an array like [{ id: "1", name: "Option 1" }, ...]
  });

  // Static options for the Type field.
  const typeOptions = [
    { value: "HC", label: "HC" },
    { value: "3P", label: "3P" },
  ];

  // Fetch the current baseline data and reset the form with its values.
  const { data: baselineData, isLoading } = useQuery({
    queryKey: ["baseline", params.id],
    queryFn: async () => {
      const response = await api.get(`/baseline/${params.id}`);
      form.reset({
        logoID: response.data?.logo || "",
        projectID: response.data?.project || "",
        type: response.data?.type || "",
        domainID: response.data?.domain || "",
        roleID: response.data?.role || "",
        levelID: response.data?.level || "",
        baseline: response.data?.baseline || 0,
        domainNameAsPerCustomer: response.data?.domainNameAsPerCustomer || "",
        notes: response.data?.notes || "",
      });
      return response.data;
    },
    enabled: !!params.id,
  });

  // Mutation for updating the baseline.
  const updateBaseline = useMutation({
    mutationFn: (values: z.infer<typeof baselineFormSchema>) =>
      BaselineApi.updateBaseline(values, params.id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["baselines"] });
      form.reset();
      router.push("/admin/manage-baseline");
    },
  });

  const onSubmit = (values: z.infer<typeof baselineFormSchema>) => {
    updateBaseline.mutate(values);
  };

  // Helper to render dropdown fields.
  const renderDropdown = (
    name: keyof z.infer<typeof baselineFormSchema>,
    label: string,
    items: Array<{ id: string; name: string }>
  ) => (
    <FormField
      control={form.control}
      name={name}
      render={({ field }) => (
        <FormItem>
          <FormLabel>{label}</FormLabel>
          <Select
            onValueChange={(value) => field.onChange(value)}
            value={field.value}
          >
            <FormControl>
              <SelectTrigger>
                <SelectValue placeholder={`Select ${label}`} />
              </SelectTrigger>
            </FormControl>
            <SelectContent>
              {items.map((item) => (
                <SelectItem key={item.id} value={item.id}>
                  {item.name}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>
          <FormMessage />
        </FormItem>
      )}
    />
  );

  if (isLoading) {
    return <div>Loading baseline data...</div>;
  }

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Edit Baseline</h1>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="space-y-6 w-3/5"
        >
          {/* Logo Dropdown */}
          {renderDropdown("logoID", "Logo *", logos)}

          {/* Project Dropdown */}
          {renderDropdown("projectID", "Project *", projects)}

          {/* Type Dropdown (static options) */}
          <FormField
            control={form.control}
            name="type"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Type *</FormLabel>
                <Select
                  onValueChange={(value) => field.onChange(value)}
                  value={field.value}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select Type" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    {typeOptions.map((option) => (
                      <SelectItem key={option.value} value={option.value}>
                        {option.label}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Domain Dropdown */}
          {renderDropdown("domainID", "Domain *", domain)}

          {/* Role Dropdown */}
          {renderDropdown("roleID", "Role *", domainroles)}

          {/* Level Dropdown */}
          {renderDropdown("levelID", "Level *", domainLevels)}

          {/* Baseline Number Input */}
          <FormField
            control={form.control}
            name="baseline"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Baseline *</FormLabel>
                <FormControl>
                  <Input
                    type="number"
                    placeholder="Enter baseline"
                    value={field.value}
                    onChange={(e) => field.onChange(Number(e.target.value))}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Domain Name as per Customer Input */}
          <FormField
            control={form.control}
            name="domainNameAsPerCustomer"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Domain Name as per Customer *</FormLabel>
                <FormControl>
                  <Input
                    placeholder="Enter domain name as per customer"
                    {...field}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Notes Text Input (optional) */}
          <FormField
            control={form.control}
            name="notes"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Notes</FormLabel>
                <FormControl>
                  <Input placeholder="Enter notes" {...field} />
                </FormControl>
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

export default EditBaseline;
