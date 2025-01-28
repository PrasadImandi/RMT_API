"use client";

import { useState } from "react";
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

// Mock data - replace with actual API call
const resources = [
  { id: "R001", name: "John Doe", email: "john.doe@example.com", department: "Engineering" },
  { id: "R002", name: "Jane Smith", email: "jane.smith@example.com", department: "Design" },
  { id: "R003", name: "Mike Johnson", email: "mike.j@example.com", department: "Product" },
  { id: "R004", name: "Sarah Williams", email: "sarah.w@example.com", department: "Engineering" },
  { id: "R005", name: "Alex Brown", email: "alex.b@example.com", department: "Marketing" },
];

export default function ResourceSelection() {
  const router = useRouter();
  const [selectedResource, setSelectedResource] = useState<string | null>(null);

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
                  {resource.name} - {resource.department}
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
                  {selectedResourceDetails.name}
                </p>
                <p>
                  <span className="text-muted-foreground">ID:</span>{" "}
                  {selectedResourceDetails.id}
                </p>
                <p>
                  <span className="text-muted-foreground">Email:</span>{" "}
                  {selectedResourceDetails.email}
                </p>
                <p>
                  <span className="text-muted-foreground">Department:</span>{" "}
                  {selectedResourceDetails.department}
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