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
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Input } from "@/components/ui/input";
import { useEffect, useState } from "react";
import { cn } from "@/lib/utils";
import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from "@/components/ui/popover";
import { Calendar } from "@/components/ui/calendar";
import { CalendarIcon } from "lucide-react";
import { format } from "date-fns";
import api from "@/lib/axiosInstance";
import { useRouter } from "next/navigation";
import { ProjectApi, projectFormSchema } from "@/services/api/projects";
import { useMutation, useQuery } from "@tanstack/react-query";
import { ClientApi, ClientRow } from "@/services/api/client";

// Mock data for dropdowns
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

const AddProject = () => {
  const router = useRouter();
  const [isDialogOpen, setIsDialogOpen] = useState(false);

  const form = useForm<z.infer<typeof projectFormSchema>>({
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

  const { data: clients = [], refetch:clientfetch } = useQuery<ClientRow[]>({
    queryKey: ["clients"],
    queryFn: ClientApi.fetchClients,
  });


  const createProject = useMutation({
    mutationFn: ProjectApi.createProject,
    onSuccess: () => {
      form.reset();
      router.push("/admin/manage-project");
    },
  });

  const onSubmit = async (values: z.infer<typeof projectFormSchema>) => {
      const payload = {
        ...values,
        startDate: values.startDate,
        endDate: values.endDate
      };   
      console.log(payload)
      createProject.mutate(payload);
  };

  const createClient = async (clientName: string) => {
    try {
      await api.post("/Client", { clientName });
      clientfetch();
      setIsDialogOpen(false);
    } catch (error) {
      console.log("Error creating client", error);
    }
  };

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
        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6 w-3/5">
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
                        {field.value ? format(field.value, "PPP") : "Pick a date"}
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
                        {field.value ? format(field.value, "PPP") : "Pick a date"}
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
          <FormField
            control={form.control}
            name="clientID"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Logo</FormLabel>
                <div className="flex gap-2">
                  <Select
                    onValueChange={(value) => field.onChange(Number(value))}
                    value={field.value.toString()}
                  >
                    <FormControl>
                      <SelectTrigger>
                        <SelectValue placeholder="Select client" />
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
                  <Dialog open={isDialogOpen} onOpenChange={setIsDialogOpen}>
                    <DialogTrigger asChild>
                      <Button variant="outline">+ New</Button>
                    </DialogTrigger>
                    <DialogContent>
                      <DialogHeader>
                        <DialogTitle>Create New Logo</DialogTitle>
                      </DialogHeader>
                      <div className="space-y-4">
                        <Input
                          id="clientName"
                          placeholder="Logo name"
                        />
                        <Button
                          onClick={() => {
                            const name = (
                              document.getElementById("clientName") as HTMLInputElement
                            )?.value;
                            if (name) createClient(name);
                          }}
                        >
                          Create Logo
                        </Button>
                      </div>
                    </DialogContent>
                  </Dialog>
                </div>
                <FormMessage />
              </FormItem>
            )}
          />

          {renderDropdown("pmid", "Project Manager", projectManagers)}
          {renderDropdown("rmid", "Relationship Manager", relationshipManagers)}
          {renderDropdown("deleiveryMotionID", "Delivery Motion", deliveryMotions)}
          {renderDropdown("segmentID", "Segment", segments)}
          {renderDropdown("supportTypeID", "Support Type", supportTypes)}

          <Button type="submit">Save Project</Button>
        </form>
      </Form>
    </div>
  );
};

export default AddProject;