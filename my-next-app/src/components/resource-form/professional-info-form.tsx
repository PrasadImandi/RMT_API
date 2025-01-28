"use client";

import { useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Switch } from "@/components/ui/switch";
import { Button } from "@/components/ui/button";

interface ProfessionalInfoFormProps {
  initialData: any;
  onSave: (data: any) => void;
}

export default function ProfessionalInfoForm({ initialData, onSave }: ProfessionalInfoFormProps) {
  const [formData, setFormData] = useState({
    domain: "",
    role: "",
    level: "",
    overallExperience: "",
    cwfId: "",
    officialEmail: "",
    laptop: "",
    assetAssignedDate: "",
    assetModelNo: "",
    assetSerialNo: "",
    poNo: "",
    poDate: "",
    lastWorkingDate: "",
    attendanceRequired: false,
    ...initialData
  });

  const handleChange = (field: string, value: any) => {
    setFormData(prev => ({
      ...prev,
      [field]: value
    }));
  };

  const handleSave = () => {
    onSave(formData);
  };

  return (
    <Card>
      <CardHeader>
        <CardTitle>Professional Information</CardTitle>
      </CardHeader>
      <CardContent className="space-y-4">
        <div className="grid grid-cols-2 gap-4">
          <div className="space-y-2">
            <Label>Domain *</Label>
            <Select
              value={formData.domain}
              onValueChange={(value) => handleChange("domain", value)}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select domain" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="IT">Information Technology</SelectItem>
                <SelectItem value="Finance">Finance</SelectItem>
                <SelectItem value="HR">Human Resources</SelectItem>
                <SelectItem value="Operations">Operations</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label>Role *</Label>
            <Select
              value={formData.role}
              onValueChange={(value) => handleChange("role", value)}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select role" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="Developer">Developer</SelectItem>
                <SelectItem value="Designer">Designer</SelectItem>
                <SelectItem value="Manager">Manager</SelectItem>
                <SelectItem value="Analyst">Analyst</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label>Level *</Label>
            <Select
              value={formData.level}
              onValueChange={(value) => handleChange("level", value)}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select level" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="Junior">Junior</SelectItem>
                <SelectItem value="Mid">Mid-Level</SelectItem>
                <SelectItem value="Senior">Senior</SelectItem>
                <SelectItem value="Lead">Lead</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label>Overall Experience (years) *</Label>
            <Input
              type="number"
              min="0"
              step="0.5"
              value={formData.overallExperience}
              onChange={(e) => handleChange("overallExperience", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>CWF ID</Label>
            <Input
              type="text"
              value={formData.cwfId}
              onChange={(e) => handleChange("cwfId", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Official Email ID</Label>
            <Input
              type="email"
              value={formData.officialEmail}
              onChange={(e) => handleChange("officialEmail", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Laptop *</Label>
            <Select
              value={formData.laptop}
              onValueChange={(value) => handleChange("laptop", value)}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select laptop type" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="Supplier">Supplier</SelectItem>
                <SelectItem value="HPE">HPE</SelectItem>
                <SelectItem value="Rented">Rented</SelectItem>
                <SelectItem value="Business Funded">Business Funded</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label>Asset Assigned Date</Label>
            <Input
              type="date"
              value={formData.assetAssignedDate}
              onChange={(e) => handleChange("assetAssignedDate", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Asset Model No</Label>
            <Input
              type="text"
              value={formData.assetModelNo}
              onChange={(e) => handleChange("assetModelNo", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Asset Serial No</Label>
            <Input
              type="text"
              value={formData.assetSerialNo}
              onChange={(e) => handleChange("assetSerialNo", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>PO No *</Label>
            <Input
              type="text"
              value={formData.poNo}
              onChange={(e) => handleChange("poNo", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>PO Date *</Label>
            <Input
              type="date"
              value={formData.poDate}
              onChange={(e) => handleChange("poDate", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Last Working Date</Label>
            <Input
              type="date"
              value={formData.lastWorkingDate}
              onChange={(e) => handleChange("lastWorkingDate", e.target.value)}
            />
          </div>

          <div className="space-y-2 flex items-center">
            <Label className="mr-2">Attendance Required? *</Label>
            <Switch
              checked={formData.attendanceRequired}
              onCheckedChange={(checked) => handleChange("attendanceRequired", checked)}
            />
          </div>
        </div>

        <div className="flex justify-end">
          <Button onClick={handleSave}>Save</Button>
        </div>
      </CardContent>
    </Card>
  );
}