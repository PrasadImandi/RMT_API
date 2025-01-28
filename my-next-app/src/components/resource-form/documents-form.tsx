"use client";

import { useState } from "react";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Plus, Trash2 } from "lucide-react";

interface DocumentsFormProps {
  initialData: {
    joining: any;
    bgv: any[];
  };
  onSave: (data: any) => void;
}

export default function DocumentsForm({ initialData, onSave }: DocumentsFormProps) {
  const [joiningDocs, setJoiningDocs] = useState(initialData.joining || {
    offerLetter: "",
    joiningLetter: "",
    appraisalLetter: "",
    panCard: "",
    aadharCard: "",
    passport: "",
    drivingLicense: "",
  });

  const [bgvDocs, setBgvDocs] = useState(initialData.bgv || []);

  const handleJoiningDocsChange = (field: string, value: string) => {
    setJoiningDocs(prev => ({
      ...prev,
      [field]: value
    }));
  };

  const handleAddBgv = () => {
    setBgvDocs([
      ...bgvDocs,
      {
        documentName: "",
        description: "",
        attachments: [],
      },
    ]);
  };

  const handleRemoveBgv = (index: number) => {
    setBgvDocs(bgvDocs.filter((_, i) => i !== index));
  };

  const handleBgvChange = (index: number, field: string, value: any) => {
    const updatedBgvDocs = [...bgvDocs];
    updatedBgvDocs[index] = {
      ...updatedBgvDocs[index],
      [field]: value,
    };
    setBgvDocs(updatedBgvDocs);
  };

  const handleSave = () => {
    onSave({
      joining: joiningDocs,
      bgv: bgvDocs,
    });
  };

  return (
    <div className="space-y-6">
      <Card>
        <CardHeader>
          <CardTitle>Joining Documents</CardTitle>
        </CardHeader>
        <CardContent className="space-y-4">
          <div className="grid grid-cols-2 gap-4">
            <div className="space-y-2">
              <Label>Offer Letter *</Label>
              <Input
                type="file"
                accept=".pdf,.jpg,.jpeg,.png"
                onChange={(e) => handleJoiningDocsChange("offerLetter", e.target.files?.[0]?.name || "")}
              />
            </div>

            <div className="space-y-2">
              <Label>Joining Letter *</Label>
              <Input
                type="file"
                accept=".pdf,.jpg,.jpeg,.png"
                onChange={(e) => handleJoiningDocsChange("joiningLetter", e.target.files?.[0]?.name || "")}
              />
            </div>

            <div className="space-y-2">
              <Label>Appraisal Letter *</Label>
              <Input
                type="file"
                accept=".pdf,.jpg,.jpeg,.png"
                onChange={(e) => handleJoiningDocsChange("appraisalLetter", e.target.files?.[0]?.name || "")}
              />
            </div>

            <div className="space-y-2">
              <Label>PAN Card *</Label>
              <Input
                type="file"
                accept=".pdf,.jpg,.jpeg,.png"
                onChange={(e) => handleJoiningDocsChange("panCard", e.target.files?.[0]?.name || "")}
              />
            </div>

            <div className="space-y-2">
              <Label>Aadhar Card *</Label>
              <Input
                type="file"
                accept=".pdf,.jpg,.jpeg,.png"
                onChange={(e) => handleJoiningDocsChange("aadharCard", e.target.files?.[0]?.name || "")}
              />
            </div>

            <div className="space-y-2">
              <Label>Passport</Label>
              <Input
                type="file"
                accept=".pdf,.jpg,.jpeg,.png"
                onChange={(e) => handleJoiningDocsChange("passport", e.target.files?.[0]?.name || "")}
              />
            </div>

            <div className="space-y-2">
              <Label>Driving License</Label>
              <Input
                type="file"
                accept=".pdf,.jpg,.jpeg,.png"
                onChange={(e) => handleJoiningDocsChange("drivingLicense", e.target.files?.[0]?.name || "")}
              />
            </div>
          </div>
        </CardContent>
      </Card>

      <Card>
        <CardHeader className="flex flex-row items-center justify-between">
          <CardTitle>BGV Documents</CardTitle>
          <Button
            type="button"
            variant="outline"
            size="sm"
            onClick={handleAddBgv}
          >
            <Plus className="h-4 w-4 mr-2" />
            Add BGV Document
          </Button>
        </CardHeader>
        <CardContent className="space-y-4">
          {bgvDocs.map((doc, index) => (
            <div key={index} className="border p-4 rounded-lg space-y-4">
              <div className="flex justify-end">
                <Button
                  type="button"
                  variant="ghost"
                  size="sm"
                  onClick={() => handleRemoveBgv(index)}
                >
                  <Trash2 className="h-4 w-4" />
                </Button>
              </div>
              <div className="space-y-4">
                <div className="space-y-2">
                  <Label>Document Name *</Label>
                  <Input
                    type="text"
                    value={doc.documentName}
                    onChange={(e) => handleBgvChange(index, "documentName", e.target.value)}
                  />
                </div>

                <div className="space-y-2">
                  <Label>Description *</Label>
                  <Textarea
                    value={doc.description}
                    onChange={(e) => handleBgvChange(index, "description", e.target.value)}
                  />
                </div>

                <div className="space-y-2">
                  <Label>Attachments *</Label>
                  <Input
                    type="file"
                    multiple
                    accept=".pdf,.jpg,.jpeg,.png"
                    onChange={(e) => {
                      const files = Array.from(e.target.files || []).map(file => file.name);
                      handleBgvChange(index, "attachments", files);
                    }}
                  />
                </div>
              </div>
            </div>
          ))}
        </CardContent>
      </Card>

      <div className="flex justify-end">
        <Button onClick={handleSave}>Save</Button>
      </div>
    </div>
  );
}