"use client";
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { format } from "date-fns";
import api from "@/lib/axiosInstance";
import { useRouter } from "next/navigation";
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
import { SupplierApi, supplierContactSchema, supplierFormSchema } from "@/services/api/supplier";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { dropdownApi } from "@/services/api/dropdown";

// Define a mapping for contact types
const contactTypes = [
  { id: 1, name: "HR" },
  { id: 2, name: "Escalation" },
  { id: 3, name: "Sales" },
  { id: 4, name: "Deals" },
  { id: 5, name: "SPOC" },
  { id: 6, name: "Sr Mgmt" },
];

export default function AddSupplier() {
  const router = useRouter();
  const [contactOpen, setContactOpen] = useState(false);
  const queryClient = useQueryClient();


  const form = useForm<z.infer<typeof supplierFormSchema>>({
    resolver: zodResolver(supplierFormSchema),
    defaultValues: {
      isActive: true,
      name: "",
      sidDate: new Date(),
      address: "",
      stateID:  1,
      gst: "",
      pan: "",
      tan: "",
      stateName: "",
      contactInformation: [],
    },
  });

  const { data: states = [] } = useQuery({
    queryKey:["states"], 
    queryFn:dropdownApi.fetchStates
  });

  const createSupplier = useMutation({
    mutationFn: SupplierApi.createSupplier,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["clients"] });
      form.reset();
      router.push("/admin/manage-supplier");
    },
  })

  const onSubmit = async (values: z.infer<typeof supplierFormSchema>) => {
    console.log("Form Values:", values);
    createSupplier.mutate(values)
  };


  

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Add Supplier</h1>
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
                  <Input {...field} placeholder="Enter supplier name" />
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

          {/* Address */}
          <FormField
            control={form.control}
            name="address"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Address</FormLabel>
                <FormControl>
                  <Input {...field} placeholder="Enter address" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* State (ID and Name) */}
          <FormField
            control={form.control}
            name="stateID"
            render={({ field }) => (
              <FormItem>
                <FormLabel>State</FormLabel>
                <FormControl>
                  <Select
                    onValueChange={(value) => {
                      // Convert the value to a number and update both stateID and stateName
                      const stateID = Number(value);
                      field.onChange(stateID);
                      const state:any = states.find((s:any) => s.id === stateID);
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
                      {states.map((state:any) => (
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

          {/* GST ID */}
          <FormField
            control={form.control}
            name="gst"
            render={({ field }) => (
              <FormItem>
                <FormLabel>GST ID</FormLabel>
                <FormControl>
                  <Input {...field} placeholder="Enter GST ID" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* PAN ID */}
          <FormField
            control={form.control}
            name="pan"
            render={({ field }) => (
              <FormItem>
                <FormLabel>PAN ID</FormLabel>
                <FormControl>
                  <Input {...field} placeholder="Enter PAN ID" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* TAN ID */}
          <FormField
            control={form.control}
            name="tan"
            render={({ field }) => (
              <FormItem>
                <FormLabel>TAN ID</FormLabel>
                <FormControl>
                  <Input {...field} placeholder="Enter TAN ID" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* Contact Matrix */}
          <div className="space-y-4">
            <FormLabel>Contact Matrix</FormLabel>
            <div className="space-y-2">
              {form.watch("contactInformation").map((contact, index) => (
                <div key={index} className="p-4 border rounded">
                  <p>
                    Type:{" "}
                    {
                      contactTypes.find(
                        (ct) => ct.id === contact.contactTypeID
                      )?.name
                    }
                  </p>
                  <p>Name: {contact.name}</p>
                  <p>Number: {contact.contactNumber}</p>
                  <p>Email: {contact.contactEmail}</p>
                </div>
              ))}

              <Dialog open={contactOpen} onOpenChange={setContactOpen}>
                <DialogTrigger asChild>
                  <Button variant="outline" type="button">
                    + Add Contact
                  </Button>
                </DialogTrigger>
                <DialogContent>
                  <DialogHeader>
                    <DialogTitle>Add New Contact</DialogTitle>
                  </DialogHeader>
                  <ContactForm onSubmit={(contact) => {
                    // Append new contact to the list
                    const currentContacts = form.getValues("contactInformation");
                    form.setValue("contactInformation", [
                      ...currentContacts,
                      contact,
                    ]);
                    setContactOpen(false);
                  }} />
                </DialogContent>
              </Dialog>
            </div>
            <FormMessage>
              {form.formState.errors.contactInformation?.message}
            </FormMessage>
          </div>

          <Button type="submit">Submit</Button>
        </form>
      </Form>
    </div>
  );
}

// -----------------
// Contact Form Component
// -----------------

function ContactForm({ onSubmit }: { onSubmit: (values: z.infer<typeof supplierContactSchema>) => void }) {
  const contactForm = useForm<z.infer<typeof supplierContactSchema>>({
    resolver: zodResolver(supplierContactSchema),
    defaultValues: {
      id: 0,
      isActive: true,
      contactTypeID: contactTypes[0].id,
      name: "",
      contactNumber: "",
      contactEmail: "",
    },
  });

  const handleSubmit = (values: z.infer<typeof supplierContactSchema>) => {
    onSubmit(values);
    contactForm.reset();
  };

  return (
    <Form {...contactForm}>
      <form onSubmit={contactForm.handleSubmit(handleSubmit)} className="space-y-4">
        {/* Contact Type */}
        <FormField
          control={contactForm.control}
          name="contactTypeID"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Contact Type</FormLabel>
              <Select
                onValueChange={(value) => field.onChange(Number(value))}
                value={String(field.value)}
              >
                <SelectTrigger>
                  <SelectValue placeholder="Select contact type" />
                </SelectTrigger>
                <SelectContent>
                  {contactTypes.map((ct) => (
                    <SelectItem key={ct.id} value={String(ct.id)}>
                      {ct.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Name */}
        <FormField
          control={contactForm.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Name</FormLabel>
              <FormControl>
                <Input {...field} placeholder="Enter name" />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Contact Number */}
        <FormField
          control={contactForm.control}
          name="contactNumber"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Contact Number</FormLabel>
              <FormControl>
                <Input {...field} placeholder="Enter contact number" />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Contact Email */}
        <FormField
          control={contactForm.control}
          name="contactEmail"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input {...field} placeholder="Enter email" />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <Button type="submit">Add Contact</Button>
      </form>
    </Form>
  );
}
