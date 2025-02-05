"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import api from "@/lib/axiosInstance";

// Define Type for Resource
interface Resource {
  id: string;
  firstName: string;
  lastName: string;
  emailID: string;
  isActive: boolean;
}

export default function ResourceSelection() {
  const router = useRouter();
  const [selectedResource, setSelectedResource] = useState<string | null>(null);
  const [resources, setResources] = useState<Resource[]>([]); // Typed resources

  useEffect(() => {
    const fetchResources = async () => {
      try {
        const response = await api.get<Resource[]>("/Resource"); // API call typed
        setResources(response.data);
        console.log(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchResources();
  }, []);

  const handleSelect = (value: string) => {
    setSelectedResource(value);
  };

  const handleSubmit = () => {
    if (selectedResource) {
      router.push(`/admin/resource-information/${selectedResource}`);
    }
  };

  const selectedResourceDetails = resources.find(
    (resource) => resource.id === selectedResource
  );

  return (
    <div className="p-16">
      <div className="container max-w-2xl mx-auto">
        <Card>
          <CardHeader>
            <CardTitle>Select Resource</CardTitle>
            <CardDescription>
              Select a resource to view or edit their information
            </CardDescription>
          </CardHeader>
          <CardContent className="space-y-4">
            <Select onValueChange={handleSelect}>
              <SelectTrigger>
                <SelectValue placeholder="Select a resource" />
              </SelectTrigger>
              <SelectContent>
                {resources.map((resource) => (
                  <SelectItem key={resource.id} value={resource.id}>
                    {resource.firstName} - {resource.lastName}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>

            {selectedResourceDetails && (
              <div className="rounded-lg border p-4 mt-4">
                <h3 className="font-medium mb-2">Selected Resource</h3>
                <div className="space-y-1 text-sm">
                  <p>
                    <span className="text-muted-foreground">Name:</span>{" "}
                    {selectedResourceDetails.firstName} {selectedResourceDetails.lastName}
                  </p>
                  <p>
                    <span className="text-muted-foreground">ID:</span>{" "}
                    {selectedResourceDetails.id}
                  </p>
                  <p>
                    <span className="text-muted-foreground">Email:</span>{" "}
                    {selectedResourceDetails.emailID}
                  </p>
                  <p>
                    <span className="text-muted-foreground">Status:</span>{" "}
                    {selectedResourceDetails.isActive ? "Active" : "Not Active"}
                  </p>
                </div>
              </div>
            )}

            <Button
              onClick={handleSubmit}
              disabled={!selectedResource}
              className="w-full"
            >
              Continue
            </Button>
          </CardContent>
        </Card>
      </div>
    </div>
  );
}
