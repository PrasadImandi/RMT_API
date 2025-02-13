"use client";

import { useState } from "react";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { Button } from "@/components/ui/button";
import PersonalInfoForm from "@/components/resource-form/personal-info-form";
import AcademicInfoForm from "@/components/resource-form/academic-info-form";
import CertificationForm from "@/components/resource-form/certification-form";
import DocumentsForm from "@/components/resource-form/documents-form";
import ProfessionalInfoForm from "@/components/resource-form/professional-info-form";
import { toast } from "sonner";
import api from "@/lib/axiosInstance";
import { useParams, useRouter } from "next/navigation";

const formTabs = [
  { id: "personal", label: "Personal Information" },
  { id: "academic", label: "Academic Details" },
  { id: "certification", label: "Certification Details" },
  { id: "documents", label: "Documents" },
  { id: "professional", label: "Professional Details" },
];

export default function ResourceForm() {
  const  params = useParams<{ id: string }>();
  const router = useRouter()
  const [activeTab, setActiveTab] = useState("personal");
  const [formData, setFormData] = useState({
    resourceId: params.id,
    personal: {},
    academic: [],
    certification: [],
    documents: {
      joining: {},
      bgv: []
    },
    professional: {}
  });

  const handleSave = (section: string, data: any) => {
    setFormData(prev => ({
      ...prev,
      [section]: data
    }));
    console.log(`${section} form data:`, data);
    toast.success("Details saved")
  };

  const handleNext = () => {
    const currentIndex = formTabs.findIndex(tab => tab.id === activeTab);
    if (currentIndex < formTabs.length - 1) {
      setActiveTab(formTabs[currentIndex + 1].id);
    }
  };

  const handlePrevious = () => {
    const currentIndex = formTabs.findIndex(tab => tab.id === activeTab);
    if (currentIndex > 0) {
      setActiveTab(formTabs[currentIndex - 1].id);
    }
  };

  const handleSubmit = async() => {
    console.log("Final form data:", formData);
    // Handle form submission
    try {
        const res = await api.put(`/ResourceInformation/${params.id}`,formData)
        console.log(res)
        router.push('/admin/resource-information')
    } catch (error) {
      toast.error("Error while submitting details")
    }
  };

  return (
    <div className="container mx-auto p-16">
      <Tabs value={activeTab} onValueChange={setActiveTab}>
        <TabsList className="grid w-full grid-cols-5">
          {formTabs.map((tab) => (
            <TabsTrigger key={tab.id} value={tab.id}>
              {tab.label}
            </TabsTrigger>
          ))}
        </TabsList>
        <TabsContent value="personal">
          <PersonalInfoForm 
            initialData={formData.personal} 
            onSave={(data) => handleSave("personal", data)} 
          />
        </TabsContent>
        <TabsContent value="academic">
          <AcademicInfoForm 
            initialData={formData.academic}
            onSave={(data) => handleSave("academic", data)}
          />
        </TabsContent>
        <TabsContent value="certification">
          <CertificationForm 
            initialData={formData.certification}
            onSave={(data) => handleSave("certification", data)}
          />
        </TabsContent>
        <TabsContent value="documents">
          <DocumentsForm 
            initialData={formData.documents}
            onSave={(data) => handleSave("documents", data)}
          />
        </TabsContent>
        <TabsContent value="professional">
          <ProfessionalInfoForm 
            initialData={formData.professional}
            onSave={(data) => handleSave("professional", data)}
          />
        </TabsContent>
      </Tabs>
      <div className="flex justify-between mt-6">
        <Button
          type="button"
          variant="outline"
          onClick={handlePrevious}
          disabled={activeTab === formTabs[0].id}
        >
          Previous
        </Button>
        {activeTab === formTabs[formTabs.length - 1].id ? (
          <Button onClick={handleSubmit}>Submit</Button>
        ) : (
          <Button onClick={handleNext}>Next</Button>
        )}
      </div>
    </div>
  );
}