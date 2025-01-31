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
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
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
import { Textarea } from "@/components/ui/textarea";
import { useRouter } from "next/navigation";

// Mock data for dropdowns
const projectManagers = [
  { id: 1, name: "John Smith", role: "Senior Project Manager" },
  { id: 2, name: "Sarah Johnson", role: "Technical Project Lead" },
  { id: 3, name: "Michael Chen", role: "Agile Project Coordinator" },
];

const relationshipManagers = [
  { id: 1, name: "Emma Wilson", role: "Client Relations Director" },
  { id: 2, name: "David Brown", role: "Account Management Lead" },
  { id: 3, name: "Lisa Rodriguez", role: "Customer Success Manager" },
];

const deliveryMotions = ["Hybrid", "ITOC", "InCountry"];
const supportTypes = ["Enterprise", "End User", "Hybrid", "T&M"];
const segments = ["BFSI", "MDI", "GOVT&PS", "IT", "Logistic"];

// Updated form schema
const formSchema = z.object({
  projectName: z.string().min(6, {
    message: "Project name must be at least 6 characters.",
  }),
  startDate: z.date({
    required_error: "Start date is required.",
  }),
  endDate: z.date({
    required_error: "End date is required.",
  }),
  status: z.string({
    required_error: "Please select project status.",
  }),
  clientID: z.number(),
  projectManager: z.string({
    required_error: "Please select a project manager.",
  }),
  relationshipManager: z.string({
    required_error: "Please select a relationship manager.",
  }),
  deliveryMotion: z.string({
    required_error: "Please select delivery motion.",
  }),
  supportType: z.string({
    required_error: "Please select support type.",
  }),
  segment: z.string({
    required_error: "Please select segment.",
  }),
});

const AddProject = () => {
  const router = useRouter();
  const [clientId, setClientId] = useState<Number>();
  const [isDialogOpen, setIsDialogOpen] = useState(false);
  const [clients, setClients] = useState<any[]>([]);

  const form = useForm({
    resolver: zodResolver(formSchema),
    defaultValues: {
      projectName: "",
      startDate: new Date(),
      endDate: new Date(),
      status: "Not Started",
      clientID: 1,
      projectManager: "",
      relationshipManager: "",
      deliveryMotion: "",
      supportType: "",
      segment: "",
    },
  });

  const fetchClients = async () => {
    try {
      const response = await api.get("/Client");
      setClients(response.data);
    } catch (error) {
      console.error("Error fetching clients:", error);
    }
  };

  useEffect(() => {
    fetchClients();
  }, []);

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    console.log(values)
    // try {
    //   const res = await api.post("/Project", values);
    //   form.reset();
    //   router.push('/admin/manage-project');
    // } catch (error) {
    //   console.log("Error registering project", error);
    // }
  };


  const createClient =async (clientName: string, description: string) => {

    const newClient = {
      clientName : clientName,
    };

    try {
      const res = await api.post("/Client", newClient);
      console.log(res);
    } catch (error) {
      console.log("error registering client", error);
    }
    fetchClients();
    console.log("New client created:", newClient);
    setIsDialogOpen(false); // Close dialog when client is created
  };

  // Add the new dropdown fields to the form
  const renderDropdown = (name: string, label: string, items: any[], description?: string) => (
    <FormField
      control={form.control}
      name={name as any}
      render={({ field }) => (
        <FormItem>
          <FormLabel>{label}</FormLabel>
          <div className="flex items-center space-x-2">
          <Select onValueChange={field.onChange} defaultValue={field.value}>
            <FormControl>
              <SelectTrigger>
                <SelectValue placeholder={`Select ${label.toLowerCase()}`} />
              </SelectTrigger>
            </FormControl>
            <SelectContent>
              {items.map((item) => (
                <SelectItem key={item.id || item} value={item.id ? item.id.toString() : item}>
                  {item.name || item}
                  {item.role && ` (${item.role})`}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>
          {name === "client" ? <Dialog open={isDialogOpen} onOpenChange={setIsDialogOpen}>
          <DialogTrigger asChild>
            <Button variant="default">Create Client</Button>
          </DialogTrigger>
          <DialogContent>
            <DialogHeader>
              <DialogTitle>Create a New Client</DialogTitle>
            </DialogHeader>
            <div className="flex flex-col gap-y-4">
              <Input
                placeholder="Enter client name"
                id="clientName"
                className="mb-2"
              />
              <Textarea
                placeholder="Enter client description"
                id="clientDescription"
                className="h-28"
              />
            </div>
            <DialogFooter>
              <Button
                type="submit"
                onClick={() => {
                  const name = (
                    document.getElementById("clientName") as HTMLInputElement
                  )?.value;
                  const description = (
                    document.getElementById(
                      "clientDescription"
                    ) as HTMLTextAreaElement
                  )?.value;
                  if (name) createClient(name, description);
                }}
              >
                Save
              </Button>
            </DialogFooter>
          </DialogContent>
        </Dialog>
        
: null}
</div>
          {description && <FormDescription>{description}</FormDescription>}
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
          {/* Existing fields */}
          <FormField
            control={form.control}
            name="projectName"
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

          {/* Date fields */}
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
                        variant={"outline"}
                        className={cn(
                          "w-[240px] pl-3 text-left font-normal",
                          !field.value && "text-muted-foreground"
                        )}
                      >
                        {field.value ? (
                          format(field.value, "PPP")
                        ) : (
                          <span>Pick a date</span>
                        )}
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
                <FormDescription>
                  Select a starting date for the project.
                </FormDescription>
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
                        variant={"outline"}
                        className={cn(
                          "w-[240px] pl-3 text-left font-normal",
                          !field.value && "text-muted-foreground"
                        )}
                      >
                        {field.value ? (
                          format(field.value, "PPP")
                        ) : (
                          <span>Pick a date</span>
                        )}
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
                <FormDescription>
                  Select a starting date for the project.
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* New dropdown fields */}
          {renderDropdown("projectManager", "Project Manager", projectManagers, "Select primary project lead")}
          {renderDropdown("relationshipManager", "Relationship Manager", relationshipManagers, "Select client relationship manager")}
          {renderDropdown("deliveryMotion", "Delivery Motion", deliveryMotions, "Select project delivery model")}
          {renderDropdown("supportType", "Support Type", supportTypes, "Select type of support required")}
          {renderDropdown("segment", "Segment", segments, "Select industry segment")}
          {renderDropdown("status", "Status", ["active", "inactive"], "Select status")}
          {renderDropdown("client", "Client", clients, "Select Client")}

          {/* Existing status and client fields */}

          <Button type="submit">Save Project</Button>
        </form>
      </Form>
    </div>
  );
};

export default AddProject;