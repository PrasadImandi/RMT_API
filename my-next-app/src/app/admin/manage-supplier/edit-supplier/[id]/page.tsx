"use client";
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

// ------------------------------------------------------
// Mappings for States and Contact Types
// ------------------------------------------------------
const statesList = [
  { id: 1, name: "Andhra Pradesh" },
  { id: 2, name: "Arunachal Pradesh" },
  { id: 3, name: "Assam" },
  { id: 4, name: "Bihar" },
  { id: 5, name: "Chhattisgarh" },
  { id: 6, name: "Goa" },
  { id: 7, name: "Gujarat" },
  { id: 8, name: "Haryana" },
  { id: 9, name: "Himachal Pradesh" },
  { id: 10, name: "Jharkhand" },
  { id: 11, name: "Karnataka" },
  { id: 12, name: "Kerala" },
  { id: 13, name: "Madhya Pradesh" },
  { id: 14, name: "Maharashtra" },
  { id: 15, name: "Manipur" },
  { id: 16, name: "Meghalaya" },
  { id: 17, name: "Mizoram" },
  { id: 18, name: "Nagaland" },
  { id: 19, name: "Odisha" },
  { id: 20, name: "Punjab" },
  { id: 21, name: "Rajasthan" },
  { id: 22, name: "Sikkim" },
  { id: 23, name: "Tamil Nadu" },
  { id: 24, name: "Telangana" },
  { id: 25, name: "Tripura" },
  { id: 26, name: "Uttar Pradesh" },
  { id: 27, name: "Uttarakhand" },
  { id: 28, name: "West Bengal" },
  { id: 29, name: "Andaman and Nicobar Islands" },
  { id: 30, name: "Chandigarh" },
  { id: 31, name: "Dadra and Nagar Haveli and Daman and Diu" },
  { id: 32, name: "Lakshadweep" },
  { id: 33, name: "Delhi" },
  { id: 34, name: "Puducherry" },
];

const contactTypes = [
  { id: 1, name: "HR" },
  { id: 2, name: "Escalation" },
  { id: 3, name: "Sales" },
  { id: 4, name: "Deals" },
  { id: 5, name: "SPOC" },
  { id: 6, name: "Sr Mgmt" },
];
const contactSchema = z.object({
  id: z.number().default(0),
  isActive: z.boolean().default(true),
  contactTypeID: z
    .number({ required_error: "Contact type is required" })
    .min(1, "Select a valid contact type"),
  name: z.string().min(1, "Name is required"),
  contactNumber: z
    .string()
    .regex(/^\d{10}$/, "Invalid contact number"),
  contactEmail: z.string().email("Invalid email address"),
});

// Supplier Form Schema
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
  contactInformation: z.array(contactSchema).default([]),
});

// ------------------------------------------------------
// Main Component: EditSupplier
// ------------------------------------------------------
const EditSupplier = () => {
  const params = useParams<{ id: string }>();
  const router = useRouter();
  const [supplier, setSupplier] = useState<any>(null);
  const [contactOpen, setContactOpen] = useState(false);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      id: 0,
      isActive: true,
      name: "",
      supplier_Code: "",
      sidDate: new Date(),
      address: "",
      stateID: statesList[0].id,
      gst: "",
      pan: "",
      tan: "",
      stateName: statesList[0].name,
      contactInformation: [],
    },
  });

  const { reset } = form;

  // Fetch supplier data and reset the form values
  useEffect(() => {
    const fetchSupplier = async () => {
      try {
        const response = await api.get(`/Supplier/${params.id}`);
        const supplierData = response.data;
        setSupplier(supplierData);
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
          stateName: supplierData.stateName,
          contactInformation: supplierData.contactInformation || [],
        });
      } catch (error) {
        console.error("Error fetching supplier:", error);
      }
    };

    if (params?.id) {
      fetchSupplier();
    }
  }, [params?.id, reset]);

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    try {
      const updatedSupplier = {
        ...supplier,
        ...values,
      };
      const response = await api.put(`/Supplier/${params.id}`, updatedSupplier);
      console.log("Supplier updated:", response.data);
      router.push("/admin/manage-supplier");
    } catch (error) {
      console.error("Error updating supplier:", error);
    }
  };

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

          {/* State */}
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
                      const state = statesList.find((s) => s.id === stateID);
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
                      {statesList.map((state) => (
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
                  <ContactForm
                    onSubmit={(contact) => {
                      const currentContacts = form.getValues("contactInformation");
                      form.setValue("contactInformation", [
                        ...currentContacts,
                        contact,
                      ]);
                      setContactOpen(false);
                    }}
                  />
                </DialogContent>
              </Dialog>
            </div>
            <FormMessage>
              {form.formState.errors.contactInformation?.message}
            </FormMessage>
          </div>

          <Button type="submit">Save</Button>
        </form>
      </Form>
    </div>
  );
};

export default EditSupplier;

// ------------------------------------------------------
// ContactForm Component for Adding a New Contact
// ------------------------------------------------------
function ContactForm({
  onSubmit,
}: {
  onSubmit: (values: z.infer<typeof contactSchema>) => void;
}) {
  const contactForm = useForm<z.infer<typeof contactSchema>>({
    resolver: zodResolver(contactSchema),
    defaultValues: {
      id: 0,
      isActive: true,
      contactTypeID: contactTypes[0].id,
      name: "",
      contactNumber: "",
      contactEmail: "",
    },
  });

  const handleSubmit = (values: z.infer<typeof contactSchema>) => {
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
