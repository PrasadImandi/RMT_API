"use client";

import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import { Input } from "@/components/ui/input";
import { format, parseISO, isValid } from "date-fns";
import { CalendarDays, Pencil, Plus, Trash2 } from "lucide-react";
import { toast } from "sonner";
import { Holiday } from "@/types";
import api from "@/lib/axiosInstance";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
// Define your form schema
const formSchema = z.object({
  name: z.string().min(2, "Name must be at least 2 characters."),
  description: z.string().min(2, "Description must be at least 2 characters."),
  phDate: z.date({ required_error: "A date is required." }),
  isPublic: z.boolean().default(true),
});

export default function HolidaysPage() {
  const [editingHoliday, setEditingHoliday] = useState<Holiday | null>(null);
  const [holidays, setHolidays] = useState<Holiday[]>([]);

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      name: "",
      description: "",
      phDate: new Date(),
      isPublic: true,
    },
  });

  // When editing a holiday, reset the form with its values.
  useEffect(() => {
    if (editingHoliday) {
      form.reset({
        name: editingHoliday.name,
        description: editingHoliday.description,
        phDate: editingHoliday.phDate ? parseISO(editingHoliday.phDate) : new Date(),
        isPublic: editingHoliday.isPublic,
      });
    }
  }, [editingHoliday, form]);

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    try {
      const holidayData = {
        ...values,
        phYear: values.phDate,
        isActive: true,
      };

      if (editingHoliday) {
        // Update the holiday
        const res = await api.put(`/PublicHolidays/${editingHoliday.id}`, {
          ...holidayData,
          id: editingHoliday.id,
        });
        setHolidays((prev) =>
          prev.map((h) => (h.id === editingHoliday.id ? res.data : h))
        );
        toast.success("Holiday updated successfully");
        window.location.reload()
      } else {
        // Create a new holiday
        const res = await api.post("/PublicHolidays", holidayData);
        setHolidays((prev) => [...prev, res.data]);
        toast.success("Holiday added successfully");
      }

      form.reset();
      setEditingHoliday(null);
    } catch (error) {
      console.error("Error saving holiday", error);
      toast.error(`Error ${editingHoliday ? "updating" : "adding"} holiday`);
    }
  };

  const fetchHolidays = async () => {
    try {
      const response = await api.get("/PublicHolidays");
      setHolidays(response.data);
    } catch (error) {
      console.error("Error fetching holidays:", error);
    }
  };

  useEffect(() => {
    fetchHolidays();
  }, []);

  const handleDeleteHoliday = async (id: string) => {
    try {
      await api.delete(`/PublicHolidays/${id}`);
      setHolidays((prev) => prev.filter((h) => h.id !== id));
      toast.success("Holiday deleted successfully");
    } catch (error) {
      console.error("Error deleting holiday", error);
      toast.error("Error deleting holiday");
    }
  };

  // Check if a date is a holiday by comparing the date strings.
  const isHoliday = (date: Date) => {
    return holidays.some((holiday) => {
      if (!holiday.phDate) return false;
      const parsed = parseISO(holiday.phDate);
      if (!isValid(parsed)) return false;
      return format(parsed, "yyyy-MM-dd") === format(date, "yyyy-MM-dd");
    });
  };

  return (
    <div className="p-16">
      <main className="container mx-auto py-8">
        <div className="flex items-center justify-between mb-8">
          <h1 className="text-4xl font-bold">Holiday Management</h1>
          <CalendarDays className="w-8 h-8 text-muted-foreground" />
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          {/* Form Card for Adding / Editing Holiday */}
          <Card>
            <CardHeader>
              <CardTitle>{editingHoliday ? "Edit Holiday" : "Add Holiday"}</CardTitle>
            </CardHeader>
            <CardContent>
              <Form {...form}>
                <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
                  <FormField
                    control={form.control}
                    name="name"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel>Holiday Name</FormLabel>
                        <FormControl>
                          <Input placeholder="Enter holiday name" {...field} />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />

                  <FormField
                    control={form.control}
                    name="description"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel>Description</FormLabel>
                        <FormControl>
                          <Input placeholder="Enter holiday description" {...field} />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />

                  <FormField
                    control={form.control}
                    name="phDate"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel>Select Date</FormLabel>
                        <FormControl>
                          <Calendar
                            mode="single"
                            selected={field.value}
                            onSelect={field.onChange}
                            className="rounded-md border"
                            modifiers={{ holiday: isHoliday }}
                            modifiersStyles={{ holiday: { color: "red" } }}
                          />
                        </FormControl>
                        <FormMessage />
                      </FormItem>
                    )}
                  />

                  <Button type="submit" className="w-full">
                    {editingHoliday ? (
                      <>
                        <Pencil className="w-4 h-4 mr-2" />
                        Edit Holiday
                      </>
                    ) : (
                      <>
                        <Plus className="w-4 h-4 mr-2" />
                        Add Holiday
                      </>
                    )}
                  </Button>
                </form>
              </Form>
            </CardContent>
          </Card>

          {/* Holiday List Card */}
          <Card>
            <CardHeader>
              <CardTitle>Holiday List</CardTitle>
            </CardHeader>
            <CardContent>
              <div className="space-y-4">
                {holidays.map((holiday, index) => (
                  <div
                    key={holiday.id || index}
                    className="flex items-center justify-between p-4 rounded-lg bg-muted/50"
                  >
                    <div>
                      <h3 className="font-medium">{holiday.name}</h3>
                      <p className="text-sm text-muted-foreground">
                        {holiday.phDate && isValid(parseISO(holiday.phDate))
                          ? format(parseISO(holiday.phDate), "PPP")
                          : "No date available"}
                      </p>
                      {holiday.description && (
                        <p className="text-sm text-muted-foreground mt-1">
                          {holiday.description}
                        </p>
                      )}
                    </div>
                    <div className="flex space-x-2">
                      <Button
                        variant="ghost"
                        size="icon"
                        onClick={() => setEditingHoliday(holiday)}
                      >
                        <Pencil className="w-4 h-4" />
                      </Button>
                      <Button
                        variant="ghost"
                        size="icon"
                        onClick={() => handleDeleteHoliday(holiday.id)}
                      >
                        <Trash2 className="w-4 h-4" />
                      </Button>
                    </div>
                  </div>
                ))}
              </div>
            </CardContent>
          </Card>
        </div>
      </main>
    </div>
  );
}
