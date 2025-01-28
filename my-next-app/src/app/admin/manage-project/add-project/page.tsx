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

// Define the form schema
const formSchema = z.object({
  projectName: z.string().min(6, {
    message: "Username must be at least 6 characters.",
  }),
  startDate: z.date({
    required_error: "A date of birth is required.",
  }),
  endDate: z.date({
    required_error: "A date of birth is required.",
  }),
  status: z.string({
    required_error: "Please select an email to display.",
  }),
  clientID: z.number(),
});

const AddProject = () => {
  // Initialize react-hook-form
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
    },
  });

  const fetchClients = async () => {
    try {
      const response = await api.get("/Client");
      console.log(response.data);
      setClients(response.data);
    } catch (error) {
      console.error("Error fetching current user:", error);
    }
  };

  useEffect(() => {
    fetchClients();
  },[])

  // Handle form submission
  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    console.log("Form Submitted", values);
    try {
      const res = await api.post("/Project", values);
      console.log(res);
      form.reset();
      router.push('/admin/manage-project')
    } catch (error) {
      console.log("error registering Project", error);
    }
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

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Add Project</h1>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="space-y-6 w-3/5"
        >
          {/* Username Field */}
          <FormField
            control={form.control}
            name="projectName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Project Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter your Project Name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          {/* Password Field */}
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

          <FormField
            control={form.control}
            name="status"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Status</FormLabel>
                <Select
                  onValueChange={field.onChange}
                  defaultValue={field.value}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a status" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="Active">Active</SelectItem>
                    <SelectItem value="Inactive">Inactive</SelectItem>
                  </SelectContent>
                </Select>
                <FormDescription>
                  Select the status of the project{" "}
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

<FormField
  control={form.control}
  name="clientID"
  render={({ field }) => (
    <FormItem>
      <FormLabel>Client</FormLabel>
      <div className="flex items-center space-x-2">
        <Select
          onValueChange={(value) => field.onChange(Number(value))}
          defaultValue={field.value?.toString()}
        >
          <FormControl>
            <SelectTrigger>
              <SelectValue placeholder="Select a Client" />
            </SelectTrigger>
          </FormControl>
          <SelectContent>
            {clients.map((client) => (
              <SelectItem
                key={client.clientID}
                value={client.clientID.toString()}
              >
                {client.clientName}
              </SelectItem>
            ))}
          </SelectContent>
        </Select>
        <Dialog open={isDialogOpen} onOpenChange={setIsDialogOpen}>
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
      </div>
      <FormDescription>
        Select the client for the project or create a new one if necessary.
      </FormDescription>
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

export default AddProject;
