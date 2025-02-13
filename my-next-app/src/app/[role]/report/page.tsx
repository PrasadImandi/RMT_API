"use client";

import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Badge } from "@/components/ui/badge";
import { Clock, Calendar } from "lucide-react";

// Mock data for timesheet
const getCurrentWeek = () => {
  const now = new Date();
  const days = [];
  for (let i = 0; i < 7; i++) {
    const day = new Date(now);
    day.setDate(now.getDate() - now.getDay() + i);
    days.push(day);
  }
  return days;
};

const timesheet = getCurrentWeek().map(day => ({
  date: day,
  hours: day.getDay() === 0 || day.getDay() === 6 ? 0 : 9,
  project: day.getDay() === 0 || day.getDay() === 6 ? "Weekend" : "Main Project",
  status: day.getDay() === 0 || day.getDay() === 6 ? "Weekend" : "Completed"
}));

// Mock data for leaves
const leaves = [
  {
    type: "Annual Leave",
    total: 20,
    used: 12,
    pending: 2,
    balance: 6
  },
  {
    type: "Sick Leave",
    total: 12,
    used: 3,
    pending: 0,
    balance: 9
  },
  {
    type: "Personal Leave",
    total: 5,
    used: 2,
    pending: 1,
    balance: 2
  }
];

const appliedLeaves = [
  {
    id: 1,
    type: "Annual Leave",
    startDate: "2024-03-15",
    endDate: "2024-03-16",
    days: 2,
    status: "Approved",
    reason: "Family vacation"
  },
  {
    id: 2,
    type: "Sick Leave",
    startDate: "2024-02-28",
    endDate: "2024-02-28",
    days: 1,
    status: "Approved",
    reason: "Doctor's appointment"
  },
  {
    id: 3,
    type: "Personal Leave",
    startDate: "2024-03-20",
    endDate: "2024-03-20",
    days: 1,
    status: "Pending",
    reason: "Personal errands"
  }
];

const getStatusBadge = (status: string) => {
  const styles = {
    Approved: "bg-green-100 text-green-800 hover:bg-green-200",
    Pending: "bg-amber-100 text-amber-800 hover:bg-amber-200",
    Rejected: "bg-red-100 text-red-800 hover:bg-red-200",
    Weekend: "bg-gray-100 text-gray-800",
    Completed: "bg-blue-100 text-blue-800"
  };
  return styles[status as keyof typeof styles] || "bg-gray-100 text-gray-800";
};

export default function ReportPage() {
  return (
    <div className="container mx-auto py-10">
      <h1 className="text-3xl font-bold mb-8">Employee Reports</h1>
      
      <Tabs defaultValue="timesheet" className="space-y-4">
        <TabsList className="grid w-full grid-cols-2">
          <TabsTrigger value="timesheet">
            <Clock className="mr-2 h-4 w-4" />
            Timesheet
          </TabsTrigger>
          <TabsTrigger value="leave">
            <Calendar className="mr-2 h-4 w-4" />
            Leave Management
          </TabsTrigger>
        </TabsList>

        <TabsContent value="timesheet">
          <Card>
            <CardHeader>
              <CardTitle>Weekly Timesheet</CardTitle>
            </CardHeader>
            <CardContent>
              <Table>
                <TableHeader>
                  <TableRow>
                    <TableHead>Date</TableHead>
                    <TableHead>Hours</TableHead>
                    <TableHead>Project</TableHead>
                    <TableHead>Status</TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  {timesheet.map((day, index) => (
                    <TableRow key={index}>
                      <TableCell>
                        {day.date.toLocaleDateString('en-US', { 
                          weekday: 'short', 
                          month: 'short', 
                          day: 'numeric' 
                        })}
                      </TableCell>
                      <TableCell>{day.hours}</TableCell>
                      <TableCell>{day.project}</TableCell>
                      <TableCell>
                        <Badge className={getStatusBadge(day.status)}>
                          {day.status}
                        </Badge>
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </CardContent>
          </Card>
        </TabsContent>

        <TabsContent value="leave">
          <div className="grid gap-4 md:grid-cols-2">
            <Card>
              <CardHeader>
                <CardTitle>Leave Balance</CardTitle>
              </CardHeader>
              <CardContent>
                <Table>
                  <TableHeader>
                    <TableRow>
                      <TableHead>Type</TableHead>
                      <TableHead>Total</TableHead>
                      <TableHead>Used</TableHead>
                      <TableHead>Pending</TableHead>
                      <TableHead>Balance</TableHead>
                    </TableRow>
                  </TableHeader>
                  <TableBody>
                    {leaves.map((leave, index) => (
                      <TableRow key={index}>
                        <TableCell>{leave.type}</TableCell>
                        <TableCell>{leave.total}</TableCell>
                        <TableCell>{leave.used}</TableCell>
                        <TableCell>{leave.pending}</TableCell>
                        <TableCell className="font-medium">{leave.balance}</TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Applied Leaves</CardTitle>
              </CardHeader>
              <CardContent>
                <Table>
                  <TableHeader>
                    <TableRow>
                      <TableHead>Type</TableHead>
                      <TableHead>Date</TableHead>
                      <TableHead>Days</TableHead>
                      <TableHead>Status</TableHead>
                    </TableRow>
                  </TableHeader>
                  <TableBody>
                    {appliedLeaves.map((leave) => (
                      <TableRow key={leave.id}>
                        <TableCell>{leave.type}</TableCell>
                        <TableCell>
                          {leave.startDate === leave.endDate
                            ? leave.startDate
                            : `${leave.startDate} to ${leave.endDate}`}
                        </TableCell>
                        <TableCell>{leave.days}</TableCell>
                        <TableCell>
                          <Badge className={getStatusBadge(leave.status)}>
                            {leave.status}
                          </Badge>
                        </TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </CardContent>
            </Card>
          </div>
        </TabsContent>
      </Tabs>
    </div>
  );
}