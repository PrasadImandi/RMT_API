'use client';
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { format } from "date-fns";
import { useParams, useRouter } from "next/navigation";
import api from "@/lib/axiosInstance";
import { cn } from "@/lib/utils";

// UI Components
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
  Popover,
  PopoverTrigger,
  PopoverContent,
} from "@/components/ui/popover";
import { Calendar } from "@/components/ui/calendar";
import { CalendarIcon } from "lucide-react";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { useMutation, useQuery } from "@tanstack/react-query";
import { dropdownApi } from "@/services/api/dropdown";
import { SupplierApi } from "@/services/api/supplier";

// Define your supplier form schema
const formSchema = z.object({
  id: z.number().default(0),
  isActive: z.boolean().default(true),
  name: z.string().min(1, "Supplier name is required"),
  supplier_Code: z.string().min(1, "Supplier code is required"),
  sidDate: z.date({ required_error: "SID date is required" }),
  address: z.string().min(1, "Address is required"),
  stateID: z.number().min(1, "State is required"),
  gst: z.string().min(1, "GST ID is required"),
  pan: z.string().min(1, "PAN ID is required"),
  tan: z.string().min(1, "TAN ID is required"),
  stateName: z.string().min(1, "State name is required"),
  contactInformation: z.array(
    // (Assume your contactSchema is defined elsewhere)
    z.object({
      id: z.number().default(0),
      isActive: z.boolean().default(true),
      contactTypeID: z
        .number({ required_error: "Contact type is required" })
        .min(1, "Select a valid contact type"),
      name: z.string().min(1, "Name is required"),
      contactNumber: z.string().regex(/^\d{10}$/, "Invalid contact number"),
      contactEmail: z.string().email("Invalid email address"),
    })
  ).default([]),
});

const EditSupplier = () => {
  const params = useParams<{ id: string }>();
  const router = useRouter();

  // Fetch states list for the dropdown
  const { data: states = [] } = useQuery({
    queryKey:["states"], 
    queryFn:dropdownApi.fetchStates
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      id: 0,
      isActive: true,
      name: "",
      supplier_Code: "",
      sidDate: new Date(),
      address: "",
      stateID: states[0]?.id || 1,
      gst: "",
      pan: "",
      tan: "",
      stateName: states[0]?.name || "",
      contactInformation: [],
    },
  });

  const { reset } = form;

  const {data: supplier, isLoading: isSupplierLoading } = useQuery({
    queryKey: ["supplier", params.id],
    queryFn: async () => {
      const response = await api.get(`/Supplier/${params.id}`);
      console.log(response.data)
      const supplierData = response.data
      reset({
        id: supplierData.id,
        isActive: supplierData.isActive,
        name: supplierData.name,
        supplier_Code: supplierData.supplier_Code,
        sidDate: new Date(supplierData.sidDate),
        address: supplierData.address,
        stateID: supplierData.stateID,
        gst: supplierData.gst,
        pan: supplierData.pan,
        tan: supplierData.tan,
        stateName: supplierData.stateName, // May be empty if not provided
        contactInformation: supplierData.contactInformation || [],
      });
      return response.data;
    },
    enabled: !!params.id,

  })
 
  useEffect(() => {
    if (supplier && states.length > 0) {
      if (!supplier.stateName) {
        const selectedState = states.find((s:any) => s.id === supplier.stateID);
        if (selectedState) {
          form.setValue("stateName", selectedState.name);
        }
      }
    }
  }, [supplier, states, form]);

  const updateSupplier = useMutation({
    mutationFn: (values: z.infer<typeof formSchema>) =>
          SupplierApi.updateSupplier(values, params.id),
        onSuccess: () => {
          form.reset()
          router.push("/admin/manage-supplier");
        },
  })

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    console.log("Form values:", values);
      const updatedSupplier = {
        ...supplier,
        ...values,
      };
      updateSupplier.mutate(updatedSupplier)
  };


  if (isSupplierLoading) {
    return <div>Loading client data...</div>;
  }

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Edit Supplier</h1>
      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6 w-3/5">
          {/* Supplier Name */}
          <FormField
            control={form.control}
            name="name"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Supplier Name</FormLabel>
                <FormControl>
                  <Input placeholder="Enter supplier name" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Supplier Code */}
          <FormField
            control={form.control}
            name="supplier_Code"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Supplier Code</FormLabel>
                <FormControl>
                  <Input placeholder="Enter supplier code" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* SID Date */}
          <FormField
            control={form.control}
            name="sidDate"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>SID Date</FormLabel>
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
                        {field.value ? format(new Date(field.value), "PPP") : "Pick a date"}
                        <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent className="w-auto p-0" align="start">
                    <Calendar
                      mode="single"
                      selected={field.value ? new Date(field.value) : undefined}
                      onSelect={(date) => field.onChange(date)}
                      initialFocus
                    />
                  </PopoverContent>
                </Popover>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Address */}
          <FormField
            control={form.control}
            name="address"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Address</FormLabel>
                <FormControl>
                  <Input placeholder="Enter address" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* State Dropdown */}
          <FormField
            control={form.control}
            name="stateID"
            render={({ field }) => (
              <FormItem>
                <FormLabel>State</FormLabel>
                <FormControl>
                  <Select
                    onValueChange={(value) => {
                      const stateID = Number(value);
                      field.onChange(stateID);
                      const state = states.find((s:any) => s.id === stateID);
                      if (state) {
                        form.setValue("stateName", state.name);
                      }
                    }}
                    value={String(field.value)}
                  >
                    <SelectTrigger>
                      <SelectValue placeholder="Select state" />
                    </SelectTrigger>
                    <SelectContent>
                      {states.map((state: any) => (
                        <SelectItem key={state.id} value={String(state.id)}>
                          {state.name}
                        </SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* GST */}
          <FormField
            control={form.control}
            name="gst"
            render={({ field }) => (
              <FormItem>
                <FormLabel>GST</FormLabel>
                <FormControl>
                  <Input placeholder="Enter GST" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* PAN */}
          <FormField
            control={form.control}
            name="pan"
            render={({ field }) => (
              <FormItem>
                <FormLabel>PAN</FormLabel>
                <FormControl>
                  <Input placeholder="Enter PAN" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* TAN */}
          <FormField
            control={form.control}
            name="tan"
            render={({ field }) => (
              <FormItem>
                <FormLabel>TAN</FormLabel>
                <FormControl>
                  <Input placeholder="Enter TAN" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Contact Matrix and Add Contact functionality omitted for brevity */}

          <Button type="submit">Save</Button>
        </form>
      </Form>
    </div>
  );
};

export default EditSupplier;
