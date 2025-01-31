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
  Popover,
  PopoverTrigger,
  PopoverContent,
} from "@/components/ui/popover";
import { Calendar } from "@/components/ui/calendar";
import { CalendarIcon } from "lucide-react";
import { format } from "date-fns";
import { cn } from "@/lib/utils";
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
import { useState } from "react";

const contactSchema = z.object({
  contactType: z.enum(["HR", "Escalation", "Sales", "Deals", "SPOC", "Sr Mgmt"]),
  name: z.string().min(1, "Name is required"),
  contactNumber: z.string().regex(/^\d{10}$/, "Invalid contact number"),
  email: z.string().email("Invalid email address"),
});

const formSchema = z.object({
  supplierName: z.string().min(1, "Supplier name is required"),
  sidDate: z.date({ required_error: "SID date is required" }),
  address: z.string().min(1, "Address is required"),
  state: z.string().min(1, "State is required"),
  gstId: z.string().min(1, "GST ID is required"),
  panId: z.string().min(1, "PAN ID is required"),
  tanId: z.string().min(1, "TAN ID is required"),
  contacts: z.array(contactSchema).min(1, "At least one contact is required"),
});

export default function AddSupplier() {
  const [contactOpen, setContactOpen] = useState(false);
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      supplierName: "",
      sidDate: new Date(),
      address: "",
      state: "",
      gstId: "",
      panId: "",
      tanId: "",
      contacts: [],
    },
  });

  const onSubmit = (values: z.infer<typeof formSchema>) => {
    console.log("Form Values:", values);
  };

  const addContact = (contact: z.infer<typeof contactSchema>) => {
    const currentContacts = form.getValues("contacts");
    form.setValue("contacts", [...currentContacts, contact]);
    setContactOpen(false);
  };

  return (
    <div className="m-16 p-4 bg-white dark:bg-[#17171A]">
      <h1 className="text-2xl mb-6">Add Supplier</h1>
      <Form {...form}>
        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6 w-3/5">
          {/* Supplier Name */}
          <FormField
            control={form.control}
            name="supplierName"
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

          {/* State */}
          <FormField
            control={form.control}
            name="state"
            render={({ field }) => (
              <FormItem>
                <FormLabel>State</FormLabel>
                <FormControl>
                  <Input {...field} placeholder="Enter state" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />

          {/* GST ID */}
          <FormField
            control={form.control}
            name="gstId"
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
            name="panId"
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
            name="tanId"
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
              {form.watch("contacts").map((contact, index) => (
                <div key={index} className="p-4 border rounded">
                  <p>Type: {contact.contactType}</p>
                  <p>Name: {contact.name}</p>
                  <p>Number: {contact.contactNumber}</p>
                  <p>Email: {contact.email}</p>
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
                  <ContactForm onSubmit={addContact} />
                </DialogContent>
              </Dialog>
            </div>
            <FormMessage>{form.formState.errors.contacts?.message}</FormMessage>
          </div>

          <Button type="submit">Submit</Button>
        </form>
      </Form>
    </div>
  );
}

function ContactForm({ onSubmit }: { onSubmit: (values: any) => void }) {
  const form = useForm<z.infer<typeof contactSchema>>({
    resolver: zodResolver(contactSchema),
    defaultValues: {
      contactType: "HR",
      name: "",
      contactNumber: "",
      email: "",
    },
  });

  const handleSubmit = (values: z.infer<typeof contactSchema>) => {
    onSubmit(values);
    form.reset();
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(handleSubmit)} className="space-y-4">
        <FormField
          control={form.control}
          name="contactType"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Contact Type</FormLabel>
              <Select onValueChange={field.onChange} defaultValue={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Select contact type" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {["HR", "Escalation", "Sales", "Deals", "SPOC", "Sr Mgmt"].map((type) => (
                    <SelectItem key={type} value={type}>{type}</SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
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

        <FormField
          control={form.control}
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

        <FormField
          control={form.control}
          name="email"
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