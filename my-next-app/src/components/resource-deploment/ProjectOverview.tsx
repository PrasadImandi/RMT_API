"use client";

import { useEffect, useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { format } from "date-fns";
import api from "@/lib/axiosInstance";

export default function ProjectOverview() {
    const [projects, setProjects] = useState<any[]>([]);
    const [selectedProjectId, setSelectedProjectId] = useState<string>("");
    const [selectedProject, setSelectedProject] = useState<any>(null);
    const [resources, setResources] = useState<any[]>([]);

    // Fetch Projects
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

    // Fetch Resources when a Project is Selected
    useEffect(() => {
        if (!selectedProjectId) {
            setSelectedProject(null);
            setResources([]);
            return;
        }

        const fetchProjectResources = async () => {
            try {
                const project = projects.find((p) => p.id === selectedProjectId);
                setSelectedProject(project);

                const response = await api.get(`http://localhost:5194/api/Resource/resources/${selectedProjectId}`);
                console.log(response.data);
                setResources(response.data);
            } catch (error) {
                console.error("Error fetching resources:", error);
            }
        };

        fetchProjectResources();
    }, [selectedProjectId, projects]);

    return (
        <div className="space-y-6">
            {/* Project Selection */}
            <Card className="space-y-2 border">
                <CardHeader className="text-sm font-medium">Select Project</CardHeader>
                <CardContent>
                    <Select value={selectedProjectId} onValueChange={setSelectedProjectId}>
                        <SelectTrigger className="w-full">
                            <SelectValue placeholder="Select a project to view details" />
                        </SelectTrigger>
                        <SelectContent>
                            {projects.map((project) => (
                                <SelectItem key={project.id} value={project.id}>
                                    {project.name}
                                </SelectItem>
                            ))}
                        </SelectContent>
                    </Select>
                </CardContent>
            </Card>

            {/* Project Details */}
            {selectedProject && (
                <Card>
                    <CardHeader>
                        <CardTitle>{selectedProject.name}</CardTitle>
                    </CardHeader>
                    <CardContent>
                        <div className="space-y-6">
                            <div className="grid grid-cols-1 md:grid-cols-2 gap-4 bg-muted/50 p-4 rounded-lg">
                                <div>
                                    <h3 className="font-medium text-sm">Start Date</h3>
                                    <p className="text-muted-foreground">
                                        {format(new Date(selectedProject.startDate), "PPP")}
                                    </p>
                                </div>
                                <div>
                                    <h3 className="font-medium text-sm">End Date</h3>
                                    <p className="text-muted-foreground">
                                        {format(new Date(selectedProject.endDate), "PPP")}
                                    </p>
                                </div>
                            </div>

                            {/* Allocated Resources */}
                            <div>
                                <h3 className="font-medium text-sm mb-4">Allocated Resources ({resources.length})</h3>
                                {resources.length === 0 ? (
                                    <div className="text-center py-8 bg-muted/50 rounded-lg">
                                        <p className="text-muted-foreground">No resources allocated to this project yet</p>
                                    </div>
                                ) : (
                                    <div className="grid grid-cols-1 gap-4">
                                        {resources.map((resource) => (
                                            <div
                                                key={resource.resourceID}
                                                className="flex items-center space-x-4 bg-muted/50 p-4 rounded-lg"
                                            >
                                                <img
                                                    src="https://github.com/shadcn.png"
                                                    alt={`${resource.firstName} ${resource.lastName}`}
                                                    className="w-12 h-12 rounded-full object-cover"
                                                />
                                                <div>
                                                    <p className="font-medium">
                                                        {resource.firstName} {resource.lastName}
                                                    </p>
                                                    <p className="text-sm text-muted-foreground">{resource.jobTitle}</p>
                                                    <p className="text-sm text-muted-foreground">{resource.email}</p>
                                                    <p className="text-sm text-muted-foreground">{resource.status}</p>
                                                    <p className="text-sm text-muted-foreground">{resource.phone}</p>
                                                </div>
                                            </div>
                                        ))}
                                    </div>
                                )}
                            </div>
                        </div>
                    </CardContent>
                </Card>
            )}
        </div>
    );
}
