"use client";

import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Button } from "@/components/ui/button";
import { toast } from "sonner";
import api from "@/lib/axiosInstance";

export default function ResourceDeallocation() {
  const [selectedProject, setSelectedProject] = useState<string>("");
  const [selectedResource, setSelectedResource] = useState<string>("");
  const [projects, setProjects] = useState<any>([]);
  const [resources, setResources] = useState<any>([]);

  // Fetch available projects
  useEffect(() => {
    const fetchProjects = async () => {
      try {
        const response = await api.get("/Project");
        setProjects(response.data);
      } catch (error) {
        console.error("Error fetching projects:", error);
      }
    };
    fetchProjects();
  }, []);

  // Fetch resources when a project is selected
  useEffect(() => {
    if (!selectedProject) return;

    const fetchResourcesByProject = async () => {
      try {
        const response = await api.get(`http://localhost:5194/api/Resource/resources/${selectedProject}`);
        setResources(response.data);
      } catch (error) {
        console.error("Error fetching resources:", error);
      }
    };
    fetchResourcesByProject();
  }, [selectedProject]);

  const handleDeallocation = async() => {
    if (!selectedResource || !selectedProject) {
      toast.error("Please select both project and resource");
      return;
    }
    console.log(selectedProject, selectedResource)
    const res = await api.patch('Resource',{
      resourceID: selectedResource,
      status: "inactive",
    })
    console.log(res.data)
    // In a real app, this would be an API call
    toast.success("Resource deallocated successfully");
  };

  return (
    <Card>
      <CardHeader>
        <CardTitle>Resource Deallocation</CardTitle>
      </CardHeader>
      <CardContent className="space-y-6">
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

        {selectedProject && (
          <div className="space-y-2">
            <label className="text-sm font-medium">Resource</label>
            <Select value={selectedResource} onValueChange={setSelectedResource}>
              <SelectTrigger>
                <SelectValue placeholder="Select a resource" />
              </SelectTrigger>
              <SelectContent>
                {resources.map((resource: any) => (
                  <SelectItem key={resource.resourceID} value={resource.resourceID}>
                    {resource.firstName} {resource.lastName} - {resource.jobTitle}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>
        )}

        <Button
          className="w-full"
          onClick={handleDeallocation}
          disabled={!selectedResource || !selectedProject}
        >
          Deallocate Resource
        </Button>
      </CardContent>
    </Card>
  );
}
