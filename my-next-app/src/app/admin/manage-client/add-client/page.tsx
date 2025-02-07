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
import { useEffect, useState } from "react";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Popover, PopoverTrigger, PopoverContent } from "@/components/ui/popover";
import { Calendar } from "@/components/ui/calendar";
import { CalendarIcon } from "lucide-react";
import { format } from "date-fns";
import api from "@/lib/axiosInstance";
import { useRouter } from "next/navigation";
import { cn } from "@/lib/utils";

// Define the form schema using Zod
const formSchema = z.object({
  name: z.string().min(1, "Logo Name is required"),
  shortName: z.string().min(1, "Short Name is required"),
  startDate: z.date({ required_error: "Start Date is required" }),
  endDate: z.date({ required_error: "End Date is required" }),
  regionID: z.number({ required_error: "Region is required" }),
  stateID: z.number({ required_error: "State is required" }),
  locationID: z.string(),
  pincodeID: z.number({ required_error: "Pincode is required" }),
  address: z.string().optional(),
  spocName: z.string().optional(),
  spocContactNumber: z.string().optional(),
  spocEmail: z.string().optional(),
  notes: z.string().optional(),
  isActive: z.boolean(),
});

const AddClient = () => {
  const router = useRouter();

  // States for dropdown options (assumed structure: { id: number, name: string }[])
  const [regions, setRegions] = useState<Array<{ id: number; name: string }>>([]);
  const [states, setStates] = useState<Array<{ id: number; name: string }>>([]);
  const [pincodes, setPincodes] = useState<Array<{ id: number; name: string }>>([]);

  // Initialize react-hook-form
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      name: "",
      shortName: "",
      startDate: new Date(),
      endDate: new Date(),
      regionID: 0,
      stateID: 0,
      locationID: "1",
      pincodeID: 1,
      address: "",
      spocName: "",
      spocContactNumber: "",
      spocEmail: "",
      notes: "",
      isActive: true,
    },
  });

  // Fetch dropdown data from APIs
  useEffect(() => {
    const fetchDropdownData = async () => {
      try {
        const regionsRes = await api.get("/DropDown/regions");
        setRegions(regionsRes.data);
        const statesRes = await api.get("/DropDown/states");
        setStates(statesRes.data);
        const pincodesRes = await api.get("/DropDown/pincodes");
        setPincodes(pincodesRes.data);
      } catch (error) {
        console.error("Error fetching dropdown data", error);
      }
    };
    fetchDropdownData();
  }, []);

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    console.log(values)
    try {
     
      console.log("Payload:", values);
      // Replace '/your-endpoint' with your actual API endpoint
      await api.post("/Client", values);
      form.reset();
      router.push("/admin/manage-client"); // Change this route as needed
    } catch (error) {
      console.error("Error submitting form", error);
    }
  };

  // Helper to render a dropdown field
  const renderDropdown = (
    name: keyof z.infer<typeof formSchema>,
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
            value={field.value ? field.value.toString() : ""}
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
      <h1 className="text-2xl mb-6">Add Entity</h1>
      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6 w-3/5">
          {/* Logo Name */}
          <FormField
            control={form.control}
            name="name"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Logo Name *</FormLabel>
                <FormControl>
                  <Input placeholder="Enter logo name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Short Name */}
          <FormField
            control={form.control}
            name="shortName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Short Name *</FormLabel>
                <FormControl>
                  <Input placeholder="Enter short name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Start Date */}
          <FormField
            control={form.control}
            name="startDate"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Start Date *</FormLabel>
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

          {/* End Date */}
          <FormField
            control={form.control}
            name="endDate"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>End Date *</FormLabel>
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

          {/* Region Dropdown */}
          {renderDropdown("regionID", "Region *", regions)}

          {/* State Dropdown */}
          {renderDropdown("stateID", "State *", states)}

          {/* Location Input */}
          <FormField
            control={form.control}
            name="locationID"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Location *</FormLabel>
                <FormControl>
                  <Input  placeholder="Enter location" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Pincode Dropdown */}
          {renderDropdown("pincodeID", "Pincode *", pincodes)}

          {/* Address (Long Text) */}
          <FormField
            control={form.control}
            name="address"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Address</FormLabel>
                <FormControl>
                  <Input  placeholder="Enter address" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* SPOC Name */}
          <FormField
            control={form.control}
            name="spocName"
            render={({ field }) => (
              <FormItem>
                <FormLabel>SPOC Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter SPOC name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* SPOC Contact Number */}
          <FormField
            control={form.control}
            name="spocContactNumber"
            render={({ field }) => (
              <FormItem>
                <FormLabel>SPOC Contact Number</FormLabel>
                <FormControl>
                  <Input placeholder="Enter SPOC contact number" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* SPOC Email ID */}
          <FormField
            control={form.control}
            name="spocEmail"
            render={({ field }) => (
              <FormItem>
                <FormLabel>SPOC Email ID</FormLabel>
                <FormControl>
                  <Input placeholder="Enter SPOC email" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Notes (Long Text) */}
          <FormField
            control={form.control}
            name="notes"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Notes</FormLabel>
                <FormControl>
                  <Input  placeholder="Enter notes" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Status Dropdown */}
          <FormField
            control={form.control}
            name="isActive"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Status *</FormLabel>
                <Select
                  onValueChange={(value) => field.onChange(value === "true")}
                  value={field.value.toString()}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select status" />
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

          <Button type="submit">Save</Button>
        </form>
      </Form>
    </div>
  );
};

export default AddClient;
