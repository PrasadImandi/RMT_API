"use client";

import { useState, useEffect } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Textarea } from "@/components/ui/textarea";
import { Button } from "@/components/ui/button";

interface PersonalInfoFormProps {
  initialData: any;
  onSave: (data: any) => void;
}

export default function PersonalInfoForm({ initialData, onSave }: PersonalInfoFormProps) {
  const [formData, setFormData] = useState({
    isActive: "",
    joiningDate: "",
    gender: "",
    dateOfBirth: "",
    officialMailingAddress: "",
    pinCode: "",
    state: "",
    hometownAddress: "",
    alternateContactNumber: "",
    emergencyContactNumber: "",
    fatherName: "",
    motherName: "",
    ...initialData
  });

  const handleChange = (field: string, value: string) => {
    setFormData(prev => {
      let updatedData = { ...prev, [field]: value };
  
      if (field === "resourceStatus") {
        updatedData.isActive = value === "Active";
      }
  
      return updatedData;
    });
  };

  const handleSave = () => {
    onSave(formData);
  };

  return (
    <Card>
      <CardHeader>
        <CardTitle>Personal Information</CardTitle>
      </CardHeader>
      <CardContent className="space-y-4">
        <div className="grid grid-cols-2 gap-4">
          <div className="space-y-2">
            <Label>Resource Status *</Label>
            <Select 
              value={formData.isActive}
              onValueChange={(value) => handleChange("isActive", value)}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select status" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="Active">Active</SelectItem>
                <SelectItem value="InActive">InActive</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label>Joining Date *</Label>
            <Input 
              type="date"
              value={formData.joiningDate}
              onChange={(e) => handleChange("joiningDate", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Gender *</Label>
            <Select
              value={formData.gender}
              onValueChange={(value) => handleChange("gender", value)}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select gender" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="Male">Male</SelectItem>
                <SelectItem value="Female">Female</SelectItem>
                <SelectItem value="Other">Other</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label>Date of Birth *</Label>
            <Input 
              type="date"
              value={formData.dateOfBirth}
              onChange={(e) => handleChange("dateOfBirth", e.target.value)}
            />
          </div>
        </div>

        <div className="space-y-2">
          <Label>Official Mailing Address *</Label>
          <Textarea 
            value={formData.officialMailingAddress}
            onChange={(e) => handleChange("officialMailingAddress", e.target.value)}
          />
        </div>

        <div className="grid grid-cols-2 gap-4">
          <div className="space-y-2">
            <Label>Pin Code *</Label>
            <Input 
              type="text"
              maxLength={6}
              value={formData.pinCode}
              onChange={(e) => handleChange("pinCode", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>State *</Label>
            <Input 
              type="text"
              value={formData.state}
              onChange={(e) => handleChange("state", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Hometown Address</Label>
            <Textarea 
              value={formData.hometownAddress}
              onChange={(e) => handleChange("hometownAddress", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Alternate Contact Number</Label>
            <Input 
              type="tel"
              value={formData.alternateContactNumber}
              onChange={(e) => handleChange("alternateContactNumber", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Emergency Contact Number *</Label>
            <Input 
              type="tel"
              value={formData.emergencyContactNumber}
              onChange={(e) => handleChange("emergencyContactNumber", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Father's Name *</Label>
            <Input 
              type="text"
              value={formData.fatherName}
              onChange={(e) => handleChange("fatherName", e.target.value)}
            />
          </div>

          <div className="space-y-2">
            <Label>Mother's Name *</Label>
            <Input 
              type="text"
              value={formData.motherName}
              onChange={(e) => handleChange("motherName", e.target.value)}
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