"use client";

import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import { Input } from "@/components/ui/input";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { mockHolidays, mockProjects } from "@/data/mock";
import { format, parseISO } from "date-fns";
import { CalendarDays, Pencil, Plus, Trash2 } from "lucide-react";
import { toast } from "sonner";
import { Holiday } from "@/types";
import api from "@/lib/axiosInstance";
import { Form, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import { FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";


// Define the form schema
const formSchema = z.object({
  PHName: z.string().min(6, {
    message: "Username must be at least 6 characters.",
  }),
  PHDescription: z.string().min(6, {
    message: "Username must be at least 6 characters.",
  }),
  PHDate: z.date({
    required_error: "A date of birth is required.",
  }),
  isPublic: z.boolean({
    required_error: "Please select an email to display.",
  })
});

export default function HolidaysPage() {
  const [selectedDate, setSelectedDate] = useState<Date>(new Date());
  const [selectedProject, setSelectedProject] = useState<string>("");
  const [editingHoliday, setEditingHoliday] = useState<Holiday | null>(null);
  const [newHoliday, setNewHoliday] = useState({
    name: "",
    description: "",
  });

  const [holidays, setHolidays] = useState<Holiday[]>([]);

  const form = useForm({
    resolver: zodResolver(formSchema),
    defaultValues: {
      PHName: "",
      PHDescription: "",
      PHDate: new Date(),
      isPublic: true
    },
  });

  const handleAddHoliday = async (values: z.infer<typeof formSchema>) => {
    if (!selectedDate || !newHoliday.name) {
      toast.error("Please fill in all required fields");
      return;
    }

    // Check for "all" and adjust logic as needed
    if (selectedProject === "all") {
      console.log("Holiday applies to all projects");
    } else {
      console.log(`Holiday applies to project ID: ${selectedProject}`);
    }

    try {
      const res = await api.post("/PublicHolidays", values);
      console.log(res);
      form.reset();
    } catch (error) {
      console.log("error creating public holiday", error);
    }

    toast.success("Holiday added successfully");
    setNewHoliday({ name: "", description: "" });
    setSelectedDate(null);
  };

  const fetchHolidays = async () => {
    try {
      const response = await api.get("/PublicHolidays");
      console.log(response.data);
      setHolidays(response.data);
    } catch (error) {
      console.error("Error fetching current user:", error);
    }
  };

  useEffect(() => {
    fetchHolidays();
  }, [])

  const handleUpdateHoliday = (holiday: Holiday) => {
    // In a real app, this would be an API call
    toast.success("Holiday updated successfully");
    setEditingHoliday(null);
  };

  const handleDeleteHoliday = (holiday: Holiday) => {
    // In a real app, this would be an API call
    toast.success("Holiday deleted successfully");
  };

  const isHoliday = (date: Date) => {
    return holidays.some(
      (holiday) =>
        format(parseISO(holiday.phDate), "yyyy-MM-dd") ===
        format(date, "yyyy-MM-dd")
    );
  };

  return (
    <div className="p-16">
      <div className="min-h-screen">
        <main className="container mx-auto py-8">
          <div className="flex items-center justify-between mb-8">
            <h1 className="text-4xl font-bold">Holiday Management</h1>
            <CalendarDays className="w-8 h-8 text-muted-foreground" />
          </div>

          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            <Card>
              <CardHeader>
                <CardTitle>Add Holiday</CardTitle>
              </CardHeader>
              <CardContent>
                  <div className="space-y-4">
                    <div className="space-y-2">
                      <label className="text-sm font-medium">Holiday Name</label>
                      <Input
                        placeholder="Enter holiday name"
                        value={newHoliday.name}
                        onChange={(e) =>
                          setNewHoliday({ ...newHoliday, name: e.target.value })
                        }
                      />
                    </div>

                    <div className="space-y-2">
                      <label className="text-sm font-medium">Description</label>
                      <Input
                        placeholder="Enter holiday description"
                        value={newHoliday.description}
                        onChange={(e) =>
                          setNewHoliday({
                            ...newHoliday,
                            description: e.target.value,
                          })
                        }
                      />
                    </div>

                    <div className="space-y-2">
                      <label className="text-sm font-medium">
                        Project (Optional)
                      </label>
                      <Select
                        value={selectedProject}
                        onValueChange={setSelectedProject}
                      >
                        <SelectTrigger>
                          <SelectValue placeholder="Select a project" />
                        </SelectTrigger>
                        <SelectContent>
                          <SelectItem value="all">All Projects</SelectItem>{" "}
                          {/* Changed value from "" to "all" */}
                          {mockProjects?.map((project) => (
                            <SelectItem key={project.id} value={project.id}>
                              {project.name}
                            </SelectItem>
                          ))}
                        </SelectContent>
                      </Select>
                    </div>

                    <div className="space-y-2">
                      <label className="text-sm font-medium">Select Date</label>
                      <Calendar
                        mode="single"
                        selected={selectedDate}
                        onSelect={setSelectedDate}
                        className="rounded-md border"
                        modifiers={{
                          holiday: (date) => isHoliday(date),
                        }}
                        modifiersStyles={{
                          holiday: { color: "red" },
                        }}
                      />
                    </div>

                    <Button
                      className="w-full"
                      onClick={handleAddHoliday}
                      disabled={!selectedDate || !newHoliday.name}
                    >
                      <Plus className="w-4 h-4 mr-2" />
                      Add Holiday
                    </Button>
                  </div>
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Holiday List</CardTitle>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {holidays!.map((holiday) => (
                    <div
                      key={holiday.phid}
                      className="flex items-center justify-between p-4 rounded-lg bg-muted/50"
                    >
                      <div>
                        <h3 className="font-medium">{holiday.phName}</h3>
                        <p className="text-sm text-muted-foreground">
                          {format(parseISO(holiday.phDate), "PPP")}
                        </p>
                        {holiday.phDescription && (
                          <p className="text-sm text-muted-foreground mt-1">
                            {holiday.phDescription}
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
                          onClick={() => handleDeleteHoliday(holiday)}
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
    </div>
  );
}
