"use client";

import { useState, useEffect } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Button } from "@/components/ui/button";
import { toast } from "sonner";
import api from "@/lib/axiosInstance";

export default function ResourceAllocation() {
  const [selectedResource, setSelectedResource] = useState<string | undefined>(
    undefined
  );
  const [selectedProject, setSelectedProject] = useState<string | undefined>(
    undefined
  );
  const [resources, setResources] = useState<any>([]);
  const [projects, setProjects] = useState<any>([]);
  const [startDate, setStartDate] = useState<string>("");
  const [endDate, setEndDate] = useState<string>("");

  useEffect(() => {
    const fetchResources = async () => {
      try {
        // Example API call to fetch data
        const resourceResponse = await api.get("/Resource");
        const resourceProject = await api.get("/Project");
        setResources(resourceResponse.data);
        setProjects(resourceProject.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchResources();
  }, []);

  const handleAllocation = async () => {
    if (!selectedResource || !selectedProject || !startDate || !endDate) {
      toast.error("Please fill all fields");
      return;
    }

    const resource = resources.find(
      (r: any) => r.resourceID === selectedResource
    );
    const role = resource?.jobTitle || "Unknown"; // Dynamically add job title

    const payload = {
      resourceID: selectedResource,
      projectID: selectedProject,
      role: role, // Add job title dynamically
      startDate: startDate,
      endDate: endDate,
      status: "Active",
      allocationPercent: 0,
    };

    console.log(payload); // Log the payload to console

    try {
      await api.post("ResourceDeployment", payload);
      toast.success("Resource allocated successfully");
    } catch (error) {
      console.error("Error allocating resource:", error);
      toast.error("Failed to allocate resource");
    }
  };

  return (
    <Card>
      <CardHeader>
        <CardTitle>Resource Allocation</CardTitle>
      </CardHeader>
      <CardContent className="space-y-6">
        <div className="space-y-2">
          <label className="text-sm font-medium">Resource</label>
          <Select value={selectedResource} onValueChange={setSelectedResource}>
            <SelectTrigger>
              <SelectValue placeholder="Select a resource" />
            </SelectTrigger>
            <SelectContent>
              {resources?.map((resource: any) => (
                <SelectItem key={resource.resourceID} value={resource.resourceID}>
                  {resource.firstName} - {resource.jobTitle}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>

        {selectedResource && (
          <div className="flex items-center space-x-4">
            <img
              src="https://github.com/shadcn.png"
              alt="Resource"
              className="w-20 h-20 rounded-full object-cover"
            />
            <div>
              <h3 className="font-medium">
                {
                  resources.find((r:any) => r.resourceID === selectedResource)
                    ?.firstName
                }
              </h3>
              <p className="text-sm text-muted-foreground">
                {
                  resources.find((r:any) => r.resourceID === selectedResource)
                    ?.jobTitle
                }
              </p>
            </div>
          </div>
        )}

        <div className="space-y-2">
          <label className="text-sm font-medium">Project</label>
          <Select value={selectedProject} onValueChange={setSelectedProject}>
            <SelectTrigger>
              <SelectValue placeholder="Select a project" />
            </SelectTrigger>
            <SelectContent>
              {projects.map((project: any) => (
                <SelectItem key={project.projectID} value={project.projectID}>
                  {project.projectName}
                </SelectItem>
              ))}
            </SelectContent>
          </Select>
        </div>

        <div className="space-y-2">
          <label className="text-sm font-medium">Start Date</label>
          <input
            type="date"
            value={startDate}
            onChange={(e) => setStartDate(e.target.value)}
            className="w-full p-2 border border-gray-300 rounded"
          />
        </div>

        <div className="space-y-2">
          <label className="text-sm font-medium">End Date</label>
          <input
            type="date"
            value={endDate}
            onChange={(e) => setEndDate(e.target.value)}
            className="w-full p-2 border border-gray-300 rounded"
          />
        </div>

        <Button
          className="w-full"
          onClick={handleAllocation}
          disabled={!selectedResource || !selectedProject || !startDate || !endDate}
        >
          Allocate Resource
        </Button>
      </CardContent>
    </Card>
  );
}
