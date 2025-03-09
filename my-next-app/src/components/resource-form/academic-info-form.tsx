"use client";

import { useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Plus, Trash2 } from "lucide-react";

interface AcademicInfoFormProps {
  initialData: any[];
  onSave: (data: any) => void;
}

export default function AcademicInfoForm({ initialData, onSave }: AcademicInfoFormProps) {
  const [academicDetails, setAcademicDetails] = useState(initialData.length > 0 ? initialData : []);

  const handleAddAcademic = () => {
    setAcademicDetails([
      ...academicDetails,
      {
        academicName: "",
        completionDate: "",
        resultPercentage: "",
        attachment: "",
      },
    ]);
  };

  const handleRemove = (index: number) => {
    setAcademicDetails(academicDetails.filter((_, i) => i !== index));
  };

  const handleChange = (index: number, field: string, value: string) => {
    const updatedDetails = [...academicDetails];
    updatedDetails[index] = {
      ...updatedDetails[index],
      [field]: value,
    };
    setAcademicDetails(updatedDetails);
  };

  const handleSave = () => {
    onSave(academicDetails);
  };

  return (
    <Card>
      <CardHeader className="flex flex-row items-center justify-between">
        <CardTitle>Academic Details</CardTitle>
        <Button
          type="button"
          variant="outline"
          size="sm"
          onClick={handleAddAcademic}
        >
          <Plus className="h-4 w-4 mr-2" />
          Add Academic Detail
        </Button>
      </CardHeader>
      <CardContent className="space-y-4">
        {academicDetails.map((detail, index) => (
          <div key={index} className="border p-4 rounded-lg space-y-4">
            <div className="flex justify-end">
              <Button
                type="button"
                variant="ghost"
                size="sm"
                onClick={() => handleRemove(index)}
              >
                <Trash2 className="h-4 w-4" />
              </Button>
            </div>
            <div className="grid grid-cols-2 gap-4">
              <div className="space-y-2">
                <Label>Academic Name *</Label>
                <Select
                  value={detail.academicName}
                  onValueChange={(value) => handleChange(index, "academicName", value)}
                >
                  <SelectTrigger>
                    <SelectValue placeholder="Select academic name" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="High School">High School</SelectItem>
                    <SelectItem value="Intermediate">Intermediate</SelectItem>
                    <SelectItem value="Bachelor">Bachelor&apos;s Degree</SelectItem>
                    <SelectItem value="Master">Master&apos;s Degree</SelectItem>
                  </SelectContent>
                </Select>
              </div>

              <div className="space-y-2">
                <Label>Completion Date *</Label>
                <Input
                  type="date"
                  value={detail.completionDate}
                  onChange={(e) => handleChange(index, "completionDate", e.target.value)}
                />
              </div>

              <div className="space-y-2">
                <Label>Result Percentage *</Label>
                <Input
                  type="number"
                  value={detail.resultPercentage}
                  onChange={(e) => handleChange(index, "resultPercentage", e.target.value)}
                />
              </div>

              <div className="space-y-2">
                <Label>Attachment *</Label>
                <Input
                  type="file"
                  accept=".pdf,.jpg,.jpeg,.png"
                  onChange={(e) => handleChange(index, "attachment", e.target.files?.[0]?.name || "")}
                />
              </div>
            </div>
          </div>
        ))}
        {academicDetails.length > 0 && (
          <div className="flex justify-end">
            <Button onClick={handleSave}>Save</Button>
          </div>
        )}
      </CardContent>
    </Card>
  );
}
