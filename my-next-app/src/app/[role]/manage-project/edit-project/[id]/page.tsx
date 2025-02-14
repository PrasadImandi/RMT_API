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
import { cn } from "@/lib/utils";
import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from "@/components/ui/popover";
import { Calendar } from "@/components/ui/calendar";
import { CalendarIcon } from "lucide-react";
import { format } from "date-fns";
import { useParams, useRouter } from "next/navigation";
import api from "@/lib/axiosInstance";
import { useEffect, useState } from "react";
import { ProjectApi, projectFormSchema } from "@/services/api/projects";
import { useMutation, useQuery } from "@tanstack/react-query";

const projectManagers = [
  { id: 1, name: "John Smith" },
  { id: 2, name: "Sarah Johnson" },
  { id: 3, name: "Michael Chen" },
];

const relationshipManagers = [
  { id: 1, name: "Emma Wilson" },
  { id: 2, name: "David Brown" },
  { id: 3, name: "Lisa Rodriguez" },
];

const deliveryMotions = [
  { id: 1, name: "Hybrid" },
  { id: 2, name: "ITOC" },
  { id: 3, name: "InCountry" },
];

const supportTypes = [
  { id: 1, name: "Enterprise" },
  { id: 2, name: "End User" },
  { id: 3, name: "Hybrid" },
  { id: 4, name: "T&M" },
];

const segments = [
  { id: 1, name: "BFSI" },
  { id: 2, name: "MDI" },
  { id: 3, name: "GOVT&PS" },
  { id: 4, name: "IT" },
  { id: 5, name: "Logistic" },
];

const EditProject = () => {
  const params = useParams<{ id: string }>();
  const router = useRouter();

  const form = useForm({
    resolver: zodResolver(projectFormSchema),
    defaultValues: {
      isActive: true,
      name: "",
      projectCode: "",
      startDate: new Date(),
      endDate: new Date(),
      clientID: 0,
      pmid: 0,
      rmid: 0,
      deleiveryMotionID: 0,
      segmentID: 0,
      supportTypeID: 0,
    },
  });

  const { reset } = form;
  
  const { data: project, isLoading: isProjectLoading } = useQuery({
    queryKey: ["project", params.id],
    queryFn: async () => {
      const response = await api.get(`/Project/${params.id}`);
      const userData = response.data
      console.log(response.data)
      reset({
        name: userData?.name || "",
        startDate: userData?.startDate
          ? new Date(userData.startDate)
          : new Date(),
        endDate: userData?.endDate ? new Date(userData.endDate) : new Date(),
        projectCode: userData?.projectCode,
        pmid: userData?.pmid,
        rmid: userData?.rmid,
        deleiveryMotionID:userData?.deleiveryMotionID,
        supportTypeID:userData?.supportTypeID,
        segmentID:userData?.segmentID,
        clientID:userData?.clientID,
        isActive: userData?.isActive,
      });
      return response.data;
    },
    enabled: !!params.id, // only run if params.id is defined
  });


  const updateProject = useMutation({
    mutationFn: (values: z.infer<typeof projectFormSchema>) =>
          ProjectApi.updateProject(values, params.id),
    onSuccess: () => {
      form.reset();
      router.push("/admin/manage-project");
    },
  });

  const onSubmit = async (values: z.infer<typeof projectFormSchema>) => {
      console.log(values)
      const updatedProject = {
        ...(project || {}), // Fallback to an empty object if user is undefined
        name: values.name,
        startDate: values.startDate,
        endDate: values.endDate,
        projectCode: values.projectCode,
        pmid: values.pmid,
        rmid: values.rmid,
        deleiveryMotionID:values.deleiveryMotionID,
        supportTypeID:values.supportTypeID,
        segmentID:values.segmentID,
        clientID:values.clientID,
        isActive:  values.isActive ,
    };
      updateProject.mutate(updatedProject);
  };

  if (isProjectLoading) {
    return <div>Loading Project data...</div>;
  }

  const renderDropdown = (
    name: keyof z.infer<typeof projectFormSchema>,
    label: string,
    items: Array<{ id: number; name: string }>
  ) => (
    <FormField
      control={form.control}
      name={name}
      render={({ field }) => (
        <FormItem>
          <FormLabel>{label}</FormLabel>
          <Select
            onValueChange={(value) => field.onChange(Number(value))}
            value={field.value.toString()}
          >
            <FormControl>
              <SelectTrigger>
                <SelectValue placeholder={`Select ${label.toLowerCase()}`} />
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
      <h1 className="text-2xl mb-6">Add Project</h1>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="space-y-6 w-3/5"
        >
          {/* Active Status */}
          <FormField
            control={form.control}
            name="isActive"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Project Status</FormLabel>
                <Select
                  onValueChange={(value) => field.onChange(value === "true")}
                  value={field.value.toString()}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select project status" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="true">Active</SelectItem>
                    <SelectItem value="false">Inactive</SelectItem>
                  </SelectContent>
                </Select>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Project Name */}
          <FormField
            control={form.control}
            name="name"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Project Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter project name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Project Code */}
          <FormField
            control={form.control}
            name="projectCode"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Project Code</FormLabel>
                <FormControl>
                  <Input placeholder="Enter project code" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Dates */}
          <FormField
            control={form.control}
            name="startDate"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Start Date</FormLabel>
                <Popover>
                  <PopoverTrigger asChild>
                    <FormControl>
                      <Button
                        variant="outline"
                        className={cn(
                          "w-[240px] pl-3 text-left font-normal",
                          !field.value && "text-muted-foreground"
                        )}
                      >
                        {field.value
                          ? format(field.value, "PPP")
                          : "Pick a date"}
                        <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent className="w-auto p-0" align="start">
                    <Calendar
                      mode="single"
                      selected={field.value}
                      onSelect={field.onChange}
                      initialFocus
                    />
                  </PopoverContent>
                </Popover>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="endDate"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>End Date</FormLabel>
                <Popover>
                  <PopoverTrigger asChild>
                    <FormControl>
                      <Button
                        variant="outline"
                        className={cn(
                          "w-[240px] pl-3 text-left font-normal",
                          !field.value && "text-muted-foreground"
                        )}
                      >
                        {field.value
                          ? format(field.value, "PPP")
                          : "Pick a date"}
                        <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent className="w-auto p-0" align="start">
                    <Calendar
                      mode="single"
                      selected={field.value}
                      onSelect={field.onChange}
                      initialFocus
                    />
                  </PopoverContent>
                </Popover>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Dropdowns */}

          {renderDropdown("pmid", "Project Manager", projectManagers)}
          {renderDropdown("rmid", "Relationship Manager", relationshipManagers)}
          {renderDropdown(
            "deleiveryMotionID",
            "Delivery Motion",
            deliveryMotions
          )}
          {renderDropdown("segmentID", "Segment", segments)}
          {renderDropdown("supportTypeID", "Support Type", supportTypes)}

          <Button type="submit">Save Project</Button>
        </form>
      </Form>
    </div>
  );
};

export default EditProject;
