"use client";

import React from "react";
import { PieChartComponent } from "@/components/charts/pieChart";
import {
  Activity,
  ArrowDownRight,
  ArrowUpRight,
  Users,
  Briefcase,
  Calendar,
  Clock,
  CalendarDays as CalendarDaysIcon,
  ExternalLink,
} from "lucide-react";
import {
  Card,
  CardHeader,
  CardTitle,
  CardContent,
  CardDescription,
  CardFooter,
} from "@/components/ui/card";
import { BarChartComponent } from "@/components/charts/barChart";
import { Badge } from "@/components/ui/badge";
import { DashBoardApi } from "@/services/api/dashboard";
import { useQuery } from "@tanstack/react-query";
import { format } from "date-fns";
import { Button } from "@/components/ui/button";

const announcements = [
  {
    title: "Company Picnic",
    date: "April 20, 2024",
    description: "Annual company picnic at Central Park",
  },
  {
    title: "New Policy Update",
    date: "April 15, 2024",
    description: "Remote work policy updates",
  },
];

const offToday = [
  { name: "Sarah Wilson", reason: "Vacation" },
  { name: "Mike Johnson", reason: "Sick Leave" },
];

const AdminPage = () => {
  const { data: data = [], isLoading } = useQuery({
    queryKey: ["users"],
    queryFn: DashBoardApi.getDashboardDetails,
  });

  console.log(data);

  return (
    <div className="min-h-screen p-4 sm:p-8 md:p-12 lg:p-16">
      {/* Header */}
      <header className="border-b bg-white dark:bg-[#17171A] shadow-sm rounded-md">
        <div className="container mx-auto flex h-16 items-center px-4">
          <Activity className="h-6 w-6 text-blue-600" />
          <h2 className="ml-2 text-lg font-semibold text-gray-800 dark:text-gray-100">
            Dashboard
          </h2>
        </div>
      </header>

      {/* Main content container */}
      <main className="container mx-auto py-8">
        <div className="lg:flex lg:space-x-8">
          {/* Left Side: Charts, Approvals, Announcements, etc. */}
          <div className="lg:w-4/5 space-y-8">
            {/* Charts Row */}
            <div className="flex flex-wrap gap-y-4">
              <div className="flex-1">
                {isLoading ? (
                  <p>Fetching data</p>
                ) : (
                  <PieChartComponent data={data.resourceCountDetails} />
                )}
              </div>
              <div className="flex-1">
                {isLoading ? (
                  <p>Fetching data</p>
                ) : (
                  <BarChartComponent
                    data={data?.clientProjects}
                    Title="Client"
                  />
                )}
              </div>
              <div className="flex-1">
                {isLoading ? (
                  <p>Fetching data</p>
                ) : (
                  <BarChartComponent
                    data={data?.projectDetails}
                    Title="Projects"
                  />
                )}
              </div>
            </div>

            <div className="grid gap-6 md:grid-cols-2">
              <Card>
                <div className="p-6 relative">
                  {/* External Link Button Positioned at Top Right */}
                  <div className="absolute top-2 right-2">
                    <Button variant="ghost">
                      <ExternalLink />
                    </Button>
                  </div>
                  <div className="flex items-center justify-between pt-4">
                    <h3 className="text-lg font-medium">
                      Timesheet Pending Approvals
                    </h3>
                    <Badge variant="secondary">2 New</Badge>
                  </div>
                  <div className="mt-4 space-y-4">
                    {data?.timesheetPendings?.map(
                      (approval: any, i: number) => (
                        <div
                          key={i}
                          className="flex items-center justify-between"
                        >
                          <div>
                            <p className="font-medium">{approval.name}</p>
                            <p className="text-sm text-muted-foreground">
                              {format(approval.weekStartDate, "yyyy-MM-dd")} -{" "}
                              {format(approval.weekEndDate, "yyyy-MM-dd")}
                            </p>
                          </div>
                          <Badge>Pending</Badge>
                        </div>
                      )
                    )}
                  </div>
                </div>
              </Card>

              <Card>
                <div className="p-6">
                  <h3 className="text-lg font-medium">Announcements</h3>
                  <div className="mt-4 space-y-4">
                    {announcements.map((announcement, i) => (
                      <div key={i} className="space-y-1">
                        <div className="flex items-center justify-between">
                          <p className="font-medium">{announcement.title}</p>
                          <span className="text-sm text-muted-foreground">
                            {announcement.date}
                          </span>
                        </div>
                        <p className="text-sm text-muted-foreground">
                          {announcement.description}
                        </p>
                      </div>
                    ))}
                  </div>
                </div>
              </Card>
              <Card>
                <div className="p-6">
                  <h3 className="text-lg font-medium">Who's Off Today</h3>
                  <div className="mt-4 space-y-4">
                    {offToday.map((person, i) => (
                      <div
                        key={i}
                        className="flex items-center justify-between"
                      >
                        <p className="font-medium">{person.name}</p>
                        <Badge variant="outline">{person.reason}</Badge>
                      </div>
                    ))}
                  </div>
                </div>
              </Card>
            </div>
          </div>

          {/* Right Side: Small Stat Cards */}
          <div className="lg:w-1/5 space-y-6 mt-8 lg:mt-0">
            {/* Next Payday */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Next Payday
                </CardTitle>
                <CalendarDaysIcon className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="mt-3">
                  <p className="text-2xl font-bold">15 Jan</p>
                  <p className="text-xs text-muted-foreground">
                    8 days remaining
                  </p>
                </div>
              </CardContent>
            </Card>

            {/* Attendance Today */}
            <Card className="p-6">
              <div className="flex items-center space-x-2">
                <Clock className="h-4 w-4 text-muted-foreground" />
                <h3 className="text-sm font-medium">Total Clients</h3>
              </div>
              <div className="mt-3">
                <p className="text-2xl font-bold">{data.clientsCount}</p>
                <p className="text-xs text-muted-foreground">230 present</p>
              </div>
            </Card>

            {/* Active Employees */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Active Employees
                </CardTitle>
                <Users className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{data?.resourceCountDetails?.activeResourceCount ? data.resourceCountDetails.activeResourceCount: "fetching..." }</div>
                <p className="text-xs text-muted-foreground flex items-center">
                  <ArrowUpRight className="h-4 w-4 text-green-500" />
                  +10% from last month
                </p>
              </CardContent>
            </Card>

            {/* Projects Onboarded */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Projects Onboarded
                </CardTitle>
                <Briefcase className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{data.projectsCount}</div>
                <p className="text-xs text-muted-foreground flex items-center">
                  <ArrowUpRight className="h-4 w-4 text-green-500" />
                  +15% from last quarter
                </p>
              </CardContent>
            </Card>

            {/* New Employees */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">
                  Total Suppliers
                </CardTitle>
                <Calendar className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">{data.suppliersCount}</div>
                <p className="text-xs text-muted-foreground flex items-center">
                  <ArrowDownRight className="h-4 w-4 text-red-500" />
                  -5% from last month
                </p>
              </CardContent>
            </Card>
          </div>
        </div>
      </main>
    </div>
  );
};

export default AdminPage;
