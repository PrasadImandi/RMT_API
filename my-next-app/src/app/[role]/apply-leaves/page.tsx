"use client";

import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import { Textarea } from "@/components/ui/textarea";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import {
  mockLeaveTypes,
  mockLeaveBalance,
  mockLeaveRequests,
} from "@/data/mock";
import { format, parseISO } from "date-fns";
import { CalendarRange, Clock, Plus } from "lucide-react";
import { toast } from "sonner";
import { DateRange } from "react-day-picker";
import { Badge } from "@/components/ui/badge";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import api from "@/lib/axiosInstance";

export default function LeavesPage() {
  const [dateRange, setDateRange] = useState<DateRange | undefined>({
    from: undefined,
    to: undefined,
  });
  const [selectedLeaveType, setSelectedLeaveType] = useState<string>("");
  const [reason, setReason] = useState("");
  const [leaveRequests, setLeaveRequests] = useState<any[]>([]);

  const handleApplyLeave = async () => {
    if (!dateRange?.from || !dateRange?.to || !selectedLeaveType || !reason) {
      toast.error("Please fill in all required fields");
      return;
    }

    const applyNewLeave = {
      resourceID: 1, // resourceid needs to change with logged in user id
      leaveType: selectedLeaveType,
      startDate: dateRange.from,
      endDate: dateRange.to,
      status: "pending",
      approverID: 2,
      created_Date: new Date(),
    };

    try {
      const res = await api.post("/Leave", applyNewLeave);
      console.log(res);
    } catch (error) {
      console.log("error registering client", error);
    }

    toast.success("Leave application submitted successfully");
    setDateRange({ from: undefined, to: undefined });
    setSelectedLeaveType("");
    setReason("");
  };

  const fetchLeaveRequests = async () => {
    try {
      const response = await api.get("/Leave");
      console.log(response.data);
      setLeaveRequests(response.data);
    } catch (error) {
      console.error("Error fetching leave requests:", error);
    }
  };

  useEffect(() => {
    fetchLeaveRequests();
  }, []);

  const getStatusColor = (status: string) => {
    switch (status) {
      case "approved":
        return "bg-green-100 text-green-800";
      case "rejected":
        return "bg-red-100 text-red-800";
      default:
        return "bg-yellow-100 text-yellow-800";
    }
  };

  return (
    <div className="min-h-screen">
      <main className="container mx-auto py-8">
        <div className="flex items-center justify-between mb-8">
          <h1 className="text-4xl font-bold">Leave Management</h1>
          <CalendarRange className="w-8 h-8 text-muted-foreground" />
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
          <Card className="lg:col-span-2">
            <CardHeader>
              <CardTitle>Apply for Leave</CardTitle>
            </CardHeader>
            <CardContent>
              <div className="space-y-6">
                <div className="space-y-2">
                  <label className="text-sm font-medium">Leave Type</label>
                  <Select
                    value={selectedLeaveType}
                    onValueChange={setSelectedLeaveType}
                  >
                    <SelectTrigger>
                      <SelectValue placeholder="Select leave type" />
                    </SelectTrigger>
                    <SelectContent>
                      {mockLeaveTypes.map((type) => (
                        <SelectItem key={type.id} value={type.id.toString()}>
                          {type.name} ({type.code})
                        </SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
                </div>

                <div className="space-y-2">
                  <label className="text-sm font-medium">Select Dates</label>
                  <Calendar
                    mode="range"
                    selected={dateRange}
                    onSelect={setDateRange}
                    numberOfMonths={2}
                    className="rounded-md border"
                  />
                </div>

                <div className="space-y-2">
                  <label className="text-sm font-medium">Reason</label>
                  <Textarea
                    placeholder="Enter reason for leave"
                    value={reason}
                    onChange={(e) => setReason(e.target.value)}
                  />
                </div>

                <Button
                  className="w-full"
                  onClick={handleApplyLeave}
                  disabled={
                    !dateRange?.from ||
                    !dateRange?.to ||
                    !selectedLeaveType ||
                    !reason
                  }
                >
                  <Plus className="w-4 h-4 mr-2" />
                  Apply for Leave
                </Button>
              </div>
            </CardContent>
          </Card>

          <div className="space-y-6">
            <Card>
              <CardHeader>
                <CardTitle>Leave Balance</CardTitle>
              </CardHeader>
              <CardContent>
                <div className="space-y-4">
                  {mockLeaveBalance.map((balance) => {
                    const leaveType = mockLeaveTypes.find(
                      (t) => t.id === balance.leaveTypeId
                    );
                    return (
                      <div
                        key={balance.id}
                        className="p-4 rounded-lg bg-muted/50"
                      >
                        <div className="flex items-center justify-between mb-2">
                          <h3 className="font-medium">{leaveType?.name}</h3>
                          <Badge variant="secondary">{leaveType?.code}</Badge>
                        </div>
                        <div className="grid grid-cols-3 gap-2 text-sm">
                          <div>
                            <p className="text-muted-foreground">Total</p>
                            <p className="font-medium">{balance.total}</p>
                          </div>
                          <div>
                            <p className="text-muted-foreground">Used</p>
                            <p className="font-medium">{balance.used}</p>
                          </div>
                          <div>
                            <p className="text-muted-foreground">Available</p>
                            <p className="font-medium">
                              {balance.total - balance.used - balance.pending}
                            </p>
                          </div>
                        </div>
                      </div>
                    );
                  })}
                </div>
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Leave Applications</CardTitle>
              </CardHeader>
              <CardContent>
                <Tabs defaultValue="pending">
                  <TabsList className="grid w-full grid-cols-2">
                    <TabsTrigger value="pending">Pending</TabsTrigger>
                    <TabsTrigger value="history">History</TabsTrigger>
                  </TabsList>
                  <TabsContent value="pending">
                    <div className="space-y-4">
                      {leaveRequests
                        .filter((request) => request.status === "pending")
                        .map((request) => {
                          const leaveType = mockLeaveTypes.find(
                            (t) => t.id === request.leaveType
                          );
                          return (
                            <div
                              key={request.id}
                              className="p-4 rounded-lg bg-muted/50"
                            >
                              <div className="flex items-center justify-between mb-2">
                                <Badge variant="secondary">
                                  {leaveType?.code}
                                </Badge>
                                <Badge
                                  className={getStatusColor(request.status)}
                                >
                                  {request.status}
                                </Badge>
                              </div>
                              <p className="text-sm mb-1">
                                {format(parseISO(request.startDate), "PPP")} -{" "}
                                {format(parseISO(request.endDate), "PPP")}
                              </p>
                              <p className="text-sm text-muted-foreground">
                                {request.reason}
                              </p>
                              <div className="flex items-center text-xs text-muted-foreground mt-2">
                                <Clock className="w-3 h-3 mr-1" />
                                Applied on{" "}
                                {format(parseISO(request.created_Date), "PPP")}
                              </div>
                            </div>
                          );
                        })}
                    </div>
                  </TabsContent>
                  <TabsContent value="history">
                    <div className="space-y-4">
                      {mockLeaveRequests
                        .filter((request) => request.status !== "pending")
                        .map((request) => {
                          const leaveType = mockLeaveTypes.find(
                            (t) => t.id === request.leaveTypeId
                          );
                          return (
                            <div
                              key={request.id}
                              className="p-4 rounded-lg bg-muted/50"
                            >
                              <div className="flex items-center justify-between mb-2">
                                <Badge variant="secondary">
                                  {leaveType?.code}
                                </Badge>
                                <Badge
                                  className={getStatusColor(request.status)}
                                >
                                  {request.status}
                                </Badge>
                              </div>
                              <p className="text-sm mb-1">
                                {format(parseISO(request.startDate), "PPP")} -{" "}
                                {format(parseISO(request.endDate), "PPP")}
                              </p>
                              <p className="text-sm text-muted-foreground">
                                {request.reason}
                              </p>
                              <div className="flex items-center text-xs text-muted-foreground mt-2">
                                <Clock className="w-3 h-3 mr-1" />
                                Applied on{" "}
                                {request.appliedOn
                                  ? format(parseISO(request.appliedOn), "PPP")
                                  : "N/A"}
                              </div>
                            </div>
                          );
                        })}
                    </div>
                  </TabsContent>
                </Tabs>
              </CardContent>
            </Card>
          </div>
        </div>
      </main>
    </div>
  );
}
