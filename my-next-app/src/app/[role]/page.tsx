import React from "react";
import { PieChartComponent } from "@/components/charts/pieChart";
import {
  Activity,
  ArrowDownRight,
  ArrowUpRight,
  Users,
  Briefcase,
  Calendar,
  CalendarDays,
  Clock,
  CalendarDays as CalendarDaysIcon,
} from "lucide-react";
import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card";
import { BarChartComponent } from "@/components/charts/barChart";
import { Badge } from "@/components/ui/badge";

const approvals = [
  {
    employee: "John Doe",
    type: "Vacation",
    dates: "Apr 15 - Apr 20",
    status: "pending",
  },
  {
    employee: "Jane Smith",
    type: "Sick Leave",
    dates: "Apr 12",
    status: "pending",
  },
];

const offToday = [
  { name: "Sarah Wilson", reason: "Vacation" },
  { name: "Mike Johnson", reason: "Sick Leave" },
];

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

const AdminPage = () => {
  return (
    <div className="min-h-screen p-16">
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
          {/* Left Side: Other Things */}
          <div className="lg:w-4/5 space-y-8">
            {/* Charts and Approvals */}
            <div className="flex flex-col gap-8 lg:flex-row">
              <div className="flex-1">
                <PieChartComponent />
              </div>
              <Card className="flex-1">
                <div className="p-6">
                  <div className="flex items-center justify-between">
                    <h3 className="text-lg font-medium">Pending Approvals</h3>
                    <Badge variant="secondary">2 New</Badge>
                  </div>
                  <div className="mt-4 space-y-4">
                    {approvals.map((approval, i) => (
                      <div key={i} className="flex items-center justify-between">
                        <div>
                          <p className="font-medium">{approval.employee}</p>
                          <p className="text-sm text-muted-foreground">
                            {approval.type} • {approval.dates}
                          </p>
                        </div>
                        <Badge>{approval.status}</Badge>
                      </div>
                    ))}
                  </div>
                </div>
              </Card>
              <div className="flex-1">
                <BarChartComponent />
              </div>
            </div>

            {/* Announcements and Who's Off Today */}
            <div className="grid gap-6 md:grid-cols-2">
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
                      <div key={i} className="flex items-center justify-between">
                        <p className="font-medium">{person.name}</p>
                        <Badge variant="outline">{person.reason}</Badge>
                      </div>
                    ))}
                  </div>
                </div>
              </Card>
            </div>
          </div>

          {/* Right Side: Small Stat Cards as a List */}
          <div className="lg:w-1/5 space-y-6 mt-8 lg:mt-0">
            {/* Next Payday */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Next Payday</CardTitle>
                <CalendarDaysIcon className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="mt-3">
                  <p className="text-2xl font-bold">15 Jan</p>
                  <p className="text-xs text-muted-foreground">8 days remaining</p>
                </div>
              </CardContent>
            </Card>

            {/* Attendance Today */}
            <Card className="p-6">
              <div className="flex items-center space-x-2">
                <Clock className="h-4 w-4 text-muted-foreground" />
                <h3 className="text-sm font-medium">Attendance Today</h3>
              </div>
              <div className="mt-3">
                <p className="text-2xl font-bold">92%</p>
                <p className="text-xs text-muted-foreground">230 present</p>
              </div>
            </Card>

            {/* Active Employees */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Active Employees</CardTitle>
                <Users className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">5,250</div>
                <p className="text-xs text-muted-foreground flex items-center">
                  <ArrowUpRight className="h-4 w-4 text-green-500" />
                  +10% from last month
                </p>
              </CardContent>
            </Card>

            {/* Projects Onboarded */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">Projects Onboarded</CardTitle>
                <Briefcase className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">42</div>
                <p className="text-xs text-muted-foreground flex items-center">
                  <ArrowUpRight className="h-4 w-4 text-green-500" />
                  +15% from last quarter
                </p>
              </CardContent>
            </Card>

            {/* New Employees */}
            <Card>
              <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                <CardTitle className="text-sm font-medium">New Employees</CardTitle>
                <Calendar className="h-4 w-4 text-muted-foreground" />
              </CardHeader>
              <CardContent>
                <div className="text-2xl font-bold">128</div>
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
