"use client";

import { useEffect } from "react";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from "@/components/ui/dialog";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { PlusCircle, Clock, Save, Lock } from "lucide-react";
import { format, startOfWeek, addDays, isAfter, startOfToday, isWeekend, endOfWeek } from "date-fns";
import { useQuery } from "@tanstack/react-query";
import { ResourceApi } from "@/services/api/resource";
import { ProjectApi, ProjectType } from "@/services/api/projects";
import { useUserStore } from "@/store/userStore";
import { useState } from "react";

interface Project {
  id: string;
  name: string;
}

interface TimeEntry {
  projectId: string;
  hours: { [key: string]: number };
}

interface TimeRange {
  [key: string]: {
    start: string;
    end: string;
  };
}

function TimesheetTable({
  projects,
  timeEntries,
  timeRanges,
  weekDays,
  onTimeChange,
  onTimeRangeChange,
  readOnly = false,
  hasWeekendPermission = false,
}: {
  projects: Project[];
  timeEntries: TimeEntry[];
  timeRanges: TimeRange;
  weekDays: Date[];
  onTimeChange: (projectId: string, date: string, hours: number) => void;
  onTimeRangeChange: (date: string, field: 'start' | 'end', value: string) => void;
  readOnly?: boolean;
  hasWeekendPermission?: boolean;
}) {
  const dailyTotals = weekDays.reduce((totals, day) => {
    const dateStr = format(day, "yyyy-MM-dd");
    totals[dateStr] = timeEntries.reduce((sum, entry) => {
      return sum + (entry.hours[dateStr] || 0);
    }, 0);
    return totals;
  }, {} as { [key: string]: number });

  return (
    <div className="overflow-x-auto">
      <table className="w-full border-collapse">
        <thead>
          <tr>
            <th className="border p-2 bg-muted">Project</th>
            {weekDays.map(day => (
              <th 
                key={day.toString()} 
                className={`border p-2 ${isWeekend(day) ? 'bg-muted/80' : 'bg-muted'}`}
              >
                <div>
                  {format(day, "EEE dd/MM")}
                  {isWeekend(day) && !hasWeekendPermission && (
                    <Lock className="inline ml-1 w-3 h-3" />
                  )}
                </div>
              </th>
            ))}
            <th className="border p-2 bg-muted">Total</th>
          </tr>
        </thead>
        <tbody>
          {projects.map(project => {
            const projectEntry = timeEntries.find(
              entry => entry.projectId === project.id
            );
            const total = weekDays.reduce((sum, day) => {
              return sum + (projectEntry?.hours[format(day, "yyyy-MM-dd")] || 0);
            }, 0);

            return (
              <tr key={project.id}>
                <td className="border p-2">{project.name}</td>
                {weekDays.map(day => {
                  const dateStr = format(day, "yyyy-MM-dd");
                  const isWeekendDay = isWeekend(day);
                  const isDisabled = isWeekendDay && !hasWeekendPermission;
                  const hours = projectEntry?.hours[dateStr] || 0;
                  
                  return (
                    <td key={dateStr} className="border p-2">
                      <input
                        type="number"
                        min="0"
                        max="24"
                        step="0.5"
                        className={`w-16 p-1 border rounded ${
                          readOnly || isDisabled ? "bg-gray-100" : ""
                        } ${isWeekendDay ? "bg-muted/50" : ""}`}
                        value={hours || ""}
                        onChange={e => onTimeChange(project.id, dateStr, Number(e.target.value))}
                        readOnly={readOnly || isDisabled}
                        disabled={isDisabled}
                      />
                    </td>
                  );
                })}
                <td className="border p-2 font-bold">{total}</td>
              </tr>
            );
          })}
          <tr className="bg-muted/20">
            <td className="border p-2 font-bold">Daily Total</td>
            {weekDays.map(day => {
              const dateStr = format(day, "yyyy-MM-dd");
              const dailyTotal = dailyTotals[dateStr];
              const isOvertime = dailyTotal > 8;
              
              return (
                <td 
                  key={dateStr} 
                  className={`border p-2 font-bold ${isOvertime ? 'text-red-600' : ''}`}
                >
                  {dailyTotal || 0}
                </td>
              );
            })}
            <td className="border p-2 font-bold">
              {Object.values(dailyTotals).reduce((sum, hours) => sum + hours, 0)}
            </td>
          </tr>
          <tr className="bg-muted/10">
            <td className="border p-2 font-bold">In Time</td>
            {weekDays.map(day => {
              const dateStr = format(day, "yyyy-MM-dd");
              const timeRange = timeRanges[dateStr] || { start: "", end: "" };
              const isWeekendDay = isWeekend(day);
              const isDisabled = isWeekendDay && !hasWeekendPermission;
              
              return (
                <td key={dateStr} className="border p-2">
                  <input
                    type="time"
                    className={`w-full p-1 border rounded ${
                      isDisabled ? "bg-gray-100" : ""
                    }`}
                    value={timeRange.start}
                    onChange={(e) => onTimeRangeChange(dateStr, 'start', e.target.value)}
                    disabled={isDisabled}
                  />
                </td>
              );
            })}
            <td className="border p-2">-</td>
          </tr>
          <tr className="bg-muted/10">
            <td className="border p-2 font-bold">Out Time</td>
            {weekDays.map(day => {
              const dateStr = format(day, "yyyy-MM-dd");
              const timeRange = timeRanges[dateStr] || { start: "", end: "" };
              const isWeekendDay = isWeekend(day);
              const isDisabled = isWeekendDay && !hasWeekendPermission;
              
              return (
                <td key={dateStr} className="border p-2">
                  <input
                    type="time"
                    className={`w-full p-1 border rounded ${
                      isDisabled ? "bg-gray-100" : ""
                    }`}
                    value={timeRange.end}
                    onChange={(e) => onTimeRangeChange(dateStr, 'end', e.target.value)}
                    disabled={isDisabled}
                  />
                </td>
              );
            })}
            <td className="border p-2">-</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}

export default function Home() {
  const {user} = useUserStore();
  const [currentWeekOffset, setCurrentWeekOffset] = useState(0);
  const [projects, setProjects] = useState<Project[]>([]);
  const [timeEntries, setTimeEntries] = useState<TimeEntry[]>([]);
  const [timeRanges, setTimeRanges] = useState<TimeRange>({});
  const [savedTimeEntries, setSavedTimeEntries] = useState<{
    [key: string]: TimeEntry[];
  }>({});
  const [savedTimeRanges, setSavedTimeRanges] = useState<{
    [key: string]: TimeRange;
  }>({});
  const [selectedProjectId, setSelectedProjectId] = useState<string>("");
  const [dialogOpen, setDialogOpen] = useState(false);
  const [hasWeekendPermission] = useState(false);

  const { data: resourceData } = useQuery({
    queryKey: ['resource', user?.id],
    queryFn: () => ResourceApi.fetchResource(user?.id!),
    enabled: !!user?.id,
  });

  const { data: initialProject } = useQuery({
    queryKey: ['project', resourceData?.projectID],
    queryFn: () => ProjectApi.fetchProject(resourceData!.projectID),
    enabled: !!resourceData?.projectID,
  });

  const { data: availableProjects } = useQuery<ProjectType[]>({
    queryKey: ['available-projects'],
    queryFn: ProjectApi.fetchProjects,
  });

  useEffect(() => {
    if (initialProject && !projects.some(p => p.id === initialProject.id)) {
      setProjects([initialProject]);
    }
  }, [initialProject]);

  const startDate = startOfWeek(addDays(new Date(), currentWeekOffset * 7), {
    weekStartsOn: 1,
  });
  const weekDays = Array.from({ length: 7 }, (_, i) => addDays(startDate, i));
  const isFutureWeek = isAfter(startDate, startOfToday());

  const availableProjectsToAdd = availableProjects?.filter(
    availableProject => !projects.some(p => p.id === availableProject.id)
  );

  const handleAddProject = () => {
    if (selectedProjectId) {
      const projectToAdd = availableProjects?.find(
        (p) => p.id === selectedProjectId
      );
      if (projectToAdd) {
        setProjects((prev) => [...prev, projectToAdd]);
        setSelectedProjectId("");
        setDialogOpen(false);
      }
    }
  };

  const handleAutoFill = () => {
    const newEntries = projects.map((project) => ({
      projectId: project.id,
      hours: weekDays.reduce((acc, day) => {
        const dateStr = format(day, "yyyy-MM-dd");
        acc[dateStr] = isWeekend(day) && !hasWeekendPermission ? 0 : 8;
        return acc;
      }, {} as { [key: string]: number }),
    }));
    setTimeEntries(newEntries);

    const newTimeRanges = weekDays.reduce((acc, day) => {
      const dateStr = format(day, "yyyy-MM-dd");
      if (!isWeekend(day) || hasWeekendPermission) {
        acc[dateStr] = { start: "09:00", end: "17:00" };
      }
      return acc;
    }, {} as TimeRange);
    setTimeRanges(newTimeRanges);
  };

  const handleTimeChange = (projectId: string, date: string, hours: number) => {
    setTimeEntries((prev) => {
      const projectEntry =
        prev.find((entry) => entry.projectId === projectId) || {
          projectId,
          hours: {},
        };

      const updatedEntry = {
        ...projectEntry,
        hours: { ...projectEntry.hours, [date]: hours },
      };

      return [...prev.filter((entry) => entry.projectId !== projectId), updatedEntry];
    });
  };

  const handleTimeRangeChange = (date: string, field: "start" | "end", value: string) => {
    setTimeRanges((prev) => ({
      ...prev,
      [date]: {
        ...prev[date],
        [field]: value,
      },
    }));
  };

  const handleSave = () => {
    const weekKey = format(startDate, "yyyy-MM-dd");
    setSavedTimeEntries((prev) => ({
      ...prev,
      [weekKey]: timeEntries,
    }));
    setSavedTimeRanges((prev) => ({
      ...prev,
      [weekKey]: timeRanges,
    }));

    const totalHours = weekDays.reduce((total, day) => {
      const dateStr = format(day, "yyyy-MM-dd");
      return total + timeEntries.reduce((sum, entry) => sum + (entry.hours[dateStr] || 0), 0);
    }, 0);

    const formattedData = {
      ID: 0,
      ResourceID: resourceData?.id || 0,
      TotalHours: 40,
      WorkedHours: totalHours,
      WeekStartDate: format(startDate, "yyyy-MM-dd"),
      WeekEndDate: format(endOfWeek(startDate, { weekStartsOn: 1 }), "yyyy-MM-dd"),
      ProjectTimesheetDetails: projects.map((project) => ({
        ProjectID: Number(project.id), // Convert project.id to number
        TimesheetDetails: weekDays.map((day) => {
          const dateStr = format(day, "yyyy-MM-dd");
          const entry = timeEntries.find((e) => e.projectId === project.id);
          return {
            id: 0,
            TimesheetId: 0,
            WorkDate: dateStr,
            HoursWorked: entry?.hours[dateStr] || 0,
          };
        }),
      })),
    };

    console.log(formattedData);
  };

  const handleWeekChange = (offset: number) => {
    const newOffset = offset;
    setCurrentWeekOffset(newOffset);
    const newStartDate = startOfWeek(addDays(new Date(), newOffset * 7), {
      weekStartsOn: 1,
    });
    const weekKey = format(newStartDate, "yyyy-MM-dd");
    setTimeEntries(savedTimeEntries[weekKey] || []);
    setTimeRanges(savedTimeRanges[weekKey] || {});
  };

  return (
    <div className="container mx-auto py-8">
      <Card className="mb-8">
        <CardHeader>
          <div className="flex items-center justify-between">
            <CardTitle className="text-2xl font-bold">
              Weekly Timesheet - {resourceData?.firstName} {resourceData?.lastName}
            </CardTitle>
            <div className="flex gap-4">
              <Button variant="outline" onClick={() => handleWeekChange(currentWeekOffset - 1)}>
                Previous Week
              </Button>
              <Button variant="outline" onClick={() => handleWeekChange(0)} disabled={currentWeekOffset === 0}>
                Current Week
              </Button>
              <Button variant="outline" onClick={() => handleWeekChange(currentWeekOffset + 1)} disabled={isFutureWeek}>
                Next Week
              </Button>
            </div>
          </div>
        </CardHeader>
        <CardContent>
          {isFutureWeek ? (
            <div className="text-center p-4 text-red-500">
              Cannot fill timesheet for future weeks
            </div>
          ) : (
            <>
              <div className="mb-4 flex justify-between items-center">
                <div className="flex gap-2">
                  <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
                    <DialogTrigger asChild>
                      <Button variant="outline" disabled={!availableProjectsToAdd?.length}>
                        <PlusCircle className="w-4 h-4 mr-2" />
                        Add Project
                      </Button>
                    </DialogTrigger>
                    <DialogContent>
                      <DialogHeader>
                        <DialogTitle>Add Project to Timesheet</DialogTitle>
                      </DialogHeader>
                      <div className="py-4">
                        <Select value={selectedProjectId} onValueChange={setSelectedProjectId}>
                          <SelectTrigger>
                            <SelectValue placeholder="Select a project" />
                          </SelectTrigger>
                          <SelectContent>
                            {availableProjectsToAdd?.map((project) => (
                              <SelectItem key={project.id} value={project.id}>
                                {project.name}
                              </SelectItem>
                            ))}
                          </SelectContent>
                        </Select>
                        <div className="mt-4 flex justify-end">
                          <Button onClick={handleAddProject} disabled={!selectedProjectId}>
                            Add Project
                          </Button>
                        </div>
                      </div>
                    </DialogContent>
                  </Dialog>
                  <Button onClick={handleAutoFill} variant="outline">
                    <Clock className="w-4 h-4 mr-2" />
                    Auto Fill
                  </Button>
                </div>
                <Button onClick={handleSave} variant="default">
                  <Save className="w-4 h-4 mr-2" />
                  Save Timesheet
                </Button>
              </div>

              <TimesheetTable
                projects={projects}
                timeEntries={timeEntries}
                timeRanges={timeRanges}
                weekDays={weekDays}
                onTimeChange={handleTimeChange}
                onTimeRangeChange={handleTimeRangeChange}
                hasWeekendPermission={hasWeekendPermission}
              />
            </>
          )}
        </CardContent>
      </Card>
    </div>
  );
}