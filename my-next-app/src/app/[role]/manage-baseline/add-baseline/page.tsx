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
import { useRouter } from "next/navigation";
import api from "@/lib/axiosInstance";
import { dropdownApi } from "@/services/api/dropdown";
// Import the updated schema
import { BaselineApi, baselineFormSchema } from "@/services/api/baseline";
import { ClientApi } from "@/services/api/client";
import { ProjectApi } from "@/services/api/projects";

const AddBaseline = () => {
  const router = useRouter();
  const queryClient = useQueryClient();

  // Initialize react-hook-form with the new schema and default values.
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

  // Fetch dropdown data (update these API calls to your endpoints)
  const { data: logos = [] } = useQuery({
    queryKey: ["logos"],
    queryFn: ClientApi.fetchClients, // Should return an array like [{ id: "1", name: "Logo 1" }, ...]
  });

  const { data: projects = [] } = useQuery({
    queryKey: ["projects"],
    queryFn: ProjectApi.fetchProjects, // Should return an array like [{ id: "1", name: "Project 1" }, ...]
  });

  // For Domain, Role & Level, we assume they come from the same endpoint
  const { data: domain = [] } = useQuery({
    queryKey: ["domainRoles"],
    queryFn: dropdownApi.fetchDomian, // Returns array like [{ id: "1", name: "Option 1" }, ...]
  });

  const { data: domainroles = [] } = useQuery({
    queryKey: ["domainRoles"],
    queryFn: dropdownApi.fetchDomianROles, // Returns array like [{ id: "1", name: "Option 1" }, ...]
  });

  const { data: domainLevels = [] } = useQuery({
    queryKey: ["domainRoles"],
    queryFn: dropdownApi.fetchDomianelevels, // Returns array like [{ id: "1", name: "Option 1" }, ...]
  });

  // Static options for the Type field.
  const typeOptions = [
    { value: "HC", label: "HC" },
    { value: "3P", label: "3P" },
  ];

  // Mutation to create a new baseline entry.
  const createBaseline = useMutation({
    mutationFn: BaselineApi.createBaseline,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["baselines"] });
      form.reset();
      router.push("/admin/manage-baseline");
    },
  });

  const onSubmit = (values: z.infer<typeof baselineFormSchema>) => {
    console.log(values);
    const payload = {
      ...values,
      isActive:true
    }
    createBaseline.mutate(payload);
  };

  // Helper to render dropdown fields for string-based values.
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
            value={field.value  ? field.value.toString() : ""}
          >
            <FormControl>
              <SelectTrigger>
                <SelectValue placeholder={`Select ${label}`} />
              </SelectTrigger>
            </FormControl>
            <SelectContent>
              {items.map((item) => (
                <SelectItem key={item.id} value={item.id.toString()}>
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

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Add Baseline</h1>
      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6 w-3/5">
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

export default AddBaseline;
