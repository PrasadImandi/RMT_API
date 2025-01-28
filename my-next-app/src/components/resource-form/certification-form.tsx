"use client";

import { useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Plus, Trash2 } from "lucide-react";

interface CertificationFormProps {
  initialData: any[];
  onSave: (data: any) => void;
}

export default function CertificationForm({ initialData, onSave }: CertificationFormProps) {
  const [certifications, setCertifications] = useState(initialData.length > 0 ? initialData : []);

  const handleAddCertification = () => {
    setCertifications([
      ...certifications,
      {
        certificationName: "",
        certificationNumber: "",
        completionDate: "",
        expireDate: "",
        attachment: "",
      },
    ]);
  };

  const handleRemove = (index: number) => {
    setCertifications(certifications.filter((_, i) => i !== index));
  };

  const handleChange = (index: number, field: string, value: string) => {
    const updatedCertifications = [...certifications];
    updatedCertifications[index] = {
      ...updatedCertifications[index],
      [field]: value,
    };
    setCertifications(updatedCertifications);
  };

  const handleSave = () => {
    onSave(certifications);
  };

  return (
    <Card>
      <CardHeader className="flex flex-row items-center justify-between">
        <CardTitle>Certification Details</CardTitle>
        <Button
          type="button"
          variant="outline"
          size="sm"
          onClick={handleAddCertification}
        >
          <Plus className="h-4 w-4 mr-2" />
          Add Certification
        </Button>
      </CardHeader>
      <CardContent className="space-y-4">
        {certifications.map((cert, index) => (
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
                <Label>Certification Name *</Label>
                <Select
                  value={cert.certificationName}
                  onValueChange={(value) => handleChange(index, "certificationName", value)}
                >
                  <SelectTrigger>
                    <SelectValue placeholder="Select certification" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="AWS">AWS Certified</SelectItem>
                    <SelectItem value="Azure">Microsoft Azure</SelectItem>
                    <SelectItem value="GCP">Google Cloud</SelectItem>
                    <SelectItem value="Other">Other</SelectItem>
                  </SelectContent>
                </Select>
              </div>

              <div className="space-y-2">
                <Label>Certification Number *</Label>
                <Input
                  type="text"
                  value={cert.certificationNumber}
                  onChange={(e) => handleChange(index, "certificationNumber", e.target.value)}
                />
              </div>

              <div className="space-y-2">
                <Label>Completion Date *</Label>
                <Input
                  type="date"
                  value={cert.completionDate}
                  onChange={(e) => handleChange(index, "completionDate", e.target.value)}
                />
              </div>

              <div className="space-y-2">
                <Label>Expiry Date *</Label>
                <Input
                  type="date"
                  value={cert.expireDate}
                  onChange={(e) => handleChange(index, "expireDate", e.target.value)}
                />
              </div>

              <div className="space-y-2 col-span-2">
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
        {certifications.length > 0 && (
          <div className="flex justify-end">
            <Button onClick={handleSave}>Save</Button>
          </div>
        )}
      </CardContent>
    </Card>
  );
}